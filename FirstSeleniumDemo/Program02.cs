using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace FirstSeleniumDemo;

class Program02
{
    static void Main(string[] args)
    {
        //SumTest();
        //MultiplyTest();
        //DivideTest();
        //DivideAlertTest();
        //LocatorTest1();
        LocatorTest2();
    }

    static void SumTest()
    {
        //Initialize WebDriver 
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url="https://demoselsite.azurewebsites.net/WebForm1.aspx";

        //Locating Element by Id and Name 
        IWebElement num1 = driver.FindElement(By.Id("txtno1"));
        IWebElement num2 = driver.FindElement(By.Id("txtno2"));
        IWebElement select = driver.FindElement(By.Name("cmbop"));
        IWebElement button = driver.FindElement(By.Id("btnsrcvcalc"));

        //Converting IWebElement to SelectElement
        SelectElement op=new SelectElement(select);

        //Perform Action
        num1.SendKeys("10");
        num2.SendKeys("20");
        op.SelectByText("Add");
        button.Click();

        Thread.Sleep(3000);

        //Verify the result
        IWebElement result = driver.FindElement(By.Id("lblres"));
        if(result.Text.Equals("30"))
        {
            Console.WriteLine("Test Passed");
        }
        else
        {
            Console.WriteLine("Test Failed");
        }

        driver.Close();
    }

    static void MultiplyTest()
    {
        //Initialize WebDriver 
        IWebDriver driver = new FirefoxDriver();
        driver.Manage().Window.Maximize();
        driver.Url="https://demoselsite.azurewebsites.net/WebForm1.aspx";

        //Locating Element by using css selector 
        IWebElement num1 = driver.FindElement(By.CssSelector("input#txtno1"));
        IWebElement num2 = driver.FindElement(By.CssSelector("input#txtno2"));
        SelectElement oper= new SelectElement(driver.FindElement(By.CssSelector("select#cmbop")));
        IWebElement button= driver.FindElement(By.CssSelector("input#btnsrcvcalc"));

        //Performing Action
        num1.SendKeys("100");
        num2.SendKeys("2");
        oper.SelectByValue("Multiply");
        button.Click();

        //Verify result 
        var result = driver.FindElement(By.CssSelector("span#lblres")).Text;

        if(result.Equals("200"))
        {
            Console.WriteLine("Test Passed");
        }
        else
        {
            Console.WriteLine("Test Failed");
        }
        
        driver.Close();
    }

    static void DivideTest()
    {
        //Initialize WebDriver 
        IWebDriver driver = new EdgeDriver();
        driver.Manage().Window.Maximize();
        driver.Url="https://demoselsite.azurewebsites.net/WebForm1.aspx";

        //Locate element based on xpath
        driver.FindElement(By.XPath("//input[@id='txtno1']")).SendKeys("100");
        driver.FindElement(By.XPath("//input[@id='txtno2']")).SendKeys("2");
        new SelectElement(driver.FindElement(By.XPath("//select[@id='cmbop']")))
        .SelectByIndex(2);
        driver.FindElement(By.XPath("//input[@id='btnsrcvcalc']")).Click();

        //Verify the result
        var result = driver.FindElement(By.XPath("//span[@id='lblres']")).Text;

        if(result.Equals("50"))
            Console.WriteLine("Test Passed");
        else
            Console.WriteLine("Test Failed");

        driver.Close();
    }

    static void DivideAlertTest()
    {
        IWebDriver driver = new EdgeDriver();
        driver.Manage().Window.Maximize();
        driver.Url="https://demoselsite.azurewebsites.net/WebForm1.aspx";

        //Locate element based on xpath
        driver.FindElement(By.XPath("//input[@id='txtno1']")).SendKeys("100");
        driver.FindElement(By.XPath("//input[@id='txtno2']")).SendKeys("0");
        new SelectElement(driver.FindElement(By.XPath("//select[@id='cmbop']")))
        .SelectByIndex(2);
        driver.FindElement(By.XPath("//input[@id='btncalc']")).Click();

        // try
        // {
        //     Thread.Sleep(3000);
        //     driver.SwitchTo().Alert().Dismiss();
        //     Console.WriteLine("Test Passed");
        // }
        // catch(Exception ex)
        // {
        //     Console.WriteLine("Test Failed");
        // }

        IAlert alert =driver.SwitchTo().Alert();

        Thread.Sleep(2000);

        if(alert.Text.Contains("divide by zero"))
        {
            Console.WriteLine("Test Passed");
        }
        else
        {
            Console.WriteLine("Test Failed");
        }

        alert.Accept();

        Thread.Sleep(2000);

        driver.Close();
    }

    static void LocatorTest1()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url="https://localhost:44362/WebForm1.aspx";

        //using tagname
        IList<IWebElement> elements= driver.FindElements(By.TagName("p"));

        foreach (var ele in elements)
        {
            Console.WriteLine(ele.Text);
        }

        driver.Close();
    }

    static void LocatorTest2()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url="https://localhost:44362/WebForm1.aspx";

        //using tagname
        IList<IWebElement> elements= driver.FindElements(By.CssSelector("p.myclass"));

        foreach (var ele in elements)
        {
            Console.WriteLine(ele.Text);
        }

        driver.Close();
    }
}