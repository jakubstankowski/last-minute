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
        List<HolidayOffers> holidayOffers = new List<HolidayOffers>();

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

            HolidayOffers holidayOffer = new HolidayOffers
            {
                Url = "com",
                Website = "itaka.pl",
                Country = "Bialorus"
            };


            foreach (var offerTitle in allFindOffersTitle)
            {
                holidayOffer.Title = offerTitle.Text;
                holidayOffers.Add(holidayOffer);
            }

            foreach(var offerPrice in allFindOffersPrice)
            {
                holidayOffer.Price = offerPrice.Text;
                holidayOffers.Add(holidayOffer);
            }

            foreach(var offer in holidayOffers)
            {
                Console.WriteLine(offer.Title + "  " + offer.Price);
            }
        
            return "taka webscrapper!";

        }



    }
}
