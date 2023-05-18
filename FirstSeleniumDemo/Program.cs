using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FirstSeleniumDemo;
class Program
{
    static void Main(string[] args)
    {
        //Creating an Instance of IWebDriver 
        IWebDriver driver = new ChromeDriver();

        //Navigate to Google.com
        driver.Manage().Window.Maximize();
        driver.Url="http://www.google.com";

        //Locate Search Text Box 
        IWebElement searchTextBox = driver.FindElement(By.Name("q"));

        //Entering Search Text 
        searchTextBox.SendKeys("Citiustech");

        //Perform Search 
        searchTextBox.Submit();

        Thread.Sleep(5000);

        //Close Browser
        driver.Quit();
    }
}
