using System;
using System.Linq;
using System.Threading;
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
                .GoToUrl("https://www.itaka.pl/last-minute/?view=offerList&package-type=wczasy&adults=2&date-from=2020-09-21&food=allInclusive&promo=lastMinute&order=priceAsc&total-price=0&page=1&transport=flight&currency=PLN");

            driver.Manage().Window.Maximize();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scroll({bottom: 0, top: document.body.scrollHeight, behavior: 'smooth'})");



            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(5);

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
                     Price = this.ParsePrice(price),
                     Url = url,
                     Date = date,
                     ImageUrl = "null"
                 };


                 _repo.CreateHolidayOffers(holidayOffer);

            }

        }

        public int ParsePrice(string price)
        {
            string removeWhiteSpace = String.Concat(price.ToString().Where(c => !Char.IsWhiteSpace(c)));
            string replaceUnusedContent = removeWhiteSpace.Replace("PLN/os", "");
            return Int32.Parse(replaceUnusedContent);
        }

    }
}