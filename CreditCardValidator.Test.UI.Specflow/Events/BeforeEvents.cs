using System;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace CreditCardValidator.Test.UI.Specflow
{
    [Binding]
    class BeforeEvents : EventBase
    {
        private IApp _app;
        private Platform _platform;
        private IScreenContext _screenContext;
        private ScenarioContext _scenarioContext;
        private FeatureContext _featureContext;


        BeforeEvents(ScenarioContext scenarioContext, FeatureContext featureContext) 
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
            _platform = new PlatformContext().GetPlatform();
        }
        
        [BeforeScenario(Order = (int)Order.InitialiseApp)]
        public void InitialiseApp()
        {
            _app = AppContext.StartApp(_platform);
            PrintTestEnvironmentInfo(_scenarioContext, _featureContext, _app, _platform);
        }

        [BeforeScenario(Order = (int)Order.InitialiseScreens)]
        public void InitialiseScreenContexts()
        {
            switch (_platform)
            {
                case Platform.Android:
                    _screenContext = new AndroidScreenContext(); 
                    break;

                case Platform.iOS:
                    _screenContext = new iOSScreenContext();
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        [BeforeScenario(Order = (int)Order.FillDictionary)]
        public void BuildScenarioContext()
        {
            _scenarioContext.Set<IApp>(_app);
            _scenarioContext.Set<Platform>(_platform);
            _scenarioContext.Add(_platform.ToString(), _screenContext);
        }
    }
}
