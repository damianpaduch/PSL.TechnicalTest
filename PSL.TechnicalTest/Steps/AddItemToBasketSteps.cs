using PSL.TechnicalTest.PageObjectModel.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Linq;

namespace PSL.TechnicalTest.Steps
{

    [Binding]
    public sealed class AddItemToBasketSteps
    {
        //making reference to our page object model and getting different web elements in to use in test steps. Creating Iwebdriver
        private IWebDriver driver;
        HomePage homePage;
        SearchProductPage searchProductPage;
      

        public AddItemToBasketSteps(IWebDriver driver)
        {
            this.driver = driver;           
        }

        [Given(@"I am on the Amazon Home Page")]
        public void GivenIAmOnTheAmazonHomePage()
        {
            // If we set object reference to the instant of an object
            homePage = new HomePage(driver);           
            homePage.AcceptCookies.Click();

           //storing the current url and home url in a string and comparing them to validate the home page is successfully opened
           string currentUrl = driver.Url;
           string HomeUrl = "https://www.amazon.co.uk/";
           Assert.AreEqual(currentUrl, HomeUrl);
           
        }

        [Given(@"I search for an item")]
        public void GivenISearchForAnItem()
        {
            // If we set object reference to the instant of an object
            searchProductPage = new SearchProductPage(driver);

            homePage.SearchBar.SendKeys("Cat Food");
            homePage.SearchButton.Click();
            //Adding a wait web driver to allow us to wait for the page to open
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(searchProductPage.CatFoodItem));
            searchProductPage.CatFoodItem.Click();
        }

        [When(@"I select add to basket")]
        public void WhenISelectAddToBasket()
        {
            // If we set object reference to the instant of an object
            searchProductPage = new SearchProductPage(driver);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(searchProductPage.AddToBasket));
            searchProductPage.AddToBasket.Click();
        }

        [Then(@"Item is successully added to the basket")]
        public void ThenItemIsSuccessullyAddedToTheBasket()
        {
            //validate the item added to basket message is displayed to the user
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("NATC_SMART_WAGON_CONF_MSG_SUCCESS")));

        }
    }
}
