namespace NKCraddock.AmazonItemLookup.Client
{
    internal class NodePath
    {
        public const string ItemPath = "ItemLookupResponse/Items/Item/";
        public const string ASIN = ItemPath + "ASIN";
        public const string DetailPageUrl = ItemPath + "DetailPageURL";
        public const string SalesRank = ItemPath + "SalesRank";
        public const string ReviewIFrameUrl = ItemPath + "CustomerReviews/IFrameURL";
        public const string ItemLinks = ItemPath + "ItemLinks/ItemLink";
        public const string ImageSets = ItemPath + "ImageSets/ImageSet";
        public const string ItemAttributes = ItemPath + "ItemAttributes";
        public const string Reviews = ItemPath + "EditorialReviews/EditorialReview";
        public const string SimilarProducts = ItemPath + "SimilarProducts/SimilarProduct";
        public const string OfferPrice = ItemPath + "Offers/Offer/OfferListing/Price/Amount";
        public const string ListPrice = ItemPath + "ItemAttributes/ListPrice/Amount";
        public const string LowestOfferPrice = ItemPath + "OfferSummary/LowestNewPrice/Amount";
    }
}