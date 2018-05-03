using System;
using TechTalk.SpecFlow;

namespace CreditCardValidator.Test.UI.Specflow
{
    [Binding]
    public class StepBase
    {
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

