using System.Configuration;

namespace Timesheets.AcceptanceTests.Common
{
    public static class ConfigSettings
    {
        static ConfigSettings()
        {
            UseRemoteServer = bool.Parse(ConfigurationManager.AppSettings["UseSeleniumServer"]);
        }

        public static bool UseRemoteServer { get; private set; }
    }
}
