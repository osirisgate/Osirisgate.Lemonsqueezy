using System.ComponentModel;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeyInstances;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeyInstances.Response;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeys.Response;

namespace Osirisgate.Lemonsqueezy.Tests.LicenseKeyInstances;

public sealed class LicenseKeyInstancesResourceTest
{
    [Fact]
    public void TestCanInitializeLicenseKeyInstancesResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var licenseKeyInstancesResource = client.LicenseKeyInstancesResource();

        Assert.IsType<LicenseKeyInstancesResource>(licenseKeyInstancesResource);
    }

    [Fact]
    public async Task TestCanRetrieveLicenseKeyInstance()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var licenseKeyInstancesResource = client.LicenseKeyInstancesResource();

        var response = await licenseKeyInstancesResource.RetrieveLicenseKeyInstanceAsync(1131825);

        Assert.IsType<LicenseKeyInstanceResponse>(response);
    }

    [Fact]
    public async Task TestCanListAllLicenseKeyInstances()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var licenseKeyInstancesResource = client.LicenseKeyInstancesResource();

        var response = await licenseKeyInstancesResource.ListAllLicenseKeyInstancesAsync();

        Assert.IsType<LicenseKeyInstancesResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveLicenseKeyInstanceLicenseKey()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var licenseKeyInstancesResource = client.LicenseKeyInstancesResource();

        var response = await licenseKeyInstancesResource.RetrieveLicenseKeyAsync(1131825);

        Assert.IsType<LicenseKeyResponse>(response);
    }
}
