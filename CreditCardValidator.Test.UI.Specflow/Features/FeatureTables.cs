using System;

namespace CreditCardValidator.Test.UI.Specflow
{
    class FeatureTables
    {
        public class CreditCardNumber
        {
            public string CardNumber { get; set; }
            public DateTime ExpiryDate { get; set; }
        }
    }
}
