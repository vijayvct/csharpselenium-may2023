using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using SeleniumPOMPageObjects.PageModels;

namespace SeleniumPOMPageObjects.PageTests;

public class CalculatorPageTests
{
    IWebDriver driver;

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        driver.Quit();
    }

    [SetUp]
    public void InitalizeBrowser()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url="https://demoselsite.azurewebsites.net/WebForm1.aspx";
    }

    [TearDown]
    public void CloseBrowser()
    {
        driver.Close();
    }   

    [TestCase("10","20","Add","30")]
    [TestCase("100","2","Multiply","200")]
    [TestCase("300","3","Divide","100")]
    [TestCase("300","-100","Divide","-3")]
    [TestCase("-20","40","Add","-20")]
    public void CalcTest(string n1,string n2,string op,string expvalue)
    {
        CalculatorPage page = new CalculatorPage(driver);

        page.PerformCalculation(n1,n2,op);

        Assert.IsTrue(page.VerifyResult(expvalue));
    }
}