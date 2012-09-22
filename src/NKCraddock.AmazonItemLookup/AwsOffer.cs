using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NKCraddock.AmazonItemLookup
{
    public class AwsOffer
    {
        public AwsItemCondition Condition { get; set; }

        public double Amount { get; set; }

        public string Availability { get; set; }
    }
}