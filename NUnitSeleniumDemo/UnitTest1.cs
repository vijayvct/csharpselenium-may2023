namespace NUnitSeleniumDemo;

public class Tests
{
    [Test]
    public void GoogleSearchTest()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url="http://www.google.com";

        IWebElement searchTextBox = driver.FindElement(By.Name("q"));

        searchTextBox.SendKeys("Selenium");
        searchTextBox.Submit();

        Thread.Sleep(3000);

        driver.Quit();
    }

    [Test]
    public void MessageTest()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url="https://demoselsite.azurewebsites.net/Default.aspx";

        driver.FindElement(By.Id("txtName")).SendKeys("James");
        driver.FindElement(By.Id("btnSubmit")).Click();

        var result= driver.FindElement(By.Id("lblMessage")).Text;

        driver.Quit();
        Assert.IsTrue(result.Contains("Welcome"));
    }
}