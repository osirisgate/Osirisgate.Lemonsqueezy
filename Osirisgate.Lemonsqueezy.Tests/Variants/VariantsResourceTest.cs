using Osirisgate.Lemonsqueezy.Resource.Files.Response;
using Osirisgate.Lemonsqueezy.Resource.Prices.Response;
using Osirisgate.Lemonsqueezy.Resource.Products.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Tests.Variants;

public sealed class VariantsResourceTest
{
    [Fact]
    public void TestCanInitializeVariantsResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var variantsResource = client.VariantsResource();

        Assert.IsType<VariantsResource>(variantsResource);
    }

    [Fact]
    public async Task TestCanRetrieveVariant()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var variantsResource = client.VariantsResource();

        var response = await variantsResource.RetrieveVariantAsync(1131825);

        Assert.IsType<VariantResponse>(response);
    }


    [Fact]
    public async Task TestCanListAllVariants()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var variantsResource = client.VariantsResource();

        var response = await variantsResource.ListAllVariantsAsync();

        Assert.IsType<VariantsResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveVariantProduct()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var variantsResource = client.VariantsResource();

        var response = await variantsResource.RetrieveProductAsync(1131825);

        Assert.IsType<ProductResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveVariantFiles()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var variantsResource = client.VariantsResource();

        var response = await variantsResource.RetrieveFilesAsync(1131825);

        Assert.IsType<FilesRelationShipResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveVariantPriceModel()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var variantsResource = client.VariantsResource();

        var response = await variantsResource.RetrievePriceModelAsync(1131825);

        Assert.IsType<PriceResponse>(response);
    }
}
