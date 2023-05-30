using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using SeleniumPOMDemo.PageModels;

namespace SeleniumPOMDemo.PageTests;

public class SamplePageTests
{
    [TestCase("Malcolm","Welcome")]
    [TestCase("James","Welcome")]
    [TestCase("","Invalid")]
    [TestCase("Vijay","Invalid")]
    public void MessageTest(string name,string message)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url="https://demoselsite.azurewebsites.net/Default.aspx";

        SamplePage page = new SamplePage(driver);

        page.SubmitData(name);

        Assert.IsTrue(page.VerifyResult(message));

        driver.Quit();        
    }
}