
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FirstSeleniumDemo;

class Program01
{
    static void Main(string[] args)
    {
        ValidMessageTest("Malcolm");
        ValidMessageTest("");
    }

    static void ValidMessageTest(string name)
    {
        //Arrange 
        //Creating instance of IWebDriver 
        IWebDriver driver = new ChromeDriver();

        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://demoselsite.azurewebsites.net/");

        //Locating Element 
        IWebElement NameTextBox = driver.FindElement(By.Id("txtName"));
        IWebElement Button = driver.FindElement(By.Id("btnSubmit"));

        //Act 
        NameTextBox.SendKeys(name);
        Button.Submit();

        Thread.Sleep(5000);

        //Assert
        //Verify the result 
        IWebElement resultLabel = driver.FindElement(By.Id("lblMessage"));

        if(resultLabel.Text.Contains("Welcome"))
        {
            Console.ForegroundColor=ConsoleColor.Green;
            Console.WriteLine("Test Passed");
        }
        else
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("Test Failed");
        }

        driver.Close();
    }
}