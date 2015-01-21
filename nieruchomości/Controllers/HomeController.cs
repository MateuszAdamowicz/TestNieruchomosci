using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Context;
using Models;
using Models.ViewModels;
using PagedList;
using Services.AdvertCitiesService.Implementation;
using Services.AdvertServices.GetFiltredAdvertsService.Implementation;
using Services.AdvertServices.GetNextPreviousService;
using Services.AdvertServices.NewestAdvertService;
using Services.AdvertServices.ShowAdvertService;
using Services.CalcService;
using Services.CreateOfferService;
using Services.EmailServices.EmailService;
using Services.FilterIndexService.Implementation;
using Services.MaxPriceService;
using Services.SearchService;
using Services.StatisticesServices.CounterService;

namespace nieruchomości.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationContext _context;
        private readonly IEmailService _emailService;
        private readonly ISearchService _searchService;
        private readonly IShowAdvertService _showAdvertService;
        private readonly ICounterService _counterService;
        private readonly IOfferService _offerService;
        private readonly ICalcService _calcService;
        private readonly IGetNextPreviousService _getNextPreviousService;
        private readonly INewestAdvertService _newestAdvertService;
        private readonly IFilterIndexService _filterIndexService;
        private readonly IGetFiltredAdvertsService _getFiltredAdvertsService;
        private readonly IAdvertCitiesService _advertCitiesService;
        private readonly IMaxPriceService _maxPriceService;

        // GET: Home
        public HomeController(IApplicationContext context, IEmailService emailService, ISearchService searchService, IShowAdvertService showAdvertService, ICounterService counterService, IOfferService offerService, ICalcService calcService, IGetNextPreviousService getNextPreviousService, INewestAdvertService newestAdvertService, IFilterIndexService filterIndexService, IGetFiltredAdvertsService getFiltredAdvertsService, IAdvertCitiesService advertCitiesService, IMaxPriceService maxPriceService)
        {
            _context = context;
            _emailService = emailService;
            _searchService = searchService;
            _showAdvertService = showAdvertService;
            _counterService = counterService;
            _offerService = offerService;
            _calcService = calcService;
            _getNextPreviousService = getNextPreviousService;
            _newestAdvertService = newestAdvertService;
            _filterIndexService = filterIndexService;
            _getFiltredAdvertsService = getFiltredAdvertsService;
            _advertCitiesService = advertCitiesService;
            _maxPriceService = maxPriceService;
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Credits()
        {
            return View();
        }

        public ActionResult Search(string key)
        {
            return RedirectToAction("Show", new {key});
        }

        public ActionResult Where()
        {
            return View();
        }

        public ActionResult SendEmail(ContactEmail contactEmail)
        {
            if (ModelState.IsValid)
            {
                var result = _emailService.SendAndSaveOfferQuestion(contactEmail);
            }
            else
            {
                return View("_ContactForm", contactEmail);
            }

            return View("Index");
        }

        public ActionResult Index(int? page, AdType? adType, string flatCities, int? flatRooms, string houseCities, string landCities, string allCities, int? priceFrom, int? priceTo, SortOption? sortOptions)
        {
            var indexFiltred = new IndexFiltred()
            {
                Page = (page ?? 1),
                AdType = adType,
                FlatCities = flatCities,
                FlatRooms = flatRooms,
                HouseCities = houseCities,
                LandCities = landCities,
                AllCities = allCities,
                PriceFrom = priceFrom,
                PriceTo = priceTo,
                SortOption = sortOptions
            };


            var model = new IndexViewModel();
            if (priceFrom != null)
            {
                int pageSize = 4;
                int pageNumber = (page ?? 1);

                var adverts = _getFiltredAdvertsService.GetAdverts(adType, flatCities, flatRooms, houseCities, landCities, allCities,
                                priceFrom, priceTo, sortOptions);
                model.AdvertList = adverts.ToPagedList(pageNumber, pageSize);
            }
            var options = _filterIndexService.GetOptions();
            
            model.IndexFilterOptions = options;
            model.IndexFiltred = indexFiltred;
            model.IndexFiltred.PriceMax = _maxPriceService.GetMaxPrice();
            return View(model);        
        }
        public ActionResult House()
        {
            return View();
        }
        public ActionResult Flat()
        {
            return View();
        }
        public ActionResult Land()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Show(ContactEmail contactEmail, string key)
        {
            var admin = User.Identity.IsAuthenticated;
            if (ModelState.IsValid)
            {
                _emailService.SendAndSaveOfferQuestion(contactEmail);
                return View("ConfirmMail");
            }

            var parsedSearch = _searchService.ParseKey(key);
            if (parsedSearch.Id > 0)
            {
                var advert = _showAdvertService.GetAdvert(parsedSearch.AdType, parsedSearch.Id, admin);
                if (advert.Success)
                {
                    if (parsedSearch.AdType == AdType.Flat)
                    {
                        advert.Data.Flat.ContactEmail = contactEmail;
                    }
                    else if (parsedSearch.AdType == AdType.House)
                    {
                        advert.Data.House.ContactEmail = contactEmail;
                    }
                    else
                    {
                        advert.Data.Land.ContactEmail = contactEmail;
                    }
                    return View(advert.Data);
                }
                return RedirectToAction("NotFound");
            }
            return RedirectToAction("NotFound");
        }

        public ActionResult Show(string key)
        {
            var admin = User.Identity.IsAuthenticated;
            var parsedSearch = _searchService.ParseKey(key);

            if (parsedSearch.Id > 0)
            {
                var result = _showAdvertService.GetAdvert(parsedSearch.AdType, parsedSearch.Id, admin);

                if (result.Success)
                {
                    if (((List<int>) Session["Visited"]).Find(x => x == Convert.ToInt32(key)) == 0)
                    {
                        ((List<int>)Session["Visited"]).Add(Convert.ToInt32(key));
                        _counterService.AddHit(key);
                    }
                    return View(result.Data);
                }
                return RedirectToAction("NotFound");
            }

            return RedirectToAction("NotFound");
        }

        public ActionResult CreateOffer()
        {
            return View(new CreateOffer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOffer(CreateOffer createOffer)
        {
            if (ModelState.IsValid)
            {
                _offerService.AddOffer(createOffer);
                return View("ConfirmOffer", createOffer);
            }
            return View(createOffer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactEmail contactEmail)
        {
            if (ModelState.IsValid)
            {
                _emailService.SendAndSaveContactQuestion(contactEmail);
                return View("ConfirmMail");
            }
            return View(contactEmail);
        }

        public ActionResult Contact()
        {
            return View(new ContactEmail());
        }

        public ActionResult NotFound()
        {
            return View();
        }



        public ActionResult CalcView(string viewPrice, string viewOwnershipForm)
        {
            var model = _calcService.BuildViewModel(viewPrice, viewOwnershipForm);

            return PartialView(model);
        }

        public ActionResult Cities()
        {
            // todo
            var cities = _advertCitiesService.GetCitiesWithRepeats(4);
            return PartialView("_Cities",cities);
        }

        public ActionResult NewestAdverts()
        {

            var adverts = _newestAdvertService.GetNewest(4);
            return PartialView("_NewestAdverts", adverts);
        }
    }
}