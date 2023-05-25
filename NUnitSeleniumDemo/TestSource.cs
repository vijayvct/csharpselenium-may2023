namespace NUnitSeleniumDemo;

public class TestSource
{
    public static IEnumerable<TestCaseData> ProductTestData
    {
        get
        {
            yield return new TestCaseData("10","2","20");
            yield return new TestCaseData("200","-40","8000");
            yield return new TestCaseData("-500","2","-1000");
            yield return new TestCaseData("256","-2","-512");
            yield return new TestCaseData("-25","-4","100");
        }
    }

    public static IEnumerable<TestCaseData> DivideTestData
    {
        get
        {
            StreamReader reader = 
                new StreamReader(@"C:\Demos\SeleniumDemos-May2023\DivideTestData.txt");

            string line;
            TestCaseData td;

            while((line=reader.ReadLine())!=null)
            {
                string [] data= line.Split(',');

                td = new TestCaseData(data[0],data[1],data[2]);

                yield return td;
            }
        }
    }

    public static IEnumerable<TestCaseData> ExcelTestData()
    {
        ExcelPackage package = 
            new ExcelPackage(new FileInfo(@"C:\Demos\SeleniumDemos-May2023\calcdata.xlsx"));

        ExcelWorksheet worksheet= package.Workbook.Worksheets["Sheet1"];
        int rowcount = worksheet.Dimension.End.Row;
        
        TestCaseData td;    
        List<TestCaseData> list = new List<TestCaseData>();

        for(int i=1;i<=rowcount;i++)
        {
            string data1= worksheet.Cells[i,1].Value.ToString();
            string data2= worksheet.Cells[i,2].Value.ToString();
            string data3= worksheet.Cells[i,3].Value.ToString();
            string data4= worksheet.Cells[i,4].Value.ToString();

            td= new TestCaseData(data1,data2,data3,data4);
            list.Add(td);
        }

        return list;
    }
}