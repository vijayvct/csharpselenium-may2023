using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace FirstSeleniumDemo;

class Program05
{
    static void Main(string[] args)
    {
        //SingleClickTest();
        //DoubleClickTest();
        //DragandDropTest();
        //ClickandHoldTest();
        KeyUpandKeyDownTest();
    }

    static void SingleClickTest()
    {
        IWebDriver driver=new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url="http://www.uitestpractice.com/Students/Actions";

        Actions actions = new Actions(driver);

        // actions.MoveToElement(driver.FindElement(By.Name("click")))
        //     .Click()
        //     .Build()
        //     .Perform();

        actions.Click(driver.FindElement(By.Name("click"))).Build().Perform();

        Thread.Sleep(3000);

        driver.SwitchTo().Alert().Dismiss();

        driver.Quit();
    }

    static void DoubleClickTest()
    {
        IWebDriver driver=new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url="http://www.uitestpractice.com/Students/Actions";

        Actions actions = new Actions(driver);

        actions.DoubleClick(driver.FindElement(By.Name("dblClick"))).Build().Perform();

        Thread.Sleep(3000);

        driver.SwitchTo().Alert().Dismiss();

        driver.Quit();
    }

    static void DragandDropTest()
    {
        IWebDriver driver=new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url="http://www.uitestpractice.com/Students/Actions";

        Actions actions = new Actions(driver);

        actions.DragAndDrop(driver.FindElement(By.Id("draggable")),
        driver.FindElement(By.Id("droppable"))).Build().Perform();

        Thread.Sleep(2000);

        driver.Quit();
    }

    static void ClickandHoldTest()
    {
        IWebDriver driver=new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url="http://www.uitestpractice.com/Students/Actions";

        Actions actions = new Actions(driver);

        actions.ClickAndHold(driver.FindElement(By.Name("one")))
            .MoveToElement(driver.FindElement(By.Name("eleven")))
            .Release().Build().Perform();

        Thread.Sleep(2000);

        driver.Quit();
    }

    static void KeyUpandKeyDownTest()
    {
        IWebDriver driver=new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url="http://www.uitestpractice.com/Students/Actions";

        Actions actions = new Actions(driver);

        actions.KeyDown(Keys.Control)
            .Click(driver.FindElement(By.Name("one")))
            .Click(driver.FindElement(By.Name("six")))
            .Click(driver.FindElement(By.Name("ten")))
            .Build().Perform();

        Thread.Sleep(2000);

        driver.Quit();
    }
}