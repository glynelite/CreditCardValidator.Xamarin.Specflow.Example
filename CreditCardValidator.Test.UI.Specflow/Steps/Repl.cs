using TechTalk.SpecFlow;

namespace CreditCardValidator.Test.UI.Specflow
{
    [Binding]
    public class Repl : StepBase
    {
        [Given(@"I start the REPL")]
        public void GivenIStarsTheREPL()
        {
            app.Repl();
        }
    }
}
