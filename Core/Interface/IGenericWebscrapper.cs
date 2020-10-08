using OpenQA.Selenium;

namespace Core.Interface
{
    public interface IGenericWebscrapper
    {
        public void CollectItakaWebscrapperData();
        public void CollectTuiWebscrapperData();

        public void StartWebscrapper(string url, IWebDriver driver);

    }
}
