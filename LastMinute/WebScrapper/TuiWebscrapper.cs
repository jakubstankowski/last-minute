using Core.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScrapper
{
    public class TuiWebscrapper : ITuiWebscrapper
    {
        private readonly IHolidayOffersRepo _repo;
        IWebDriver driver = new ChromeDriver();

        public TuiWebscrapper(IHolidayOffersRepo repo)
        {
            _repo = repo;
        }

        public void CollectWebscrapperData()
        {
            /* _repo.DeleteHolidayOffersByWebstie("tui.pl");*/
            driver.Navigate()
                .GoToUrl("https://www.tui.pl/last-minute?pm_source=MENU&pm_name=Last_Minute");

            driver.Manage().Window.Maximize();

            var oneDivElements = driver.FindElements(By.CssSelector(".offer-tile-wrapper.offer-tile-wrapper--listingOffer"));

            //.offer-tile-body__hotel-name

            foreach (var element in oneDivElements)
            {
                var title = element.FindElement(By.CssSelector(".offer-tile-body__hotel-name")).Text;
                var country = element.FindElement(By.CssSelector(".breadcrumbs__list .breadcrumbs__item span")).Text;
                var price = element.FindElement(By.CssSelector(".price-value__amount")).Text;
                var url = element.FindElement(By.CssSelector(".offer-tile.offer-tile--listingOffer.row a")).GetAttribute("href");
               // var imageUrl = element.FindElement(By.CssSelector(".offer-tile.offer-tile--listingOffer.row a")).GetAttribute("style");

             



            }

        }
    }
}
