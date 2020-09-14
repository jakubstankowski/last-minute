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

          
            var oneDivElements = driver.FindElements(By.CssSelector(".offer_object-info.col-xs-12.col-md-8.col-sm-8"));

           
            
            foreach(var element in oneDivElements)
            {
                var header = element.FindElement(By.CssSelector(".header_title a")).Text;
                var opinions = element.FindElement(By.CssSelector(".hotel-opinions")).Text;

                Console.WriteLine(header + "   " + opinions);

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
