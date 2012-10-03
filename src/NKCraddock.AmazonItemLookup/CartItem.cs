using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NKCraddock.AmazonItemLookup
{
    public class CartItem
    {
        public CartItem()
        {
            Quantity = 1;
        }

        public string Asin { get; set; }
        public int Quantity { get; set; }
        public string Title { get; set; }
        public double? Price { get; set; }
        public double? ItemTotal { get; set; }
    }
}