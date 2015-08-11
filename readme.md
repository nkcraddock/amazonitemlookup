#AmazonItemLookup

##Easy item lookup by ASIN from Amazon Product Advertising API

by [Nathan Craddock](http://nathancraddock.org/ "Nathan Craddock - Software Developer")

### Set up a connection
		AwsProductApiClient api = new AwsProductApiClient(new ProductApiConnectionInfo
		{
			AWSAccessKey = config.AWSAccessKey,
			AWSSecretKey = config.AWSSecretKey,
			AWSAssociateTag = config.AWSAssociateTag,
			[AWSServerUri = "webservices.amazon.co.uk"]
		});

### Retrieve an item from Amazon by ASIN
    AwsItem item = api.LookupByAsin(ASIN);

### Create a cart on Amazon with 2 items in it and transfer the user to the purchase URL		

    AwsCart cart = api.CreateCart(new CartItem { Asin = "B0071YIFJ6" }, new CartItem { Asin = "B001H1SVO8" });


### Colaborators
[Marcos Placona](www.placona.co.uk) - Twilio

### Changelog
*   Add support for CreateCart
*   Add support for localized Amazon websites
*   Create Nuget package
