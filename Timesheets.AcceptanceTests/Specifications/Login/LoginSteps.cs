using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Timesheets.AcceptanceTests.Specifications.Login
{
    [Binding]
    [Scope(Feature = "Login")]
    public class LoginSteps : StepDefinitionBase
    {
        [Given(@"I am on the home url")]
        public void GivenIAmOnTheHomeUrl()
        {
            I.Open("http://my-timesheets.azurewebsites.net/");
        }

        [When(@"I click the log on link")]
        public void WhenIClieckTheLogOnLink()
        {
            I.Click("#loginLink");
        }

        [When(@"I enter the following user credentials")]
        public void WhenIEnterTheFollowingUserCredentials(Table table)
        {
            table.Rows.ToList().ForEach(item =>
            {
                if (item.Values.ToArray()[0].Contains("Email"))
                {
                    I.Enter(item.Values.ToArray()[1]).In("input#Email");
                }
                if (item.Values.ToArray()[0].Contains("Password"))
                {
                    I.Enter(item.Values.ToArray()[1]).In("input#Password");
                }
            });
        }
        
        [When(@"I click the Login button")]
        public void WhenIClickTheLoginButton()
        {
            I.Click("input[type='submit']");
        }
        
        [Then(@"I should be on the home url")]
        public void ThenIShouldBeOnTheHomeUrl()
        {
            I.Assert.Url("http://my-timesheets.azurewebsites.net/");
        }

        [Then(@"I should remain on the be on the login url")]
        public void ThenIShouldRemainOnTheBeOnTheLoginUrl()
        {
            I.Assert.Url("http://my-timesheets.azurewebsites.net/Account/Login");
        }

        [Then(@"I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            I.Assert.Exists(".validation-summary-errors");
        }

    }
}
