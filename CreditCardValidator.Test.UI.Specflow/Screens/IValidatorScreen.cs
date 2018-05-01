using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CreditCardValidator.Test.UI.Specflow
{
    public interface IValidatorScreen
    {
        Query CardNumberField { get; }
        Query ValidateButton { get; }
        Query ErrorMessage { get; }
        Query SuccessMessage { get; }
        Query ValidateScreenTitleBar { get; }
        Query SuccessScreenTitleBar { get; }

        void TestMethod();
    } 
}