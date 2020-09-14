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

            var allFindOffersTitle = driver.FindElements(By.CssSelector(".header_title a"));
            var allFindOffersPrice = driver.FindElements(By.CssSelector(".current-price_value"));
            var oneDivElements = driver.FindElements(By.CssSelector(".offer_object-info.col-xs-12.col-md-8.col-sm-8"));

            Console.WriteLine(allFindOffersPrice);
            
            foreach(var element in oneDivElements)
            {

                Console.WriteLine(element.Text);

            }

          /*  foreach (var offer in zipOffers)
            {
                HolidayOffers holidayOffer = new HolidayOffers
                {
                    Url = "com",
                    Website = "itaka.pl",
                    Country = "Bialorus",
                    Title = offer.Title.Text,
                    Price = offer.Price.Text
                };
                _repo.CreateHolidayOffers(holidayOffer);
            }
*/


            /*
                        var zipOffers = allFindOffersTitle.Zip(allFindOffersPrice, (n, w) => new { Title = n, Price = w });




                        foreach (var offer in zipOffers)
                        {
                            HolidayOffers holidayOffer = new HolidayOffers
                            {
                                Url = "com",
                                Website = "itaka.pl",
                                Country = "Bialorus",
                                Title = offer.Title.Text,
                                Price = offer.Price.Text
                        };
                            _repo.CreateHolidayOffers(holidayOffer);
                        }
                    */
            return "itaka webscrapper!";

        }



    }
}
