using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.TechnicalTest.PageObjectModel.Pages
{
    public class LogInPage
    {
        public IWebDriver WebDriver { get; }

        public LogInPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        //Adding Our UI Elements
        public IWebElement EmailLogInField => WebDriver.FindElement(By.Id("ap_email"));
        public IWebElement EmailLogInButton => WebDriver.FindElement(By.Id("continue"));

        public IWebElement PasswordLoginField => WebDriver.FindElement(By.Id("ap_password"));
        public IWebElement PasswordLoginSubmit => WebDriver.FindElement(By.Id("signInSubmit"));


        internal void Login(string Email)
        {
            EmailLogInField.SendKeys(Email);
        }

        internal void Login2(string Password)
        {
            PasswordLoginField.SendKeys(Password);
        }
    }
}
