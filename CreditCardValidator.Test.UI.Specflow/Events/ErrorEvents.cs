using System;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace CreditCardValidator.Test.UI.Specflow
{
    [Binding]
    class ErrorEvents : EventBase
    {
        private IApp _app;
        private Platform _platform;

        public ErrorEvents()
        {
            _app = scenarioContext.Get<IApp>();
            _platform = scenarioContext.Get<Platform>();
        }

        [AfterStep]
        public void StepInfoOnError()
        {
            if (scenarioContext.TestError != null)
            {
                var stepInfo = scenarioContext.StepContext.StepInfo;
                var stepDescription = stepInfo.StepDefinitionType + stepInfo.Text;
                Console.WriteLine(stepDescription);
                PrintTestEnvironmentInfo(_app, _platform);
            }
        }
    }
}
