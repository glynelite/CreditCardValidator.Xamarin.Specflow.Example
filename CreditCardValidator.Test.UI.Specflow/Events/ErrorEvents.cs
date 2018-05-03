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
        private ScenarioContext _scenarioContext;
        private FeatureContext _featureContext;

        public ErrorEvents(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
            _platform = scenarioContext.Get<Platform>();
            _app = scenarioContext.Get<IApp>();
        }

        [AfterStep]
        public void StepInfoOnError()
        {
            if (_scenarioContext.TestError != null)
            {
                var stepInfo = _scenarioContext.StepContext.StepInfo;
                var stepDescription = stepInfo.StepDefinitionType + stepInfo.Text;
                Console.WriteLine(stepDescription);
                PrintTestEnvironmentInfo(_scenarioContext, _featureContext, _app, _platform);
            }
        }
    }
}
