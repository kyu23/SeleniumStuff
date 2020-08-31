using OpenQA.Selenium;
using threepointone.util;

namespace threepointone.pages
{
    class Login
    {
        private IWebDriver driver = null;
        private Util util = null;
        private By loginUsername = By.Id("ctl00_MainContent_Username");
        private By loginPassword = By.Id("ctl00_MainContent_Password");
        private By loginBtn = By.Id("ctl00_MainContent_cmdLogin");


        public Login(IWebDriver d)
        {
            driver = d;
            util = new Util(d);
        }

        public void TypeUsername(string username)
        {
            util.ClickElement(loginUsername);
            util.SendText(loginUsername, username);
        }

        public void TypePassword(string password)
        {
            util.ClickElement(loginPassword);
            util.SendText(loginPassword, password);
        }


        public bool InputUsername()
        {

            return util.ClickElementAndSendText(loginUsername, "kyu");
        }

        public bool InputPassword()
        {
            return util.ClickElementAndSendText(loginPassword, "1111");
        }

        public bool ClickLogin()
        {
            return util.ClickElement(loginBtn);
        }

        public void openHome(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.FullScreen();

        }

        

        //public bool isFeaturePageLoaded()
        //{
        //    return util.IsElementVisible(pageImageClass);
        //}
        //public bool clickLegalLink()
        //{
        //    return util.ClickElement(legalLink);
        //}
        //public bool clickBackToTop()
        //{
        //    return util.ClickElement(backToTop);
        //}
    }
}