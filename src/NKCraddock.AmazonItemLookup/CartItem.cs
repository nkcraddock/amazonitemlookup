using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace NKCraddock.AmazonItemLookup
{
    public class CartItem
    {
        public CartItem()
        {
            Quantity = 1;
        }

        public string CartItemId { get; set; }
        public string Asin { get; set; }
        public int? Quantity { get; set; }
        public string Title { get; set; }
        public string ProductGroup { get; set; }
        public double? Price { get; set; }
        public double? ItemTotal { get; set; }

        internal static CartItem FromXmlNode(XmlNode node)
        {
            var item = new CartItem();
            foreach (XmlNode child in node.ChildNodes)
                if (child.Name.Equals("CartItemId", StringComparison.CurrentCultureIgnoreCase))
                    item.CartItemId = XmlHelper.GetValue(child);
                else if (child.Name.Equals("ASIN", StringComparison.CurrentCultureIgnoreCase))
                    item.Asin = XmlHelper.GetValue(child);
                else if (child.Name.Equals("Quantity", StringComparison.CurrentCultureIgnoreCase))
                    item.Quantity = XmlHelper.GetInt(XmlHelper.GetValue(child));
                else if (child.Name.Equals("Title", StringComparison.CurrentCultureIgnoreCase))
                    item.Title = XmlHelper.GetValue(child);
                else if (child.Name.Equals("ProductGroup", StringComparison.CurrentCultureIgnoreCase))
                    item.ProductGroup = XmlHelper.GetValue(child);
                else if (child.Name.Equals("Price", StringComparison.CurrentCultureIgnoreCase))
                    item.Price = XmlHelper.GetDollars(XmlHelper.GetChildNode(child, "Amount"));
                else if (child.Name.Equals("ItemTotal", StringComparison.CurrentCultureIgnoreCase))
                    item.ItemTotal = XmlHelper.GetDollars(XmlHelper.GetChildNode(child, "Amount"));

            return item;
        }
    }
}