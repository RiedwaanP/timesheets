using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Timesheets.AcceptanceTests
{
    [Binding]
    public class StepDefinitionSetupBase
    {
        [BeforeStep]
        public virtual void BeforeStep()
        {
        }

        [AfterStep]
        public virtual void AfterStep()
        {

        }

        [BeforeScenarioBlock]
        public virtual void BeforeScenarioBlock()
        {

        }

        [AfterScenarioBlock]
        public virtual void AfterScenarioBlock()
        {

        }

        [BeforeScenario]
        public virtual void BeforeScenario()
        {
        }

        [AfterScenario]
        public virtual void AfterScenario()
        {

        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
        }

        [AfterFeature]
        public static void AfterFeature()
        {
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
        }
    }
}
