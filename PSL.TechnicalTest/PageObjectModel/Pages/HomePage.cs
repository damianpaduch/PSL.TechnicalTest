using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.TechnicalTest.PageObjectModel.Pages
{
    public class HomePage
    {
        public IWebDriver WebDriver { get; }

        public HomePage(IWebDriver webDriver) 
        {
            WebDriver = webDriver;
        }

        //Adding Our UI Elements
        public IWebElement AcceptCookies => WebDriver.FindElement(By.Id("sp-cc-accept"));
        public IWebElement SearchBar => WebDriver.FindElement(By.Id("twotabsearchtextbox"));
        public IWebElement SearchButton => WebDriver.FindElement(By.Id("nav-search-submit-button"));

        public IWebElement GoToLogIn => WebDriver.FindElement(By.Id("nav-link-accountList"));

    }
}
