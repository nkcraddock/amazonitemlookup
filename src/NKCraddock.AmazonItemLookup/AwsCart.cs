using System.Collections.Generic;

namespace NKCraddock.AmazonItemLookup
{
    public class AwsCart
    {
        public string CartId { get; set; }
        public string HMAC { get; set; }
        public string URLEncodedHMAC { get; set; }
        public string PurchaseURL { get; set; }
        public double? Subtotal { get; set; }
        public IList<CartItem> CartItems { get; set; }
    }
}