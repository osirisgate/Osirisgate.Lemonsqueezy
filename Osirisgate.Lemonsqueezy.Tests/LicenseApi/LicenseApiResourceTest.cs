using Osirisgate.Lemonsqueezy.Model.LicenseApi;
using Osirisgate.Lemonsqueezy.Resource.LicenseApi;

namespace Osirisgate.Lemonsqueezy.Tests.LicenseApi;

public sealed class LicenseApiResourceTest
{
    [Fact]
    public void TestCanInitializeLicenseApiResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var licenseApiResource = client.LicenseApiResource();

        Assert.IsType<LicenseApiResource>(licenseApiResource);
    }

    [Fact]
    public async Task TestCanActivateLicenseKey()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var licenseApiResource = client.LicenseApiResource();

        var response = await licenseApiResource.ActivateLicenseKeyAsync(new Dictionary<string, object>
        {
            ["license_key"] = "38b1460a-5104-4067-a91d-77b872934d51",
            ["instance_name"] = "test_instance_name",
        });

        Assert.IsType<ActivateLicenseKey>(response);
    }

    [Fact]
    public async Task TestCanDeactivateLicenseKey()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var licenseApiResource = client.LicenseApiResource();

        var response = await licenseApiResource.DeactivateLicenseKeyAsync(new Dictionary<string, object>
        {
            ["license_key"] = "38b1460a-5104-4067-a91d-77b872934d51",
            ["instance_id"] = "f90ec370-fd83-46a5-8bbd-44a241e78665",
        });

        Assert.IsType<DeactivateLicenseKey>(response);
    }

    [Fact]
    public async Task TestCanValidateLicenseKey()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var licenseApiResource = client.LicenseApiResource();

        var response = await licenseApiResource.ValidateLicenseKeyAsync(new Dictionary<string, object>
        {
            ["license_key"] = "38b1460a-5104-4067-a91d-77b872934d51",
            ["instance_id"] = "f90ec370-fd83-46a5-8bbd-44a241e78665",
        });

        Assert.IsType<ValidateLicenseKey>(response);
    }
}
