using System;
using System.Threading;
using Core.Entities;
using Core.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScrapper
{
    public class GenericWebscrapper : IGenericWebscrapper
    {
        private readonly IHolidayOffersRepo _offersRepo;
        private readonly IWebscrapperService _webscrapperService;
       

        public GenericWebscrapper(IHolidayOffersRepo offersRepo, IWebscrapperService webscrapperService)
        {
            _offersRepo = offersRepo;
            _webscrapperService = webscrapperService;

        }

        public void CollectItakaWebscrapperData()
        {
            IWebDriver driver = new ChromeDriver();
            _offersRepo.DeleteHolidayOffersByWebstie("itaka.pl");
            this.StartWebscrapper("https://www.itaka.pl/last-minute/?view=offerList&package-type=wczasy&adults=2&date-from=2020-09-21&food=allInclusive&promo=lastMinute&order=priceAsc&total-price=0&page=1&transport=flight&currency=PLN", driver);

            Thread.Sleep(1000);
            //TODO handle image url with lazy loading
            var elementsContainer = driver.FindElements(By.CssSelector(".offer.clearfix"));

            foreach (var element in elementsContainer)
            {
                Thread.Sleep(1000);
                var title = element.FindElement(By.CssSelector(".header_title a")).Text;
                var price = element.FindElement(By.CssSelector(".offer_offer-info-details .current-price_value")).Text;
                var url = element.FindElement(By.CssSelector(".offer_link.pull-right")).GetAttribute("href");
                var country = element.FindElements(By.CssSelector(".header_geo-labels a"))[0].Text;
                // var imageUrl = element.FindElement(By.CssSelector(".slider-frame .slider-list .slider-slide a img")).GetAttribute("src");
                var date = element.FindElement(By.CssSelector(".offer_offer-info-additional.hidden-xs .offer_date.pull-right")).Text;


                HolidayOffers holidayOffer = new HolidayOffers
                {
                    Website = "itaka.pl",
                    Title = title,
                    Country = country,
                    Price = _webscrapperService.ParsePrice(price, "PLN/os"),
                    Url = url,
                    Date = date,
                    ImageUrl = "null"
                };


                _offersRepo.CreateHolidayOffers(holidayOffer);

            }
        }
        
        public void CollectTuiWebscrapperData()
        {
            IWebDriver driver = new ChromeDriver();
            _offersRepo.DeleteHolidayOffersByWebstie("tui.pl");
            this.StartWebscrapper("https://www.tui.pl/last-minute?pm_source=MENU&pm_name=Last_Minute", driver);

          
            driver.Navigate()
             .GoToUrl("https://www.tui.pl/last-minute?pm_source=MENU&pm_name=Last_Minute");

            driver.Manage().Window.Maximize();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scroll({bottom: 0, top: document.body.scrollHeight, behavior: 'smooth'})");


            Thread.Sleep(1000);
            var elementsContainer = driver.FindElements(By.CssSelector(".offer-tile-wrapper.offer-tile-wrapper--listingOffer"));


            //TODO handle image url with lazy loading

            foreach (var element in elementsContainer)
            {
                Thread.Sleep(1000);
                var title = element.FindElement(By.CssSelector(".offer-tile-body__hotel-name")).Text;
                var country = element.FindElement(By.CssSelector(".breadcrumbs__list .breadcrumbs__item span")).Text;
                var price = element.FindElement(By.CssSelector(".price-value__amount")).Text;
                var url = element.FindElement(By.CssSelector(".offer-tile.offer-tile--listingOffer.row a")).GetAttribute("href");
                // var imageUrl = element.FindElement(By.CssSelector(".offer-tile.offer-tile--listingOffer.row a")).GetAttribute("style");
                var date = element.FindElement(By.CssSelector(".offer-tile-body__info-item-text")).Text;


                HolidayOffers holidayOffer = new HolidayOffers
                {
                    Website = "tui.pl",
                    Title = title,
                    Country = country,
                    Price = _webscrapperService.ParsePrice(price, " "),
                    Url = url,
                    Date = date,
                    ImageUrl = "null"
                };


                _offersRepo.CreateHolidayOffers(holidayOffer);



            }
        }


        public void StartWebscrapper(string url, IWebDriver driver)
        {
           
            driver.Navigate()
             .GoToUrl(url);

            driver.Manage().Window.Maximize();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scroll({bottom: 0, top: document.body.scrollHeight, behavior: 'smooth'})");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(5);

        }
    }
}
