using Osirisgate.Lemonsqueezy.Resource.DiscountRedemptions.Response;
using Osirisgate.Lemonsqueezy.Resource.Discounts;
using Osirisgate.Lemonsqueezy.Resource.Discounts.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Tests.Discounts;

public sealed class DiscountsResourceTest
{
    [Fact]
    public void TestCanInitializeDiscountsResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var discountsResource = client.DiscountsResource();

        Assert.IsType<DiscountsResource>(discountsResource);
    }

    [Fact]
    public async Task TestCanRetrieveDiscount()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var discountsResource = client.DiscountsResource();

        var response = await discountsResource.RetrieveDiscountAsync(1131825);

        Assert.IsType<DiscountResponse>(response);
    }

    [Fact]
    public async Task TestCanListAllDiscounts()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var discountsResource = client.DiscountsResource();

        var response = await discountsResource.ListAllDiscountsAsync();

        Assert.IsType<DiscountsResponse>(response);
    }

    [Fact]
    public async Task TestCreateDiscount()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var discountsResource = client.DiscountsResource();

        var response = await discountsResource.CreateDiscountAsync(new Dictionary<string, object>
        {
            ["data"] = new Dictionary<string, object>
            {
                ["type"] = "discounts",
                ["attributes"] = new Dictionary<string, object>
                {
                    ["name"] = "Discount 1",
                    ["code"] = "DISCOUNT1",
                    ["amount"] = 10,
                    ["amount_type"] = "percent"
                },
                ["relationships"] = new Dictionary<string, object>
                {
                    ["store"] = new Dictionary<string, object>
                    {
                        ["data"] = new Dictionary<string, object>
                        {
                            ["type"] = "stores",
                            ["id"] = "1"
                        }
                    }
                }
            }
        });

        Assert.IsType<DiscountResponse>(response);
    }

    [Fact]
    public async Task TestCanDeleteDiscount()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var discountsResource = client.DiscountsResource();

        var response = await discountsResource.DeleteDiscountAsync(1131825);

        Assert.IsType<Dictionary<string, object>>(response);
    }

    [Fact]
    public async Task TestCanRetrieveDiscountStore()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var discountsResource = client.DiscountsResource();

        var response = await discountsResource.RetrieveStoreAsync(1131825);

        Assert.IsType<StoreResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveDiscountVariants()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var discountsResource = client.DiscountsResource();

        var response = await discountsResource.RetrieveVariantsAsync(1131825);

        Assert.IsType<VariantsRelationShipResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveDiscountDiscountRedemptions()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var discountsResource = client.DiscountsResource();

        var response = await discountsResource.RetrieveDiscountRedemptionsAsync(1131825);

        Assert.IsType<DiscountRedemptionsRelationShipResponse>(response);
    }
}
