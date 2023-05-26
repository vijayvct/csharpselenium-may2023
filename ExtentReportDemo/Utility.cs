namespace ExtentReportDemo;

public class Utility
{
    public static string CaputerScreen(IWebDriver driver,string filename)
    {
        ITakesScreenshot screenshot= (ITakesScreenshot) driver;

        Screenshot ss = screenshot.GetScreenshot();

        string path = filename+DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
        string filepath = @"C:\Demos\SeleniumDemos-May2023\Reports\"+path+".png";

        ss.SaveAsFile(filepath);

        return filepath;
    }
}