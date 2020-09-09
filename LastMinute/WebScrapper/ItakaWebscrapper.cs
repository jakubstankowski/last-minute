using System;
using Core.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScrapper
{
    public class ItakaWebScrapper : IItakaWebScrapper
    {
       IWebDriver driver = new ChromeDriver();

        public ItakaWebScrapper()
        {

        }


        public string GetHtmlElements()
        {
            /* driver.Navigate().GoToUrl("https://www.itaka.pl/last-minute/");
            var searchField = driver.FindElement(By.CssSelector(".current-price_value"));

            Console.WriteLine(searchField.Text);*/
            return "taka webscrapper!";

        }



    }
}
