using System;
using OpenQA.Selenium;

namespace SeleniumPOMDemo.PageModels;

public class SamplePage
{
    IWebDriver driver;

    //Using Constructor to inject the IWebDriver object 
    public SamplePage(IWebDriver driver)
    {
        this.driver=driver;
    }

    //Locating Element 
    private IWebElement NameTextBox => driver.FindElement(By.Name("txtName"));
    private IWebElement Button => driver.FindElement(By.XPath("//input[@id='btnSubmit']"));

    //Performing Action for Page
    public void SubmitData(string name)
    {
        NameTextBox.SendKeys(name);
        Button.Click();
    }

    //Verifying the Result
    public bool VerifyResult(string message)
    {
        var result = driver.FindElement(By.Id("lblMessage")).Text;

        if(result.Contains(message))
            return true;
        else
            return false;
    }
}