using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Core.Entities;
using Core.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScrapper
{
    class GenericWebscrapper : IGenericWebscrapper
    {
        private readonly IHolidayOffersRepo _offersRepo;
        private readonly IWebscrapperService _webscrapperService;
        IWebDriver driver = new ChromeDriver();

        public GenericWebscrapper(IHolidayOffersRepo offersRepo, IWebscrapperService webscrapperService)
        {
            _offersRepo = offersRepo;
            _webscrapperService = webscrapperService;
        
        }

        public void CollectItakaWebscrapperData()
        {
            _offersRepo.DeleteHolidayOffersByWebstie("itaka.pl");
            this.StartWebscrapper("https://www.itaka.pl/last-minute/?view=offerList&package-type=wczasy&adults=2&date-from=2020-09-21&food=allInclusive&promo=lastMinute&order=priceAsc&total-price=0&page=1&transport=flight&currency=PLN");
         
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
            throw new NotImplementedException();
        }

        public void CollectWakacjeWebscrapperData()
        {
            throw new NotImplementedException();
        }

        public void StartWebscrapper(string url)
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
