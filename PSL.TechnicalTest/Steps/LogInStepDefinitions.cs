using PSL.TechnicalTest.PageObjectModel.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow.Assist;

namespace PSL.TechnicalTest.Steps
{
    [Binding]
    public class LogInStepDefinitions
    {
        private IWebDriver driver;
        HomePage homePage;
        LogInPage logInPage;

        public LogInStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I am On Auction Page")]
        public void GivenIAmOnAuctionPage()
        {
            // If we set object reference to the instant of an object
            homePage = new HomePage(driver);
            homePage.AcceptCookies.Click();

            //storing the current url and home url in a string and comparing them to validate the home page is successfully opened
            string currentUrl = driver.Url;
            string HomeUrl = "https://www.amazon.co.uk/";
            Assert.AreEqual(currentUrl, HomeUrl);
        }

        [Given(@"I Slect Log In")]
        public void GivenISlectLogIn()
        {
            // If we set object reference to the instant of an object
            homePage = new HomePage(driver);
            logInPage = new LogInPage(driver);

            homePage.GoToLogIn.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(logInPage.EmailLogInButton));

        }

        [Given(@"I Enter Incorrect LogIn Details")]
        public void GivenIEnterIncorrectLogInDetails(Table table)
        {
            logInPage = new LogInPage(driver);

            //creating dynamic instance of the data.email value we have in our feature file
            dynamic data = table.CreateDynamicInstance();
            logInPage.Login((string)data.Email);

            logInPage.EmailLogInButton.Click();

            logInPage.Login2((string)data.Password);

        }

        [When(@"I Select Submit")]
        public void WhenISelectSubmit()
        {
            logInPage = new LogInPage(driver);

            logInPage.PasswordLoginSubmit.Click();
        }

        [Then(@"An Error Is Displayed")]
        public void ThenAnErrorIsDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("auth-error-message-box")));
        }
    }
}
