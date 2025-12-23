using Osirisgate.Lemonsqueezy.Exception;
using Osirisgate.Lemonsqueezy.Resource.Affiliates;
using Osirisgate.Lemonsqueezy.Resource.Checkouts;
using Osirisgate.Lemonsqueezy.Resource.Customers;
using Osirisgate.Lemonsqueezy.Resource.DiscountRedemptions;
using Osirisgate.Lemonsqueezy.Resource.Discounts;
using Osirisgate.Lemonsqueezy.Resource.Files;
using Osirisgate.Lemonsqueezy.Resource.LicenseApi;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeyInstances;
using Osirisgate.Lemonsqueezy.Resource.LicenseKeys;
using Osirisgate.Lemonsqueezy.Resource.OrderItem;
using Osirisgate.Lemonsqueezy.Resource.Orders;
using Osirisgate.Lemonsqueezy.Resource.Prices;
using Osirisgate.Lemonsqueezy.Resource.Products;
using Osirisgate.Lemonsqueezy.Resource.Stores;
using Osirisgate.Lemonsqueezy.Resource.SubscriptionInvoices;
using Osirisgate.Lemonsqueezy.Resource.SubscriptionItems;
using Osirisgate.Lemonsqueezy.Resource.Subscriptions;
using Osirisgate.Lemonsqueezy.Resource.UsageRecords;
using Osirisgate.Lemonsqueezy.Resource.Users;
using Osirisgate.Lemonsqueezy.Resource.Variants;
using Osirisgate.Lemonsqueezy.Resource.Webhooks;

namespace Osirisgate.Lemonsqueezy;

