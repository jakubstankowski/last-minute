using Core.Entities;
using Core.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScrapper
{
    public class ItakaWebScrapper : IItakaWebscrapper
    {
        private readonly IHolidayOffersRepo _repo;
        IWebDriver driver = new ChromeDriver();


        public ItakaWebScrapper(IHolidayOffersRepo repo)
        {
            _repo = repo;
        }


        public void CollectWebscrapperData()
        {
             _repo.DeleteHolidayOffersByWebstie("itaka.pl");
            driver.Navigate()
                .GoToUrl("https://www.wakacje.pl/lastminute/?samolotem,all-inclusive,tanio");

            driver.Manage().Window.Maximize();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scroll({bottom: 0, top: 200, behavior: 'smooth'})");
            js.ExecuteScript("window.scroll({bottom: 200, top: 400, behavior: 'smooth'})");

            js.ExecuteScript("window.scroll({bottom: 400, top: 600, behavior: 'smooth'})");
            js.ExecuteScript("window.scroll({bottom: 600, top: 800, behavior: 'smooth'})");
            js.ExecuteScript("window.scroll({bottom: 800, top: 1000, behavior: 'smooth'})");
            js.ExecuteScript("window.scroll({bottom: 1000, top: 1200, behavior: 'smooth'})");



            var elementsContainer = driver.FindElements(By.CssSelector(".sc-1d4p1bq-0.hLqJDc.sc-1dp1fmu-0.josQgD"));

            foreach (var element in elementsContainer)
            {
                var title = element.FindElement(By.CssSelector(".sc-1x38ct5-4.h04pl1-7.gUAzqv")).Text;

                var price = element.FindElement(By.CssSelector(".sc-1icels6-4.uHGsR")).Text;
                System.Console.WriteLine("title: " + title + "   " + " price: " + price);
                /* var price = element.FindElement(By.CssSelector(".offer_offer-info-details .current-price_value")).Text;
                var url = element.FindElement(By.CssSelector(".offer_link.pull-right")).GetAttribute("href");
                var country = element.FindElements(By.CssSelector(".header_geo-labels a"))[0].Text;
                // var imageUrl = element.FindElement(By.CssSelector(".slider-frame .slider-list .slider-slide a img")).GetAttribute("src");
                var date = element.FindElement(By.CssSelector(".offer_offer-info-additional.hidden-xs .offer_date.pull-right")).Text;

                HolidayOffers holidayOffer = new HolidayOffers
                {
                    Website = "itaka.pl",
                    Title = title,
                    Country = country,
                    Price = price,
                    Url = url,
                    Date = date,
                    ImageUrl = "null"
                };

               
                _repo.CreateHolidayOffers(holidayOffer);*/

            }

        }



    }
}
