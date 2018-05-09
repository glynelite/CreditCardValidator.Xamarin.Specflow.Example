using AppQuery = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CreditCardValidator.Test.UI.Specflow
{
    public class AndroidValidatorScreen : IValidatorScreen
    {
        public AppQuery CardNumberField { get; } = e => e.Marked("creditCardNumberText");
        public AppQuery ValidateButton { get; } = e => e.Marked("validateButton");
        public AppQuery ErrorMessage { get; } = e => e.Marked("errorMessagesText");
        public AppQuery SuccessMessage { get; } = e => e.Marked("validationSuccessMessage");
        public AppQuery ValidateScreenTitleBar { get; } = e => e.Marked("action_bar_title").Text("Enter Credit Card Number");
        public AppQuery SuccessScreenTitleBar { get; } = e => e.Marked("action_bar_title").Text("Valid Credit Card");
    }
}
