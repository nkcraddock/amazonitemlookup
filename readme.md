#AmazonItemLookup: Easy item lookup by ASIN from Amazon Product Advertising API
by [Nathan Craddock](http://nathan.craddock.org/ "Nathan Craddock - Software Developer")

It just does the bare minimum I need at the moment. I'll expand it and if anyone 
else actually uses it and wants something implemented, I'll probably do it.

##Example:
		AwsProductApi api = new AwsProductApi(new ProductApiConnectionInfo
		{
			AWSAccessKey = config.AWSAccessKey,
			AWSSecretKey = config.AWSSecretKey,
			AWSAssociateTag = config.AWSAssociateTag
		});

		AwsItem item = api.LookupByAsin(ASIN);

The AwsItem class has:

- ASIN
- DetailPageURL
- Links
- SalesRank
- ImageSets
- ItemAttributes
- Reviews
- Similar Product Links
- ListPrice, OfferPrice, LowestOfferPrice 
- GetLowestPrice()
- GetImageUrl(Type)
