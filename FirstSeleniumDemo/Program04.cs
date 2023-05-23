using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using SeleniumExtras.WaitHelpers;

namespace FirstSeleniumDemo;

class Program04
{
    static void IFrameTest()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url = "https://demoselsite.azurewebsites.net/WebForm5.aspx";

        //Navigating to Iframe
        driver.SwitchTo().Frame("iframe_a");
        Thread.Sleep(2000);

        //Interacting with page in the Iframe 
        driver.FindElement(By.Name("txtName")).SendKeys("Malcolm");
        driver.FindElement(By.Name("btnSubmit")).Submit();

        //Navigating from Iframe to Web Page
        driver.SwitchTo().DefaultContent();

        Thread.Sleep(2000);

        driver.FindElement(By.LinkText("Go to Page 2")).Click();

        Thread.Sleep(4000);

        driver.Close();
    }

    static void WindowTest1()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url= "http://www.google.com";

        //Opening a new browser window
        //driver.SwitchTo().NewWindow(WindowType.Window);
        driver.SwitchTo().NewWindow(WindowType.Tab);

        driver.Navigate().GoToUrl("http://www.microsoft.com");

        Thread.Sleep(3000);

        driver.Quit();
    }
    
    static void ThreadWaitTest()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url ="https://demoselsite.azurewebsites.net/WebForm3.aspx";

        //Locating the Hyperlink 
        driver.FindElement(By.PartialLinkText("Click me")).Click();

        Thread.Sleep(12000);

        var result = driver.FindElement(By.Id("Label1")).Text;

        if(result.Contains("Selenium"))
            Console.WriteLine("Test Passed");
        else
            Console.WriteLine("Test Failed");

        driver.Quit();
    }

    static void ImplicitWaitTest()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url ="https://demoselsite.azurewebsites.net/WebForm3.aspx";

        //Applying Implicit Wait
        driver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(12);

        //Locating the Hyperlink 
        driver.FindElement(By.PartialLinkText("Click me")).Click();

        var result = driver.FindElement(By.Id("Label1")).Text;

        if(result.Contains("Selenium"))
            Console.WriteLine("Test Passed");
        else
            Console.WriteLine("Test Failed");

        driver.Quit();
    }

    static void ExplicitWaitTest()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url ="https://demoselsite.azurewebsites.net/WebForm3.aspx";

        //Applying Explicit Wait
        WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(15));
        Stopwatch watch= new Stopwatch();

        driver.FindElement(By.PartialLinkText("Click me")).Click();

        watch.Start();
        //Using Explict wait to check whether element is present or not 
        IWebElement label = wait.Until(d=>d.FindElement(By.Id("Label1")));
        //IWebElement label = wait.Until(ExpectedConditions.ElementExists(By.Id("Lable1")));

        watch.Stop();

        Console.WriteLine($"Execution Time = {watch.ElapsedMilliseconds} ms");

        if(label.Text.Contains("Selenium"))
            Console.WriteLine("Test Passed");
        else
            Console.WriteLine("Test Failed");

        driver.Quit();
    }

    static void FluentWaitTest()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url ="https://demoselsite.azurewebsites.net/WebForm3.aspx";

        DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        fluentWait.Timeout= TimeSpan.FromSeconds(15);
        fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);

        driver.FindElement(By.PartialLinkText("Click me")).Click();

        IWebElement label = fluentWait.Until(d=>d.FindElement(By.Id("Label1")));

        if(label.Text.Contains("Selenium"))
            Console.WriteLine("Test Passed");
        else
            Console.WriteLine("Test Failed");

        driver.Quit();
    }

    static void Main(string[] args)
    {
        //IFrameTest();
        //WindowTest1();
        //ThreadWaitTest();
        //ImplicitWaitTest();
        //ExplicitWaitTest();
        FluentWaitTest();
    }
}