using AppQuery = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CreditCardValidator.Test.UI.Specflow
{
    public interface IValidatorScreen
    {
        AppQuery CardNumberField { get; }
        AppQuery ValidateButton { get; }
        AppQuery ErrorMessage { get; }
        AppQuery SuccessMessage { get; }
        AppQuery ValidateScreenTitleBar { get; }
        AppQuery SuccessScreenTitleBar { get; }
    } 
}