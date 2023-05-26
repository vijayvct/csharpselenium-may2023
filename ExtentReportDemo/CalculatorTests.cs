using NUnit.Framework.Interfaces;

namespace ExtentReportDemo;

public class CalculatorTests
{
    IWebDriver driver;
    ExtentV3HtmlReporter htmlReporter;
    ExtentReports reports;
    ExtentTest test;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        //Initializing the report 
        var filename = this.GetType().ToString()+"-"+DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss")+".html";
        htmlReporter = 
        new ExtentV3HtmlReporter(@"C:\Demos\SeleniumDemos-May2023\Reports\"+filename);

        reports= new ExtentReports();
        reports.AttachReporter(htmlReporter);
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        driver.Quit();
        reports.Flush();
    }

    [SetUp]
    public void InitializeBrowser()
    {
        driver = new ChromeDriver();

        test = reports.CreateTest(TestContext.CurrentContext.Test.Name);

        driver.Manage().Window.Maximize();

        driver.Url="https://demoselsite.azurewebsites.net/WebForm1.aspx";

        test.Log(Status.Info,"Test Started");
    }

    [TearDown]
    public void CloseBrowser()
    {

        var status = TestContext.CurrentContext.Result.Outcome.Status;
        var stackTrace =  "<pre>"+TestContext.CurrentContext.Result.StackTrace+"</pre>";
        var errorMessage = TestContext.CurrentContext.Result.Message;

        if(status == TestStatus.Failed)
        {
            string screenshot = Utility.CaputerScreen(driver,"ErrorScreenShot");
            test.Log(Status.Fail,stackTrace + errorMessage);
            test.Log(Status.Fail,"Snapshot "+test.AddScreenCaptureFromPath(screenshot));
        }

        driver.Close();
        test.Log(Status.Info,"Test Completed");
    }

    [TestCase("10","2","Multiply","20")]
    [TestCase("20","30","Add","50")]
    [TestCase("20","-40","Add","-20")]
    [TestCase("200","2","Divide","100")]
    [TestCase("20","-40","Add","20")]
    [TestCase("200","2","Divide","-100")]
    public void ArithematicTest(string n1,string n2,string op,string expvalue)
    {
        driver.FindElement(By.Id("txtno1")).SendKeys(n1);
        test.Pass("Located first textbox and entered a number into it");

        driver.FindElement(By.Id("txtno2")).SendKeys(n2);
        test.Pass("Located second textbox and enetered a number into it");

        new SelectElement(driver.FindElement(By.Id("cmbop"))).SelectByValue(op);
        test.Pass("Located dropdown list and selected the required operation");

        driver.FindElement(By.Id("btnsrcvcalc")).Click();
        test.Pass("Located button and performed click operation");

        var result = driver.FindElement(By.Id("lblres")).Text;

        Utility.CaputerScreen(driver,op +"Test");

        Assert.AreEqual(expvalue,result);
        test.Info("Verifying the result");
    }
}