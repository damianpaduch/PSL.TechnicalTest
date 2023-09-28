using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.TechnicalTest.PageObjectModel.Pages
{
    public class SearchProductPage
    {
        public IWebDriver WebDriver { get; }

        public SearchProductPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        //Adding Our UI Elements
        public IWebElement CatFoodItem => WebDriver.FindElement(By.LinkText("Amazon Brand - Lifelong Cat Food, Paté with Salmon, 100g, Pack of 16"));
        public IWebElement AddToBasket => WebDriver.FindElement(By.Id("add-to-cart-button"));

    }
}
