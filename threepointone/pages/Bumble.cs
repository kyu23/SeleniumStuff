using System;
using System.Diagnostics;
using NUnit.Framework;
using OpenQA.Selenium;
using threepointone.util;


namespace threepointone.pages
{
    public class Bumble
    {

        //########## Setup ############
        private IWebDriver driver = null;
        private Util util = null;

        public Bumble(IWebDriver d)
        {
            this.driver = d;
            util = new Util(d);
        }
        //########### Element Definition #############
        private By SignInBtn = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/a[1]");
        private By CellPhoneBtn = By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[3]/form[1]/div[3]/div[1]/span[1]/span[1]/span[1]");
        private By EnterNumber = By.Id("phone");
        private By ContinueWithFacebook = By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[3]/form[1]/div[1]/div[1]/div[2]/div[1]/span[1]/span[2]/span[1]");
        private By ContinueBtn = By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[3]/form[1]/div[4]");
        private By FacebookEmail = By.Id("email");
        private By FacebookPass = By.Id("pass");
        private By FacebookLoginBtn = By.Id("u_0_0");
        private By SwipeRight = By.XPath("//div[@class='encounters-action tooltip-activator encounters-action--like']//span[@class='icon icon--size-stretch']");
        private By SwipeLeft = By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/main[1]/div[2]/div[1]/div[1]/span[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/span[1]");
        private By NextBtn = By.XPath("//div[@class='encounters-album__nav-item encounters-album__nav-item--next']");
        private By Match = By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/main[1]/div[2]/article[1]/div[1]/footer[1]/div[1]/div[2]/div[1]/span[1]/span[1]/span[1]");
        private By NextBtn2 = By.XPath("//div[@class='encounters-album__nav-item encounters-album__nav-item--next is-disabled\']");
        private By NoMoreBees = By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/main[1]/div[2]/article[1]/div[1]/span[1]/section[1]/div[1]/div[1]/span[1]");
        private By ContinueBumbling = By.LinkText("Continue Bumling");
        private By ContinueBumbling2 = By.ClassName("button button--narrow button--size-m  color-white button--transparent");
        private By ContinueBumbling3 = By.XPath("//span");

        //######### Function Definition ################

        public void openHome(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.FullScreen();

        }

        public void ClickSignIn()
        {
            util.JsClick(SignInBtn);
        }

        public void ClickCellPhoneBtn()
        {
            util.JsClick(CellPhoneBtn);
        }

        public void EnterPhoneNumber()
        {
            util.ClickElementAndSendText(EnterNumber, "3018256980");
        }

        public void ClickContinue()
        {
            util.ClickElement(ContinueBtn);
        }


        public void LoginWithFacebook()
        {
            util.JsClick(ContinueWithFacebook);
            string currentWindowHandle = driver.CurrentWindowHandle;
            SwitchToLoginWindow();
            //string currentWindow = driver.CurrentWindowHandle;
            //currentWindow.Contains("FacebookEmail");  
            util.ClickElementAndSendText(FacebookEmail, "kevin.yu239@gmail.com");
            util.ClickElementAndSendText(FacebookPass, "mansion23");
            util.JsClick(FacebookLoginBtn);
            driver.SwitchTo().Window(currentWindowHandle);

        }

        public void SwitchToLoginWindow()
        {
            Assert.AreEqual(2, driver.WindowHandles.Count);
            var newTabHandle = driver.WindowHandles[1];
            driver.SwitchTo().Window(newTabHandle);
        }

        public void StartSwiping()
        {

            //util.JsClick(SwipeLeft);
            //util.JsClick(SwipeRight);

            Console.WriteLine("whatever");




            

            


            do
            {

                //Random rnd = new Random();
                //int numWaits = rnd.Next(1000, 3500);
                //int numScrollDowns = rnd.Next(1, 5);
                //int count = 0;
                //bool isSwipe = false;

                if(util.AssertIsTrue(Match))
                {
                    Console.WriteLine("You got a match..");

                    //click okay/cancel
                    try
                    {
                        util.ClickElement(ContinueBumbling);
                        util.ClickElement(ContinueBumbling2);

                    }
                    catch
                    {
                        Console.WriteLine("got a match and failed to continue");
                    }
                    

                    //refresh the page
                    //util.RefreshPage();
                }
                else if (util.AssertIsTrue(NoMoreBees))
                {
                    Console.WriteLine("No More Bees...quitting");
                    driver.Quit();
                }



                //util.WaitElementVisible(SwipeRight);
                //util.Sleep(1000);
                util.NumScrolls(NextBtn, NextBtn2);
                util.ClickElement(SwipeRight);


                

                


                //scrolls randomly down to bottom of profile
                //util.ClickElement(NextBtn);
                //util.ClickElement(SwipeRight);

                //handle matches
                bool isMatch = true;



                //logging
                //Console.WriteLine("You have swiped {0} times", count);
                
            }
            while (util.AssertIsTrue(SwipeRight));


        }



        //int[] numScrolls = { 1, 2, 3, 4, 5 };

        //private class GetScroll(x)
        //{
            
            
        //    for(var i=0; i<numScrolls.Length - 1; i++)
        //    {
        //          Random rnd = new Random();
                   
        //          x = rnd.Next(numScrolls[i])
        //          temp = XmlWriterTraceListener;
        //            return XmlWriterTraceListener;
        //    }


        //    return numSrolls;
    }






}





    