/// <summary>
/// Implementation of the Lemonsqueezy API client.
/// This class provides the main entry point for interacting with the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public class LemonsqueezyClient : ILemonsqueezyClient
{
    /// <summary>
    /// The API key used for authentication with the Lemonsqueezy API.
    /// </summary>
    private readonly string _apiKey;

    /// <summary>
    /// The configuration options for this client instance.
    /// </summary>
    private readonly LemonsqueezyClientOptions? _options;

    /// <summary>
    /// Private constructor to enforce initialization through the Init method.
    /// </summary>
    /// <param name="apiKey">The API key for authentication.</param>
    /// <param name="options">Optional configuration options.</param>
    private LemonsqueezyClient(string apiKey, LemonsqueezyClientOptions? options = null)
    {
        _apiKey = apiKey;
        _options = options;
    }

    /// <summary>
    /// Initializes a new instance of the Lemonsqueezy client.
    /// </summary>
    /// <param name="apiKey">The API key for authenticating with the Lemonsqueezy API.</param>
    /// <returns>A new instance of <see cref="ILemonsqueezyClient"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the API key is null or empty.</exception>
    public static ILemonsqueezyClient Init(string apiKey)
    {
        if (string.IsNullOrEmpty(apiKey))
        {
            throw new Exception.ArgumentNullException(new Dictionary<string, object>
            {
                ["message"] = "API key cannot be null or empty.",
                ["details"] = new Dictionary<string, object>
                {
                    ["parameterName"] = nameof(apiKey)
                }
            });
        }

        return new LemonsqueezyClient(apiKey);
    }

    /// <summary>
    /// Initializes a new instance of the Lemonsqueezy client with configuration options.
    /// </summary>
    /// <param name="options">The configuration options for the Lemonsqueezy client. Must be valid (created via LemonsqueezyClientOptions.From).</param>
    /// <returns>A new instance of <see cref="ILemonsqueezyClient"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when options is null.</exception>
    public static ILemonsqueezyClient Init(LemonsqueezyClientOptions options)
    {
        if (options == null)
        {
            throw new Exception.ArgumentNullException(new Dictionary<string, object>
            {
                ["message"] = "Options cannot be null.",
                ["details"] = new Dictionary<string, object>
                {
                    ["parameterName"] = nameof(options)
                }
            });
        }

        // Options are already validated during creation via factory methods and property setters
        return new LemonsqueezyClient(options.ApiKey, options);
    }

    /// <summary>
    /// Retrieves the API key associated with this client instance.
    /// </summary>
    /// <returns>The API key as a string.</returns>
    public string GetApiKey()
    {
        return _apiKey;
    }

    /// <summary>
    /// Retrieves the configuration options associated with this client instance.
    /// </summary>
    /// <returns>The configuration options, or null if initialized with API key only.</returns>
    public LemonsqueezyClientOptions? GetOptions()
    {
        return _options;
    }

    /// <summary>
    /// Provides access to the Users resource.
    /// </summary>
    /// <returns>An instance of <see cref="IUsersResource"/>.</returns>
    public IUsersResource UsersResource()
    {
        return Resource.Resource.Init<UsersResource>(this);
    }

    /// <summary>
    /// Provides access to the Stores resource.
    /// </summary>
    /// <returns>An instance of <see cref="IStoresResource"/>.</returns>
    public IStoresResource StoresResource()
    {
        return Resource.Resource.Init<StoresResource>(this);
    }

    /// <summary>
    /// Provides access to the Customers resource.
    /// </summary>
    /// <returns>An instance of <see cref="ICustomersResource"/>.</returns>
    public ICustomersResource CustomersResource()
    {
        return Resource.Resource.Init<CustomersResource>(this);
    }

    /// <summary>
    /// Provides access to the Products resource.
    /// </summary>
    /// <returns>An instance of <see cref="IProductsResource"/>.</returns>
    public IProductsResource ProductsResource()
    {
        return Resource.Resource.Init<ProductsResource>(this);
    }

    /// <summary>
    /// Provides access to the Variants resource.
    /// </summary>
    /// <returns>An instance of <see cref="IVariantsResource"/>.</returns>
    public IVariantsResource VariantsResource()
    {
        return Resource.Resource.Init<VariantsResource>(this);
    }

    /// <summary>
    /// Provides access to the Prices resource.
    /// </summary>
    /// <returns>An instance of <see cref="IPricesResource"/>.</returns>
    public IPricesResource PricesResource()
    {
        return Resource.Resource.Init<PricesResource>(this);
    }

    /// <summary>
    /// Provides access to the Files resource.
    /// </summary>
    /// <returns>An instance of <see cref="IFilesResource"/>.</returns>
    public IFilesResource FilesResource()
    {
        return Resource.Resource.Init<FilesResource>(this);
    }

    /// <summary>
    /// Provides access to the Orders resource.
    /// </summary>
    /// <returns>An instance of <see cref="IOrdersResource"/>.</returns>
    public IOrdersResource OrdersResource()
    {
        return Resource.Resource.Init<OrdersResource>(this);
    }

    /// <summary>
    /// Provides access to the Order Items resource.
    /// </summary>
    /// <returns>An instance of <see cref="IOrderItemsResource"/>.</returns>
    public IOrderItemsResource OrderItemsResource()
    {
        return Resource.Resource.Init<OrderItemsResource>(this);
    }

    /// <summary>
    /// Provides access to the Subscriptions resource.
    /// </summary>
    /// <returns>An instance of <see cref="ISubscriptionsResource"/>.</returns>
    public ISubscriptionsResource SubscriptionsResource()
    {
        return Resource.Resource.Init<SubscriptionsResource>(this);
    }

    /// <summary>
    /// Provides access to the Subscription Invoices resource.
    /// </summary>
    /// <returns>An instance of <see cref="ISubscriptionInvoicesResource"/>.</returns>
    public ISubscriptionInvoicesResource SubscriptionInvoicesResource()
    {
        return Resource.Resource.Init<SubscriptionInvoicesResource>(this);
    }

    /// <summary>
    /// Provides access to the Subscription Items resource.
    /// </summary>
    /// <returns>An instance of <see cref="ISubscriptionItemsResource"/>.</returns>
    public ISubscriptionItemsResource SubscriptionItemsResource()
    {
        return Resource.Resource.Init<SubscriptionItemsResource>(this);
    }

    /// <summary>
    /// Provides access to the Usage Records resource.
    /// </summary>
    /// <returns>An instance of <see cref="IUsageRecordsResource"/>.</returns>
    public IUsageRecordsResource UsageRecordsResource()
    {
        return Resource.Resource.Init<UsageRecordsResource>(this);
    }

    /// <summary>
    /// Provides access to the Discounts resource.
    /// </summary>
    /// <returns>An instance of <see cref="IDiscountsResource"/>.</returns>
    public IDiscountsResource DiscountsResource()
    {
        return Resource.Resource.Init<DiscountsResource>(this);
    }

    /// <summary>
    /// Provides access to the Discount Redemptions resource.
    /// </summary>
    /// <returns>An instance of <see cref="IDiscountRedemptionsResource"/>.</returns>
    public IDiscountRedemptionsResource DiscountRedemptionsResource()
    {
        return Resource.Resource.Init<DiscountRedemptionsResource>(this);
    }

    /// <summary>
    /// Provides access to the License Keys resource.
    /// </summary>
    /// <returns>An instance of <see cref="ILicenseKeysResource"/>.</returns>
    public ILicenseKeysResource LicenseKeysResource()
    {
        return Resource.Resource.Init<LicenseKeysResource>(this);
    }

    /// <summary>
    /// Provides access to the License Key Instances resource.
    /// </summary>
    /// <returns>An instance of <see cref="ILicenseKeyInstancesResource"/>.</returns>
    public ILicenseKeyInstancesResource LicenseKeyInstancesResource()
    {
        return Resource.Resource.Init<LicenseKeyInstancesResource>(this);
    }

    /// <summary>
    /// Provides access to the Checkouts resource.
    /// </summary>
    /// <returns>An instance of <see cref="ICheckoutsResource"/>.</returns>
    public ICheckoutsResource CheckoutsResource()
    {
        return Resource.Resource.Init<CheckoutsResource>(this);
    }

    /// <summary>
    /// Provides access to the Webhooks resource.
    /// </summary>
    /// <returns>An instance of <see cref="IWebhooksResource"/>.</returns>
    public IWebhooksResource WebhooksResource()
    {
        return Resource.Resource.Init<WebhooksResource>(this);
    }

    /// <summary>
    /// Provides access to the License API resource.
    /// </summary>
    /// <returns>An instance of <see cref="ILicenseApiResource"/>.</returns>
    public ILicenseApiResource LicenseApiResource()
    {
        return Resource.Resource.Init<LicenseApiResource>(this);
    }

    /// <summary>
    /// Provides access to the Affiliates resource.
    /// </summary>
    /// <returns>An instance of <see cref="IAffiliatesResource"/>.</returns>
    public IAffiliatesResource AffiliatesResource()
    {
        return Resource.Resource.Init<AffiliatesResource>(this);
    }
}
