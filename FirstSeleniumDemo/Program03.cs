using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FirstSeleniumDemo;

class Program03
{
    static void Main(string[] args)
    {
        RadioButtonTest("Java");
        RadioButtonTest("Python");
        RadioButtonTest("Scala");
    }

    static void RadioButtonTest(string language)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url="https://demoselsite.azurewebsites.net/WebForm4.aspx";

        //Locating radiobutton
        IList<IWebElement> elements = driver.FindElements(By.Name("RadioButtonList1"));

        foreach(IWebElement ele in elements)
        {
            if(ele.GetAttribute("value").Equals(language))
            {
                ele.Click();
                break;
            }
        }
        Thread.Sleep(3000);
        //verify result
        var result = driver.FindElement(By.Id("lblText")).Text;

        if(result.Contains(language))
        {
            Console.WriteLine("Test Passed");
        }
        else
        {
            Console.WriteLine("Test Failed");
        }

        driver.Close();
    }
}