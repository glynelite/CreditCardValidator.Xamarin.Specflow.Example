using Microsoft.Extensions.Logging;
using System;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace CreditCardValidator.Test.UI.Specflow
{
    [Binding]
    class LogEvents : EventBase
    {
        private IApp _app;
        private Platform _platform;
        private ScenarioContext _scenarioContext;
        private FeatureContext _featureContext;
        private ILoggerFactory _loggerFactory;
        private ILogger _logger;

        public LogEvents(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
            _platform = scenarioContext.Get<Platform>();
            _app = scenarioContext.Get<IApp>();
            _loggerFactory = scenarioContext.Get<ILoggerFactory>();
            _logger = _loggerFactory.CreateLogger<LogEvents>();
        }

        [AfterStep]
        public void LogInfoOnError()
        { 
            if(_scenarioContext.TestError != null)
            {
                var stepInfo = _scenarioContext.StepContext.StepInfo;
                var stepDescription = stepInfo.StepDefinitionType + stepInfo.Text;
                LogTestInfo($"Test failed on step: {stepInfo}/n{stepDescription}", _scenarioContext, _featureContext, _app, _platform, _logger);
            }
        }
    }
}
