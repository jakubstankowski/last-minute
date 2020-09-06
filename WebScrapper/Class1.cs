using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScrapper
{
    public class Class1
    {
        IWebDriver driver = new ChromeDriver();
       

        public void GetHtmlElements()
        {
             driver.Navigate().GoToUrl("https://www.google.com");
            var searchField = driver.FindElement(By.CssSelector(".current-price_value"));

            Console.WriteLine(searchField.Text);

        }



    }
}
