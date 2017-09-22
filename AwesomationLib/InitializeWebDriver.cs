using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.PhantomJS;
using NUnit.Framework;

namespace AwesomationLib
{
    public class InitializeWebDriver
    {
        public static void Browser(string browser)
        {
            if (browser == "FF")
            {
                IWebDriver webDriver = new FirefoxDriver();
                webDriver.Manage().Window.Maximize();
                //webDriver.Quit();
            }
            else if (browser == "Chrome")
            {
                IWebDriver webDriver = new ChromeDriver();
                webDriver.Manage().Window.Maximize();
                //webDriver.Quit();
            }
            else if (browser == "IE")
            {
                InternetExplorerOptions IEO = new InternetExplorerOptions { IgnoreZoomLevel = true };
                IWebDriver webDriver = new InternetExplorerDriver(IEO);
                webDriver.Manage().Window.Maximize();
                //webDriver.Quit();
            }
            else if (browser == "Edge")
            {
                EdgeOptions EO = new EdgeOptions();
                IWebDriver webDriver = new EdgeDriver(EO);
                webDriver.Manage().Window.Maximize();
                //webDriver.Quit();
            }
            else if (browser == "PhantomJS")
            {
                IWebDriver webDriver = new PhantomJSDriver();
                webDriver.Manage().Window.Maximize();
                //webDriver.Quit();
            }
            else
                Console.WriteLine("Valid arguments are: FF, Chrome, IE, Edge and PhantomJS.");
        }

        #region Debug Driver Initialization
        public static void DebugDriverInit()
        {
            Console.WriteLine("1. Mozilla Firefox");
            Console.WriteLine("2. Google Chrome");
            Console.WriteLine("3. Microsoft Internet Explorer");
            Console.WriteLine("4. Microsoft Edge");
            Console.WriteLine("5. PhantomJS");
            Console.WriteLine();
            Console.Write(">> ");

            try
            {
                int selection = Convert.ToInt32(Console.ReadLine());

                if (selection == 1)
                    Browser("FF");
                else if (selection == 2)
                    Browser("Chrome");
                else if (selection == 3)
                    Browser("IE");
                else if (selection == 4)
                    Browser("Edge");
                else if (selection == 5)
                    Browser("PhantomJS");
                else
                {
                    Console.WriteLine("\r\n" + "Invalid Selection. Press ENTER to exit." + "\r\n");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\r\n" + ex + "\r\n");
                Console.WriteLine("Press ENTER to exit." + "\r\n");
                Console.ReadLine();
            }
        }
        #endregion

        #region Debug NUnit Test
        [Test]
        public static void DebugNUnitTest()
        {
            try
            {
                InternetExplorerOptions IEO = new InternetExplorerOptions { IgnoreZoomLevel = true };
                IWebDriver webDriver = new InternetExplorerDriver(IEO);
                webDriver.Manage().Window.Maximize();
                webDriver.Navigate().GoToUrl("https://www.google.com");
                Assert.AreEqual("Google", webDriver.Title);
                webDriver.Close(); //This method is used to close the current open window. It closes the current open window on which driver has focus on.
                webDriver.Quit(); //This method is used to destroy the instance of WebDriver. It closes all browser windows associated with that driver and safely ends the session.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion
    }
}