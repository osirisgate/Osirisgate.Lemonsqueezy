using Osirisgate.Lemonsqueezy.Resource.OrderItem;
using Osirisgate.Lemonsqueezy.Resource.OrderItem.Response;
using Osirisgate.Lemonsqueezy.Resource.Orders.Response;
using Osirisgate.Lemonsqueezy.Resource.Products.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Tests.OrderItems;

public sealed class OrderItemsResourceTest
{
    [Fact]
    public void TestCanInitializeOrderItemsResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var orderItemsResource = client.OrderItemsResource();

        Assert.IsType<OrderItemsResource>(orderItemsResource);
    }

    [Fact]
    public async Task TestCanRetrieveOrderItem()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var orderItemsResource = client.OrderItemsResource();

        var response = await orderItemsResource.RetrieveOrderItemAsync(1131825);

        Assert.IsType<OrderItemResponse>(response);
    }

    [Fact]
    public async Task TestCanListAllOrderItems()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var orderItemsResource = client.OrderItemsResource();

        var response = await orderItemsResource.ListAllOrderItemsAsync();

        Assert.IsType<OrderItemsResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveOrder()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var orderItemsResource = client.OrderItemsResource();

        var response = await orderItemsResource.RetrieveOrderAsync(1131825);

        Assert.IsType<OrderResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveProduct()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var orderItemsResource = client.OrderItemsResource();

        var response = await orderItemsResource.RetrieveProductAsync(1131825);

        Assert.IsType<ProductResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveVariant()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var orderItemsResource = client.OrderItemsResource();

        var response = await orderItemsResource.RetrieveVariantAsync(1131825);

        Assert.IsType<VariantResponse>(response);
    }
}
