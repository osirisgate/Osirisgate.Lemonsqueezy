using Osirisgate.Lemonsqueezy.Model.Price;
using Osirisgate.Lemonsqueezy.Resource.Prices;
using Osirisgate.Lemonsqueezy.Resource.Prices.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Tests.Prices;

public sealed class PricesResourceTest
{
    [Fact]
    public void TestCanInitializePricesResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var pricesResource = client.PricesResource();

        Assert.IsType<PricesResource>(pricesResource);
    }

    [Fact]
    public void TestCanRetrievePrice()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var pricesResource = client.PricesResource();

        var response = pricesResource.RetrievePriceAsync(1131825);

        Assert.IsType<PriceResponse>(response);
    }

    [Fact]
    public void TestCanListAllPrices()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var pricesResource = client.PricesResource();

        var response = pricesResource.ListAllPricesAsync();

        Assert.IsType<PricesResponse>(response);
    }

    [Fact]
    public void TestCanRetrievePriceVariant()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var pricesResource = client.PricesResource();

        var response = pricesResource.RetrieveVariantAsync(1131825);

        Assert.IsType<VariantResponse>(response);
    }
}
