using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SeleniumPOMPageObjects.PageModels;

public class CalculatorPage
{
    IWebDriver driver;

    //Initializing the IWebDriver Object
    public CalculatorPage(IWebDriver driver)
    {
        this.driver= driver;
        PageFactory.InitElements(driver,this);      
    }

    //Locating All the elements
    [FindsBy(How=How.Id,Using = "txtno1")]
    private IWebElement FirstTextBox;

    [FindsBy(How=How.Id,Using = "txtno2")]
    private IWebElement SecondTextBox;

    [FindsBy(How = How.Id,Using = "cmbop")]
    private IWebElement select;

    [FindsBy(How= How.XPath,Using ="//input[@id='btnsrcvcalc']")]
    private IWebElement Button;

    //Performing the action
    public void PerformCalculation(string n1,string n2,string op)
    {
        FirstTextBox.SendKeys(n1);
        SecondTextBox.SendKeys(n2);
        new SelectElement(select).SelectByValue(op);
        Button.Click();
    }

    //Verifying results
    public bool VerifyResult(string expvalue)
    {
        var result = driver.FindElement(By.Id("lblres")).Text;

        if(result.Equals(expvalue))
            return true;
        else
            return false;
    }
}