namespace NUnitSeleniumDemo;

public class BaseTests
{
    protected IWebDriver driver;
    protected IWebElement Num1,Num2,Button,Result;
    protected SelectElement Select;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        TestContext.Progress.WriteLine("OneTimeSetup Executed");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        driver.Quit();
        TestContext.Progress.WriteLine("OneTimeTearDown Executed");
    }

    [SetUp]
    public void SetUp()
    {
        driver= CreateDriver(ConfigurationProvider.Configuration["browser"]);
        driver.Manage().Window.Maximize();
        driver.Url="https://demoselsite.azurewebsites.net/WebForm1.aspx";

        //Locating Elements
        Num1= driver.FindElement(By.Id("txtno1"));
        Num2=driver.FindElement(By.Id("txtno2"));
        Select = new SelectElement(driver.FindElement(By.Id("cmbop")));
        Button = driver.FindElement(By.Id("btnsrcvcalc"));

        TestContext.Progress.WriteLine("Setup Executed");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Close();
        TestContext.Progress.WriteLine("TearDown Executed");
    }

    private IWebDriver CreateDriver(string browserName)
    {
        switch(browserName.ToLowerInvariant())
        {
            case "chrome":
                return new ChromeDriver();
            
            case "firefox":
                return new FirefoxDriver();

            case "edge":
                return new EdgeDriver();

            default:
                throw new Exception("Provide browser is not supported");
        }
    }
}