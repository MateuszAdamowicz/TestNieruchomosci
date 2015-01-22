using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Context;
using Models.EntityModels;
using Models.ViewModels;
using PagedList;
using Services.AdminLoginService;
using Services.AdminSettingsService;
using Services.AdvertServices.AddAdvertService;
using Services.AdvertServices.AdminFilterAdvertService;
using Services.AdvertServices.ChangeAdvertVisability;
using Services.AdvertServices.UpdateAdvertService;
using Services.CalcService;
using Services.CreateOfferService;
using Services.DeleteMessageService;
using Services.EmailServices.EmailService;
using Services.GenericRepository;
using Services.SearchService;

namespace nieruchomości.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IApplicationContext _applicationContext;
        private readonly IAddAdvertService _addAdvertService;
        private readonly IUpdateAdvertService _updateAdvertService;
        private readonly IAdminLoginService _adminLoginService;
        private readonly IEmailService _emailService;
        private readonly IAdminFilterAdvertService _adminFilterAdvertService;
        private readonly IOfferService _offerService;
        private readonly IDeleteMessageService _deleteMessageService;
        private readonly IGenericRepository _genericRepository;
        private readonly ISearchService _searchService;
        private readonly IChangeAdvertVisibility _changeAdvertVisibility;
        private readonly ICalcService _calcService;
        private readonly IAdminSettingsService _adminSettingsService;

        // GET: Admin
        public AdminController(IApplicationContext applicationContext, IAddAdvertService addAdvertService, IUpdateAdvertService updateAdvertService, IAdminLoginService adminLoginService, IEmailService emailService, IAdminFilterAdvertService adminFilterAdvertService, IOfferService offerService, IDeleteMessageService deleteMessageService, IGenericRepository genericRepository, ISearchService searchService, IChangeAdvertVisibility changeAdvertVisibility, ICalcService calcService, IAdminSettingsService adminSettingsService)
        {
            _applicationContext = applicationContext;
            _addAdvertService = addAdvertService;
            _updateAdvertService = updateAdvertService;
            _adminLoginService = adminLoginService;
            _emailService = emailService;
            _adminFilterAdvertService = adminFilterAdvertService;
            _offerService = offerService;
            _deleteMessageService = deleteMessageService;
            _genericRepository = genericRepository;
            _searchService = searchService;
            _changeAdvertVisibility = changeAdvertVisibility;
            _calcService = calcService;
            _adminSettingsService = adminSettingsService;
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

        public ActionResult DeleteMessage(int id)
        {
            _deleteMessageService.DeleteMesssage(id);
            return RedirectToAction("Messages");
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
            TempData["AdType"] = 2;
            return View("AddAdvert", new AdminAdvertToAdd() { Land = adminLand });
        }


        [HttpGet]
        public ActionResult AdList(AdList adList, int? page, bool? changed, bool? hide, string key, string worker, DateTime? dateFrom, DateTime? dateTo, bool? flat, bool? house, bool? land, bool? paged, bool? hidden, bool? showHidden = false)
        {
            var modelToShow = new AdList();
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            IEnumerable<AdminAdvertToShow> advertList;
            if (adList != null && adList.FilterOptions != null)
            {
                advertList =
                    _adminFilterAdvertService.FilterAdverts(adList.FilterOptions.Key, adList.FilterOptions.Worker,
                        adList.FilterOptions.ShowHidden, adList.FilterOptions.DateFrom, adList.FilterOptions.DateTo,
                        adList.FilterOptions.Type).ToList();
            }
            else
            {
                if (paged == null || paged == false)
                {
                    advertList = _adminFilterAdvertService.ActiveAdverts(showHidden).ToList();
                    modelToShow.FilterOptions = new AdListFilter();
                }
                else
                {
                    var filterOptions = new AdListFilter()
                    {
                        DateFrom = dateFrom,
                        DateTo = dateTo,
                        Flat = flat.GetValueOrDefault(),
                        Land = land.GetValueOrDefault(),
                        House = house.GetValueOrDefault(),
                        Key = key,
                        ShowHidden = showHidden,
                        Worker = worker
                    };
                    modelToShow.FilterOptions = filterOptions;
                    advertList = _adminFilterAdvertService.FilterAdverts(key, worker, showHidden, dateFrom, dateTo, filterOptions.Type);
                }
            }
            modelToShow.Adverts = advertList.ToPagedList(pageNumber, pageSize);
            if (modelToShow.FilterOptions == null)
            {
                modelToShow.FilterOptions = adList.FilterOptions;
            }
            return View(modelToShow);

        }

        public ActionResult AdListPaged(int? page, IPagedList<AdminAdvertToShow> pagedList)
        {
            return RedirectToAction("AdList");
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

            var flat = _genericRepository.GetSet<Flat>().FirstOrDefault(x => x.Id == id);
            if (flat != null)
            {
                editFlat.Pictures = flat.Pictures;
            }
            return View(editFlat);
        }

        public ActionResult EditFlat(int id)
        {
            var flat = _genericRepository.GetSet<Flat>().FirstOrDefault(x => x.Id == id);
            var flatToEdit = AutoMapper.Mapper.Map<EditFlat>(flat);

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

            var house = _genericRepository.GetSet<House>().FirstOrDefault(x => x.Id == id);
            if (house != null)
            {
                editHouse.Pictures = house.Pictures;
            }
            return View(editHouse);
        }
        public ActionResult EditHouse(int id)
        {
            var house = _genericRepository.GetSet<House>().FirstOrDefault(x => x.Id == id);
            var houseToEdit = AutoMapper.Mapper.Map<EditHouse>(house);

            return View(houseToEdit);
        }

        public ActionResult EditLand(int id)
        {
            var land = _genericRepository.GetSet<Land>().FirstOrDefault(x => x.Id == id);
            var landToEdit = AutoMapper.Mapper.Map<EditLand>(land);

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

            var land = _genericRepository.GetSet<Land>().FirstOrDefault(x => x.Id == id);
            if (land != null)
            {
                editLand.Pictures = land.Pictures;
            }
            return View(editLand);
        }

        public ActionResult ChangeAd(IEnumerable<string> numbers, bool delete)
        {
            if (!delete)
            {
                var visible = _changeAdvertVisibility.HideAdverts(numbers);
                return RedirectToAction("AdList", new { changed = true, hide = !visible, search=!visible,showHidden = !visible });
            }
            _changeAdvertVisibility.DeleteAdverts(numbers);
            return RedirectToAction("AdList");

            //return RedirectToAction("AdList", new{changed = true, hide = !visible});
        }

        public ActionResult Offers(int? page)
        {
            var offers = _genericRepository.GetSet<Offer>().OrderByDescending(x => x.CreatedAt).ToList();
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(offers.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Offer(int id, OfferStatus? status)
        {
            var offer = _genericRepository.GetSet<Offer>().FirstOrDefault(x => x.Id == id);
            if (offer != null)
            {
                if (status != null)
                {
                    offer.Status = (OfferStatus)status;
                    _genericRepository.SaveChanges();
                    _emailService.SendAndSaveOfferResponse(offer.Status, offer);
                    return RedirectToAction("Offers");
                }
                return View(offer);
            }
            return RedirectToAction("Offers");
        }

        public ActionResult Messages(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);

            var msgList = _genericRepository.GetSet<Mail>().OrderByDescending(x => x.CreatedAt).ToList();
            return View(msgList.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Message(int id)
        {
            var msg = _genericRepository.GetSet<Mail>().FirstOrDefault(x => x.Id == id);
            if (msg != null)
            {
                return View(msg);
            }
            return RedirectToAction("Messages");
        }

        public ActionResult DeleteOffer(int id)
        {
            _offerService.DeleteOffer(id);
            return RedirectToAction("Offers");
        }

        public ActionResult Statistics()
        {
            return View(_genericRepository.GetSet<Statistics>().ToList());
        }

        public ActionResult Settings()
        {
            return View(_calcService.BuildViewModel());
        }

        [HttpPost]
        public ActionResult EditClat(Clat clatModel)
        {
            if (ModelState.IsValid)
            {
                _adminSettingsService.EditClat(clatModel);
                return RedirectToAction("Settings");
            }
            var model = _calcService.BuildViewModel();

            model.ClatList.Clear();
            model.ClatList.Add(clatModel);

            return View("Settings", model);

        }



        public ActionResult DeleteClat(int id)
        {
            _adminSettingsService.DeleteClat(id);
            return RedirectToAction("Settings");
        }


        public ActionResult AddClat()
        {
            var model = _adminSettingsService.AddClat();
            return View(model);
        }


        [HttpPost]
        public ActionResult AddClat(Clat clat)
        {

            if (ModelState.IsValid)
            {
                _adminSettingsService.AddClat(clat);
                return RedirectToAction("Settings");
            }

            var model = _adminSettingsService.AddClat();
            model.Clat = clat;

            return View("AddClat", model);
        }


        [HttpPost]
        public ActionResult EditCostPropList(CostProperty costPropModel)
        {
            _adminSettingsService.EditCostPropList(costPropModel);
            return RedirectToAction("Settings");
        }
    }
}