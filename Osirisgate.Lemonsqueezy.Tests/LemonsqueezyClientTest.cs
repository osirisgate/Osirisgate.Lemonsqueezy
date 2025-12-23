using Osirisgate.Lemonsqueezy.Enums;
using Osirisgate.Lemonsqueezy.Exception;

namespace Osirisgate.Lemonsqueezy.Tests;

public sealed class LemonsqueezyClientTest
{
    [Fact]
    public void TestCanInitLemonsqueezyClientAndGetApiKey()
    {
        var client = LemonsqueezyClientFactory.Init("test_api_key");
        Assert.Equal("test_api_key", client.GetApiKey());
    }

    [Fact]
    public void TestCanNotInitLemonsqueezyClientWithEmptyApiKey()
    {
        var apiKey = "";
        try
        {
            var client = LemonsqueezyClientFactory.Init(apiKey);
        }
        catch (RuntimeException ex)
        {
            Assert.Equal(
                new Dictionary<string, object>
                {
                    ["status"] = Status.Error.GetValue(),
                    ["error_code"] = StatusCode.InternalServerError.GetValue(),
                    ["message"] = "API key cannot be empty.",
                    ["details"] = new Dictionary<string, object>
                    {
                        ["apiKey"] = apiKey
                    }
                },
                ex.Format()
            );
        }
    }

    [Fact]
    public void TestCanInitLemonsqueezyClientWithOptions()
    {
        var options = LemonsqueezyClientOptions.From("test_api_key")
            .WithBaseUrl("https://api.lemonsqueezy.com/v1/")
            .WithTimeout(TimeSpan.FromSeconds(60));

        var client = LemonsqueezyClientFactory.Init(options);

        Assert.NotNull(client);
    }

    [Fact]
    public void TestGetOptionsReturnsNullWhenInitWithApiKeyOnly()
    {
        var client = LemonsqueezyClientFactory.Init("test_api_key");

        Assert.Null(client.GetOptions());
    }

    [Fact]
    public void TestGetOptionsReturnsOptionsWhenInitWithOptions()
    {
        var options = LemonsqueezyClientOptions.From("test_api_key")
            .WithBaseUrl("https://custom.api.com/v1/")
            .WithTimeout(TimeSpan.FromSeconds(120));

        var client = LemonsqueezyClientFactory.Init(options);
        var retrievedOptions = client.GetOptions();

        Assert.NotNull(retrievedOptions);
        Assert.Equal(options.ApiKey, retrievedOptions!.ApiKey);
        Assert.Equal(options.BaseUrl, retrievedOptions!.BaseUrl);
        Assert.Equal(options.Timeout, retrievedOptions!.Timeout);
    }

    [Fact]
    public void TestCanNotInitLemonsqueezyClientWithNullOptions()
    {
        LemonsqueezyClientOptions? options = null;
        try
        {
            var client = LemonsqueezyClientFactory.Init(options!);
        }
        catch (Exception.ArgumentNullException ex)
        {
            Assert.Equal(
                new Dictionary<string, object>
                {
                    ["status"] = Status.Error.GetValue(),
                    ["error_code"] = StatusCode.BadRequest.GetValue(),
                    ["message"] = "Options cannot be null.",
                    ["details"] = new Dictionary<string, object>
                    {
                        ["parameterName"] = "options"
                    }
                },
                ex.Format()
            );
        }
    }

    [Fact]
    public void TestCanNotInitLemonsqueezyClientWithEmptyApiKeyInOptions()
    {
        try
        {
            var options = LemonsqueezyClientOptions.From("");
        }
        catch (Exception.ArgumentNullException ex)
        {
            Assert.Equal(
                new Dictionary<string, object>
                {
                    ["status"] = Status.Error.GetValue(),
                    ["error_code"] = StatusCode.BadRequest.GetValue(),
                    ["message"] = "API key cannot be null or empty.",
                    ["details"] = new Dictionary<string, object>
                    {
                        ["parameterName"] = "ApiKey"
                    }
                },
                ex.Format()
            );
        }
    }

    [Fact]
    public void TestCanInitLemonsqueezyClientWithDefaultOptions()
    {
        var options = LemonsqueezyClientOptions.From("test_api_key");

        var client = LemonsqueezyClientFactory.Init(options);

        Assert.Equal("test_api_key", client.GetApiKey());
        var retrievedOptions = client.GetOptions();
        Assert.NotNull(retrievedOptions);
        Assert.Equal("https://api.lemonsqueezy.com/v1/", retrievedOptions!.BaseUrl);
        Assert.Equal(TimeSpan.FromSeconds(30), retrievedOptions!.Timeout);
    }
}
