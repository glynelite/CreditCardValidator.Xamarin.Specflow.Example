using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace CreditCardValidator.Test.UI.Specflow
{
    [Binding]
    public class Repl : StepBase
    {
        private ScenarioContext _scenarioContext;
        private IApp _app;

        public Repl(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _app = scenarioContext.Get<IApp>();
        }
        [Given(@"I start the REPL")]
        public void GivenIStarsTheREPL()
        {
            _app.Repl();
        }
    }
}
