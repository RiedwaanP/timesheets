using System;
using System.Linq;
using FluentAutomation;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Timesheets.AcceptanceTests.Common;

namespace Timesheets.AcceptanceTests
{
    public class StepDefinitionBase : FluentTest
    {
        protected string AdminUrl;
        protected string StandardBankTenantUrl;
        protected string LibertyTenantUrl;

        protected IWebDriver WebDriver { get { return (IWebDriver)this.Provider; } }


        public StepDefinitionBase()
        {
            Configure();

            if (ConfigSettings.UseRemoteServer)
            {
                SeleniumWebDriver.Bootstrap(new Uri("http://localhost:4444/wd/hub"),
                            SeleniumWebDriver.Browser.Chrome,
                            TimeSpan.FromSeconds(60));
            }
            else
            {
                SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
            }
        }

        private void Configure()
        {
            this.Config.Configure(new FluentSettings()
            {
                WaitTimeout = TimeSpan.FromSeconds(30),
                WaitUntilInterval = TimeSpan.FromSeconds(30),
                WaitUntilTimeout = TimeSpan.FromSeconds(30)
            });
            this.Config.Settings.ScreenshotOnFailedAction = true;
            this.Config.Settings.ScreenshotPath = @"C:\TestResults\ScreenShots";
        }


        protected bool HasScenarioTag(string tag, StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
        {
            return ScenarioContext.Current.ScenarioInfo.Tags.Any(x => x.Equals(tag, stringComparison));
        }
    }
}
