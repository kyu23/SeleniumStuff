using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using threepointone.util;
using System.Runtime;
using threepointone.pages;
using FluentAssertions;
using System.Threading;

namespace threepointone.tests
{


    [TestFixture]
    class testClass
    {
        IWebDriver driver = null;
        Home home = null;
        Login login = null;
        Rep rep = null;
        Bumble bumble = null;


        [OneTimeSetUp]
        public void initialize()
        {
            driver = new ChromeDriver(Environment.CurrentDirectory);
            //driver = new ChromeDriver();
            home = new Home(driver);
            login = new Login(driver);
            rep = new Rep(driver);
            bumble = new Bumble(driver);

        }

        [Test]
        public void B()
        {
            bumble.openHome("https://www.bumble.com");
            bumble.ClickSignIn();
            bumble.LoginWithFacebook();
            bumble.StartSwiping();
         
            //bumble.ClickCellPhoneBtn();
            //bumble.EnterPhoneNumber();
            //bumble.ClickContinue();
        }

        [Test]
        public void T()
        {
            //Tinder();
        }


        [Test]
        public void LoginAsAdmin()
        {
            login.openHome("https://qawebcnst.ontlp.com/login.aspx");
            login.TypeUsername("kyu");
            login.TypePassword("1111");
            login.ClickLogin();

            
            Console.WriteLine("Admin is successfully logged in!");
        }

        [Test]
        public void GoToRepsPage()
        {
            LoginAsAdmin();
            home.NavigateToRepsPage();
        }

        [Test]
        public void CreateNewResiAgent()
        {
            GoToRepsPage();

            rep.ClickCreateNewAgentButton();
            rep.ClickResiDropdowns();
            rep.FillOutPersonalInfoResi();
            rep.GrabRepIDAndReOpenRep();
            rep.ValidateAgentSummaryAfterAgentCreated();
            rep.FillOutBackgroundCheck();
            rep.SetBCToPendingRequestException();
            rep.SetBCToDeniedRequestException();
            rep.SetBCToApprovedRequestException();
            rep.FillOutDrugTest();
            rep.FillOutDocumentation();
            rep.ContingentStartTheAgent();
        }

        [Test]
        public void Debug()
        {
            GoToRepsPage();
            rep.DebugInputAgentID();
            rep.DebugClickNewBC();


        }





        [OneTimeTearDown]
        public void cleanUp()
        {
            //driver.Quit();
        }
    }
}