using Osirisgate.Lemonsqueezy.Resource.Files;
using Osirisgate.Lemonsqueezy.Resource.Files.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Tests.Files;

public sealed class FilesResourceTest
{
    [Fact]
    public void TestCanInitializeFilesResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var filesResource = client.FilesResource();

        Assert.IsType<FilesResource>(filesResource);
    }

    [Fact]
    public void TestCanRetrieveFile()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var filesResource = client.FilesResource();

        var response = filesResource.RetrieveFileAsync(1131825);

        Assert.IsType<FileResponse>(response);
    }

    [Fact]
    public void TestCanListAllFiles()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var filesResource = client.FilesResource();

        var response = filesResource.ListAllFilesAsync();

        Assert.IsType<FilesResponse>(response);
    }

    [Fact]
    public void TestCanRetrieveFileVariant()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var filesResource = client.FilesResource();

        var response = filesResource.RetrieveVariantAsync(1131825);

        Assert.IsType<VariantResponse>(response);
    }
}
