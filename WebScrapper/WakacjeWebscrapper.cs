using System;
using Core.Entities;
using Core.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScrapper
{
    public class WakacjeWebscrapper : IWakacjeWebscrapper
    {
        private readonly IHolidayOffersRepo _repo;
        IWebDriver driver = new ChromeDriver();

        public WakacjeWebscrapper(IHolidayOffersRepo repo)
        {
            _repo = repo;
        }
        public void CollectWebscrapperData()
        {
            _repo.DeleteHolidayOffersByWebstie("wakacje.pl");
            driver.Navigate()
               .GoToUrl("https://www.wakacje.pl/lastminute/?samolotem,all-inclusive,tanio");

            driver.Manage().Window.Maximize();

            //TODO : for get more than 3 offerts, find solution with lazdy loading

            var elementsContainer = driver.FindElements(By.CssSelector(".sc-1d4p1bq-0.hLqJDc.sc-1dp1fmu-0.josQgD"));

            foreach (var element in elementsContainer)
            {
                var title = element.FindElement(By.CssSelector(".sc-1x38ct5-4.h04pl1-7.gUAzqv")).Text;
                var url = element.GetAttribute("href");
                var price = element.FindElement(By.CssSelector(".sc-1icels6-4.uHGsR")).Text;
                var country = element.FindElement(By.CssSelector(".sc-1x38ct5-13.h04pl1-3.dfxezd")).Text;
                var imageUrl = element.FindElement(By.CssSelector(".wulc49-1.ldNESj img")).GetAttribute("src");
                var date = element.FindElement(By.CssSelector(".sc-1x38ct5-13.bVpuRE")).Text;

                HolidayOffers holidayOffer = new HolidayOffers
                {
                    Website = "wakacje.pl",
                    Title = title,
                    Country = country,
                    Price = price,
                    Url = url,
                    Date = date,
                    ImageUrl = imageUrl
                };

               
                _repo.CreateHolidayOffers(holidayOffer);

            }
        }
    }
}
