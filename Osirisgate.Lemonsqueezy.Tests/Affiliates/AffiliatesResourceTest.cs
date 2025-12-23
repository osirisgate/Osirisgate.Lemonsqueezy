using Osirisgate.Lemonsqueezy.Resource.Affiliates;
using Osirisgate.Lemonsqueezy.Resource.Affiliates.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Users.Response;

namespace Osirisgate.Lemonsqueezy.Tests.Affiliates;

public sealed class AffiliatesResourceTest
{
    [Fact]
    public void TestCanInitializeAffiliatesResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var affiliatesResource = client.AffiliatesResource();

        Assert.IsType<AffiliatesResource>(affiliatesResource);
    }

    [Fact]
    public async Task TestCanRetrieveAffiliate()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var affiliatesResource = client.AffiliatesResource();

        var response = await affiliatesResource.RetrieveAffiliateAsync(1131825);

        Assert.IsType<AffiliateResponse>(response);
    }

    [Fact]
    public async Task TestCanListAllAffiliates()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var affiliatesResource = client.AffiliatesResource();

        var response = await affiliatesResource.ListAllAffiliatesAsync();

        Assert.IsType<AffiliatesResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveAffiliateStore()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var affiliatesResource = client.AffiliatesResource();

        var response = await affiliatesResource.RetrieveStoreAsync(1131825);

        Assert.IsType<StoreResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveAffiliateUser()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var affiliatesResource = client.AffiliatesResource();

        var response = await affiliatesResource.RetrieveUserAsync(1131825);

        Assert.IsType<UserResponse>(response);
    }
}
