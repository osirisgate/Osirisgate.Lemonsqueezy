using Osirisgate.Lemonsqueezy.Resource.Users;
using Osirisgate.Lemonsqueezy.Resource.Users.Response;

namespace Osirisgate.Lemonsqueezy.Tests.Users;

public sealed class UserResourceTest
{
    [Fact]
    public void TestCanInitializeUsersResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var usersResource = client.UsersResource();

        Assert.IsType<UsersResource>(usersResource);
    }

    [Fact]
    public async Task TestCanRetrieveUser()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var usersResource = client.UsersResource();

        var response = await usersResource.RetrieveUserAsync();

        Assert.IsType<UserResponse>(response);
    }
}
