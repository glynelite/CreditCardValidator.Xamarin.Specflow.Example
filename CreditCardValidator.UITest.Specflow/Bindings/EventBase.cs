using Microsoft.Extensions.Logging;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace CreditCardValidator.Test.UI.Specflow
{
    [Binding]
    public class EventBase
    {
        public enum Order
        {
            BuildLogger = 1,
            InitialiseApp = 2,
            InitialiseScreens = 3,
            BuildScenarioContext = 4
        };

        public void LogTestInfo(string message, ScenarioContext scenarioContext, FeatureContext featureContext, IApp app, Platform platform, ILogger logger)
        {
            var featureTitle = featureContext.FeatureInfo.Title;
            var scenarioTitle = scenarioContext.ScenarioInfo.Title;
            var deviceId = app.Device.DeviceIdentifier;
            var deviceUri = app.Device.DeviceUri;
            var platformName = platform;

            logger.LogInformation($"Message:{message}\nFeature:{featureTitle}\nScenario:{scenarioTitle}\nDevice:{deviceId}\nDeviceUri:{deviceUri}\nPlatform:{platformName}");
        }
    }    
}
