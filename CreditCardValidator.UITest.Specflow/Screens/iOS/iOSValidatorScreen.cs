using AppQuery = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CreditCardValidator.Test.UI.Specflow
{
    //too poor to support iOS
    public class iOSValidatorScreen : IValidatorScreen
    {
        public AppQuery CardNumberField { get; } = e => e.Marked("");
        public AppQuery ValidateButton { get; } = e => e.Marked("");
        public AppQuery ErrorMessage { get; } = e => e.Marked("");
        public AppQuery SuccessMessage { get; } = e => e.Marked("");
        public AppQuery ValidateScreenTitleBar { get; } = e => e.Marked("").Text("");
        public AppQuery SuccessScreenTitleBar { get; } = e => e.Marked("").Text("");
    }
}
