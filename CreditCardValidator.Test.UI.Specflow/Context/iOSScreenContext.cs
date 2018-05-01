namespace CreditCardValidator.Test.UI.Specflow
{
    public class iOSScreenContext : IScreenContext
    {
        public IValidatorScreen GetValidatorScreen { get; private set; }

        public iOSScreenContext()
        {
            InitialiseScreenModels();
        }

        private void InitialiseScreenModels()
        {
            GetValidatorScreen = new iOSValidatorScreen();
        }
    }
}