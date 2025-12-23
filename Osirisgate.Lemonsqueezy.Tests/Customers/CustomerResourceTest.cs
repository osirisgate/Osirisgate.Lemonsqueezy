using Osirisgate.Lemonsqueezy.Enums;
using Osirisgate.Lemonsqueezy.Exception;
using Osirisgate.Lemonsqueezy.Resource.Customers;
using Osirisgate.Lemonsqueezy.Resource.Customers.Response;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeys.Response;
using Osirisgate.Lemonsqueezy.Resource.Orders.Response;
using Osirisgate.Lemonsqueezy.Resource.Stores.Response;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions.Response;

namespace Osirisgate.Lemonsqueezy.Tests.Customers;

public sealed class CustomerResourceTest
{
    [Fact]
    public void TestCanInitializeCustomersResource()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var customersResource = client.CustomersResource();

        Assert.IsType<CustomersResource>(customersResource);
    }

    [Fact]
    public async Task TestCanNotCreateCustomerWithEmptyData()
    {
        var data = new Dictionary<string, object>();
        try
        {
            var apiKey = "test_api_key";
            var client = LemonsqueezyClientFactory.Init(apiKey);

            var customersResource = client.CustomersResource();

            var response = await customersResource.CreateCustomerAsync(data);
        }
        catch (BadRequestContentException ex)
        {
            Assert.Equal(new Dictionary<string, object>
            {
                ["status"] = Status.Error.GetValue(),
                ["error_code"] = StatusCode.BadRequest.GetValue(),
                ["message"] = "Request data is mandatory for POST|PUT|PATCH requests.",
                ["details"] = new Dictionary<string, object>
                {
                    ["data"] = data
                }
            }, ex.Format());
        }
    }

    [Fact]
    public async Task TestCanCreateCustomerIncludeOptionalData()
    {
        var data = new Dictionary<string, object>
        {
            ["data"] = new Dictionary<string, object>
            {
                ["type"] = "customers",
                ["attributes"] = new Dictionary<string, object>
                {
                    ["name"] = "Kendy Doe",
                    ["email"] = "kendy.doe@example.com",
                    ["city"] = "New York",
                    ["region"] = "NY",
                    ["country"] = "US"
                },
                ["relationships"] = new Dictionary<string, object>
                {
                    ["store"] = new Dictionary<string, object>
                    {
                        ["data"] = new Dictionary<string, object>
                        {
                            ["type"] = "stores",
                            ["id"] = "178624"
                        }
                    }
                }
            }
        };

        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var customersResource = client.CustomersResource();

        var response = await customersResource.CreateCustomerAsync(data);

        Assert.IsType<CustomerResponse>(response);

        Assert.Equal("Kendy Doe", response.Data.Attributes.Name);
        Assert.Equal("kendy.doe@example.com", response.Data.Attributes.Email);
        Assert.Equal("New York", response.Data.Attributes.City);
        Assert.Equal("NY", response.Data.Attributes.Region);
        Assert.Equal("US", response.Data.Attributes.Country);
    }

    [Fact]
    public async Task TestCanRetrieveCustomer()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var customersResource = client.CustomersResource();

        var response = await customersResource.RetrieveCustomerAsync(7299024);

        Assert.IsType<CustomerResponse>(response);

        Assert.Equal("7299024", response.Data.Id);
    }

    [Fact]
    public async Task TestCanListAllCustomers()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var customersResource = client.CustomersResource();

        var response = await customersResource.ListAllCustomersAsync();

        Assert.IsType<CustomersResponse>(response);
    }

    [Fact]
    public async Task TestCanListAllCustomersByStoreId()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var customersResource = client.CustomersResource();

        var response = await customersResource.ListAllCustomersAsync(filters: new Dictionary<string, object>
        {
            { "filter", new Dictionary<string, object> { { "store_id", 178624 } } }
        });

        Assert.IsType<CustomersResponse>(response);
    }

    [Fact]
    public async Task TestCanUpdateCustomer()
    {
        var customerId = 7299024;
        var data = new Dictionary<string, object>
        {
            ["data"] = new Dictionary<string, object>
            {
                ["type"] = "customers",
                ["id"] = customerId.ToString(),
                ["attributes"] = new Dictionary<string, object>
                {
                    ["name"] = "Kendy Doe II",
                    ["email"] = "kendy.doe2@example.com",
                    ["status"] = "archived",
                }
            }
        };

        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var customersResource = client.CustomersResource();

        var response = await customersResource.UpdateCustomerAsync(customerId, data);

        Assert.IsType<CustomerResponse>(response);

        Assert.Equal("Kendy Doe II", response.Data.Attributes.Name);
        Assert.Equal("kendy.doe2@example.com", response.Data.Attributes.Email);
        Assert.Equal("New York", response.Data.Attributes.City);
        Assert.Equal("NY", response.Data.Attributes.Region);
        Assert.Equal("US", response.Data.Attributes.Country);
        Assert.Equal("archived", response.Data.Attributes.Status);
    }

    [Fact]
    public async Task TestCanRetrieveStore()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var customersResource = client.CustomersResource();

        var response = await customersResource.RetrieveStoreAsync(7299024);

        Assert.IsType<StoreResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveOrders()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var customersResource = client.CustomersResource();

        var response = await customersResource.RetrieveOrdersAsync(7299024);

        Assert.IsType<OrdersRelationShipResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveSubscriptions()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var customersResource = client.CustomersResource();

        var response = await customersResource.RetrieveSubscriptionsAsync(7299024);

        Assert.IsType<SubscriptionsRelationShipResponse>(response);
    }

    [Fact]
    public async Task TestCanRetrieveLicenseKeys()
    {
        var apiKey = "test_api_key";
        var client = LemonsqueezyClientFactory.Init(apiKey);

        var customersResource = client.CustomersResource();

        var response = await customersResource.RetrieveLicenseKeysAsync(7299024);

        Assert.IsType<LicenseKeysRelationShipResponse>(response);
    }
}
