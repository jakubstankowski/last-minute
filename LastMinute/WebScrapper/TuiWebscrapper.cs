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
            _repo.DeleteHolidayOffersByWebstie("tui.pl");
            driver.Navigate()
                .GoToUrl("https://www.tui.pl/last-minute?pm_source=MENU&pm_name=Last_Minute");

            driver.Manage().Window.Maximize();


        }
    }
}
