namespace NUnitSeleniumDemo;

public class NewCalculatorTests: BaseTests
{

    [Test]
    [Order(1)]
    public void AddTest()
    {
        Num1.SendKeys("10");
        Num2.SendKeys("20");
        Select.SelectByValue("Add");
        Button.Click();

        Result = driver.FindElement(By.Id("lblres"));

        Assert.AreEqual("30",Result.Text);

        TestContext.Progress.WriteLine("Add Test Executed");

    }

    [Test]
    [Order(2)]
    public void ProducTest()
    {
        Num1.SendKeys("100");
        Num2.SendKeys("2");
        Select.SelectByValue("Multiply");
        Button.Click();

        Result = driver.FindElement(By.Id("lblres"));

        Assert.AreEqual("200",Result.Text);

        TestContext.Progress.WriteLine("Product Test Executed");
    }

    [Test]
    [Order(3)]
    public void DivideTest()
    {
        Num1.SendKeys("10");
        Num2.SendKeys("2");
        Select.SelectByValue("Divide");
        Button.Click();

        Result = driver.FindElement(By.Id("lblres"));

        Assert.AreEqual("5",Result.Text);
        
        TestContext.Progress.WriteLine("Divide Test Executed");

    }
}