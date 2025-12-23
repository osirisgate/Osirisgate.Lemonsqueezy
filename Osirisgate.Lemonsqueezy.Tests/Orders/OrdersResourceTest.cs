using System.ComponentModel;
using Osirisgate.Lemonsqueezy.Model.Discount;
using Osirisgate.Lemonsqueezy.Model.Order;
using Osirisgate.Lemonsqueezy.Model.Subscription;
using Osirisgate.Lemonsqueezy.Resource.Customers.Response;
using Osirisgate.Lemonsqueezy.Resource.DiscountRedemptions.Response;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeys.Response;
using Osirisgate.Lemonsqueezy.Resource.OrderItem.Response;
using Osirisgate.Lemonsqueezy.Resource.Orders;
using Osirisgate.Lemonsqueezy.Resource.Orders.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions.Response;

namespace Osirisgate.Lemonsqueezy.Tests.Orders;

public sealed class OrdersResourceTest
{
    [Fact]
    public void TestCanInitializeOrdersResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var ordersResource = client.OrdersResource();

        Assert.IsType<OrdersResource>(ordersResource);
    }

    [Fact]
    public async Task TestCanRetrieveOrder()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var ordersResource = client.OrdersResource();

        var response = await ordersResource.RetrieveOrderAsync(1131825);

        Assert.IsType<OrderResponse>(response);
    }

    [Fact]
    public async Task TestCanListAllOrders()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var ordersResource = client.OrdersResource();

        var response = await ordersResource.ListAllOrdersAsync();

        Assert.IsType<OrdersResponse>(response);
    }

    [Fact]
    public async Task TestCanGenerateOrderInvoice()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var ordersResource = client.OrdersResource();

        var response = await ordersResource.GenerateOrderInvoiceAsync(1131825);

        Assert.IsType<OrderInvoiceResponse>(response);
    }

    [Fact]
    public async Task TestCanIssueRefund()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var ordersResource = client.OrdersResource();

        var response = await ordersResource.IssueRefundAsync(orderId: 1131825, data: new Dictionary<string, object>()
        {
            ["data"] = new Dictionary<string, object>()
            {
                ["type"] = "orders",
                ["id"] = "1131825",
                ["attributes"] = new Dictionary<string, object>()
                {
                    ["amount"] = 100
                }
            }
        });

        Assert.IsType<Order>(response, exactMatch: false);
    }

    [Fact]
    public async Task TestCanRetrieveStore()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var ordersResource = client.OrdersResource();

        var response = await ordersResource.RetrieveStoreAsync(1131825);

        Assert.IsType<StoreResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveCustomer()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var ordersResource = client.OrdersResource();

        var response = await ordersResource.RetrieveCustomerAsync(1131825);

        Assert.IsType<CustomerResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveOrderItems()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var ordersResource = client.OrdersResource();

        var response = await ordersResource.RetrieveOrderItemsAsync(1131825);

        Assert.IsType<OrderItemsRelationShipResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveSubscriptions()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var ordersResource = client.OrdersResource();

        var response = await ordersResource.RetrieveSubscriptionsAsync(1131825);

        Assert.IsType<SubscriptionsRelationShipResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveLicenseKeys()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var ordersResource = client.OrdersResource();

        var response = await ordersResource.RetrieveLicenseKeysAsync(1131825);

        Assert.IsType<LicenseKeysRelationShipResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveDiscountRedemptions()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var ordersResource = client.OrdersResource();

        var response = await ordersResource.RetrieveDiscountRedemptionsAsync(1131825);

        Assert.IsType<DiscountRedemptionsRelationShipResponse>(response);
    }
}
