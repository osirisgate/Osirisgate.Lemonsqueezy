using Osirisgate.Lemonsqueezy.Resource.DiscountRedemptions;
using Osirisgate.Lemonsqueezy.Resource.DiscountRedemptions.Response;
using Osirisgate.Lemonsqueezy.Resource.Discounts.Response;
using Osirisgate.Lemonsqueezy.Resource.Orders.Response;

namespace Osirisgate.Lemonsqueezy.Tests.DiscountRedemptions;

public sealed class DiscountRedemptionsResourceTest
{
    [Fact]
    public void TestCanInitializeDiscountRedemptionsResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var discountRedemptionsResource = client.DiscountRedemptionsResource();

        Assert.IsType<DiscountRedemptionsResource>(discountRedemptionsResource);
    }

    [Fact]
    public async Task TestCanRetrieveDiscountRedemption()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var discountRedemptionsResource = client.DiscountRedemptionsResource();

        var response = await discountRedemptionsResource.RetrieveDiscountRedemptionAsync(1131825);

        Assert.IsType<DiscountRedemptionResponse>(response);
    }

    [Fact]
    public async Task TestCanListAllDiscountRedemptions()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var discountRedemptionsResource = client.DiscountRedemptionsResource();

        var response = await discountRedemptionsResource.ListAllDiscountRedemptionsAsync();

        Assert.IsType<DiscountRedemptionsResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveDiscountRedemptionsDiscount()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var discountRedemptionsResource = client.DiscountRedemptionsResource();

        var response = await discountRedemptionsResource.RetrieveDiscountAsync(1131825);

        Assert.IsType<DiscountResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveDiscountRedemptionsOrder()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var discountRedemptionsResource = client.DiscountRedemptionsResource();

        var response = await discountRedemptionsResource.RetrieveOrderAsync(1131825);

        Assert.IsType<OrderResponse>(response);
    }
}
