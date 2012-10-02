﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace NKCraddock.AmazonItemLookup
{
    internal static class XmlHelper
    {
        public static string GetAttributeValue(XmlNode node, string attributeName)
        {
            if (node.Attributes[attributeName] == null)
                return null;

            return node.Attributes[attributeName].Value ?? node.Attributes[attributeName].InnerText;
        }

        public static double? GetDollars(XmlNode node)
        {
            if (node == null)
                return null;

            double cents = 0;
            if (double.TryParse(node.Value ?? node.InnerText, out cents))
                return cents / 100;
            return null;
        }

        public static int? GetInt(string value)
        {
            int iValue = 0;

            if (int.TryParse(value, out iValue))
                return iValue;

            return null;
        }

        public static string GetValue(XmlNode node)
        {
            return node == null ? null : (node.Value ?? node.InnerText);
        }
    }
}