using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace CreditCardValidator.Test.UI.Specflow
{
    [Binding]
    public class ScreenBase
    {
        public IApp app;
        private ScenarioContext _scenarioContext;

        public ScreenBase()
        {
            _scenarioContext = ScenarioContext.Current;
            _scenarioContext.TryGetValue<IApp>(out app);
        }

        public void DoSomeGenericInteractions()
        {

        }
    }
}
