using Osirisgate.Lemonsqueezy.Resource.Checkouts;
using Osirisgate.Lemonsqueezy.Resource.Checkouts.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Tests.Checkouts;

public sealed class CheckoutsResourceTest
{
    [Fact]
    public void TestCanInitializeCheckoutsResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var checkoutsResource = client.CheckoutsResource();

        Assert.IsType<CheckoutsResource>(checkoutsResource);
    }

    [Fact]
    public async Task TestCanRetrieveCheckout()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var checkoutsResource = client.CheckoutsResource();

        var response = await checkoutsResource.RetrieveCheckoutAsync(1131825);

        Assert.IsType<CheckoutResponse>(response);
    }

    [Fact]
    public async Task TestCanListAllCheckouts()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var checkoutsResource = client.CheckoutsResource();

        var response = await checkoutsResource.ListAllCheckoutsAsync();

        Assert.IsType<CheckoutsResponse>(response);
    }

    [Fact]
    public async Task TestCanCreateCheckout()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var checkoutsResource = client.CheckoutsResource();

        var response = await checkoutsResource.CreateCheckoutAsync(new Dictionary<string, object>
        {
            ["data"] = new Dictionary<string, object>
            {
                ["type"] = "checkouts",
                ["attributes"] = new Dictionary<string, object>
                {
                    ["custom_price"] = 50000,
                    ["product_options"] = new Dictionary<string, object>
                    {
                        ["enabled_variants"] = new List<object> { 1 }
                    },
                    ["checkout_options"] = new Dictionary<string, object>
                    {
                        ["button_color"] = "#7047EB"
                    },
                    ["checkout_data"] = new Dictionary<string, object>
                    {
                        ["discount_code"] = "10PERCENTOFF",
                        ["custom"] = new Dictionary<string, object>
                        {
                            ["user_id"] = 123
                        }
                    },
                    ["expires_at"] = "2022-10-30T15:20:06Z",
                    ["preview"] = true
                }
            }
        });

        Assert.IsType<CheckoutResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveCheckoutStore()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var checkoutsResource = client.CheckoutsResource();

        var response = await checkoutsResource.RetrieveStoreAsync(1131825);

        Assert.IsType<StoreResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveCheckoutVariant()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var checkoutsResource = client.CheckoutsResource();

        var response = await checkoutsResource.RetrieveVariantAsync(1131825);

        Assert.IsType<VariantResponse>(response);
    }
}
