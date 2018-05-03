using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CreditCardValidator.Test.UI.Specflow
{
    public class AndroidValidatorScreen : IValidatorScreen
    {
        public Query CardNumberField { get; } = e => e.Marked("creditCardNumberText");
        public Query ValidateButton { get; } = e => e.Marked("validateButton");
        public Query ErrorMessage { get; } = e => e.Marked("errorMessagesText");
        public Query SuccessMessage { get; } = e => e.Marked("validationSuccessMessage");
        public Query ValidateScreenTitleBar { get; } = e => e.Marked("action_bar_title").Text("Enter Credit Card Number");
        public Query SuccessScreenTitleBar { get; } = e => e.Marked("action_bar_title").Text("Valid Credit Card");
    }
}
