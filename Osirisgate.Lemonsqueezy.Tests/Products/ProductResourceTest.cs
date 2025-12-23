using Osirisgate.Lemonsqueezy.Resource.Products;
using Osirisgate.Lemonsqueezy.Resource.Products.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Tests.Products;

public sealed class ProductResourceTest
{
    [Fact]
    public void TestCanInitializeProductsResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var productsResource = client.ProductsResource();

        Assert.IsType<ProductsResource>(productsResource);
    }

    [Fact]
    public async Task TestCanRetrieveProduct()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var productsResource = client.ProductsResource();

        var response = await productsResource.RetrieveProductAsync(719085);

        Assert.IsType<ProductResponse>(response);
    }

    [Fact]
    public async Task TestCanListAllProducts()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var productsResource = client.ProductsResource();

        var response = await productsResource.ListAllProductsAsync();

        Assert.IsType<ProductsResponse>(response);
    }

    [Fact]
    public async Task TestCanListAllProductsByStoreId()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var productsResource = client.ProductsResource();

        var response = await productsResource.ListAllProductsAsync(new Dictionary<string, object>
        {
            ["filter"] = new Dictionary<string, object>
            {
                ["store_id"] = 178624,
            },
            ["page"] = new Dictionary<string, object>
            {
                ["size"] = 20
            }
        });

        Assert.IsType<ProductsResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveStore()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var productsResource = client.ProductsResource();

        var response = await productsResource.RetrieveStoreAsync(719085);

        Assert.IsType<StoreResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveVariants()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var productsResource = client.ProductsResource();

        var response = await productsResource.RetrieveVariantsAsync(719085);

        Assert.IsType<VariantsRelationShipResponse>(response);
    }
}
