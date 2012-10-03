using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NKCraddock.AmazonItemLookup.Client.Responses;

namespace NKCraddock.AmazonItemLookup.Client.Operations
{
    public class CartCreateOperation : IAwsOperation<CartCreateResponse>
    {
        CartItem[] cartItems;

        public CartCreateOperation() : this(new CartItem[0]) { }

        public CartCreateOperation(CartItem[] cartItems)
        {
            this.cartItems = cartItems;
        }

        public Dictionary<string, string> GetRequestArguments()
        {
            var requestArgs = new Dictionary<string, string>
            {
                { "Operation", "CartCreate" },
            };

            for (int i = 0; i < cartItems.Length; i++)
            {
                requestArgs[string.Format("Item.{0}.ASIN", i + 1)] = cartItems[i].Asin;
                requestArgs[string.Format("Item.{0}.Quantity", i + 1)] = cartItems[i].Quantity.ToString();
            }

            return requestArgs;
        }

        public CartCreateResponse GetResultsFromXml(string xml)
        {
            return new CartCreateResponse(xml);
        }
    }
}