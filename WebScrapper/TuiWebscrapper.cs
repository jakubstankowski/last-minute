using System;
using System.Threading;
using Core.Entities;
using Core.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScrapper
{
    public class TuiWebscrapper : ITuiWebscrapper
    {
        private readonly IHolidayOffersRepo _repo;
        private readonly IWebscrapperService _webscrapperService;
        IWebDriver driver = new ChromeDriver();

        public TuiWebscrapper(IHolidayOffersRepo repo, IWebscrapperService webscrapperService)
        {
            _repo = repo;
            _webscrapperService = webscrapperService;
        }

        public void CollectWebscrapperData()
        {
            _repo.DeleteHolidayOffersByWebstie("tui.pl");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(5);

            driver.Navigate()
                .GoToUrl("https://www.tui.pl/last-minute?pm_source=MENU&pm_name=Last_Minute");


            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.Manage().Window.Maximize();

            js.ExecuteScript("window.scroll({bottom: 0, top: document.body.scrollHeight, behavior: 'smooth'})");

            Thread.Sleep(1000);
            var elementsContainer = driver.FindElements(By.CssSelector(".offer-tile-wrapper.offer-tile-wrapper--listingOffer"));


            //TODO handle image url with lazy loading

            foreach (var element in elementsContainer)
            {
                Thread.Sleep(1000);
                var title = element.FindElement(By.CssSelector(".offer-tile-body__hotel-name")).Text;
                var country = element.FindElement(By.CssSelector(".breadcrumbs__list .breadcrumbs__item span")).Text;
                var price = element.FindElement(By.CssSelector(".price-value__amount")).Text;
                var url = element.FindElement(By.CssSelector(".offer-tile.offer-tile--listingOffer.row a")).GetAttribute("href");
                // var imageUrl = element.FindElement(By.CssSelector(".offer-tile.offer-tile--listingOffer.row a")).GetAttribute("style");
                var date = element.FindElement(By.CssSelector(".offer-tile-body__info-item-text")).Text;


                HolidayOffers holidayOffer = new HolidayOffers
                {
                    Website = "tui.pl",
                    Title = title,
                    Country = country,
                    Price = _webscrapperService.ParsePrice(price, " "),
                    Url = url,
                    Date = date,
                    ImageUrl = "null"
                };


                _repo.CreateHolidayOffers(holidayOffer);



            }

        }
    }
}
