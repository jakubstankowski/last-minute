using System;
using System.Linq;
using Core.Entities;
using Core.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScrapper
{
    public class ItakaWebScrapper : IItakaWebScrapper
    {
        private readonly IHolidayOffersRepo _repo;
        IWebDriver driver = new ChromeDriver();


        public ItakaWebScrapper(IHolidayOffersRepo repo)
        {
            _repo = repo;
        }


        public string GetHtmlElements()
        {

            driver.Navigate()
                .GoToUrl("https://www.itaka.pl/last-minute/");


            var oneDivElements = driver.FindElements(By.CssSelector(".offer_column.offer_column-second.col-sm-9.col-lg-8.clearfix"));



            foreach (var element in oneDivElements)
            {
                var title = element.FindElement(By.CssSelector(".header_title a")).Text;
                var price = element.FindElement(By.CssSelector(".offer_offer-info-details .current-price_value")).Text;
                var url = element.FindElement(By.CssSelector(".offer_link.pull-right")).GetAttribute("href");
                var country = element.FindElements(By.CssSelector(".header_geo-labels a"))[0].Text;


                HolidayOffers holidayOffer = new HolidayOffers
                {
                    Website = "itaka.pl",
                    Title = title,
                    Country = country,
                    Price = price,
                    Url = url,
                };

                _repo.CreateHolidayOffers(holidayOffer);

            }

            return "itaka webscrapper!";

        }



    }
}
