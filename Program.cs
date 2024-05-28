using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumTests
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            try
            {
                driver.Navigate().GoToUrl("https://www.booking.com");

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                Actions actions = new Actions(driver);
                var tabs = driver.WindowHandles;

                // Selectors
                By xButtonSelector = By.XPath("//*[@id=\"b2indexPage\"]/div[19]/div/div/div/div[1]/div[1]/div/button");
                By destinationFieldSelector = By.XPath("//*[@id=\":re:\"]");
                By firstDateSelector = By.XPath("//*[@id=\"calendar-searchboxdatepicker\"]/div/div[1]/div/div[2]/table/tbody/tr[1]/td[6]");
                By lastDateSelector = By.XPath("//*[@id=\"calendar-searchboxdatepicker\"]/div/div[1]/div/div[2]/table/tbody/tr[3]/td[1]");
                By searchButtonSelector = By.XPath("//*[@id=\"indexsearch\"]/div[2]/div/form/div[1]/div[4]/button");
                By bookNowButtonSelector = By.XPath("//*[@id=\"bodyconstraint-inner\"]/div[2]/div/div[2]/div[3]/div[2]/div[2]/div[3]/div[2]/div[1]/div[2]/div/div[3]/div[2]/div/div[2]/a");
                By firstNameFieldSelector = By.XPath("//*[@id='firstname']");
                By lastNameFieldSelector = By.XPath("//*[@id='lastname']");
                By emailFieldSelector = By.XPath("//*[@id='email']");
                By phoneFieldSelector = By.XPath("//*[@id='phone']");
                By bookNowButton2Selector = By.XPath("//*[@id=\"bookForm\"]/div[4]/div/div[2]/button");

                // Wait for element visibility
                wait.Until(ExpectedConditions.ElementIsVisible(xButtonSelector));

                // Actions
                IWebElement xButton = driver.FindElement(xButtonSelector);
                IWebElement destinationField = driver.FindElement(destinationFieldSelector);
                IWebElement firstDate = driver.FindElement(firstDateSelector);
                IWebElement lastDate = driver.FindElement(lastDateSelector);

                // Perform actions
                destinationField.SendKeys("Istanbul");
                firstDate.Click();
                lastDate.Click();
                driver.FindElement(searchButtonSelector).Click();

                // Wait for element visibility
                wait.Until(ExpectedConditions.ElementIsVisible(bookNowButtonSelector));

                IWebElement bookNowButton = driver.FindElement(bookNowButtonSelector);
                bookNowButton.Click();

                // Switch to new window
                driver.SwitchTo().Window(tabs[1]);

                IWebElement firstNameField = driver.FindElement(firstNameFieldSelector);
                firstNameField.Clear();
                firstNameField.SendKeys("Hadi");

                IWebElement lastNameField = driver.FindElement(lastNameFieldSelector);
                lastNameField.Clear();
                lastNameField.SendKeys("Jaradat");

                IWebElement emailField = driver.FindElement(emailFieldSelector);
                emailField.Clear();
                emailField.SendKeys("hadi.kh.jaradat@gmail.com");

                IWebElement phoneField = driver.FindElement(phoneFieldSelector);
                phoneField.Clear();
                phoneField.SendKeys("5995556287");
                emailField.Click();

                IWebElement bookNowButton2 = wait.Until(ExpectedConditions.ElementIsVisible(bookNowButton2Selector));
                bookNowButton2.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test failed with exception: {ex.Message}");
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
