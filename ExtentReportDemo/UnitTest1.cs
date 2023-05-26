namespace ExtentReportDemo;

public class Tests
{
    [Test]
    public void GoogleSearchTest()
    {
        //Creating ExtentHTMLReportes Instance 
        ExtentV3HtmlReporter htmlReporter = 
            new ExtentV3HtmlReporter(@"C:\Demos\SeleniumDemos-May2023\Reports\GoogleSerach.html");

        //Creating ExtentReport Object 
        ExtentReports extentReports= new ExtentReports();

        //Attaching the Reporter Object to report object 
        extentReports.AttachReporter(htmlReporter);

        //Creating Extent Test
        ExtentTest test = extentReports.CreateTest("Google Search Test",
            "This is a Simple test to perform google search");

        //Logging Message in test
        test.Log(Status.Info,"Test Started");

        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Url ="http://www.google.com";

        test.Pass("Navigated to Google.com");

        var element = driver.FindElement(By.Name("q"));
        test.Pass("Search textbox element found");

        element.SendKeys("Selenium WebDriver");
        test.Pass("Search Text Entered");

        element.Submit();
        test.Pass("Search Performed");

        driver.Close();
        test.Info("Browser Closed");

        test.Info("Test Completed");

        //Write the report file to disk 
        extentReports.Flush();
    }
}