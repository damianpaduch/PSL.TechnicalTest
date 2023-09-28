using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.TechnicalTest.PageObjectModel.Pages
{
    public  class AddedToBasketPage
    {
        public IWebDriver WebDriver { get; }

        public AddedToBasketPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        //Adding Our UI Elements
        public IWebElement AddToBasketSuccess => WebDriver.FindElement(By.Id("NATC_SMART_WAGON_CONF_MSG_SUCCESS"));
        
    }
}
