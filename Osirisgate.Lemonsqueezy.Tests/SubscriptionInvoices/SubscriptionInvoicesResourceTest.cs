using Osirisgate.Lemonsqueezy.Resource.Customers.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.SubscriptionInvoices;
using Osirisgate.Lemonsqueezy.Resource.SubscriptionInvoices.Response;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions.Response;

namespace Osirisgate.Lemonsqueezy.Tests.SubscriptionInvoices;

public sealed class SubscriptionInvoicesResourceTest
{
    [Fact]
    public void TestCanInitializeSubscriptionInvoicesResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionInvoicesResource = client.SubscriptionInvoicesResource();

        Assert.IsType<SubscriptionInvoicesResource>(subscriptionInvoicesResource);
    }

    [Fact]
    public async Task TestCanRetrieveSubscriptionInvoice()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionInvoicesResource = client.SubscriptionInvoicesResource();

        var response = await subscriptionInvoicesResource.RetrieveSubscriptionInvoiceAsync(1131825);

        Assert.IsType<SubscriptionInvoiceResponse>(response);
    }

    [Fact]
    public async Task TestCanListAllSubscriptionInvoices()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionInvoicesResource = client.SubscriptionInvoicesResource();

        var response = await subscriptionInvoicesResource.ListAllSubscriptionInvoicesAsync();

        Assert.IsType<SubscriptionInvoicesResponse>(response);
    }

    [Fact]
    public async Task TestCanGenerateSubscriptionInvoice()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionInvoicesResource = client.SubscriptionInvoicesResource();

        var response = await subscriptionInvoicesResource.GenerateSubscriptionInvoiceAsync(1131825);

        Assert.IsType<GenerateSubscriptionInvoiceResponse>(response);
    }

    [Fact]
    public async Task TestCanIssueRefund()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionInvoicesResource = client.SubscriptionInvoicesResource();

        var response = await subscriptionInvoicesResource.IssueRefundAsync(subscriptionInvoiceId: 1131825, data: new Dictionary<string, object>()
        {
            ["data"] = new Dictionary<string, object>()
            {
                ["type"] = "subscription-invoices",
                ["id"] = "1131825",
                ["attributes"] = new Dictionary<string, object>()
                {
                    ["amount"] = 100
                }
            }
        });

        Assert.IsType<SubscriptionInvoiceResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveStore()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionInvoicesResource = client.SubscriptionInvoicesResource();

        var response = await subscriptionInvoicesResource.RetrieveStoreAsync(1131825);

        Assert.IsType<StoreResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveSubscription()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionInvoicesResource = client.SubscriptionInvoicesResource();

        var response = await subscriptionInvoicesResource.RetrieveSubscriptionAsync(1131825);

        Assert.IsType<SubscriptionResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveCustomer()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var subscriptionInvoicesResource = client.SubscriptionInvoicesResource();

        var response = await subscriptionInvoicesResource.RetrieveCustomerAsync(1131825);

        Assert.IsType<CustomerResponse>(response);
    }
}
