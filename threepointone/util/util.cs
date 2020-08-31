using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;

namespace threepointone.util
{
    class Util
    {
        private IWebDriver driver = null;

        public Util(IWebDriver d)
        {
            driver = d;
        }

        
        public int NumScrolls(By locator, By locator2)
        {

            Random rnd = new Random();

            int numWaits = rnd.Next(1000, 2000);
            int numScrollDowns = rnd.Next(1, 6);
            Console.Write("numscrollDowns:", numScrollDowns);
            Debug.WriteLine("numscrollDowns: ", numScrollDowns);



            //for (int i = 0; i < 1; i++)
            //{
            //    int temp;
            //    temp = rnd.Next(numScrollDowns);
            //    temp.ToString();

            //    Console.WriteLine(temp);
            //    Debug.WriteLine(temp);

            for (var i=0; i <= numScrollDowns; i++) //this comes back as zero
                {
                    try
                    {
                        ClickElement(locator);
                        Thread.Sleep(numWaits);
                        Console.WriteLine("here");
                        i++;
                    }
                    catch
                    {
                        ClickElement(locator2);
                        Thread.Sleep(numWaits);
                        Console.WriteLine("how many times clicked: {0}", locator2);
                        i++;
                    }
                    
                }
                return numScrollDowns;
        }
            

        

        public void RefreshPage()
        {
            driver.Navigate().Refresh();
        }
            

        public void captureScreenshot()
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            //ss.SaveAsFile("E:\\code\\CSharpe\\" + "Step" + GetTimestamp(DateTime.Now) + ".jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            //Console.WriteLine("Screenshot captured in file " + "E:\\code\\CSharpe\\" + "Step" + GetTimestamp(DateTime.Now) + ".jpeg");
        }

        

        public String GetTimeStamp(DateTime value)
        {
            Thread.Sleep(100);
            return value.ToString("mmssffff");
        }
        //public static String Timestamp(DateTime value)
        //{
        //    Thread.Sleep(500);
        //    return value.ToString("yyyyMMddHHmmssffff");
        //}

        public IWebElement WaitElementVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            Thread.Sleep(500);
            return element;

        }

        public bool ClickElement(By locator)
        {
            bool returnValue = false;
            try
            {
                WaitElementVisible(locator).Click();
                Thread.Sleep(500);
                returnValue = true;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + locator + "not found on page " + driver.Title);
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error " + e.Message + " occurred on page " + driver.Title);
                returnValue = false;
            }
            return returnValue;
        }

        //public bool isElementPresent(By locator)
        //{
        //    bool returnValue = false;
        //    try
        //    {

        //    }
        //}


        public void AssertAreEqual(By locator1, By locator2)
        {
            Assert.AreEqual(expected: locator1, actual: locator2);
        }

        public void AssertEqualStrings(string text1, string text2)
        {
            Assert.AreEqual(expected: text1, actual: text2);
        }

        public void AssertEqualByRole(string text, By locator)
        {
            string value = WaitElementVisible(locator).GetAttribute("role").ToString();
            Assert.AreEqual(expected: text, actual: value);
        }

        public void AssertEqualByValue(string text, By locator)
        {
            string value = WaitElementVisible(locator).GetAttribute("value").ToString();
            Assert.AreEqual(expected: text, actual: value);
        }

        public void AssertEqualByClass(string text, By locator)
        {
            string value = WaitElementVisible(locator).GetAttribute("class").ToString();
            Assert.AreEqual(expected: text, actual: value);
        }

        public bool AssertIsTrue(By locator)
        {

            try
            {
                Assert.IsTrue(driver.FindElement(locator).Displayed);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsElementVisible(By locator)
        {
            bool returnValue = false;
            try
            {
                Thread.Sleep(500);
                returnValue = WaitElementVisible(locator).Displayed;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + locator + "not found on page " + driver.Title);
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error " + e.Message + " occurred on page " + driver.Title);
                returnValue = false;
            }
            return returnValue;
        }

        public bool IsElementVisibleOut(By locator, out IWebElement element)
        {
            element = null;

            try
            {
                element = WaitElementVisible(locator);
                Thread.Sleep(500);
                return element.Displayed;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + locator + "not found on page " + driver.Title);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error " + e.Message + " occurred on page " + driver.Title);
            }
            return false;
        }

        public void SendText(By locator, string text)
        {
            Thread.Sleep(500);
            WaitElementVisible(locator).SendKeys(text);
        }

        public void ClearText(By locator)
        {
            WaitElementVisible(locator).Clear();
        }

        public bool ClickElementAndSendText(By locator, string text)
        {
            bool returnValue = false;
            try
            {

                WaitElementVisible(locator).SendKeys(text);
                Thread.Sleep(500);
                returnValue = true;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + locator + "not found on page" + driver.Title + "or sendkeys messed up ");
                returnValue = false;
            }
            return returnValue;
        }

        public void FindElement(By locator)
        {
            driver.FindElement(locator);
        }

        public void JsClick(By locator)
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IsElementVisible(locator);
            js.ExecuteScript("arguments[0].click();", driver.FindElement(locator)); //hopefully WaitForElementVisible returns element           
        }

        public void JsGetAttribute(By locator)
        {
            Thread.Sleep(500);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("return arguments[0].value", driver.FindElement(locator)); //hopefully WaitForElementVisible returns element
        }

        public void JsGetAttributeAssertEqual(By locator, string text)
        {
            Thread.Sleep(500);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string text1 = js.ExecuteScript("return arguments[0].value", driver.FindElement(locator)).ToString();
            AssertEqualStrings(text1, text);
        }

        public void Sleep(int number)
        {
            Thread.Sleep(number);
        }

        public void SwitchToFrame()
        {
            driver.SwitchTo().Frame(0);
        }

        public void GetValueAttributeAndReOpenPortal(By locator, By locator1, By locator2)
        {

            string value = WaitElementVisible(locator).GetAttribute("value").ToString();
            Debug.WriteLine("AGENT'S LAST NAME IS: " + value);
            try
            {
                JsClick(locator1);
            }
            catch
            {
                ClickElement(locator1);
            }


            ClearText(locator2);
            ClickElementAndSendText(locator2, value);
        }

        public void UploadDoc(By locator)
        {
            Thread.Sleep(1500);
            IWebElement element = driver.FindElement(locator);
            string element2 = @"C:\Users\KevinYu\Desktop\Tablet_Management_Resources.docx";
            element.SendKeys(element2);
        }

        public void ValidateCheckmarkIsGreen(By locator)
        {
            string value = WaitElementVisible(locator).GetAttribute("style").ToString();
            Assert.AreEqual(expected: "color: green;", actual: value);
        }

        public void ValidateCheckmarkIsRed(By locator)
        {
            string value = WaitElementVisible(locator).GetAttribute("style").ToString();
            Assert.AreEqual(expected: "color: red;", actual: value);

        }

        public void ValidateCheckmarkIsOrange(By locator)
        {
            string value = WaitElementVisible(locator).GetAttribute("style").ToString();
            Assert.AreEqual(expected: "color: orange;", actual: value);
        }


        public void SetUpTestCaseToDebug()
        {

        }

        public void Comment()
        {
            Console.WriteLine("###################################");
        }

    }
}