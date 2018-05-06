using FluentAssertions;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xamarin.UITest;

namespace CreditCardValidator.Test.UI.Specflow
{
    [Binding]
    public class ValidatorSteps : StepBase
    {
        private IValidatorScreen _screen;
        private StringBuilder _errors;
        private IApp _app;

        public ValidatorSteps(ScenarioContext scenarioContext)
        {
            _app = scenarioContext.Get<IApp>();
            _screen = scenarioContext.Get<IScreenContext>().GetValidatorScreen;
            _errors = new StringBuilder();
        }

        [Given(@"I am on the card number validator screen")]
        public void GivenOnCreditCardValidatorScreen()
        {
            _app.WaitForElement(_screen.ValidateScreenTitleBar);
        }

        [Given(@"I enter this number into the card number field: (.*)")]
        public void GivenEnterCreditCardNumber(string cardNumber)
        {
            _app.EnterText(_screen.CardNumberField, cardNumber);
        }

        [When(@"I tap the validate card number button")]
        public void WhenTapValidateButton()
        {
            _app.Tap(_screen.ValidateButton);
        }

        [Given(@"I enter a random number of length (.*)")]
        public void GivenEnterRandomNumber(int length)
        {
            _app.EnterText(_screen.CardNumberField, RandomNumber(length, length));
        }

        [Given(@"I enter a random number of length less than (.*)")]
        public void GivenEnterRandomLengthNumbeLessThan(int length)
        {
            _app.EnterText(_screen.CardNumberField, RandomNumber(1, length));
        }

        [Given(@"I enter a random number of minimum length (.*) and maximum length (.*)")]
        public void GivenEnterRandomNumber(int minLength, int maxLength)
        {
            _app.EnterText(_screen.CardNumberField, RandomNumber(minLength, maxLength));
        }

        [Then(@"card number is too long error is displayed")]
        public void ThenCardNumberTooLongError()
        {
            var error = _app.WaitForElement(_screen.ErrorMessage).First().Text;
            error.Should().Be("Credit card number is too long.");
        }

        [Then(@"not a card number error is displayed")]
        public void ThenNotACardNumberError()
        {
            var error = _app.WaitForElement(_screen.ErrorMessage).First().Text;
            error.Should().Be("This is not a credit card number.");
        }

        [Then(@"the card number is too short error is displayed")]
        public void ThenCreditCardTooShortError()
        {
            var error = _app.WaitForElement(_screen.ErrorMessage).First().Text;
            error.Should().Be("Credit card number is too short.");
        }

        [Then(@"the validation success screen loads")]
        public void ThenSuccessScreen()
        {
            _app.WaitForElement(_screen.SuccessScreenTitleBar);
        }

        [Then(@"card number is valid message is displayed")]
        public void ThenCardNumberValidMessage()
        {
            var message = _app.WaitForElement(_screen.SuccessMessage).First().Text;
            message.Should().Be("The credit card number is valid!");
        }

        [Then(@"this validation message is displayed: (.*)")]
        public void ThenValidationMessage(string validationMessage)
        {
            var message = _app.WaitForElement(_screen.SuccessMessage).First().Text;
            message.Should().Be(validationMessage);
        }


        [Given(@"I submit these numbers to the card validator:")]
        public void GivenISubmitTheseNumbersToTheCardValidator(Table table)
        {
            var _table = table.CreateDynamicSet(false);

            foreach(var row in _table)
            {
                _app.EnterText(_screen.CardNumberField, row.CardNumber);
                _app.Tap(_screen.ValidateButton);

                try
                {
                    if (row.CardNumber.Length < 16)
                    {
                        ThenCreditCardTooShortError();
                    }
                    else if (row.CardNumber.Length == 16)
                    {
                        ThenCardNumberValidMessage();
                        _app.Back();
                        _app.WaitForElement(_screen.ValidateScreenTitleBar);
                    }
                    else if (row.CardNumber.Length > 16)
                    {
                        ThenCardNumberTooLongError();
                    }
                }
                catch(Exception e)
                {
                    _errors.Append(e);
                }

                _app.ClearText(_screen.CardNumberField);
            }
        }

        [Then(@"every number is correctly validated")]
        public void ThenrCorrectlyValidated()
        {
            var e = String.Empty;

            if(_errors != null)
            {
                e = _errors.ToString();
            }
            
            _errors.Should().Be(null, $"because the submit card number loop only appends to string builder on error. Errors: {e}");
        }
    }
}
