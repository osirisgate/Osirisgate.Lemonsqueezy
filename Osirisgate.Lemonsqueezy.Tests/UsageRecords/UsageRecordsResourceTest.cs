using Osirisgate.Lemonsqueezy.Resource.SubscriptionItems.Response;
using Osirisgate.Lemonsqueezy.Resource.UsageRecords;
using Osirisgate.Lemonsqueezy.Resource.UsageRecords.Response;

namespace Osirisgate.Lemonsqueezy.Tests.UsageRecords;

public sealed class UsageRecordsResourceTest
{
    [Fact]
    public void TestCanInitializeUsageRecordsResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var usageRecordsResource = client.UsageRecordsResource();

        Assert.IsType<UsageRecordsResource>(usageRecordsResource);
    }

    [Fact]
    public async Task TestCanRetrieveUsageRecord()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var usageRecordsResource = client.UsageRecordsResource();

        var response = await usageRecordsResource.RetrieveUsageRecordAsync(1131825);

        Assert.IsType<UsageRecordResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveUsageRecords()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var usageRecordsResource = client.UsageRecordsResource();

        var response = await usageRecordsResource.ListAllUsageRecordsAsync();

        Assert.IsType<UsageRecordsResponse>(response);
    }

    [Fact]
    public async Task TestCanCreateUsageRecord()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var usageRecordsResource = client.UsageRecordsResource();

        var response = await usageRecordsResource.CreateUsageRecordAsync(new Dictionary<string, object>
        {
            ["data"] = new Dictionary<string, object>
            {
                ["type"] = "usage-records",
                ["attributes"] = new Dictionary<string, object>
                {
                    ["quantity"] = 10
                },
                ["relationships"] = new Dictionary<string, object>
                {
                    ["subscription-item"] = new Dictionary<string, object>
                    {
                        ["data"] = new Dictionary<string, object>
                        {
                            ["type"] = "subscription-items",
                            ["id"] = "1"
                        }
                    }
                }
            }
        });

        Assert.IsType<UsageRecordResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveUsageRecordsSubscriptionItem()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var usageRecordsResource = client.UsageRecordsResource();

        var response = await usageRecordsResource.RetrieveSubscriptionItemAsync(1131825);

        Assert.IsType<SubscriptionItemResponse>(response);
    }
}
