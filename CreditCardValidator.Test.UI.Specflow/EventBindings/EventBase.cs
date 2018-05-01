using System;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace CreditCardValidator.Test.UI.Specflow
{
    [Binding]
    public class EventBase
    {
        private FeatureContext _featureContext;
        public ScenarioContext scenarioContext;


        public EventBase()
        {
            _featureContext = FeatureContext.Current;
            scenarioContext = ScenarioContext.Current;
        }

        public class Order
        {
            public const int InitialiseApp = 1;
            public const int InitialiseScreens = 2;
            public const int FillDictionary = 3;
        }

        public void PrintTestEnvironmentInfo(IApp app, Platform platform)
        {
            var featureTitle = _featureContext.FeatureInfo.Title;
            var scenarioTitle = scenarioContext.ScenarioInfo.Title;
            var deviceId = app.Device.DeviceIdentifier;
            var deviceUri = app.Device.DeviceUri;
            var platformName = platform;

            Console.WriteLine($"Feature:{featureTitle}\nScenario:{scenarioTitle}\nDevice:{deviceId}\nDeviceUri:{deviceUri}\nPlatform:{platformName}");
        }
    }    
}
