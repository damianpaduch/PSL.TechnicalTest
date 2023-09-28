using BoDi;
using OpenQA.Selenium.Chrome;

using TechTalk.SpecFlow;

namespace PSL.TechnicalTest.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _container;
        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            //Creating a hook to enter amazon page as an inital action before any steps from the feature files
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.amazon.co.uk";
            driver.Manage().Window.Maximize();

            _container.RegisterInstanceAs<IWebDriver>(driver);
          
        }

        [AfterScenario]
        public void AfterScenario(IWebDriver driver)
        {
            //adding a post scenario hook to quit driver and allow a fres test run in the future
            driver.Quit();
        }
    }
}