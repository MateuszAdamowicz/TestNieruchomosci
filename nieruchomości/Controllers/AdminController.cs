using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Context;
using Models.EntityModels;
using Models.ViewModels;
using Services.Admin;
using Services.Home.EmailService;

namespace nieruchomości.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IApplicationContext _applicationContext;
        private readonly IAddAdvertService _addAdvertService;
        private readonly IWorkerService _workerService;
        private readonly IUpdateAdvertService _updateAdvertService;
        private readonly IAdminLoginService _adminLoginService;
        private readonly IEmailService _emailService;

        // GET: Admin
        public AdminController(IApplicationContext applicationContext, IAddAdvertService addAdvertService, IWorkerService workerService, IUpdateAdvertService updateAdvertService, IAdminLoginService adminLoginService, IEmailService emailService)
        {
            _applicationContext = applicationContext;
            _addAdvertService = addAdvertService;
            _workerService = workerService;
            _updateAdvertService = updateAdvertService;
            _adminLoginService = adminLoginService;
            _emailService = emailService;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return View(new LoginViewModel());
            }
            var ticket = new FormsAuthenticationTicket(1, "", DateTime.Now, DateTime.Now.AddMinutes(-30), false, String.Empty, FormsAuthentication.FormsCookiePath);
            _adminLoginService.Cookies().Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket)));
            _adminLoginService.Logout();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }

        public ActionResult DeleteAd(int id, AdType adType)
        {
            if (adType == AdType.Flat)
            {
                var flat = _applicationContext.Flats.Find(id);
                flat.Deleted = true;
            }
            else if (adType == AdType.House)
            {
                var house = _applicationContext.Houses.Find(id);
                house.Deleted = true;
            }
            else
            {
                var land = _applicationContext.Lands.Find(id);
                land.Deleted = true;
            }

            _applicationContext.SaveChanges();

            return RedirectToAction("AdList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _adminLoginService.Login(loginViewModel);
                if (result.Authorized)
                {
                    string user = HttpContext.User.ToString();
                    _adminLoginService.SetLoginCookies(loginViewModel.Login);
                    return RedirectToAction("Index");
                }
                ViewBag.LoginError = true;
                return View(loginViewModel);
            }
            ViewBag.LoginError = true;
            return View(loginViewModel);
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddAdvert()
        {
            if (!TempData.ContainsKey("AdType"))
            {
                TempData["AdType"] = 0;
            }
            ViewData["Workers"] = _applicationContext.Workers.ToList();
            return View(new AdminAdvertToAdd());
        }

        [HttpGet]
        public ActionResult AddFlat()
        {
            TempData["AdType"] = 0;
            return RedirectToAction("AddAdvert");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddFlat(AdminFlat adminFlat)
        {
            if (ModelState.IsValid)
            {
                var result = _addAdvertService.AddFlat(adminFlat);
                return RedirectToAction("Show", "Home", new { key = result.Data});
            }
            ViewData["Workers"] = _applicationContext.Workers.ToList();
            TempData["AdType"] = 0;
            return View("AddAdvert", new AdminAdvertToAdd() { Flat = adminFlat });
        }

        [HttpGet]
        public ActionResult AddHouse()
        {
            TempData["AdType"] = 1;
            return RedirectToAction("AddAdvert");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddHouse(AdminHouse adminHouse)
        {
            if (ModelState.IsValid)
            {
                var result = _addAdvertService.AddHouse(adminHouse);
                return RedirectToAction("Show", "Home", new { key = result.Data });
            }
            ViewData["Workers"] = _applicationContext.Workers.ToList();
            TempData["AdType"] = 1;
            return View("AddAdvert", new AdminAdvertToAdd() { House = adminHouse });
        }

        [HttpGet]
        public ActionResult AddLand()
        {
            TempData["AdType"] = 2;
            return RedirectToAction("AddAdvert");
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddLand(AdminLand adminLand)
        {
            if (ModelState.IsValid)
            {
                var result = _addAdvertService.AddLand(adminLand);
                return RedirectToAction("Show", "Home", new { key = result.Data });
            }
            ViewData["Workers"] = _applicationContext.Workers.ToList();
            TempData["AdType"] = 2;
            return View("AddAdvert", new AdminAdvertToAdd() { Land = adminLand });
        }

        public ActionResult Workers()
        {
            var workers = _applicationContext.Workers.ToList();
            var workersVm = new WorkersViewModel() { Workers = workers };
            return View(workersVm);
        }

        public ActionResult Worker(int id)
        {
            var worker = _applicationContext.Workers.Find(id);
            var model = AutoMapper.Mapper.Map<WorkerAdverts>(worker);

            var flats = AutoMapper.Mapper.Map<IEnumerable<NewestAdvert>>(_applicationContext.Flats.Where(x => x.Worker.Id == id).ToList());
            var houses = AutoMapper.Mapper.Map<IEnumerable<NewestAdvert>>(_applicationContext.Houses.Where(x => x.Worker.Id == id).ToList());
            var lands = AutoMapper.Mapper.Map<IEnumerable<NewestAdvert>>(_applicationContext.Lands.Where(x => x.Worker.Id == id).ToList());

            model.Adverts = (flats.Concat(houses).Concat(lands)).OrderByDescending(x => x.CreatedAt);

            return View(model);
        }


        public ActionResult AddWorker()
        {
            return View(new AdminWorker());
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddWorker(AdminWorker adminWorker)
        {
            if (ModelState.IsValid)
            {
                var result = _workerService.AddWorker(adminWorker);

                if (result.Success == true)
                {
                    var workers = _applicationContext.Workers.ToList();
                    var response = new Response()
                    {
                        Message = "Dodano nowego pracownika!",
                        Success = true
                    };
                    var workersVm = new WorkersViewModel() {Workers = workers, Response = response};
                    return View("Workers", workersVm);
                }
                return View(adminWorker);
            }
            return View(adminWorker);
        }

        public ActionResult EditWorker(int id)
        {
            var worker = Enumerable.FirstOrDefault(_applicationContext.Workers.Where(obj => obj.Id == id));

            var adminWorker = AutoMapper.Mapper.Map<AdminWorker>(worker);

            return View(adminWorker);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditWorker(AdminWorker adminWorker, int id)
        {
            if (ModelState.IsValid)
            {
                var result = _workerService.EditWorker(adminWorker, id);
                if (result.Success == true)
                {
                    var workers = _applicationContext.Workers.ToList();
                    var response = new Response()
                    {
                        Message = "Pomyślnie edytowano pracownika!",
                        Success = true
                    };
                    var workersVm = new WorkersViewModel() {Workers = workers, Response = response};
                    return View("Workers", workersVm);
                }
                return View(adminWorker);
            }
            return View(adminWorker);
        }

        [HttpGet]
        public ActionResult AdList(bool? changed, bool? hide)
        {
            var flats = AutoMapper.Mapper.Map<List<AdminAdvertToShow>>(_applicationContext.Flats);
            var houses = AutoMapper.Mapper.Map<List<AdminAdvertToShow>>(_applicationContext.Houses);
            var lands = AutoMapper.Mapper.Map<List<AdminAdvertToShow>>(_applicationContext.Lands);

            var ads = flats.Concat(houses).Concat(lands).OrderByDescending(x => x.CreatedAt);
            return View(ads);
        }

        public ActionResult EditAd(int id, AdType adtype)
        {
            if (adtype == AdType.Flat)
            {
                return RedirectToAction("EditFlat", new {id = id});
            }
            if (adtype == AdType.House)
            {
                return RedirectToAction("EditHouse", new {id = id});
            }
            return RedirectToAction("EditLand", new {id = id});
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditFlat(EditFlat editFlat, int id)
        {
            editFlat.Pictures = new List<Photo>();
            if (ModelState.IsValid)
            {
                _updateAdvertService.UpdateFlat(editFlat, id);
                return RedirectToAction("Show", "Home", new {key = String.Format("{0}{1}", id*9999, "12")});
            }

            var flat = _applicationContext.Flats.Find(id);
            if (flat != null)
            {
                editFlat.Pictures = flat.Pictures;
            }
            ViewData["Workers"] = _applicationContext.Workers.ToList();
            return View(editFlat);
        }

        public ActionResult EditFlat(int id)
        {
            var flat = Enumerable.FirstOrDefault(_applicationContext.Flats.Where(obj => obj.Id == id));
            var flatToEdit = AutoMapper.Mapper.Map<EditFlat>(flat);
            ViewData["Workers"] = _applicationContext.Workers.ToList();

            return View(flatToEdit);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditHouse(EditHouse editHouse, int id)
        {
            editHouse.Pictures = new List<Photo>();
            if (ModelState.IsValid)
            {
                _updateAdvertService.UpdateHouse(editHouse, id);
                return RedirectToAction("Show", "Home", new { key = String.Format("{0}{1}", id * 9999, "14") });
            }

            var house = _applicationContext.Houses.Find(id);
            if (house != null)
            {
                editHouse.Pictures = house.Pictures;
            }
            ViewData["Workers"] = _applicationContext.Workers.ToList();
            return View(editHouse);
        }
        public ActionResult EditHouse(int id)
        {
            var house = Enumerable.FirstOrDefault(_applicationContext.Houses.Where(obj => obj.Id == id));
            var houseToEdit = AutoMapper.Mapper.Map<EditHouse>(house);
            ViewData["Workers"] = _applicationContext.Workers.ToList();

            return View(houseToEdit);
        }

        public ActionResult EditLand(int id)
        {
            var land = Enumerable.FirstOrDefault(_applicationContext.Lands.Where(obj => obj.Id == id));
            var landToEdit = AutoMapper.Mapper.Map<EditLand>(land);
            ViewData["Workers"] = _applicationContext.Workers.ToList();

            return View(landToEdit);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditLand(EditLand editLand, int id)
        {
            editLand.Pictures = new List<Photo>();
            if (ModelState.IsValid)
            {
                _updateAdvertService.UpdateLand(editLand, id);
                return RedirectToAction("Show", "Home", new { key = String.Format("{0}{1}", id * 9999, "18") });
            }

            var land = _applicationContext.Lands.Find(id);
            if (land != null)
            {
                editLand.Pictures = land.Pictures;
            }
            ViewData["Workers"] = _applicationContext.Workers.ToList();
            return View(editLand);
        }

        public ActionResult Hide(int id, AdType adtype)
        {

            bool visible;
            if (adtype == AdType.Flat)
            {
                var advert = _applicationContext.Flats.Find(id);
                advert.Visible = !advert.Visible;
                visible = advert.Visible;
            }
            else if (adtype == AdType.House)
            {
                var advert = _applicationContext.Houses.Find(id);
                advert.Visible = !advert.Visible;
                visible = advert.Visible;
            }
            else
            {
                var advert = _applicationContext.Lands.Find(id);
                advert.Visible = !advert.Visible;
                visible = advert.Visible;
            }
            _applicationContext.SaveChanges();

            return RedirectToAction("AdList", new{changed = true, hide = !visible});
        }

        public ActionResult Offers()
        {
            var offers = _applicationContext.Offers.ToList();
            return View(offers);
        }

        public ActionResult Offer(int id, OfferStatus? status)
        {
            var offer = _applicationContext.Offers.Find(id);
            if (offer != null)
            {
                if (status != null)
                {
                    offer.Status = (OfferStatus)status;
                    _applicationContext.SaveChanges();
                    _emailService.SendAndSaveOfferResponse(offer.Status, offer);
                    return RedirectToAction("Offers");
                }
                return View(offer);
            }
            return RedirectToAction("Offers");
        }

        public ActionResult Messages()
        {
            var msgList = _applicationContext.Mails.ToList();
            return View(msgList);
        }

        public ActionResult Message(int id)
        {
            var msg = _applicationContext.Mails.Find(id);
            if (msg != null)
            {
                return View(msg);
            }
            return RedirectToAction("Messages");
        }

        public ActionResult Statistics()
        {
            return View(_applicationContext.Statisticses.ToList());
        }
    }
}