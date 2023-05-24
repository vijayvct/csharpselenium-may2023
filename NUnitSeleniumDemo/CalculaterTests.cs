namespace NUnitSeleniumDemo;

[TestFixture]
public class CalculatorTests
{
    [Test]
    public void AddTest()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url="https://demoselsite.azurewebsites.net/WebForm1.aspx";

        driver.FindElement(By.Id("txtno1")).SendKeys("40");
        driver.FindElement(By.Id("txtno2")).SendKeys("-80");
        new SelectElement(driver.FindElement(By.Id("cmbop"))).SelectByText("Add");
        driver.FindElement(By.Id("btnsrcvcalc")).Click();

        var result = driver.FindElement(By.Id("lblres")).Text;

        Assert.AreEqual("-40",result);

        driver.Quit();
    }

     [Test]
    public void MultiplyTest()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url="https://demoselsite.azurewebsites.net/WebForm1.aspx";

        driver.FindElement(By.Id("txtno1")).SendKeys("100");
        driver.FindElement(By.Id("txtno2")).SendKeys("2");
        new SelectElement(driver.FindElement(By.Id("cmbop"))).SelectByText("Multiply");
        driver.FindElement(By.Id("btnsrcvcalc")).Click();

        var result = driver.FindElement(By.Id("lblres")).Text;

        Assert.AreEqual("200",result);

        driver.Quit();
    }

     [Test]
    public void DivideTest()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url="https://demoselsite.azurewebsites.net/WebForm1.aspx";

        driver.FindElement(By.Id("txtno1")).SendKeys("40");
        driver.FindElement(By.Id("txtno2")).SendKeys("-8");
        new SelectElement(driver.FindElement(By.Id("cmbop"))).SelectByText("Divide");
        driver.FindElement(By.Id("btnsrcvcalc")).Click();

        var result = driver.FindElement(By.Id("lblres")).Text;

        Assert.AreEqual("5",result);

        driver.Quit();
    }
}