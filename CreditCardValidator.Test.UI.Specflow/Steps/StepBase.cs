using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace CreditCardValidator.Test.UI.Specflow
{
    [Binding]
    public class StepBase
    {
        public IApp app;
        public string platform;
        public ScenarioContext scenarioContext;

        public StepBase()
        {
            scenarioContext = ScenarioContext.Current;
            app = scenarioContext.Get<IApp>();
            platform = scenarioContext.Get<Platform>().ToString();
        }

        public string RandomNumber(int minLength, int maxLength)
        {
            var random = new Random();
            var number = String.Empty;
            var length = random.Next(minLength, maxLength + 1);

            for (int i = 0; i < length; ++i)
            {
                number = String.Concat(number, random.Next(10).ToString());
            }

            return number;
        }
    }
}

