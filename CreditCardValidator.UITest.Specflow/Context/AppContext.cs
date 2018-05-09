using System;
using Xamarin.UITest;

namespace CreditCardValidator.Test.UI.Specflow
{
    public class AppContext
    {
        public static IApp StartApp(Platform platform)
        {
            switch (platform)
            {
                case Platform.Android:
                    return ConfigureApp
                    .Android
                    .InstalledApp("com.xamarin.example.creditcardvalidator")
                    .PreferIdeSettings()
                    .EnableLocalScreenshots()
                    .StartApp();

                case Platform.iOS:
                    return ConfigureApp
                    .iOS
                    .InstalledApp("com.xamarin.example.creditcardvalidator")
                    .PreferIdeSettings()
                    .EnableLocalScreenshots()
                    .StartApp();

                default:
                    throw new NotImplementedException(platform);
            }
        }
    }
}