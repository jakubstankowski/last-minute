using System;
using System.IO;
using System.Reflection;
using Core.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScrapper
{
    public class ItakaWebScrapper : IItakaWebScrapper
    {
       IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        public ItakaWebScrapper()
        {

        }


        public string GetHtmlElements()
        {
             driver.Navigate().GoToUrl("https://www.itaka.pl/last-minute/");
            var searchField = driver.FindElement(By.CssSelector(".current-price_value"));

            Console.WriteLine("Get html elements: ");
            Console.WriteLine(searchField.Text);
            return "taka webscrapper!";

        }



    }
}
