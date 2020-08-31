using System;
using System.Collections.Generic;
using System.Text;
using threepointone.util;
using OpenQA.Selenium;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace threepointone.pages
{
    class Rep
    {
        //########## Setup ############

        private IWebDriver driver = null;
        private Util util = null;

        public Rep(IWebDriver d)
        {
            driver = d;
            util = new Util(d);

        }

        //########### Element Definition #############   //STORE THESE MOTHERFUCKERS AS ARRAYS, WRITE A FUNCTION TO READ IT AND STORE IT AS ARRAY

        //DropdownMenus
        private By CreateNewAgentBtn = By.Id("NewPortalRecordButton");
        private By ChannelDropDown = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[2]/div[1]/form[1]/div[1]/section[2]/div[2]/section[1]/div[1]/div[1]/div[2]/span[1]/span[1]/span[1]");
        private By VendorDropDown = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[2]/div[1]/form[1]/div[1]/section[2]/div[2]/section[1]/div[1]/div[2]/div[2]/span[1]/span[1]/span[1]");
        private By StateDropDown = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[2]/div[1]/form[1]/div[1]/section[2]/div[2]/section[1]/div[1]/div[3]/div[2]/span[1]/span[1]/span[1]");
        private By OfficeDropDown = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[2]/div[1]/form[1]/div[1]/section[2]/div[2]/section[1]/div[1]/div[4]/div[4]/span[1]/span[1]/span[1]");

        //channels
        private By SelectResiChannelDropDown = By.XPath("/html[1]/body[1]/div[4]/div[1]/div[3]/ul[1]/li[2]");
        private By SelectBrokerChannelDropDown = By.XPath("/html[1]/body[1]/div[4]/div[1]/div[3]/ul[1]/li[1]");
        private By SelectResiDTDWebChannelDropDown = By.XPath("/html[1]/body[1]/div[4]/div[1]/div[3]/ul[1]/li[3]");
        private By SelectRetailChannelDropDown = By.XPath("/html[1]/body[1]/div[4]/div[1]/div[3]/ul[1]/li[4]");
        private By SelectSmbChannelDropDown = By.XPath("/html[1]/body[1]/div[4]/div[1]/div[3]/ul[1]/li[5]");

        //Vendors
        private By SelectResiVendorTLPVentures = By.XPath("/html[1]/body[1]/div[5]/div[1]/div[3]/ul[1]/li[29]");
        private By SelectRetailVendorUES = By.XPath("/html[1]/body[1]/div[5]/div[1]/div[3]/ul[1]/li[10]");
        private By SelectSMBVendorNetpique = By.XPath("/html[1]/body[1]/div[5]/div[1]/div[3]/ul[1]/li[4]");


        //States
        private By SelectResiStateMD = By.XPath("/html[1]/body[1]/div[6]/div[1]/div[3]/ul[1]/li[1]");
        private By SelectRetailStateIL = By.XPath("/html[1]/body[1]/div[5]/div[1]/div[3]/ul[1]/li[10]");
        private By SelectSMBStateMD = By.XPath("//html[1]/body[1]/div[6]/div[1]/div[3]/ul[1]/li[2]");


        //Offices
        private By SelectResiOfficeMD = By.XPath("/html[1]/body[1]/div[7]/div[1]/div[3]/ul[1]/li[1]"); //Baltimore, MD
        private By SelectRetailOfficeIL = By.XPath("/html[1]/body[1]/div[7]/div[1]/div[3]/ul[1]/li[1]"); //IL UES Retail Test Office
        private By SelectSMBOfficeMD = By.XPath("/html[1]/body[1]/div[7]/div[1]/div[3]/ul[1]/li[1]"); //Laurel MD & DC

        //Rep Portal Tabs
        private By PersonalInformationTab = By.XPath("/html[1]/body[1]/div[2]/div[1]/ul[1]/li[2]/a[1]");
        private By AgentSummaryTab = By.XPath("//a[contains(text(),'Agent Summary')]");
        private By BackgroundCheckTab = By.XPath("//a[contains(text(),'Background Checks')]");
        private By DrugTestTab = By.XPath("//a[contains(text(),'Drug Tests')]");
        private By DocumentationTab = By.XPath("//a[contains(text(),'Documentation')]");
        private By ComplaintsTab = By.XPath("//a[contains(text(),'Complaints')]");
        private By DisciplineTab = By.XPath("//a[contains(text(),'Discipline')]");

        //Agent Summary Elements
        private By RepID = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/section[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[2]");
        private By XOutRepPortalBtn = By.XPath("/html[1]/body[1]/div[17]/div[1]/div[1]/a[1]/span[1]");
        private By CheckOrXBackgroundCheck = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/span[1]");
        private By CheckOrXDrugTest = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[2]/span[1]");
        private By CheckOrXDocumentationUpload = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[3]/span[1]");
        private By CheckOrXActivatedToSell = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[4]/span[1]");
        private By ActivateBtn = By.CssSelector("#activateButton");
        private By DeactivateBtn = By.CssSelector("#deactivateButton");

        //Personal Info 
        private By RepIDField = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[2]/div[1]/form[1]/div[1]/section[2]/div[2]/section[2]/div[1]/div[2]/div[2]/input[1]");
        private By FirstNameField = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[2]/div[1]/form[1]/div[1]/section[2]/div[2]/section[2]/div[1]/div[2]/div[2]/input[1]");
        private By MiddleNameField = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[2]/div[1]/form[1]/div[1]/section[2]/div[2]/section[2]/div[1]/div[3]/div[2]/input[1]");
        private By LastNameField = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[2]/div[1]/form[1]/div[1]/section[2]/div[2]/section[2]/div[1]/div[4]/div[2]/input[1]");
        private By PhoneNumberField = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[2]/div[1]/form[1]/div[1]/section[2]/div[2]/section[3]/div[1]/div[1]/div[2]/span[1]/input[1]");
        private By EmailField = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[2]/div[1]/form[1]/div[1]/section[2]/div[2]/section[3]/div[1]/div[2]/div[2]/input[1]");
        private By LastFourSSNField = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[2]/div[1]/form[1]/div[1]/section[2]/div[2]/section[3]/div[1]/div[3]/div[2]/input[1]");
        private By DateOfBirthField = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[2]/div[1]/form[1]/div[1]/section[2]/div[2]/section[3]/div[1]/div[4]/div[2]/span[1]/span[1]/input[1]");
        private By PinField = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[2]/div[1]/form[1]/div[1]/section[2]/div[2]/section[4]/div[1]/div[1]/div[2]/input[1]");
        private By LanguageDropDown = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[2]/div[1]/form[1]/div[1]/section[2]/div[2]/section[4]/div[1]/div[2]/div[2]/span[1]/span[1]/span[1]");
        private By SelectLangauageBoth = By.XPath("/html[1]/body[1]/div[10]/div[1]/div[3]/ul[1]/li[1]");
        private By SelectLanguageEnglish = By.XPath("/html[1]/body[1]/div[10]/div[1]/div[3]/ul[1]/li[2]");
        private By SelectLanguageSpanish = By.XPath("/html[1]/body[1]/div[10]/div[1]/div[3]/ul[1]/li[3]");
        private By SavePersonalInfoBtn = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[2]/div[1]/form[1]/div[2]/div[1]/div[1]/input[1]");
        private By ClosePersonalInfoBtn = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[2]/div[1]/form[1]/div[2]/div[1]/div[1]/input[2]");
        private By PositionDropDown = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[2]/div[1]/form[1]/div[1]/section[2]/div[2]/section[4]/div[1]/div[3]/div[2]/span[1]/span[1]/span[1]");
        private By SelectAgentPosition = By.XPath("/html[1]/body[1]/div[11]/div[1]/div[2]/ul[1]/li[1]");
        private By SelectManagerPosition = By.XPath("/html[1]/body[1]/div[11]/div[1]/div[2]/ul[1]/li[2]");
        private By SelectVendorManagerPosition = By.XPath("/html[1]/body[1]/div[11]/div[1]/div[2]/ul[1]/li[3]");
        private By VendorDetailsResiTLPVentures = By.XPath("//td[contains(text(),'TLP Ventures LLC')]");
        private By StateDetailsResiMD = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/section[1]/div[3]/div[1]/table[1]/tbody[1]/tr[2]/td[2]");
        private By ChannelDetailsResiResiDTD = By.XPath("//td[contains(text(),'Residential DTD')]");
        private By BranchDetailsResiBaltimore = By.XPath("//td[contains(text(),'Baltimore MD')]");
        private By OnboardingTitle = By.XPath("//span[contains(text(),'Onboarding')]");
        private By RelatedRepsTitleBar = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[4]/div[2]/div[1]/div[1]");


        //Background Check
        private By BCNewBCBtn = By.XPath("//button[@id='NewBackgroundCheckButton']");
        private By BCIntroText = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[3]/div[1]/div[4]/form[1]/fieldset[1]/div[1]/div[1]/label[1]");
        private By BCYesToStart = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[3]/div[1]/div[4]/form[1]/fieldset[1]/div[1]/div[1]/div[2]/div[1]/a[2]");
        private By BCUploadResponseDoc = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[3]/div[1]/div[4]/form[1]/fieldset[1]/div[1]/div[2]/div[1]/div[1]/input[1]");
        private By BCRequestDate = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[3]/div[1]/div[4]/form[1]/fieldset[1]/div[2]/div[1]/div[1]/div[1]/div[2]/span[1]/span[1]/input[1]");
        private By BCUploadDriversLicenseBtn = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[3]/div[1]/div[4]/form[1]/fieldset[1]/div[2]/div[1]/div[1]/div[1]/div[9]/div[1]/div[1]/input[1]");
        private By BCStartResponseBtn = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[3]/div[1]/div[4]/form[1]/fieldset[1]/div[2]/div[1]/div[2]/div[1]/div[1]/button[1]");
        private By BCComments = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[3]/div[1]/div[4]/form[1]/fieldset[1]/div[2]/div[1]/div[1]/div[1]/div[10]/textarea[1]");
        private By BCResponseDate = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[3]/div[1]/div[4]/form[1]/fieldset[1]/div[2]/div[1]/div[2]/div[1]/div[2]/div[1]/span[1]/span[1]/input[1]");
        private By BCPassedCriminalHistoryCheckYes = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[3]/div[1]/div[4]/form[1]/fieldset[1]/div[2]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/a[2]");
        private By BCPassedCriminalHistoryCheckNo = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[3]/div[1]/div[4]/form[1]/fieldset[1]/div[2]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/a[1]");
        private By BCExceptionRequestedYes = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[3]/div[1]/div[4]/form[1]/fieldset[1]/div[2]/div[1]/div[2]/div[1]/div[2]/div[6]/div[1]/a[2]");
        private By BCExceptionRequestedNo = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[3]/div[1]/div[4]/form[1]/fieldset[1]/div[2]/div[1]/div[2]/div[1]/div[2]/div[6]/div[1]/a[1]");
        private By BCSaveBtn = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[3]/div[1]/div[4]/form[1]/fieldset[1]/div[2]/div[2]/div[1]/div[1]/input[1]");
        private By BCGridResponseDate = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[3]/div[1]/div[2]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[2]");
        private By BCGridRequestDate = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[3]/div[1]/div[2]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[1]");
        private By BCExceptionReason = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[3]/div[1]/div[4]/form[1]/fieldset[1]/div[2]/div[1]/div[2]/div[1]/div[2]/div[7]/div[1]/input[1]");

        private By BCExceptionStatusDropdown = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[3]/div[1]/div[4]/form[1]/fieldset[1]/div[2]/div[1]/div[2]/div[1]/div[2]/div[7]/div[2]/span[1]/span[1]/span[1]");

        private By BCExceptionStatusApproved = By.XPath("//ul[@id='ExceptionStatus_listbox']//li[@class='k-item'][contains(text(),'Approved')]");
        private By BCExceptionStatusDenied = By.XPath("//ul[@id='ExceptionStatus_listbox']//li[@class='k-item'][contains(text(),'Denied')]");
        private By BCExceptionStatusPending = By.XPath("//ul[@id='ExceptionStatus_listbox']//li[@class='k-item'][contains(text(),'Pending')]");

        private By BCExceptionStatusDropdownIsPending = By.XPath("//span[@class='k-widget k-dropdown k-header form-control']//span[@class='k-input'][contains(text(),'Pending')]");



        //Drug Test
        private By DTNewDTBtn = By.XPath("//button[@id='NewDrugTestButton']");
        private By DTComments = By.XPath("//textarea[@id='Comments']");
        private By DTResultsDropDown = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[4]/div[1]/div[4]/form[1]/fieldset[1]/div[2]/section[1]/div[1]/div[5]/span[1]/span[1]/span[1]");
        private By DTResultPositive = By.XPath("//ul[@id='Result_listbox']//li[@class='k-item'][contains(text(),'Positive')]");
        private By DTResultNegative = By.XPath("/html[1]/body[1]/div[35]/div[1]/div[3]/ul[1]/li[2]");
        private By DTResultUploadBtn = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[4]/div[1]/div[4]/form[1]/fieldset[1]/div[2]/section[1]/div[1]/div[6]/div[1]/div[1]/div[1]/input[1]");
        private By DTSaveBtn = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[4]/div[1]/div[4]/form[1]/fieldset[1]/div[3]/div[1]/div[1]/input[1]");
        private By DTExceptionRequestedNo = By.LinkText("No");
        private By DTExceptionRequestedYes = By.LinkText("Yes");
        private By DTExceptionReason = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[4]/div[1]/div[4]/form[1]/fieldset[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/input[1]");
        private By DTExceptionStatusDropDown = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[4]/div[1]/div[4]/form[1]/fieldset[1]/div[1]/div[2]/div[1]/div[2]/div[2]/div[1]/span[1]/span[1]/span[1]");
        private By DTExceptionStatusApproved = By.XPath("//ul[@id='ExceptionStatus_listbox']//li[@class='k-item'][contains(text(),'Approved')]");
        private By DTExceptionStatusPending = By.XPath("//ul[@id='ExceptionStatus_listbox']//li[@class='k-item'][contains(text(),'Pending')]");
        private By DTExceptionStatusDenied = By.XPath("//ul[@id='ExceptionStatus_listbox']//li[@class='k-item'][contains(text(),'Denied')]");
        private By DTResultsSecondDropdown = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[4]/div[1]/div[4]/form[1]/fieldset[1]/div[2]/section[2]/div[2]/div[4]/span[1]/span[1]/span[1]");
        private By DTResultPositiveSecond = By.XPath("//ul[@id='ExceptionStatus_listbox']//li[@class='k-item'][contains(text(),'Positive')]");
        private By DTResultNegativeSecond = By.XPath("//ul[@id='SecondTestResult_listbox']//li[@class='k-item'][contains(text(),'Negative')]");
        private By DTResultUploadSecondBtn = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[4]/div[1]/div[4]/form[1]/fieldset[1]/div[2]/section[2]/div[2]/div[5]/div[1]/div[1]/input[1]");

        //Documentation
        private By DocRentionAndDocumentationTitle = By.XPath("//h1[contains(text(),'Retention & Documentation')]");
        private By DocText1 = By.XPath("//p[contains(text(),'Has Vendor retained the following documents with r')]");
        private By DocText2 = By.XPath("//div[@id='RepPortalTabStrip-5']//li[1]"); //a copy of the Vendor Agent's written authorization and consend document...
        private By DocText3 = By.XPath("//div[@id='RepPortalTabStrip-5']//li[2]"); //a copy of the Vendor Agent's background check investigation report
        private By DocText4 = By.XPath("//div[@id='RepPortalTabStrip-5']//li[3]"); //if applicable, a copy of the written approval.....
        private By DocText5 = By.XPath("//li[contains(text(),'A copy of the executed Vendor Agent Performance an')]");
        private By DocText6 = By.XPath("//li[contains(text(),'A copy of the completed and scored Vendor Agent ce')]");
        private By DocText7 = By.XPath("//div[@id='RepPortalTabStrip-5']//li[6]"); //if applicable, a copy of the written approval from EXELON for the....
        private By DocText8 = By.XPath("//p[contains(text(),'If Vendor fails to have the required documents whe')]");
        private By DocText9 = By.XPath("");
        private By DocText10 = By.XPath("");
        private By DocText11 = By.XPath("");
        private By DocText12 = By.XPath("");
        private By DocPerformanceAndEthicalStandardsTitle = By.XPath("//h1[contains(text(),'Performance and Ethical Standards')]");
        private By DocText13 = By.XPath("//p[contains(text(),'Did the Agent execute the Vendor Agent Performance')]");
        private By DocRetentionAndDocumentationYes = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[5]/div[1]/form[1]/fieldset[1]/div[1]/div[1]/div[1]/a[2]");
        private By DocRententionAndDocumentationNo = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[5]/div[1]/form[1]/fieldset[1]/div[1]/div[1]/div[1]/a[1]");
        private By DocPerformanceAndEthicalStandardsYes = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[5]/div[1]/form[2]/fieldset[1]/div[1]/div[1]/div[1]/div[1]/a[2]");
        private By DocPerformanceAndEthicalStandardsNo = By.XPath("/html[1]/body[1]/div[2]/div[1]/div[5]/div[1]/form[2]/fieldset[1]/div[1]/div[1]/div[1]/div[1]/a[1]");


        //Validation Messages
        private By ChannelValidationMsg = By.CssSelector("#ChannelId_validationMessage");
        private By VendorValidationMsg = By.CssSelector("#MarketerId_validationMessage");
        private By StateValidationMsg = By.CssSelector("#StateId_validationMessage");
        private By OfficeValidationMsg = By.CssSelector("#StateId_validationMessage");
        private By RepIdValidationMsg = By.CssSelector("#Login_validationMessage");
        private By FirstNameValidationMsg = By.CssSelector("#FirstName_validationMessage");
        private By LastNameValidationMsg = By.CssSelector("#LastName_validationMessage");
        private By PhoneNumValidationMsg = By.CssSelector("#Phone_validationMessage");
        private By LastFourSSNValidationMsg = By.CssSelector("#LastFourSSN_validationMessage");
        private By DateOfBitchValidationMsg = By.CssSelector("#DateOfBirth_validationMessage");
        private By PinValidationMsg = By.CssSelector("#PIN_validationMessage");
        private By LanguageValidationMsg = By.CssSelector("#LanguageId_validationMessage");

        //Rep Filters
        private By RepIdFilterField = By.CssSelector("#txtRepLogin");
        private By FindBtn = By.CssSelector("#btnSearch");
        private By PortalBtn = By.CssSelector("#PortalButton");
        private By LastNameFilterField = By.CssSelector("#txtLastName");
        private By GridLastName = By.PartialLinkText("/html[1]/body[1]/form[1]/div[2]/div[2]/div[1]/div[4]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[12]");

        public string CurrentRepID { get; set; }

        //######### Function Definition #################

        public void ClickCreateNewAgentButton()
        {
            //util.ClickElement(CreateNewAgentButton);

            try
            {
                string RepPageURL = driver.FindElement(By.LinkText("https://qawebcnst.ontlp.com/MVC/Representatives")).GetAttribute("href");
                util.AssertEqualStrings(RepPageURL, "https://qawebcnst.ontlp.com/MVC/Representatives");
                util.JsClick(CreateNewAgentBtn);
            }
            catch
            {
                driver.Navigate().GoToUrl("https://qawebcnst.ontlp.com/MVC/Representatives");
                util.IsElementVisible(CreateNewAgentBtn);
                util.JsClick(CreateNewAgentBtn);
            }


            while (util.AssertIsTrue(CreateNewAgentBtn) == true)
            {
                try
                {
                    util.IsElementVisible(PersonalInformationTab);
                    break;
                }
                catch
                {
                    Debug.WriteLine("Rep Portal never popped up... reclicking!");
                    util.JsClick(CreateNewAgentBtn);

                }
            }

        }

        public void ClickResiDropdowns()
        {
            try
            {
                util.SwitchToFrame();
            }
            catch
            {
                ClickCreateNewAgentButton();
            }


            try
            {
                util.JsClick(ChannelDropDown);
                util.JsClick(SelectResiChannelDropDown);

                util.JsClick(VendorDropDown);
                util.JsClick(SelectResiVendorTLPVentures);

                util.JsClick(StateDropDown);
                util.JsClick(SelectResiStateMD);

                util.JsClick(OfficeDropDown);
                util.JsClick(SelectResiOfficeMD);
            }
            catch
            {
                util.JsClick(ChannelDropDown);
                util.JsClick(SelectResiChannelDropDown);

                util.JsClick(VendorDropDown);
                util.JsClick(SelectResiVendorTLPVentures);

                util.JsClick(StateDropDown);
                util.JsClick(SelectResiStateMD);

                util.JsClick(OfficeDropDown);
                util.JsClick(SelectResiOfficeMD);
            }

        }

        public void ClickRetailDropdowns()
        {
            util.SwitchToFrame();

            util.JsClick(ChannelDropDown);
            util.JsClick(SelectRetailChannelDropDown);

            util.JsClick(VendorDropDown);
            util.JsClick(SelectRetailVendorUES);

            util.JsClick(StateDropDown);
            util.JsClick(SelectRetailStateIL);

            util.JsClick(OfficeDropDown);
            util.JsClick(SelectRetailOfficeIL);

        }

        public void ClickSMBDropdowns()
        {
            util.SwitchToFrame();

            util.JsClick(ChannelDropDown);
            util.JsClick(SelectSmbChannelDropDown);

            util.JsClick(VendorDropDown);
            util.JsClick(SelectSMBVendorNetpique);

            util.JsClick(StateDropDown);
            util.JsClick(SelectSMBStateMD);

            util.JsClick(OfficeDropDown);
            util.JsClick(SelectSMBOfficeMD);
        }

        public void FillOutPersonalInfoResi() //no rep ID
        {
            string DateAndTime = util.GetTimeStamp(DateTime.UtcNow);

            util.ClickElementAndSendText(FirstNameField, "KYU");
            util.ClickElementAndSendText(LastNameField, DateAndTime);
            util.ClickElementAndSendText(MiddleNameField, "Testing");
            util.ClickElementAndSendText(PhoneNumberField, "1231231234");
            util.ClickElementAndSendText(EmailField, "kyuautomatedtests@test.com");
            util.ClickElementAndSendText(LastFourSSNField, "1234");
            util.ClickElementAndSendText(DateOfBirthField, "09/23/1992");
            util.ClickElementAndSendText(PinField, "1111");
            util.JsClick(LanguageDropDown);
            util.JsClick(SelectLangauageBoth);
            util.JsClick(PositionDropDown);
            util.JsClick(SelectAgentPosition);

            util.ClickElement(SavePersonalInfoBtn);
            Debug.WriteLine("--PERSONAL INFORMATION SAVED--");
        }

        public void FilleOutPersonalInfoRetailSMB() //with RepID
        {
            string DateAndTime = DateTime.UtcNow.ToString("mmssffff");

            util.ClickElementAndSendText(RepIDField, $"Kyu{DateAndTime}");
            util.ClickElementAndSendText(FirstNameField, "KYU");
            util.ClickElementAndSendText(LastNameField, DateAndTime);
            util.ClickElementAndSendText(MiddleNameField, "Testing");
            util.ClickElementAndSendText(PhoneNumberField, "1231231234");
            util.ClickElementAndSendText(EmailField, "kyuautomatedtests@test.com");
            util.ClickElementAndSendText(LastFourSSNField, "1234");
            util.ClickElementAndSendText(DateOfBirthField, "09/23/1992");
            util.ClickElementAndSendText(PinField, "1111");
            util.JsClick(LanguageDropDown);
            util.JsClick(SelectLangauageBoth);
            util.JsClick(PositionDropDown);
            util.JsClick(SelectAgentPosition);

            util.ClickElement(SavePersonalInfoBtn);

            Debug.WriteLine("--PERSONAL INFO SAVED SUCCESSFULLY--");
        }

        public void GrabRepIDAndReOpenRep()
        {
            util.ClickElement(PersonalInformationTab);
            util.WaitElementVisible(LastNameField);



            util.GetValueAttributeAndReOpenPortal(LastNameField, ClosePersonalInfoBtn, LastNameFilterField);

            util.ClickElement(FindBtn);


            if (util.IsElementVisible(GridLastName) == true)
            {
                util.AssertAreEqual(LastNameFilterField, GridLastName);
                util.JsClick(PortalBtn);
            }
            else if (util.IsElementVisible(GridLastName) == false)
            {
                util.AssertAreEqual(LastNameFilterField, LastNameFilterField);
                util.ClickElement(FindBtn);
                util.IsElementVisible(PortalBtn);
                util.JsClick(PortalBtn);
            }
            else
            {
                util.JsClick(PortalBtn);
            }

            try
            {
                util.SwitchToFrame();
            }
            catch
            {
                AgentSummaryTabShows();
            }

            Debug.WriteLine("--REOPENED AGENT SUCCESSFULLY--");
        }

        public void ValidateAgentSummaryAfterAgentCreated()
        {
            util.WaitElementVisible(PersonalInformationTab);
            util.IsElementVisible(PersonalInformationTab);

            util.AssertIsTrue(VendorDetailsResiTLPVentures);
            util.AssertIsTrue(StateDetailsResiMD);
            util.AssertIsTrue(ChannelDetailsResiResiDTD);
            util.AssertIsTrue(BranchDetailsResiBaltimore);
            util.AssertIsTrue(OnboardingTitle);
            CompleteOnboardingIsGray();

            util.ValidateCheckmarkIsRed(CheckOrXBackgroundCheck);
            util.ValidateCheckmarkIsRed(CheckOrXDrugTest);
            util.ValidateCheckmarkIsRed(CheckOrXDocumentationUpload);
            util.ValidateCheckmarkIsRed(CheckOrXActivatedToSell);


        }

        public void CompleteOnboardingIsGray()
        {
            try
            {
                IWebElement OnboardingBtn = driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[4]/div[1]/div[1]/div[1]"));
                string GrayedOutOnboardingBtn = OnboardingBtn.GetAttribute("title");
                util.AssertEqualStrings("Rep must be in Awaiting Activation status to complete onboarding", GrayedOutOnboardingBtn);
            }
            catch { }




        }

        public bool ClickFindBtn()
        {
            return util.ClickElement(FindBtn);
        }

        public void AgentSummaryTabShows()
        {

            util.IsElementVisibleOut(AgentSummaryTab, out var element);

            if (element.Displayed)
            {
                util.SwitchToFrame();
                ValidateAgentSummaryAfterAgentCreated();
            }
            else if (element.Displayed == false)
            {
                driver.Navigate().Refresh();
                util.WaitElementVisible(PortalBtn);
                util.JsClick(PortalBtn);
                ValidateAgentSummaryAfterAgentCreated();
            }

        }

        public void FillOutBackgroundCheck()
        {



            //1. All elements are present
            //2. After clicking "Yes" all other elements appear
            //3. Fill out and save background check
            //4. New Grid Item Appears
            //5. Validate Onboarding Requirements for BC are fulfilled
            //6. Validate Exception Requested works

            util.JsClick(BackgroundCheckTab);

            //1.
            util.AssertIsTrue(BCIntroText);
            util.AssertIsTrue(BCNewBCBtn);
            util.AssertIsTrue(BCStartResponseBtn);
            util.AssertIsTrue(BCUploadResponseDoc);

            try
            {
                util.UploadDoc(BCUploadResponseDoc);
                util.JsClick(BCYesToStart);
            }
            catch
            {
                util.JsClick(BackgroundCheckTab);
                util.Sleep(500);
                util.UploadDoc(BCUploadResponseDoc);
                util.JsClick(BCYesToStart);

            }


            //2.
            util.AssertIsTrue(BCRequestDate);
            util.AssertIsTrue(BCUploadDriversLicenseBtn);
            util.AssertIsTrue(BCComments);
            util.AssertIsTrue(BCRequestDate);
            util.AssertIsTrue(BCPassedCriminalHistoryCheckYes);
            util.AssertIsTrue(BCPassedCriminalHistoryCheckNo);

            //3.
            util.ClearText(BCRequestDate);
            util.ClickElementAndSendText(BCRequestDate, "9/23/2019");
            util.UploadDoc(BCUploadDriversLicenseBtn);
            util.ClickElementAndSendText(BCComments, "testing background check");

            util.JsClick(BCStartResponseBtn);

            util.ClearText(BCResponseDate);
            util.ClickElementAndSendText(BCResponseDate, "9/23/2019");
            util.JsClick(BCPassedCriminalHistoryCheckYes);
            util.ClickElement(BCSaveBtn);

            //4.
            util.IsElementVisible(BCGridRequestDate);

            util.AssertEqualByRole("gridcell", BCGridResponseDate);
            util.AssertEqualByRole("gridcell", BCGridRequestDate);

            //5.
            util.ClickElement(AgentSummaryTab);
            util.ValidateCheckmarkIsOrange(CheckOrXBackgroundCheck);
            Debug.WriteLine("--BACKGROUND CHECK FILLED OUT SUCCESSFULLY--");

            //6.
            //SetBCToPendingRequestException();
            //SetBCToDeniedRequestException();
            //SetBCToApprovedRequestException();

            Debug.WriteLine("--ONBOARDING REQUIREMENTS BACKGROUND CHECK PASSED--");


        }

        public void SetBCToPendingRequestException()
        {

            util.JsClick(BackgroundCheckTab);
            util.JsClick(BCPassedCriminalHistoryCheckNo);
            util.AssertIsTrue(BCExceptionRequestedNo);
            util.JsClick(BCExceptionRequestedYes);
            util.AssertIsTrue(BCExceptionRequestedYes);

            util.ClickElementAndSendText(BCExceptionReason, "testing exception request");
            //util.JsClick(BCExceptionStatusDropdown);

            try
            {
                util.JsClick(BCExceptionStatusPending);
            }
            catch
            {
                Debug.WriteLine("JsClick Pending failed, trying maybe click element?");
                //util.JsClick(BCExceptionStatusDropdown);
                util.ClickElement(BCExceptionStatusPending);
            }

            util.ClickElement(BCSaveBtn);
            util.Sleep(3000);

            util.JsClick(AgentSummaryTab);
            util.ValidateCheckmarkIsRed(CheckOrXBackgroundCheck);
        } //doesn't work

        public void SetBCToDeniedRequestException()
        {
            //set denied --> red X
            util.JsClick(BackgroundCheckTab);

            util.JsClick(BCPassedCriminalHistoryCheckYes);
            util.ClickElement(BCSaveBtn);
            util.Sleep(1000);

            util.JsClick(BCPassedCriminalHistoryCheckNo);
            util.AssertIsTrue(BCExceptionRequestedNo);
            util.JsClick(BCExceptionRequestedYes);
            util.AssertIsTrue(BCExceptionRequestedYes);

            util.ClickElementAndSendText(BCExceptionReason, "testing exception request");

            //do
            //{
            //    util.JsClick(BCExceptionStatusDropdown);
            //    util.JsClick(BCExceptionStatusDenied);
            //    util.JsGetAttribute(BCExceptionStatusDropdown); //gives the xpath               
            //    Debug.WriteLine(BCExceptionStatusDropdown);

            //    //util.AssertEqualByValue(BCExcep)
            //} while (BCExceptionStatusDropdown != BCExceptionStatusApproved || BCExceptionStatusDropdown != BCExceptionStatusPending);





            util.ClickElement(BCExceptionStatusDenied);




            Debug.WriteLine("trying code below");
            util.JsClick(BCExceptionStatusDropdown);
            util.ClickElement(BCExceptionStatusDenied);

            //util.JsClick(BCExceptionStatusDenied);



            // util.ClickElement(BCExceptionStatusDenied);


            util.ClickElement(BCSaveBtn);
            util.Sleep(3000);

            util.JsClick(AgentSummaryTab);
            util.ValidateCheckmarkIsRed(CheckOrXBackgroundCheck);
        } //doesn't work

        public void SetBCToApprovedRequestException()
        {
            //set denied --> red X
            util.JsClick(BackgroundCheckTab);

            util.JsClick(BCPassedCriminalHistoryCheckYes);
            util.ClickElement(BCSaveBtn);
            util.Sleep(1000);

            util.JsClick(BCPassedCriminalHistoryCheckNo);
            util.AssertIsTrue(BCExceptionRequestedNo);
            util.JsClick(BCExceptionRequestedYes);
            util.AssertIsTrue(BCExceptionRequestedYes);

            util.ClickElementAndSendText(BCExceptionReason, "testing exception request");
            //util.JsClick(BCExceptionStatusDropdown);

            try
            {
                util.JsClick(BCExceptionStatusApproved);
            }
            catch
            {
                Debug.WriteLine("entered SetBCToApproved catch block");
                util.ClickElement(BCExceptionStatusApproved);
            }

            util.JsClick(BCExceptionStatusDropdown);
            util.Sleep(1000);
            util.JsClick(BCExceptionStatusApproved);


            //util.JsClick(BCExceptionStatusPending);

            util.ClickElement(BCSaveBtn);
            util.Sleep(3000);

            util.JsClick(AgentSummaryTab);
            util.ValidateCheckmarkIsOrange(CheckOrXBackgroundCheck);
        } //doesn't work

        public void FillOutDrugTest()
        {
            //1. All elements are present            
            //2. Fill out and save drug test - confirm onboarding requirements fulfilled
            //3. New Grid Item Appears
            //4. Validate Onboarding requirements fulfilled through Exception Requested 


            //1. 
            util.JsClick(DrugTestTab);

            util.AssertIsTrue(DTNewDTBtn);
            util.AssertIsTrue(DTComments);
            util.AssertIsTrue(DTResultsDropDown);
            util.AssertIsTrue(DTResultUploadBtn);
            util.AssertIsTrue(DTResultUploadSecondBtn);
            util.AssertIsTrue(DTSaveBtn);

            //2.
            util.ClickElementAndSendText(DTComments, "test drug test");
            util.JsClick(DTResultsDropDown);
            util.JsClick(DTResultNegative);
            util.JsClick(DTResultUploadBtn);
            util.UploadDoc(DTResultUploadBtn);
            util.ClickElement(DTSaveBtn);

            util.JsClick(AgentSummaryTab);
            util.ValidateCheckmarkIsGreen(CheckOrXDrugTest);

            ;


            Debug.Write("--DRUG TEST ONBOARDING REQUIREMENTS PASSED--");


            SetDTToPendingRequestException();
            SetDTToDeniedRequestException();
            SetDTToApprovedRequestException();

            Debug.WriteLine("--REQUEST EXCEPTION DRUG TEST ONBOARDING REQUIREMENTS PASSED--");

        }

        public void SetDTToPendingRequestException()
        {
            //3. set to pending
            util.JsClick(DrugTestTab);
            util.JsClick(DTExceptionRequestedYes);
            util.ClickElementAndSendText(DTExceptionReason, "testing drug test request exception");
            util.JsClick(DTExceptionStatusDropDown);
            util.JsClick(DTExceptionStatusPending);
            util.JsClick(DTSaveBtn);

            util.JsClick(AgentSummaryTab);
            util.ValidateCheckmarkIsRed(CheckOrXDrugTest);
        } //doesn't work

        public void SetDTToDeniedRequestException()
        {
            //set request exception to denied
            util.JsClick(DrugTestTab);
            util.JsClick(DTExceptionStatusDropDown);
            util.ClickElement(DTExceptionStatusDenied);
            util.JsClick(DTSaveBtn);

            util.JsClick(AgentSummaryTab);
            util.ValidateCheckmarkIsRed(CheckOrXDrugTest);
        } //doesn't work

        public void SetDTToApprovedRequestException()
        {
            //set request exception to approved
            util.JsClick(DrugTestTab);
            util.JsClick(DTExceptionStatusDropDown);
            util.ClickElement(DTExceptionStatusApproved);
            util.JsClick(DTSaveBtn);

            util.JsClick(AgentSummaryTab);
            util.ValidateCheckmarkIsGreen(CheckOrXDrugTest);
        } //doesn't work

        public void FillOutDocumentation()
        {
            //1. Verify all text are present
            //2. Verify all permutations of buttons are fulfill or don't fulfill requirements - check against agent summary


            //1.
            util.JsClick(DocumentationTab);
            util.AssertIsTrue(DocRentionAndDocumentationTitle);
            util.AssertIsTrue(DocText1);
            util.AssertIsTrue(DocText2);
            util.AssertIsTrue(DocText3);
            util.AssertIsTrue(DocText4);
            util.AssertIsTrue(DocText5);
            util.AssertIsTrue(DocText6);
            util.AssertIsTrue(DocText7);
            util.AssertIsTrue(DocText8);
            util.AssertIsTrue(DocText9);
            util.AssertIsTrue(DocText10);
            util.AssertIsTrue(DocText11);
            util.AssertIsTrue(DocText12);
            util.AssertIsTrue(DocText13);
            util.AssertIsTrue(DocPerformanceAndEthicalStandardsTitle);

            util.AssertIsTrue(DocRententionAndDocumentationNo);
            util.AssertIsTrue(DocRetentionAndDocumentationYes);
            util.AssertIsTrue(DocPerformanceAndEthicalStandardsYes);
            util.AssertIsTrue(DocPerformanceAndEthicalStandardsNo);

            util.AssertEqualByClass("btn active btn-danger", DocRententionAndDocumentationNo);
            util.AssertEqualByClass("btn active btn-danger", DocPerformanceAndEthicalStandardsNo);

            util.JsClick(DocRetentionAndDocumentationYes);
            util.JsClick(AgentSummaryTab);
            util.ValidateCheckmarkIsRed(CheckOrXDocumentationUpload);
            util.JsClick(DocumentationTab);
            util.AssertEqualByClass("btn active btn-success", DocRetentionAndDocumentationYes); //Retention&Documentation is green
            util.JsClick(DocRententionAndDocumentationNo); //set it back to red

            util.JsClick(DocPerformanceAndEthicalStandardsYes);
            util.JsClick(AgentSummaryTab);
            util.ValidateCheckmarkIsRed(CheckOrXDocumentationUpload);
            util.JsClick(DocumentationTab);
            util.AssertEqualByClass("btn active btn-success", DocPerformanceAndEthicalStandardsYes); //Performance is green

            util.JsClick(DocRetentionAndDocumentationYes);
            util.JsClick(AgentSummaryTab);
            util.ValidateCheckmarkIsGreen(CheckOrXDocumentationUpload);

            Debug.WriteLine("--DOCUMENTATION ONBOARDING REQUIREMENTS PASSED--");





        }

        public void ContingentStartTheAgent()
        {
            util.JsClick(AgentSummaryTab);

            util.AssertIsTrue(ActivateBtn);


            util.ValidateCheckmarkIsRed(CheckOrXActivatedToSell);
            util.ValidateCheckmarkIsOrange(CheckOrXBackgroundCheck);
            util.ValidateCheckmarkIsGreen(CheckOrXDrugTest);
            util.ValidateCheckmarkIsGreen(CheckOrXDocumentationUpload);

            util.JsClick(ActivateBtn);
            util.Sleep(1000);

            GrabRepIDAndReOpenRep();

            util.ValidateCheckmarkIsGreen(CheckOrXActivatedToSell);
            util.ValidateCheckmarkIsOrange(CheckOrXBackgroundCheck);
            util.ValidateCheckmarkIsGreen(CheckOrXDrugTest);
            util.ValidateCheckmarkIsGreen(CheckOrXDocumentationUpload);

            Debug.WriteLine("--CONTINGENT AGENT CREATED SUCCESSFULLY--");
        }



        private static bool CheckFileDownloaded(string filename)
        {
            bool exist = false;
            string Path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            string[] filePaths = Directory.GetFiles(Path);
            foreach (string p in filePaths)
            {
                if (p.Contains(filename))
                {
                    FileInfo thisFile = new FileInfo(p);
                    //Check the file that are downloaded in the last 3 minutes
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                        exist = true;
                    File.Delete(p);
                    break;
                }
            }
            return exist;
        }

        public void DebugInputAgentID()
        {
            util.ClickElementAndSendText(LastNameFilterField, "41390290");
            util.JsClick(FindBtn);
            util.JsClick(PortalBtn);
            util.SwitchToFrame();
        }

        public void DebugClickNewBC()
        {
            //util.JsClick(BackgroundCheckTab);
            //util.ClickElement(BackgroundCheckTab);
            //try
            //{
            //    util.AssertIsTrue(BCIntroText);
            //}
            //catch
            //{
            //    util.JsClick(BackgroundCheckTab);
            //    util.ClickElement(BackgroundCheckTab);
            //}

            //SetBCToPendingRequestException();          
            //SetBCToDeniedRequestException();        
            //SetBCToApprovedRequestException();
            ;
            util.JsClick(DrugTestTab);
            util.ClickElement(DrugTestTab);
            try
            {
                util.AssertIsTrue(BCIntroText);
            }
            catch
            {
                util.JsClick(BackgroundCheckTab);
                util.ClickElement(BackgroundCheckTab);
            }

            util.ClickElement(DTNewDTBtn);

            FillOutDrugTest();
            SetDTToPendingRequestException();
            SetDTToDeniedRequestException();
            SetDTToApprovedRequestException();
        }

        public void DebugDrugTest()
        {
            util.JsClick(DrugTestTab);
            util.JsClick(DTResultsDropDown);
            util.JsClick(DTResultPositive);
        }

        

        public void NewClickCreateNewAgentButton()
        {
            //util.ClickElement(CreateNewAgentButton);

            try
            {
                string RepPageURL = driver.FindElement(By.LinkText("https://qawebcnst.ontlp.com/MVC/Representatives")).GetAttribute("href");
                util.AssertEqualStrings(RepPageURL, "https://qawebcnst.ontlp.com/MVC/Representatives");
                util.JsClick(CreateNewAgentBtn);
            }
            catch
            {
                driver.Navigate().GoToUrl("https://qawebcnst.ontlp.com/MVC/Representatives");
                util.IsElementVisible(CreateNewAgentBtn);
                util.JsClick(CreateNewAgentBtn);
            }

        }

    }
}