using OpenQA.Selenium;
using threepointone.util;


namespace threepointone.pages
{
    class Home
    {
        //########## Setup ############
        private IWebDriver driver = null;
        private Util util = null;
        public Home(IWebDriver d)
        {
            this.driver = d;
            util = new Util(d);
        }
        //########### Element Definition #############
        private By AgentTab = By.LinkText("Agents");
        private By AgentTabSearch = By.XPath("/html[1]/body[1]/form[1]/div[2]/div[1]/div[5]/div[1]/div[1]/ul[1]/li[3]/ul[1]/li[1]/a[1]");
        private By CreateNewAgentButton = By.CssSelector("#NewPortalRecordButton");
        //######### Function Definition #################

        public void NavigateToRepsPage()
        {



            util.ClickElement(AgentTab);
            util.Sleep(250);
            util.ClickElement(AgentTab);
            util.ClickElement(AgentTabSearch);

            if (util.IsElementVisible(CreateNewAgentButton) == false)
            {
                driver.Navigate().GoToUrl("https://qawebcnst.ontlp.com/MVC/Representatives");
            }
            else if (util.IsElementVisible(CreateNewAgentButton) == true)
            {

            }





        }

        public void NewNavigateToRepsPage()
        {



            util.ClickElement(AgentTab);
            util.Sleep(250);
            util.ClickElement(AgentTab);
            util.ClickElement(AgentTabSearch);

            if (util.IsElementVisible(CreateNewAgentButton) == false)
            {
                driver.Navigate().GoToUrl("https://qawebcnst.ontlp.com/MVC/RepresentativesTest");
            }
            else if (util.IsElementVisible(CreateNewAgentButton) == true)
            {

            }

        }

    }


}

