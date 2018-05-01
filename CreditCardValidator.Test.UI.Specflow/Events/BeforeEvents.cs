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

        [BeforeScenario(Order = Order.InitialiseApp)]
        public void InitialiseApp()
        {
            _platform = new PlatformContext().GetPlatform();
            _app = AppContext.StartApp(_platform);
            PrintTestEnvironmentInfo(_app, _platform);
        }

        [BeforeScenario(Order = Order.InitialiseScreens)]
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
                    throw new ArgumentOutOfRangeException();
            }
        }

        [BeforeScenario(Order = Order.FillDictionary)]
        public void BuildScenarioContext()
        {
            scenarioContext.Set<IApp>(_app);
            scenarioContext.Set<Platform>(_platform);
            scenarioContext.Add(_platform.ToString(), _screenContext);
        }
    }
}
