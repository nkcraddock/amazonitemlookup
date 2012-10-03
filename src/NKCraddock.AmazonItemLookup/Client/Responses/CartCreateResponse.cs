using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace NKCraddock.AmazonItemLookup.Client.Responses
{
    public class CartCreateResponse
    {
        AwsXmlParser parser;

        public CartCreateResponse(string xml)
        {
            parser = new AwsXmlParser(xml);
        }

        public AwsCart ToCart()
        {
            var cart = new AwsCart
            {
                CartId = parser.SelectNodeValue(NodePath.CartCreateResponse.CartId),
                HMAC = parser.SelectNodeValue(NodePath.CartCreateResponse.HMAC),
                PurchaseURL = parser.SelectNodeValue(NodePath.CartCreateResponse.PurchaseURL),
                Subtotal = XmlHelper.GetDollars(parser.SelectNode(NodePath.CartCreateResponse.SubTotal)),
                URLEncodedHMAC = parser.SelectNodeValue(NodePath.CartCreateResponse.URLEncodedHMAC),
                CartItems = GetCartItems()
            };

            return cart;
        }

        private IList<CartItem> GetCartItems()
        {
            var items = new List<CartItem>();
            foreach (XmlNode ItemNode in parser.SelectNodes(NodePath.CartCreateResponse.CartItems))
                items.Add(CartItem.FromXmlNode(ItemNode));
            return items;
        }
    }
}