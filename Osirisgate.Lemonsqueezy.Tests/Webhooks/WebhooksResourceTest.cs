using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Webhooks;
using Osirisgate.Lemonsqueezy.Resource.Webhooks.Response;

namespace Osirisgate.Lemonsqueezy.Tests.Webhooks;

public sealed class WebhooksResourceTest
{
    [Fact]
    public void TestCanInitializeWebhooksResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var webhooksResource = client.WebhooksResource();

        Assert.IsType<WebhooksResource>(webhooksResource);
    }

    [Fact]
    public async Task TestCanRetrieveWebhook()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var webhooksResource = client.WebhooksResource();

        var response = await webhooksResource.RetrieveWebhookAsync(1131825);

        Assert.IsType<WebhookResponse>(response);
    }

    [Fact]
    public async Task TestCanListAllWebhooks()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var webhooksResource = client.WebhooksResource();

        var response = await webhooksResource.ListAllWebhooksAsync();

        Assert.IsType<WebhooksResponse>(response);
    }

    [Fact]
    public async Task TestCreateWebhook()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var webhooksResource = client.WebhooksResource();

        var response = await webhooksResource.CreateWebhookAsync(new Dictionary<string, object>
        {
            ["data"] = new Dictionary<string, object>
            {
                ["type"] = "webhooks",
                ["attributes"] = new Dictionary<string, object>
                {
                    ["url"] = "https://mysite.com/webhooks/",
                    ["events"] = new List<string> { "order_created", "subscription_created", "subscription_updated", "subscription_expired" },
                    ["secret"] = "SIGNING_SECRET"
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

        Assert.IsType<WebhookResponse>(response);
    }

    [Fact]
    public async Task TestUpdateWebhook()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var webhooksResource = client.WebhooksResource();

        var response = await webhooksResource.UpdateWebhookAsync(webhookId: 1131825, data: new Dictionary<string, object>
        {
            ["data"] = new Dictionary<string, object>
            {
                ["type"] = "webhooks",
                ["attributes"] = new Dictionary<string, object>
                {
                    ["store_id"] = 1,
                    ["url"] = "https://mysite.com/webhooks/",
                    ["events"] = new List<string> { "order_created", "subscription_created", "subscription_updated", "subscription_expired" },
                    ["secret"] = "SIGNING_SECRET"
                }
            }
        });

        Assert.IsType<WebhookResponse>(response);
    }

    [Fact]
    public async Task TestCanDeleteWebhook()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var webhooksResource = client.WebhooksResource();

        var response = await webhooksResource.DeleteWebhookAsync(1131825);

        Assert.IsType<Dictionary<string, object>>(response);
    }

    [Fact]
    public async Task TestCanRetrieveWebhookStore()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var webhooksResource = client.WebhooksResource();

        var response = await webhooksResource.RetrieveStoreAsync(1131825);

        Assert.IsType<StoreResponse>(response);
    }
}
