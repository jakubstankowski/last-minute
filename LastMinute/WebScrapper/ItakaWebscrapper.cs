using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Core.Entities;
using Core.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScrapper
{
    public class ItakaWebScrapper : IItakaWebScrapper
    {
        IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        List<HolidayOffers> holidayOffers = new List<HolidayOffers>();

        public ItakaWebScrapper()
        {

        }


        public string GetHtmlElements()
        {
            driver.Navigate().GoToUrl("https://www.itaka.pl/last-minute/");
            var allFindOffersTitle = driver.FindElements(By.CssSelector(".header_title a"));
            var allFindOffersPrice = driver.FindElements(By.CssSelector(".current-price_value"));


             foreach (var title in allFindOffersTitle)
            {
                Console.WriteLine("title:");
                Console.WriteLine(title.Text);

                HolidayOffers offer = new HolidayOffers
                {
                    Title = title.Text,
                    Price = 0,
                    Url = "com",
                    Website = "itaka.pl"
                };
                holidayOffers.Add(offer);
            }


            foreach (var price in allFindOffersPrice)
            {
                Console.WriteLine("price: ");
                Console.WriteLine(price.Text);
            }


            foreach(HolidayOffers offer in holidayOffers)
            {
                Console.WriteLine("title in model:");
                Console.WriteLine(offer.Title);
            }
            return "taka webscrapper!";

        }



    }
}
