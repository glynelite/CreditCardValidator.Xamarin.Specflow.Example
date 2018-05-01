using NUnit.Framework;
using Xamarin.UITest;

namespace CreditCardValidator.Test.UI.Specflow
{
    [TestFixture(Platform.iOS)]
    [TestFixture(Platform.Android)]
    
    public class PlatformContext
    {
        private readonly Platform _platform;

        public PlatformContext(Platform platform)
        {
            _platform = platform;
        }

        public PlatformContext()
        {

        }

        public Platform GetPlatform()
        {
            return _platform;
        }
    }
}
