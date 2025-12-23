using Osirisgate.Lemonsqueezy.Resource.Prices.Response;
using Osirisgate.Lemonsqueezy.Resource.SubscriptionItems;
using Osirisgate.Lemonsqueezy.Resource.SubscriptionItems.Response;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions.Response;
using Osirisgate.Lemonsqueezy.Resource.UsageRecords.Response;

namespace Osirisgate.Lemonsqueezy.Tests.SubscriptionItems;

public sealed class SubscriptionItemsResourceTest
{
    [Fact]
    public void TestCanInitializeSubscriptionItemsResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionItemsResource = client.SubscriptionItemsResource();

        Assert.IsType<SubscriptionItemsResource>(subscriptionItemsResource);
    }

    [Fact]
    public async Task TestCanRetrieveSubscriptionItem()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionItemsResource = client.SubscriptionItemsResource();

        var response = await subscriptionItemsResource.RetrieveSubscriptionItemAsync(1131825);

        Assert.IsType<SubscriptionItemResponse>(response);
    }

    [Fact]
    public async Task TestCanListAllSubscriptionItems()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionItemsResource = client.SubscriptionItemsResource();

        var response = await subscriptionItemsResource.ListAllSubscriptionItemsAsync();

        Assert.IsType<SubscriptionItemsResponse>(response);
    }

    [Fact]
    public async Task TestCanUpdateSubscriptionItems()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionItemsResource = client.SubscriptionItemsResource();

        var response = await subscriptionItemsResource.UpdateSubscriptionItemAsync(subscriptionItemId: 1131825, data: new Dictionary<string, object>()
        {
            ["data"] = new Dictionary<string, object>()
            {
                ["type"] = "subscription-items",
                ["id"] = "1131825",
                ["attributes"] = new Dictionary<string, object>()
                {
                    ["quantity"] = "10"
                }
            }
        });

        Assert.IsType<SubscriptionItemResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveCurrentUsage()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionItemsResource = client.SubscriptionItemsResource();

        var response = await subscriptionItemsResource.RetrieveUsageRecordsAsync(1131825);

        Assert.IsType<UsageRecordsRelationShipResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveSubscriptionItemsSubscription()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionItemsResource = client.SubscriptionItemsResource();

        var response = await subscriptionItemsResource.RetrieveSubscriptionAsync(1131825);

        Assert.IsType<SubscriptionResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveSubscriptionItemsPrice()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionItemsResource = client.SubscriptionItemsResource();

        var response = await subscriptionItemsResource.RetrievePriceAsync(1131825);

        Assert.IsType<PriceResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveSubscriptionItemsUsageRecords()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionItemsResource = client.SubscriptionItemsResource();

        var response = await subscriptionItemsResource.RetrieveUsageRecordsAsync(1131825);

        Assert.IsType<UsageRecordsRelationShipResponse>(response);
    }
}
