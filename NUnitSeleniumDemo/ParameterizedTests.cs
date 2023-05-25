namespace NUnitSeleniumDemo;

public class ParameterizedTests : BaseTests
{
    [TestCase("10","20","30")]
    [TestCase("-100","70","-30")]
    [TestCase("8","780","788")]
    [TestCase("20","80","-100")]
    [Category("InternalDataTest")]
    public void AddTest(string n1,string n2,string expvalue)
    {
        Num1.SendKeys(n1);
        Num2.SendKeys(n2);
        Select.SelectByValue("Add");
        Button.Click();

        Result = driver.FindElement(By.Id("lblres"));

        Assert.AreEqual(expvalue,Result.Text);
    }

    [TestCase("10","20","Add","30")]
    [TestCase("25","5","Divide","5")]
    [TestCase("-25","5","Multiply","-125")]
    [Category("InternalDataTest")]
    public void CalcTest(string n1,string n2,string op,string expvalue)
    {
        Num1.SendKeys(n1);
        Num2.SendKeys(n2);
        Select.SelectByValue(op);
        Button.Click();

        Result = driver.FindElement(By.Id("lblres"));

        Assert.AreEqual(expvalue,Result.Text);
    }

    [TestCaseSource(typeof(TestSource),"ProductTestData")]
    [Category("InternalDataTest")]
    public void ProductTest(string n1,string n2,string expvalue)
    {
        Num1.SendKeys(n1);
        Num2.SendKeys(n2);
        Select.SelectByValue("Multiply");
        Button.Click();

        Result = driver.FindElement(By.Id("lblres"));

        Assert.AreEqual(expvalue,Result.Text);
    }

    [TestCaseSource(typeof(TestSource),"DivideTestData")]
    [Category("ExternalDataTest")]
    public void DivideTest(string n1,string n2,string expvalue)
    {
        Num1.SendKeys(n1);
        Num2.SendKeys(n2);
        Select.SelectByValue("Divide");
        Button.Click();

        Result = driver.FindElement(By.Id("lblres"));

        Assert.AreEqual(expvalue,Result.Text);
    }

    [TestCaseSource(typeof(TestSource),"ExcelTestData")]
    [Category("ExternalDataTest")]
    public void CalcTest_Excel(string n1,string n2,string op,string expvalue)
    {
        Num1.SendKeys(n1);
        Num2.SendKeys(n2);
        Select.SelectByValue(op);
        Button.Click();

        Result = driver.FindElement(By.Id("lblres"));

        Assert.AreEqual(expvalue,Result.Text);
    }

}