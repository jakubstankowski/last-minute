using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Core.Entities;
using Core.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScrapper
{
    public class ItakaWebScrapper : IItakaWebScrapper
    {
        private readonly IHolidayOffersRepo _repo;
        IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
       

        public ItakaWebScrapper(IHolidayOffersRepo repo)
        {
            _repo = repo;
        }


        public string GetHtmlElements()
        {
            driver.Navigate().GoToUrl("https://www.itaka.pl/last-minute/");
            var allFindOffersTitle = driver.FindElements(By.CssSelector(".header_title a"));
            var allFindOffersPrice = driver.FindElements(By.CssSelector(".current-price_value"));
            var zipOffers = allFindOffersTitle.Zip(allFindOffersPrice, (n, w) => new { Title = n.Text, Price = w.Text });


            foreach (var offer in zipOffers)
            {
              
                HolidayOffers holidayOffer = new HolidayOffers
                {
                    Title = offer.Title,
                    Price = offer.Price,
                    Url = "com",
                    Website = "itaka.pl",
                    Country = "null"
                };
                _repo.CreateHolidayOffers(holidayOffer);
            }



        
            return "taka webscrapper!";

        }



    }
}
