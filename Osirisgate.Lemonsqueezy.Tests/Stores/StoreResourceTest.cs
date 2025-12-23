using Osirisgate.Lemonsqueezy.Resource.Discounts.Response;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeys.Response;
using Osirisgate.Lemonsqueezy.Resource.Orders.Response;
using Osirisgate.Lemonsqueezy.Resource.Products.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions.Response;
using Osirisgate.Lemonsqueezy.Resource.Webhooks.Response;

namespace Osirisgate.Lemonsqueezy.Tests.Stores;

public sealed class StoreResourceTest
{
    [Fact]
    public void TestCanInitializeStoresResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var storesResource = client.StoresResource();

        Assert.IsType<StoresResource>(storesResource);
    }

    [Fact]
    public async Task TestCanRetrieveStore()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var storesResource = client.StoresResource();

        var response = await storesResource.RetrieveStoreAsync(178624);

        Assert.IsType<StoreResponse>(response);
    }

    [Fact]
    public async Task TestCanListAllStores()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var storesResource = client.StoresResource();

        var response = await storesResource.ListAllStoresAsync();

        Assert.IsType<StoresResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveStoreProducts()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var storesResource = client.StoresResource();

        var response = await storesResource.RetrieveProductsAsync(178624);

        Assert.IsType<ProductsRelationShipResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveStoreOrders()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var storesResource = client.StoresResource();

        var response = await storesResource.RetrieveOrdersAsync(178624);

        Assert.IsType<OrdersRelationShipResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveStoreSubscriptions()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var storesResource = client.StoresResource();

        var response = await storesResource.RetrieveSubscriptionsAsync(178624);

        Assert.IsType<SubscriptionsRelationShipResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveStoreDiscounts()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var storesResource = client.StoresResource();

        var response = await storesResource.RetrieveDiscountsAsync(178624);

        Assert.IsType<DiscountsRelationShipResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveStoreLicenseKeys()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var storesResource = client.StoresResource();

        var response = await storesResource.RetrieveLicenseKeysAsync(178624);

        Assert.IsType<LicenseKeysRelationShipResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveStoreWebhooks()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var storesResource = client.StoresResource();

        var response = await storesResource.RetrieveWebhooksAsync(178624);

        Assert.IsType<WebhooksRelationShipResponse>(response);
    }
}
