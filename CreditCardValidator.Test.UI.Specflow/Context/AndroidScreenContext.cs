using Xamarin.UITest;

namespace CreditCardValidator.Test.UI.Specflow
{
    public class AndroidScreenContext : IScreenContext
    {
        public IValidatorScreen GetValidatorScreen { get; private set; }

        public AndroidScreenContext()
        {
            InitialiseScreenModels();
        }

        private void InitialiseScreenModels()
        {
            GetValidatorScreen = new AndroidValidatorScreen();
        }
    }
}
