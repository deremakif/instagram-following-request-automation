using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Windows;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.InteropServices.Expando;

namespace instagram
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.instagram.com/explore/people/suggested/");

            // Waiting users for logging in during 30 seconds. 

            System.Threading.Thread.Sleep(30000);

            IJavaScriptExecutor js = driver as IJavaScriptExecutor;

            // 200 thousand follow request will be sent.

            int j = 1;
            while (j < 5000)
            {

                for (int i = 1; i < 41; i++)
                {
                    string s = "" + i;

                    IWebElement follow = driver.FindElement(By.XPath("/html/body/span/section/main/div/ul/div/li[" + s + "]/div/div[1]/div[2]/button"));
                    follow.Click();

                    System.Threading.Thread.Sleep(3000);

                    // To load more suggestions, page should be scrolled down.
                    js.ExecuteScript("window.scrollBy(0,50000);");

                    System.Threading.Thread.Sleep(3000);
                }
                
                // Because of Instagram's restrictions, system will be wait during 10 minutes before refreshing.
                System.Threading.Thread.Sleep(600000);
                
                driver.Navigate().Refresh();
                
                j++;
            }
        }
    }
}
