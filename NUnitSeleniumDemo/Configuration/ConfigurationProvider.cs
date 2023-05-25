using Microsoft.Extensions.Configuration;

namespace NUnitSeleniumDemo;

public class ConfigurationProvider
{
    private static ConfigurationManager configuration;

    public static ConfigurationManager Configuration
    {
        get
        {
            if(configuration==null)
            {
                configuration= new ConfigurationManager();

                configuration.AddJsonFile("../appsettings.local.json",optional:true,false);
            }

            return configuration;
        }
    }
}