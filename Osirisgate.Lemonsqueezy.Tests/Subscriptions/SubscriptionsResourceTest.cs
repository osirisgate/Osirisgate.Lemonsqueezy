using Osirisgate.Lemonsqueezy.Model.Subscription;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions.Response;

namespace Osirisgate.Lemonsqueezy.Tests.Subscriptions;

public sealed class SubscriptionsResourceTest
{
    [Fact]
    public void TestCanInitializeSubscriptionsResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionsResource = client.SubscriptionsResource();

        Assert.IsType<SubscriptionsResource>(subscriptionsResource);
    }

    [Fact]
    public async Task TestCanRetrieveSubscription()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionsResource = client.SubscriptionsResource();

        var response = await subscriptionsResource.RetrieveSubscriptionAsync(1131825);

        Assert.IsType<SubscriptionResponse>(response);
    }

    [Fact]
    public async Task TestCanListAllSubscriptions()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionsResource = client.SubscriptionsResource();

        var response = await subscriptionsResource.ListAllSubscriptionsAsync();

        Assert.IsType<SubscriptionsResponse>(response);
    }

    [Fact]
    public async Task TestCanUpdateSubscription()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionsResource = client.SubscriptionsResource();

        var response = await subscriptionsResource.UpdateSubscriptionAsync(subscriptionId: 1131825, data: new Dictionary<string, object>()
        {
            ["data"] = new Dictionary<string, object>()
            {
                ["type"] = "subscriptions",
                ["id"] = "1131825",
                ["attributes"] = new Dictionary<string, object>()
                {
                    ["variant_id"] = "11"
                }
            }
        });

        Assert.IsType<Subscription>(response, exactMatch: false);
    }

    [Fact]
    public async Task TestCanCancelSubscription()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionsResource = client.SubscriptionsResource();

        var response = await subscriptionsResource.CancelSubscriptionAsync(1131825);

        Assert.IsType<SubscriptionResponse>(response);
    }
}
