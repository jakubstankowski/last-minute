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
           // _repo.DeleteHolidayOffersByWebstie("itaka.pl");
            driver.Navigate()
                .GoToUrl("https://www.itaka.pl/last-minute/");

            driver.Manage().Window.Maximize();
 /* IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
             js.ExecuteScript("window.scroll({bottom: 0, top: 500, behavior: 'smooth'})");

 */

             var oneDivElements = driver.FindElements(By.CssSelector(".offer.clearfix"));

            foreach (var element in oneDivElements)
            {
                var title = element.FindElement(By.CssSelector(".header_title a")).Text;
                var price = element.FindElement(By.CssSelector(".offer_offer-info-details .current-price_value")).Text;
                var url = element.FindElement(By.CssSelector(".offer_link.pull-right")).GetAttribute("href");
                var country = element.FindElements(By.CssSelector(".header_geo-labels a"))[0].Text;
                // var imageUrl = element.FindElement(By.CssSelector(".slider-frame .slider-list .slider-slide a img")).GetAttribute("src");
                var date = element.FindElement(By.CssSelector(".offer_date.pull-right span")).Text;


                    System.Console.WriteLine("date : " + date);
              /*  HolidayOffers holidayOffer = new HolidayOffers
                {
                    Website = "itaka.pl",
                    Title = title,
                    Country = country,
                    Price = price,
                    Url = url,
                    ImageUrl = "null"
                };

               
                _repo.CreateHolidayOffers(holidayOffer);*/

            }

        }



    }
}
