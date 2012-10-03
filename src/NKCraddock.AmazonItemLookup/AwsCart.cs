using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NKCraddock.AmazonItemLookup
{
    public class AwsCart
    {
        string CartId { get; set; }
        public string HMAC { get; set; }
        public string URLEncodedHMAC { get; set; }
        public string PurchaseURL { get; set; }
        public double? Subtotal { get; set; }
        public IList<CartItem> CartItems { get; set; }
    }
}