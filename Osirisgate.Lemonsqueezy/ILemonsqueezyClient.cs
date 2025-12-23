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
/// Main interface for interacting with the Lemonsqueezy API.
/// Provides access to all available resource endpoints for managing stores, products, subscriptions, and more.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface ILemonsqueezyClient
{
    /// <summary>
    /// Retrieves the API key associated with this client instance.
    /// </summary>
    /// <returns>The API key as a string.</returns>
    public string GetApiKey();

    /// <summary>
    /// Retrieves the configuration options associated with this client instance.
    /// </summary>
    /// <returns>The configuration options, or null if initialized with API key only.</returns>
    public LemonsqueezyClientOptions? GetOptions();

    /// <summary>
    /// Provides access to the Users resource for managing user accounts.
    /// </summary>
    /// <returns>An instance of <see cref="IUsersResource"/>.</returns>
    public IUsersResource UsersResource();

    /// <summary>
    /// Provides access to the Stores resource for managing stores.
    /// </summary>
    /// <returns>An instance of <see cref="IStoresResource"/>.</returns>
    public IStoresResource StoresResource();

    /// <summary>
    /// Provides access to the Customers resource for managing customers.
    /// </summary>
    /// <returns>An instance of <see cref="ICustomersResource"/>.</returns>
    public ICustomersResource CustomersResource();

    /// <summary>
    /// Provides access to the Products resource for managing products.
    /// </summary>
    /// <returns>An instance of <see cref="IProductsResource"/>.</returns>
    public IProductsResource ProductsResource();

    /// <summary>
    /// Provides access to the Variants resource for managing product variants.
    /// </summary>
    /// <returns>An instance of <see cref="IVariantsResource"/>.</returns>
    public IVariantsResource VariantsResource();

    /// <summary>
    /// Provides access to the Prices resource for managing pricing information.
    /// </summary>
    /// <returns>An instance of <see cref="IPricesResource"/>.</returns>
    public IPricesResource PricesResource();

    /// <summary>
    /// Provides access to the Files resource for managing product files.
    /// </summary>
    /// <returns>An instance of <see cref="IFilesResource"/>.</returns>
    public IFilesResource FilesResource();

    /// <summary>
    /// Provides access to the Orders resource for managing orders.
    /// </summary>
    /// <returns>An instance of <see cref="IOrdersResource"/>.</returns>
    public IOrdersResource OrdersResource();

    /// <summary>
    /// Provides access to the Order Items resource for managing individual order items.
    /// </summary>
    /// <returns>An instance of <see cref="IOrderItemsResource"/>.</returns>
    public IOrderItemsResource OrderItemsResource();

    /// <summary>
    /// Provides access to the Subscriptions resource for managing recurring subscriptions.
    /// </summary>
    /// <returns>An instance of <see cref="ISubscriptionsResource"/>.</returns>
    public ISubscriptionsResource SubscriptionsResource();

    /// <summary>
    /// Provides access to the Subscription Invoices resource for managing subscription billing invoices.
    /// </summary>
    /// <returns>An instance of <see cref="ISubscriptionInvoicesResource"/>.</returns>
    public ISubscriptionInvoicesResource SubscriptionInvoicesResource();

    /// <summary>
    /// Provides access to the Subscription Items resource for managing individual subscription items.
    /// </summary>
    /// <returns>An instance of <see cref="ISubscriptionItemsResource"/>.</returns>
    public ISubscriptionItemsResource SubscriptionItemsResource();

    /// <summary>
    /// Provides access to the Usage Records resource for tracking usage-based billing.
    /// </summary>
    /// <returns>An instance of <see cref="IUsageRecordsResource"/>.</returns>
    public IUsageRecordsResource UsageRecordsResource();

    /// <summary>
    /// Provides access to the Discounts resource for managing discount codes and campaigns.
    /// </summary>
    /// <returns>An instance of <see cref="IDiscountsResource"/>.</returns>
    public IDiscountsResource DiscountsResource();

    /// <summary>
    /// Provides access to the Discount Redemptions resource for tracking discount usage.
    /// </summary>
    /// <returns>An instance of <see cref="IDiscountRedemptionsResource"/>.</returns>
    public IDiscountRedemptionsResource DiscountRedemptionsResource();

    /// <summary>
    /// Provides access to the License Keys resource for managing software licenses.
    /// </summary>
    /// <returns>An instance of <see cref="ILicenseKeysResource"/>.</returns>
    public ILicenseKeysResource LicenseKeysResource();

    /// <summary>
    /// Provides access to the License Key Instances resource for managing license activations.
    /// </summary>
    /// <returns>An instance of <see cref="ILicenseKeyInstancesResource"/>.</returns>
    public ILicenseKeyInstancesResource LicenseKeyInstancesResource();

    /// <summary>
    /// Provides access to the Checkouts resource for managing checkout sessions.
    /// </summary>
    /// <returns>An instance of <see cref="ICheckoutsResource"/>.</returns>
    public ICheckoutsResource CheckoutsResource();

    /// <summary>
    /// Provides access to the Webhooks resource for managing webhook endpoints and events.
    /// </summary>
    /// <returns>An instance of <see cref="IWebhooksResource"/>.</returns>
    public IWebhooksResource WebhooksResource();

    /// <summary>
    /// Provides access to the License API resource for license validation and activation operations.
    /// </summary>
    /// <returns>An instance of <see cref="ILicenseApiResource"/>.</returns>
    public ILicenseApiResource LicenseApiResource();

    /// <summary>
    /// Provides access to the Affiliates resource for managing affiliate partnerships.
    /// </summary>
    /// <returns>An instance of <see cref="IAffiliatesResource"/>.</returns>
    public IAffiliatesResource AffiliatesResource();
}
