# Osirisgate Lemonsqueezy C# SDK

![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)
![.NET](https://img.shields.io/badge/.NET-8.0-purple.svg)
![.NET](https://img.shields.io/badge/.NET-9.0-purple.svg)
![.NET](https://img.shields.io/badge/.NET-10.0-purple.svg)
![C#](https://img.shields.io/badge/C%23-12.0-green.svg)

Lightweight, developer first SDK to interact with the Lemonsqueezy API. Built with modern C#. Focused on simplicity, readability and full control.

## Table of contents

- [Installation](#installation)
- [Requirements](#requirements)
- [Getting started](#getting-started)
  - [Basic usage](#basic-usage)
  - [Initialization with options](#initialization-with-options)
  - [Configuration options](#configuration-options)
- [Dependency injection setup (ASP.NET Core)](#dependency-injection-setup-aspnet-core)
  - [Configuration](#configuration)
  - [Simple registration (API key only)](#simple-registration-api-key-only)
  - [Registration with options](#registration-with-options)
  - [Manual registration (without extension methods)](#manual-registration-without-extension-methods)
  - [Using the client in controllers](#using-the-client-in-controllers)
  - [Webhook validation middleware](#webhook-validation-middleware)
- [HTTP extensions](#http-extensions)
  - [Parsing nested query parameters](#parsing-nested-query-parameters)
- [Available resources](#available-resources)
  - [Users resource](#users-resource)
  - [Stores resource](#stores-resource)
  - [Customers resource](#customers-resource)
  - [Products resource](#products-resource)
  - [Variants resource](#variants-resource)
  - [Prices resource](#prices-resource)
  - [Files resource](#files-resource)
  - [Orders resource](#orders-resource)
  - [Order items resource](#order-items-resource)
  - [Subscriptions resource](#subscriptions-resource)
  - [Subscription invoices resource](#subscription-invoices-resource)
  - [Subscription items resource](#subscription-items-resource)
  - [Usage records resource](#usage-records-resource)
  - [Discounts resource](#discounts-resource)
  - [Discount redemptions resource](#discount-redemptions-resource)
  - [License keys resource](#license-keys-resource)
  - [License key instances resource](#license-key-instances-resource)
  - [Checkouts resource](#checkouts-resource)
  - [Webhooks resource](#webhooks-resource)
  - [License API resource](#license-api-resource)
  - [Affiliates resource](#affiliates-resource)
- [Webhooks](#webhooks)
  - [Event types](#event-types)
  - [Webhook payload types](#webhook-payload-types)
  - [Deserializing webhook payloads](#deserializing-webhook-payloads)
  - [Manual validating webhook signatures](#manual-validating-webhook-signatures)
  - [Automatic webhook validation middleware](#automatic-webhook-validation-middleware)
  - [Using webhook extensions (recommended)](#using-webhook-extensions-recommended)
  - [Security best practices](#security-best-practices)
- [Error handling](#error-handling)
  - [Available exception methods](#available-exception-methods)
  - [Exception types](#exception-types)
  - [Error handling examples](#error-handling-examples)
  - [Using Format() method](#using-format-method)
- [Advanced usage](#advanced-usage)
  - [CancellationToken support](#cancellationtoken-support)
  - [Automatic retry for transient errors](#automatic-retry-for-transient-errors)
  - [Rate limit handling](#rate-limit-handling)
- [Learning more](#learning-more)
  - [Source code](#source-code)
  - [Test suite](#test-suite)
  - [Demo API project](#demo-api-project)
- [About](#about)
  - [Author](#author)
  - [License](#license)
  - [Support](#support)

## Installation

```bash
# Via .NET CLI
dotnet add package Osirisgate.Lemonsqueezy

# Via Package Manager
Install-Package Osirisgate.Lemonsqueezy

# Via PackageReference
<PackageReference Include="Osirisgate.Lemonsqueezy" Version="1.0.0" />
```

## Requirements

* .NET 10.0 or higher
* C# 12.0 or higher

## Getting started

### Basic usage

```csharp
using Osirisgate.Lemonsqueezy;

var client = LemonsqueezyClientFactory.Init("your-api-key");
var user = await client.UsersResource().RetrieveUserAsync(CancellationToken.None);
```

### Initialization with options

```csharp
var options = LemonsqueezyClientOptions.From("your-api-key")
    .WithBaseUrl("https://api.lemonsqueezy.com/v1/") // Optional, defaults to production
    .WithTimeout(TimeSpan.FromSeconds(60)) // Optional, defaults to 30 seconds
    .WithRetryCount(3); // Optional, defaults to 3 retries for transient errors

var client = LemonsqueezyClientFactory.Init(options);
```

### Configuration options

```csharp
var options = LemonsqueezyClientOptions.From("your-api-key")
    .WithBaseUrl("https://api.lemonsqueezy.com/v1/") // Optional
    .WithTimeout(TimeSpan.FromSeconds(60)) // Optional, defaults to 30 seconds
    .WithRetryCount(3); // Optional, defaults to 3 retries for transient errors
```

**Available options**
- `ApiKey` (required) - Your Lemonsqueezy API key
- `BaseUrl` (optional) - API base URL, defaults to production (`https://api.lemonsqueezy.com/v1/`)
- `Timeout` (optional) - HTTP request timeout, defaults to 30 seconds
- `RetryCount` (optional) - Number of automatic retry attempts for transient errors (HTTP 5xx and RequestTimeout), defaults to 3 retries with exponential backoff (2s, 4s, 8s)

## Dependency injection setup (ASP.NET Core)

The SDK provides extension methods to simplify service registration. All extension methods are available in the `Osirisgate.Lemonsqueezy.Extensions` namespace.

### Configuration

The SDK reads configuration from the `Lemonsqueezy` section in `appsettings.json`. You must set the required environment variables, and ASP.NET Core will automatically read them.

#### appsettings.json

Create or update your `appsettings.json` file with the following structure:

```json
{
  "Lemonsqueezy": {
    "ApiKey": "",
    "BaseUrl": "https://api.lemonsqueezy.com/v1/",
    "WebhookSecret": "",
    "Timeout": 30,
    "RetryCount": 3
  }
}
```

**Important:** For security, do not hardcode sensitive values in `appsettings.json`. Instead, use environment variables or `appsettings.Development.json` for local development.

#### Required environment variables

The following environment variables **must** be set:

- `Lemonsqueezy:ApiKey` - Your Lemonsqueezy API key (required for all SDK operations)
- `Lemonsqueezy:WebhookSecret` - Webhook signing secret (required only if using webhook validation)

#### Optional environment variables

- `Lemonsqueezy:BaseUrl` - API base URL (defaults to `https://api.lemonsqueezy.com/v1/` if not set)
- `Lemonsqueezy:Timeout` - HTTP request timeout in seconds (defaults to `30` if not set)
- `Lemonsqueezy:RetryCount` - Number of retry attempts for transient errors (defaults to `3` if not set)

#### Using appsettings.Development.json for local development

For local development, you can override values in `appsettings.Development.json`:

```json
{
  "Lemonsqueezy": {
    "ApiKey": "your-local-api-key",
    "WebhookSecret": "your-local-webhook-secret",
    "BaseUrl": "https://api.lemonsqueezy.com/v1/",
    "Timeout": 60,
    "RetryCount": 3
  }
}
```

**Security note** Add `appsettings.Development.json` to `.gitignore` to prevent committing sensitive values to version control. In production, always use environment variables for sensitive values like API keys and webhook secrets.

### Simple registration (API key only)

For a simple initialization with only the API key (uses default options):

```csharp
using Osirisgate.Lemonsqueezy.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Register Lemonsqueezy Client with API key from configuration
builder.Services.AddLemonsqueezy();

// Optionally register webhook validator
builder.Services.AddLemonsqueezyWebhookValidator();

var app = builder.Build();
app.MapControllers();
app.Run();
```

**Alternative: Direct API key**

```csharp
using Osirisgate.Lemonsqueezy.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Register with explicit API key
builder.Services.AddLemonsqueezy("your-api-key");

var app = builder.Build();
app.MapControllers();
app.Run();
```

### Registration with options

For a complete configuration with all options from configuration:

```csharp
using Osirisgate.Lemonsqueezy.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Register Lemonsqueezy Client with full options from configuration
builder.Services.AddLemonsqueezyWithOptions();

// Register webhook signature validator
builder.Services.AddLemonsqueezyWebhookValidator();

var app = builder.Build();
app.MapControllers();
app.Run();
```

**Alternative: Explicit options**

```csharp
using Osirisgate.Lemonsqueezy;
using Osirisgate.Lemonsqueezy.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Register with explicit options object
var options = LemonsqueezyClientOptions.From("your-api-key")
    .WithBaseUrl("https://api.lemonsqueezy.com/v1/")
    .WithTimeout(TimeSpan.FromSeconds(60))
    .WithRetryCount(3);
builder.Services.AddLemonsqueezy(options);

// Register webhook validator with explicit secret
builder.Services.AddLemonsqueezyWebhookValidator("your-webhook-secret");

var app = builder.Build();
app.MapControllers();
app.Run();
```

### Manual registration (without extension methods)

If you prefer manual registration without extension methods:

```csharp
using Osirisgate.Lemonsqueezy;
using Osirisgate.Lemonsqueezy.Events.Webhook;
using Osirisgate.Lemonsqueezy.Exception;

var builder = WebApplication.CreateBuilder(args);

// Register Lemonsqueezy Client manually

builder.Services.AddSingleton<ILemonsqueezyClient>(serviceProvider =>
{
    var config = serviceProvider.GetRequiredService<IConfiguration>();
    var apiKey = config["Lemonsqueezy:ApiKey"];
    if (string.IsNullOrEmpty(apiKey))
    {
        throw new InvalidOperationException(new Dictionary<string, object>
        {
            ["message"] = "Lemonsqueezy:ApiKey is required in configuration",
            ["details"] = new Dictionary<string, object>
            {
                ["configurationKey"] = "Lemonsqueezy:ApiKey"
            }
        });
    }
    
    var options = LemonsqueezyClientOptions.From(apiKey)
        .WithBaseUrl(config["Lemonsqueezy:BaseUrl"] ?? "https://api.lemonsqueezy.com/v1/")
        .WithTimeout(TimeSpan.FromSeconds(
            int.TryParse(config["Lemonsqueezy:Timeout"], out var timeout) ? timeout : 30
        ))
        .WithRetryCount(int.TryParse(config["Lemonsqueezy:RetryCount"], out var retryCount) ? retryCount : 3);
    return LemonsqueezyClientFactory.Init(options);
});

// Register webhook signature validator manually
builder.Services.AddSingleton<IWebhookSignatureValidator>(serviceProvider =>
{
    var config = serviceProvider.GetRequiredService<IConfiguration>();
    var secret = config["Lemonsqueezy:WebhookSecret"];
    if (string.IsNullOrEmpty(secret))
    {
        throw new InvalidOperationException(new Dictionary<string, object>
        {
            ["message"] = "Lemonsqueezy:WebhookSecret is required in configuration",
            ["details"] = new Dictionary<string, object>
            {
                ["configurationKey"] = "Lemonsqueezy:WebhookSecret"
            }
        });
    }
    return new WebhookSignatureValidator(secret);
});

var app = builder.Build();
app.MapControllers();
app.Run();
```

### Using the client in controllers

```csharp
[ApiController]
[Route("api/[controller]")]
public class StoresController : ControllerBase
{
    private readonly ILemonsqueezyClient _client;
    
    public StoresController(ILemonsqueezyClient client)
    {
        _client = client;
    }
    
    [HttpGet("{storeId}")]
    public async Task<IActionResult> GetStore(string storeId, CancellationToken cancellationToken)
    {
        try
        {
            var store = await _client.StoresResource()
                .RetrieveStoreAsync(storeId, cancellationToken);
            return Ok(store);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { error = ex.GetMessage() });
        }
        catch (UnauthorizedException ex)
        {
            return Unauthorized(new { error = "Invalid API key" });
        }
    }
}
```

### Webhook validation middleware

The SDK provides a built-in middleware for automatic webhook signature validation. Register it in your `Program.cs`:

```csharp
using Osirisgate.Lemonsqueezy.Middleware;

var app = builder.Build();

// Register webhook validation middleware
// Option 1: Use default path prefix "/webhooks"
app.UseLemonsqueezyWebhookValidation();

// Option 2: Use custom path prefix (e.g., "/v1/webhooks" or "/api/webhooks")
// app.UseLemonsqueezyWebhookValidation("/v1/webhooks");
```

The middleware automatically:
- Validates webhook signatures for requests matching the configured path prefix
- Stores the validated raw body in `HttpContext.Items[WebhookValidationMiddleware.WebhookRawBodyKey]`
- Returns appropriate error responses for invalid or missing signatures
- Allows non-webhook requests to pass through without validation

See the [Webhooks section](#webhooks) for complete examples of using the middleware with controllers.

## HTTP extensions

The SDK provides extension methods for `HttpRequest` and `IQueryCollection` to simplify common HTTP operations in ASP.NET Core applications.

### Parsing nested query parameters

The SDK provides extension methods to parse nested query parameters from HTTP requests into a dictionary structure. This is useful when working with API endpoints that accept filters and pagination parameters in nested format (e.g., `filter[name]=value&page[number]=1`).

**Extension methods:**

- `ParseNestedQueryParameters(this HttpRequest request)` - Parses query parameters from an `HttpRequest`
- `ParseNestedQueryParameters(this IQueryCollection query)` - Parses query parameters from an `IQueryCollection`

**Example usage:**

```csharp
using Osirisgate.Lemonsqueezy.Extensions;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("v1/stores")]
public class StoresController : ControllerBase
{
    private readonly ILemonsqueezyClient _client;

    public StoresController(ILemonsqueezyClient client)
    {
        _client = client;
    }

    [HttpGet]
    public async Task<IActionResult> GetStores(CancellationToken cancellationToken)
    {
        // Parse nested query parameters from the request
        // Supports: ?filter[name]=test&page[number]=1&page[size]=10
        var filters = Request.ParseNestedQueryParameters();
        
        // Result structure:
        // {
        //     "filter": { "name": "test" },
        //     "page": { "number": "1", "size": "10" }
        // }

        var stores = await _client.StoresResource().ListAllStoresAsync(
            filters: filters.Count > 0 ? filters : null,
            cancellationToken: cancellationToken
        );

        return Ok(new { success = true, data = stores });
    }
}
```

**Alternative: Using IQueryCollection directly**

```csharp
[HttpGet]
public async Task<IActionResult> GetStores(CancellationToken cancellationToken)
{
    // Parse from IQueryCollection directly
    var filters = Request.Query.ParseNestedQueryParameters();
    
    var stores = await _client.StoresResource().ListAllStoresAsync(
        filters: filters.Count > 0 ? filters : null,
        cancellationToken: cancellationToken
    );

    return Ok(new { success = true, data = stores });
}
```

**Supported syntax:**

- **Nested parameters**: `filter[name]=value` → `{ "filter": { "name": "value" } }`
- **Multiple nested values**: `page[number]=1&page[size]=10` → `{ "page": { "number": "1", "size": "10" } }`
- **Simple parameters**: `sort=name` → `{ "sort": "name" }`
- **Mixed**: `filter[name]=test&sort=name&page[number]=1` → `{ "filter": { "name": "test" }, "sort": "name", "page": { "number": "1" } }`

**Note:** Invalid bracket formats (e.g., `filter[name` or `filter]name`) are treated as simple key-value parameters for safety.

## Available resources

The SDK provides access to all Lemonsqueezy API resources via typed methods. Each resource exposes methods for CRUD operations and related resource retrieval.

**Note:** All async methods support `CancellationToken` for cancellation support.

### Users resource

```csharp
var users = client.UsersResource();

// Retrieve authenticated user
var user = await users.RetrieveUserAsync(cancellationToken);
```

### Stores resource

```csharp
var stores = client.StoresResource();

// Retrieve a specific store
await stores.RetrieveStoreAsync(storeId, cancellationToken);

// List all stores
await stores.ListAllStoresAsync(filters, cancellationToken);

// Retrieve related resources
await stores.RetrieveProductsAsync(storeId, filters, cancellationToken);
await stores.RetrieveOrdersAsync(storeId, filters, cancellationToken);
await stores.RetrieveSubscriptionsAsync(storeId, filters, cancellationToken);
await stores.RetrieveDiscountsAsync(storeId, filters, cancellationToken);
await stores.RetrieveLicenseKeysAsync(storeId, filters, cancellationToken);
await stores.RetrieveWebhooksAsync(storeId, filters, cancellationToken);
```

### Customers resource

```csharp
var customers = client.CustomersResource();

// Create a customer
await customers.CreateCustomerAsync(data, cancellationToken);

// Retrieve a specific customer
await customers.RetrieveCustomerAsync(customerId, cancellationToken);

// Update a customer
await customers.UpdateCustomerAsync(customerId, data, cancellationToken);

// List all customers
await customers.ListAllCustomersAsync(filters, cancellationToken);

// Retrieve related resources
await customers.RetrieveStoreAsync(customerId, cancellationToken);
await customers.RetrieveOrdersAsync(customerId, filters, cancellationToken);
await customers.RetrieveSubscriptionsAsync(customerId, filters, cancellationToken);
await customers.RetrieveLicenseKeysAsync(customerId, filters, cancellationToken);
```

### Products resource

```csharp
var products = client.ProductsResource();

// Retrieve a specific product
await products.RetrieveProductAsync(productId, cancellationToken);

// List all products
await products.ListAllProductsAsync(filters, cancellationToken);

// Retrieve related resources
await products.RetrieveStoreAsync(productId, cancellationToken);
await products.RetrieveVariantsAsync(productId, filters, cancellationToken);
```

### Variants resource

```csharp
var variants = client.VariantsResource();

// Retrieve a specific variant
await variants.RetrieveVariantAsync(variantId, cancellationToken);

// List all variants
await variants.ListAllVariantsAsync(filters, cancellationToken);

// Retrieve related resources
await variants.RetrieveProductAsync(variantId, cancellationToken);
await variants.RetrieveFilesAsync(variantId, filters, cancellationToken);
await variants.RetrievePriceModelAsync(variantId, cancellationToken);
```

### Prices resource

```csharp
var prices = client.PricesResource();

// Retrieve a specific price
await prices.RetrievePriceAsync(priceId, cancellationToken);

// List all prices
await prices.ListAllPricesAsync(filters, cancellationToken);

// Retrieve variant
await prices.RetrieveVariantAsync(priceId, cancellationToken);
```

### Files resource

```csharp
var files = client.FilesResource();

// Retrieve a specific file
await files.RetrieveFileAsync(fileId, cancellationToken);

// List all files
await files.ListAllFilesAsync(filters, cancellationToken);

// Retrieve variant
await files.RetrieveVariantAsync(fileId, cancellationToken);
```

### Orders resource

```csharp
var orders = client.OrdersResource();

// Retrieve a specific order
await orders.RetrieveOrderAsync(orderId, cancellationToken);

// List all orders
await orders.ListAllOrdersAsync(filters, cancellationToken);

// Generate invoice
await orders.GenerateOrderInvoiceAsync(orderId, cancellationToken);

// Issue refund
await orders.IssueRefundAsync(orderId, data, cancellationToken);

// Retrieve related resources
await orders.RetrieveStoreAsync(orderId, cancellationToken);
await orders.RetrieveCustomerAsync(orderId, cancellationToken);
await orders.RetrieveOrderItemsAsync(orderId, filters, cancellationToken);
await orders.RetrieveSubscriptionsAsync(orderId, filters, cancellationToken);
await orders.RetrieveLicenseKeysAsync(orderId, filters, cancellationToken);
await orders.RetrieveDiscountRedemptionsAsync(orderId, filters, cancellationToken);
```

### Order items resource

```csharp
var orderItems = client.OrderItemsResource();

// Retrieve a specific order item
await orderItems.RetrieveOrderItemAsync(orderItemId, cancellationToken);

// List all order items
await orderItems.ListAllOrderItemsAsync(filters, cancellationToken);

// Retrieve related resources
await orderItems.RetrieveOrderAsync(orderItemId, cancellationToken);
await orderItems.RetrieveProductAsync(orderItemId, cancellationToken);
await orderItems.RetrieveVariantAsync(orderItemId, cancellationToken);
```

### Subscriptions resource

```csharp
var subscriptions = client.SubscriptionsResource();

// Update a subscription
await subscriptions.UpdateSubscriptionAsync(subscriptionId, data, cancellationToken);

// Cancel a subscription
await subscriptions.CancelSubscriptionAsync(subscriptionId, cancellationToken);

// Retrieve a specific subscription
await subscriptions.RetrieveSubscriptionAsync(subscriptionId, cancellationToken);

// List all subscriptions
await subscriptions.ListAllSubscriptionsAsync(filters, cancellationToken);

// Retrieve related resources
await subscriptions.RetrieveStoreAsync(subscriptionId, cancellationToken);
await subscriptions.RetrieveCustomerAsync(subscriptionId, cancellationToken);
await subscriptions.RetrieveOrderAsync(subscriptionId, cancellationToken);
await subscriptions.RetrieveOrderItemAsync(subscriptionId, cancellationToken);
await subscriptions.RetrieveProductAsync(subscriptionId, cancellationToken);
await subscriptions.RetrieveVariantAsync(subscriptionId, cancellationToken);
await subscriptions.RetrieveSubscriptionItemsAsync(subscriptionId, filters, cancellationToken);
await subscriptions.RetrieveSubscriptionInvoicesAsync(subscriptionId, filters, cancellationToken);
```

### Subscription invoices resource

```csharp
var invoices = client.SubscriptionInvoicesResource();

// Generate a subscription invoice
await invoices.GenerateSubscriptionInvoiceAsync(subscriptionInvoiceId, cancellationToken);

// Issue refund
await invoices.IssueRefundAsync(subscriptionInvoiceId, data, cancellationToken);

// Retrieve a specific invoice
await invoices.RetrieveSubscriptionInvoiceAsync(subscriptionInvoiceId, cancellationToken);

// List all invoices
await invoices.ListAllSubscriptionInvoicesAsync(filters, cancellationToken);

// Retrieve related resources
await invoices.RetrieveStoreAsync(subscriptionInvoiceId, cancellationToken);
await invoices.RetrieveSubscriptionAsync(subscriptionInvoiceId, cancellationToken);
await invoices.RetrieveCustomerAsync(subscriptionInvoiceId, cancellationToken);
```

### Subscription items resource

```csharp
var subscriptionItems = client.SubscriptionItemsResource();

// Update a subscription item
await subscriptionItems.UpdateSubscriptionItemAsync(subscriptionItemId, data, cancellationToken);

// Retrieve a specific subscription item
await subscriptionItems.RetrieveSubscriptionItemAsync(subscriptionItemId, cancellationToken);

// Retrieve current usage
await subscriptionItems.RetrieveItemCurrentUsageAsync(subscriptionItemId, cancellationToken);

// List all subscription items
await subscriptionItems.ListAllSubscriptionItemsAsync(filters, cancellationToken);

// Retrieve related resources
await subscriptionItems.RetrieveSubscriptionAsync(subscriptionItemId, cancellationToken);
await subscriptionItems.RetrievePriceAsync(subscriptionItemId, cancellationToken);
await subscriptionItems.RetrieveUsageRecordsAsync(subscriptionItemId, filters, cancellationToken);
```

### Usage records resource

```csharp
var usageRecords = client.UsageRecordsResource();

// Create a usage record
await usageRecords.CreateUsageRecordAsync(data, cancellationToken);

// Retrieve a specific usage record
await usageRecords.RetrieveUsageRecordAsync(usageRecordId, cancellationToken);

// List all usage records
await usageRecords.ListAllUsageRecordsAsync(filters, cancellationToken);

// Retrieve subscription item
await usageRecords.RetrieveSubscriptionItemAsync(usageRecordId, cancellationToken);
```

### Discounts resource

```csharp
var discounts = client.DiscountsResource();

// Create a discount
await discounts.CreateDiscountAsync(data, cancellationToken);

// Delete a discount
await discounts.DeleteDiscountAsync(discountId, cancellationToken);

// Retrieve a specific discount
await discounts.RetrieveDiscountAsync(discountId, cancellationToken);

// List all discounts
await discounts.ListAllDiscountsAsync(filters, cancellationToken);

// Retrieve related resources
await discounts.RetrieveStoreAsync(discountId, cancellationToken);
await discounts.RetrieveVariantsAsync(discountId, filters, cancellationToken);
await discounts.RetrieveDiscountRedemptionsAsync(discountId, filters, cancellationToken);
```

### Discount redemptions resource

```csharp
var redemptions = client.DiscountRedemptionsResource();

// Retrieve a specific discount redemption
await redemptions.RetrieveDiscountRedemptionAsync(discountId, cancellationToken);

// List all discount redemptions
await redemptions.ListAllDiscountRedemptionsAsync(filters, cancellationToken);

// Retrieve related resources
await redemptions.RetrieveDiscountAsync(discountId, cancellationToken);
await redemptions.RetrieveOrderAsync(discountId, cancellationToken);
```

### License keys resource

```csharp
var licenseKeys = client.LicenseKeysResource();

// Update a license key
await licenseKeys.UpdateLicenseKeyAsync(licenseKeyId, data, cancellationToken);

// Retrieve a specific license key
await licenseKeys.RetrieveLicenseKeyAsync(licenseKeyId, cancellationToken);

// List all license keys
await licenseKeys.ListAllLicenseKeysAsync(filters, cancellationToken);

// Retrieve related resources
await licenseKeys.RetrieveStoreAsync(licenseKeyId, cancellationToken);
await licenseKeys.RetrieveCustomerAsync(licenseKeyId, cancellationToken);
await licenseKeys.RetrieveOrderAsync(licenseKeyId, cancellationToken);
await licenseKeys.RetrieveOrderItemAsync(licenseKeyId, cancellationToken);
await licenseKeys.RetrieveProductAsync(licenseKeyId, cancellationToken);
await licenseKeys.RetrieveLicenseKeyInstancesRelationshipAsync(licenseKeyId, filters, cancellationToken);
```

### License key instances resource

```csharp
var instances = client.LicenseKeyInstancesResource();

// Retrieve a specific license key instance
await instances.RetrieveLicenseKeyInstanceAsync(licenseKeyInstanceId, cancellationToken);

// List all license key instances
await instances.ListAllLicenseKeyInstancesAsync(filters, cancellationToken);

// Retrieve license key
await instances.RetrieveLicenseKeyAsync(licenseKeyInstanceId, cancellationToken);
```

### Checkouts resource

```csharp
var checkouts = client.CheckoutsResource();

// Create a checkout
await checkouts.CreateCheckoutAsync(data, cancellationToken);

// Retrieve a specific checkout
await checkouts.RetrieveCheckoutAsync(checkoutId, cancellationToken);

// List all checkouts
await checkouts.ListAllCheckoutsAsync(filters, cancellationToken);

// Retrieve related resources
await checkouts.RetrieveStoreAsync(checkoutId, cancellationToken);
await checkouts.RetrieveVariantAsync(checkoutId, cancellationToken);
```

### Webhooks resource

```csharp
var webhooks = client.WebhooksResource();

// Create a webhook
await webhooks.CreateWebhookAsync(data, cancellationToken);

// Update a webhook
await webhooks.UpdateWebhookAsync(webhookId, data, cancellationToken);

// Delete a webhook
await webhooks.DeleteWebhookAsync(webhookId, cancellationToken);

// Retrieve a specific webhook
await webhooks.RetrieveWebhookAsync(webhookId, cancellationToken);

// List all webhooks
await webhooks.ListAllWebhooksAsync(filters, cancellationToken);

// Retrieve store
await webhooks.RetrieveStoreAsync(webhookId, cancellationToken);
```

### License API resource

```csharp
var licenseApi = client.LicenseApiResource();

// Activate a license key
await licenseApi.ActivateLicenseKeyAsync(data, cancellationToken);

// Deactivate a license key
await licenseApi.DeactivateLicenseKeyAsync(data, cancellationToken);

// Validate a license key
await licenseApi.ValidateLicenseKeyAsync(data, cancellationToken);
```

### Affiliates resource

```csharp
var affiliates = client.AffiliatesResource();

// Retrieve a specific affiliate
await affiliates.RetrieveAffiliateAsync(affiliateId, cancellationToken);

// List all affiliates
await affiliates.ListAllAffiliatesAsync(filters, cancellationToken);

// Retrieve related resources
await affiliates.RetrieveStoreAsync(affiliateId, cancellationToken);
await affiliates.RetrieveUserAsync(affiliateId, cancellationToken);
```

## Webhooks

### Event types

The SDK provides strongly typed enumerations for all webhook events:

```csharp
using Osirisgate.Lemonsqueezy.Events;

// Order events
WebhookEvent.OrderCreated
WebhookEvent.OrderRefunded

// Subscription events
WebhookEvent.SubscriptionCreated
WebhookEvent.SubscriptionUpdated
WebhookEvent.SubscriptionCancelled
WebhookEvent.SubscriptionResumed
WebhookEvent.SubscriptionExpired
WebhookEvent.SubscriptionPaused
WebhookEvent.SubscriptionUnpaused
WebhookEvent.SubscriptionPaymentSuccess
WebhookEvent.SubscriptionPaymentFailed
WebhookEvent.SubscriptionPaymentRecovered
WebhookEvent.SubscriptionPaymentRefunded

// License key events
WebhookEvent.LicenseKeyCreated
WebhookEvent.LicenseKeyUpdated

// Affiliate events
WebhookEvent.AffiliateActivated
```

### Checking event types

The SDK provides the `IsEventType` extension method to check if a webhook event matches a specific type or any of multiple types:

```csharp
using Osirisgate.Lemonsqueezy.Events;
using Osirisgate.Lemonsqueezy.Events.Payloads;

// Get event type from payload
var payload = HttpContext.GetLemonsqueezyWebhookPayload();
var eventType = payload.GetEventType();

// Check if event is a specific type
if (eventType.IsEventType(WebhookEvent.SubscriptionPaymentSuccess))
{
    // Handle subscription payment success
    Console.WriteLine("Subscription payment successful");
}

// Check if event matches any of multiple types
if (eventType.IsEventType(
    WebhookEvent.SubscriptionCreated,
    WebhookEvent.SubscriptionUpdated,
    WebhookEvent.SubscriptionCancelled))
{
    // Handle subscription lifecycle events
    Console.WriteLine("Subscription lifecycle event");
}

// Example: Handle all payment-related events
if (eventType.IsEventType(
    WebhookEvent.SubscriptionPaymentSuccess,
    WebhookEvent.SubscriptionPaymentFailed,
    WebhookEvent.SubscriptionPaymentRecovered,
    WebhookEvent.SubscriptionPaymentRefunded))
{
    // Handle payment events
    Console.WriteLine("Payment event received");
}
```

### Webhook payload types

The SDK provides strongly typed payload classes for each event category:

- **`OrderWebhookPayload`** - For `order_created`, `order_refunded`
- **`SubscriptionWebhookPayload`** - For subscription lifecycle events
- **`SubscriptionPaymentWebhookPayload`** - For subscription payment events
- **`LicenseKeyWebhookPayload`** - For license key events
- **`AffiliateWebhookPayload`** - For affiliate events

Each payload includes:
- **`Meta`** - Event metadata (event_name, webhook_id, test_mode, custom_data)
- **`Data`** - The actual resource data (Order, Subscription, etc.)

### Deserializing webhook payloads

```csharp
using Osirisgate.Lemonsqueezy.Events.Payloads;
using Osirisgate.Lemonsqueezy.Events.Payloads.Order;
using Osirisgate.Lemonsqueezy.Events.Payloads.Subscription;

// Deserialize webhook payload
var payload = WebhookPayloadDeserializer.Deserialize(rawBody);

// Get event type
var eventType = payload.GetEventType();
Console.WriteLine($"Event: {eventType.GetValue()}");

// Handle specific payload types
switch (payload)
{
    case OrderWebhookPayload orderPayload:
        var order = orderPayload.Data;
        Console.WriteLine($"Order ID: {order.Id}, Total: {order.Attributes.Total}");
        break;
        
    case SubscriptionWebhookPayload subscriptionPayload:
        var subscription = subscriptionPayload.Data;
        Console.WriteLine($"Subscription Status: {subscription.Attributes.Status}");
        break;
        
    case SubscriptionPaymentWebhookPayload paymentPayload:
        // Handle payment events
        break;
}
```

### Manual validating webhook signatures

**Important:** You must read the raw body as-is before any JSON parsing. The signature is computed from the exact bytes received.

#### Complete example with ASP.NET Core

```csharp
using Osirisgate.Lemonsqueezy.Events.Webhook;
using Osirisgate.Lemonsqueezy.Events.Payloads;

[ApiController]
[Route("api/webhooks")]
public class WebhooksController : ControllerBase
{
    private readonly IWebhookSignatureValidator _validator;
    private readonly ILogger<WebhooksController> _logger;
    
    public WebhooksController(
        IWebhookSignatureValidator validator,
        ILogger<WebhooksController> logger)
    {
        _validator = validator;
        _logger = logger;
    }
    
    [HttpPost("lemonsqueezy")]
    public async Task<IActionResult> HandleWebhook(CancellationToken cancellationToken)
    {
        // CRITICAL: Read raw body BEFORE any JSON parsing
        Request.EnableBuffering();
        
        string rawBody;
        using (var reader = new StreamReader(
            Request.Body, 
            Encoding.UTF8, 
            leaveOpen: true))
        {
            rawBody = await reader.ReadToEndAsync(cancellationToken);
            Request.Body.Position = 0; // Reset stream position
        }
        
        // Get signature from header
        if (!Request.Headers.TryGetValue("X-Signature", out var signatureValue))
        {
            _logger.LogWarning("Missing X-Signature header");
            return Unauthorized("Missing signature");
        }
        
        var signature = signatureValue.ToString();
        
        // Validate signature
        if (!_validator.ValidateSignature(rawBody, signature))
        {
            _logger.LogWarning("Invalid webhook signature");
            return Unauthorized("Invalid signature");
        }
        
        // Deserialize and process
        try
        {
            var payload = WebhookPayloadDeserializer.Deserialize(rawBody);
            var eventType = payload.GetEventType();
            
            _logger.LogInformation("Webhook received: {EventType}", eventType.GetValue());
            
            // Process webhook based on type
            await ProcessWebhookAsync(payload, cancellationToken);
            
            return Ok(new { success = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing webhook");
            return BadRequest(new { error = "Invalid payload format" });
        }
    }
    
    private async Task ProcessWebhookAsync(Events.Payloads.WebhookPayload payload, CancellationToken cancellationToken)
    {
        switch (payload)
        {
            case OrderWebhookPayload orderPayload:
                await HandleOrderEvent(orderPayload, cancellationToken);
                break;
            case SubscriptionWebhookPayload subscriptionPayload:
                await HandleSubscriptionEvent(subscriptionPayload, cancellationToken);
                break;
            // Handle other types...
        }
    }
}
```

#### Using static method (without DI)

```csharp
using Osirisgate.Lemonsqueezy.Events.Webhook;

var signingSecret = Configuration["Lemonsqueezy:WebhookSecret"];
var isValid = WebhookSignatureStaticValidator.ValidateSignature(
    rawBody, 
    signature, 
    signingSecret
);
```

#### Automatic webhook validation middleware

The SDK provides a built-in middleware for automatic webhook signature validation. This middleware validates webhook signatures automatically for requests to webhook endpoints and stores the raw body for easy access in your controllers.

**Setup in Program.cs**

```csharp
using Osirisgate.Lemonsqueezy.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Register services (as shown in Dependency Injection section)
builder.Services.AddLemonsqueezyWithOptions();
builder.Services.AddLemonsqueezyWebhookValidator();

var app = builder.Build();

// Register webhook validation middleware
// Option 1: Use default webhook path prefix "/webhooks"
app.UseLemonsqueezyWebhookValidation();

// Option 2: Use custom path prefix (e.g., "/v1/webhooks" or "/api/webhooks")
// app.UseLemonsqueezyWebhookValidation("/v1/webhooks");

app.MapControllers();
app.Run();
```

**Using webhook extensions (recommended)**

The SDK provides extension methods on `HttpContext` and `HttpRequest` to simplify webhook content access. These extensions eliminate boilerplate code and provide a cleaner, more intuitive API.

**Example with extensions:**

```csharp
using Osirisgate.Lemonsqueezy.Events.Payloads;
using Osirisgate.Lemonsqueezy.Extensions;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("v1/webhooks")]
public class WebhooksController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> HandleWebhook(CancellationToken cancellationToken)
    {
        try
        {
            // Get webhook payload using extension method (already validated by middleware)
            var payload = HttpContext.GetLemonsqueezyWebhookPayload();
            var eventType = payload.GetEventType();
            
            // Process webhook based on type
            switch (payload)
            {
                case OrderWebhookPayload orderPayload:
                    await HandleOrderEvent(orderPayload, cancellationToken);
                    break;
                case SubscriptionWebhookPayload subscriptionPayload:
                    await HandleSubscriptionEvent(subscriptionPayload, cancellationToken);
                    break;
                // Handle other types...
            }
            
            return Ok(new { success = true, eventType = eventType.GetValue() });
        }
        catch (InvalidOperationException ex)
        {
            // Thrown when webhook body is not available
            return BadRequest(new { error = ex.GetMessage() });
        }
    }
}
```

**Available extension methods:**

The SDK provides extension methods on `HttpContext`, `HttpRequest`, and `WebhookPayload`:

| Method | Returns | Description |
|--------|---------|-------------|
| `GetLemonsqueezyWebhookRawBody()` | `string` | Gets the Lemonsqueezy raw webhook body, throws `InvalidOperationException` if not available |
| `GetLemonsqueezyWebhookPayload()` | `WebhookPayload` | Deserializes the Lemonsqueezy webhook payload, throws `InvalidOperationException` if not available |
| `GetEventType()` (on `WebhookPayload`) | `WebhookEvent` | Gets the event type from an already deserialized payload |

**Getting event type from payload:**

If you already have a `WebhookPayload` instance, you can get the event type directly using the extension method:

```csharp
using Osirisgate.Lemonsqueezy.Events.Payloads;

// Get payload from HttpContext
var payload = HttpContext.GetLemonsqueezyWebhookPayload();

// Get event type directly from the payload using extension method
var eventType = payload.GetEventType();
```

**Getting event type from raw body without full deserialization (performance optimization):**

For better performance, you can extract the event type from the raw body string without deserializing the entire payload. This is useful when you need to check the event type before deciding whether to process the webhook:

```csharp
using Osirisgate.Lemonsqueezy.Events.Payloads;

// Get raw body from HttpContext
var rawBody = HttpContext.GetLemonsqueezyWebhookRawBody();

// Get event type without deserializing the entire payload
var eventType = WebhookPayloadDeserializer.GetEventTypeFromRawBody(rawBody);

// Only deserialize if needed based on event type
if (eventType.IsEventType(
    WebhookEvent.SubscriptionPaymentSuccess,
    WebhookEvent.SubscriptionPaymentFailed))
{
    var payload = WebhookPayloadDeserializer.Deserialize(rawBody);
    // Process payment events...
}
else
{
    // Skip processing for other event types
    return Ok(new { skipped = true });
}
```

This approach is more efficient because:
- It only parses the JSON structure to extract `meta.event_name`
- It doesn't deserialize the entire payload object graph
- It allows you to make routing decisions before expensive deserialization

**Using with HttpRequest:**

```csharp
[HttpPost]
public async Task<IActionResult> HandleWebhook(HttpRequest request, CancellationToken cancellationToken)
{
    // Extension methods also work on HttpRequest
    var payload = request.GetLemonsqueezyWebhookPayload();
    var eventType = payload.GetEventType();
    
    // Process webhook...
    return Ok(new { success = true, eventType = eventType.GetValue() });
}
```

**Manual access (legacy approach)**

If you prefer manual access, you can still use `HttpContext.Items` directly:

```csharp
using Osirisgate.Lemonsqueezy.Events.Payloads;
using Osirisgate.Lemonsqueezy.Middleware;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("v1/webhooks")]
public class WebhooksController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> HandleWebhook(CancellationToken cancellationToken)
    {
        // Get validated raw body from middleware
        if (!HttpContext.Items.TryGetValue(
            WebhookValidationMiddleware.WebhookRawBodyKey, 
            out var rawBodyObj) || 
            rawBodyObj is not string rawBody)
        {
            return BadRequest(new { error = "Webhook body not available" });
        }
        
        // Deserialize and process webhook
        var payload = WebhookPayloadDeserializer.Deserialize(rawBody);
        var eventType = payload.GetEventType(); // Using extension method
        
        // Process webhook based on type
        switch (payload)
        {
            case OrderWebhookPayload orderPayload:
                await HandleOrderEvent(orderPayload, cancellationToken);
                break;
            case SubscriptionWebhookPayload subscriptionPayload:
                await HandleSubscriptionEvent(subscriptionPayload, cancellationToken);
                break;
            // Handle other types...
        }
        
        return Ok(new { success = true, eventType = eventType.GetValue() });
    }
}
```

**Note:** The extension methods are the recommended approach as they provide better developer experience, type safety, and error handling.

### Security best practices

1. **Always validate signatures** - Never skip signature validation, even in development
2. **Use HTTPS** - Webhooks should only be received over HTTPS in production
3. **Store secrets securely** - Use Azure Key Vault, AWS Secrets Manager, or environment variables
4. **Log validation failures** - Monitor for potential attacks
5. **Implement idempotency** - Handle duplicate webhook deliveries using `webhook_id` from metadata

```csharp
// Example: Check for duplicate webhooks
private async Task<bool> IsDuplicateWebhook(string webhookId)
{
    return await _dbContext.WebhookLogs
        .AnyAsync(w => w.WebhookId == webhookId);
}

[HttpPost("/webhook")]
public async Task<IActionResult> HandleWebhook(CancellationToken cancellationToken)
{
    // ... validation code ...
    
    var payload = WebhookPayloadDeserializer.Deserialize(rawBody);
    var webhookId = payload.Meta.WebhookId;
    
    // Check for duplicates
    if (await IsDuplicateWebhook(webhookId))
    {
        _logger.LogInformation("Duplicate webhook ignored: {WebhookId}", webhookId);
        return Ok(new { duplicate = true });
    }
    
    // Process webhook...
    await StoreWebhookIdAsync(webhookId, cancellationToken);
    
    return Ok();
}
```

## Error handling

The SDK provides specific exception types for different HTTP status codes. All exceptions implement the `IException` interface, which provides the following methods:

### Available exception methods

All exception types inherit from `BaseException` and implement `IException`, providing these methods:

| Method | Return Type | Description |
|--------|-------------|-------------|
| `GetErrorCode()` | `int` | Gets the HTTP status code as an integer (401, 404, 400, 429, 500, etc.) |
| `GetMessage()` | `string` | Gets the main error message |
| `GetDetailsMessage()` | `string` | Gets the detailed error message from exception details |
| `Format()` | `IDictionary<string, object>` | Formats the exception into a structured dictionary with status, error_code, message, and details |
| `GetErrors()` | `IDictionary<string, object>` | Gets all error information as a dictionary |
| `GetDetails()` | `IDictionary<string, object>` | Gets additional exception details as a dictionary |

### Exception types

| Exception | HTTP Status | Description |
|-----------|-------------|-------------|
| `UnauthorizedException` | 401 | Invalid or missing API key |
| `NotFoundException` | 404 | Requested resource not found |
| `BadRequestContentException` | 400 | Invalid request data or parameters |
| `TooManyRequestsException` | 429 | Rate limit exceeded |
| `RuntimeException` | 500+ | Server-side errors |
| `InvalidOperationException` | 400 | Invalid operation (e.g., missing configuration) |
| `ArgumentNullException` | 400 | Null or empty argument provided |
| `ArgumentOutOfRangeException` | 500 | Argument value outside acceptable range |
| `ForbiddenException` | 403 | Client does not have permission to access the resource |

### Error handling examples

```csharp
using Osirisgate.Lemonsqueezy.Exception;

try
{
    var order = await client.OrdersResource()
        .RetrieveOrderAsync(orderId, cancellationToken);
}
catch (UnauthorizedException ex)
{
    // HTTP 401 - Invalid or missing API key
    var errorCode = ex.GetErrorCode(); // Returns 401
    var message = ex.GetMessage(); // Main error message
    var details = ex.GetDetails(); // Additional error details
    var detailsMessage = ex.GetDetailsMessage(); // Detailed error message
    var formatted = ex.Format(); // Complete formatted error
    var errors = ex.GetErrors(); // All error information
    
    Console.WriteLine($"Authentication failed: {message}");
    Console.WriteLine($"Error code: {errorCode}");
    Console.WriteLine($"Details: {detailsMessage}");
}
catch (NotFoundException ex)
{
    // HTTP 404 - Resource not found
    var errorCode = ex.GetErrorCode(); // Returns 404
    var message = ex.GetMessage();
    var formatted = ex.Format();
    
    Console.WriteLine($"Resource not found: {message}");
    Console.WriteLine($"Formatted error: {formatted["message"]}");
}
catch (BadRequestContentException ex)
{
    // HTTP 400 - Invalid request data
    var errorCode = ex.GetErrorCode(); // Returns 400
    var message = ex.GetMessage();
    var detailsMessage = ex.GetDetailsMessage();
    var details = ex.GetDetails();
    var formatted = ex.Format();
    
    Console.WriteLine($"Bad request: {message}");
    Console.WriteLine($"Details: {detailsMessage}");
    
    // Access specific error details
    if (details.TryGetValue("field", out var field))
    {
        Console.WriteLine($"Invalid field: {field}");
    }
}
catch (TooManyRequestsException ex)
{
    // HTTP 429 - Rate limit exceeded
    var errorCode = ex.GetErrorCode(); // Returns 429
    var message = ex.GetMessage();
    var details = ex.GetDetails();
    var formatted = ex.Format();
    
    Console.WriteLine($"Rate limit exceeded: {message}");
    Console.WriteLine($"Error code: {errorCode}");
    
    // Wait before retrying
    await Task.Delay(TimeSpan.FromSeconds(60), cancellationToken);
}
catch (RuntimeException ex)
{
    // HTTP 500+ - Server errors
    var errorCode = ex.GetErrorCode(); // Returns 500
    var message = ex.GetMessage();
    var detailsMessage = ex.GetDetailsMessage();
    var details = ex.GetDetails();
    var formatted = ex.Format();
    var errors = ex.GetErrors();
    
    Console.WriteLine($"Server error: {message}");
    Console.WriteLine($"Error code: {errorCode}");
    Console.WriteLine($"Details: {detailsMessage}");
    
    // Log complete error information
    _logger.LogError("Server error occurred: {Error}", formatted);
}
catch (InvalidOperationException ex)
{
    // HTTP 400 - Invalid operation (e.g., missing configuration)
    var errorCode = ex.GetErrorCode(); // Returns 400
    var message = ex.GetMessage();
    var details = ex.GetDetails();
    var formatted = ex.Format();
    
    Console.WriteLine($"Invalid operation: {message}");
    Console.WriteLine($"Error code: {errorCode}");
    
    // Access configuration details
    if (details.TryGetValue("configurationKey", out var configKey))
    {
        Console.WriteLine($"Missing configuration: {configKey}");
    }
}
catch (ArgumentNullException ex)
{
    // HTTP 400 - Null or empty argument
    var errorCode = ex.GetErrorCode(); // Returns 400
    var message = ex.GetMessage();
    var details = ex.GetDetails();
    var formatted = ex.Format();
    
    Console.WriteLine($"Invalid argument: {message}");
    Console.WriteLine($"Error code: {errorCode}");
    
    // Access parameter name
    if (details.TryGetValue("parameterName", out var paramName))
    {
        Console.WriteLine($"Parameter: {paramName}");
    }
}
catch (ForbiddenException ex)
{
    // HTTP 403 - Forbidden access
    var errorCode = ex.GetErrorCode(); // Returns 403
    var message = ex.GetMessage();
    var details = ex.GetDetails();
    var formatted = ex.Format();
    
    Console.WriteLine($"Forbidden: {message}");
    Console.WriteLine($"Error code: {errorCode}");
}
catch (BaseException ex)
{
    // Catch-all for any custom exception
    var errorCode = ex.GetErrorCode();
    var message = ex.GetMessage();
    var formatted = ex.Format();
    var errors = ex.GetErrors();
    
    Console.WriteLine($"Error: {message}");
    Console.WriteLine($"Error code: {errorCode}");
    
    // Access formatted error structure
    var status = formatted["status"];
    var errorCodeFormatted = formatted["error_code"];
    var messageFormatted = formatted["message"];
    var detailsFormatted = formatted["details"];
}
```

### Using Format() method

The `Format()` method returns a structured dictionary that can be easily serialized or logged:

```csharp
catch (BadRequestContentException ex)
{
    var formatted = ex.Format();
    // Returns:
    // {
    //     "status": "error",
    //     "error_code": 400,
    //     "message": "Invalid request",
    //     "details": { ... }
    // }
    
    return BadRequest(formatted);
}
```

## Advanced usage

### CancellationToken support

All async methods support `CancellationToken` for cancellation:

```csharp
var cts = new CancellationTokenSource();
cts.CancelAfter(TimeSpan.FromSeconds(30)); // Timeout after 30 seconds

try
{
    var products = await client.ProductsResource()
        .ListAllProductsAsync(cancellationToken: cts.Token);
}
catch (OperationCanceledException)
{
    Console.WriteLine("Operation was cancelled");
}
```

### Automatic retry for transient errors

The SDK automatically retries requests that fail with transient errors (HTTP 5xx and RequestTimeout) using an exponential backoff strategy. This improves resilience and reduces the need for manual retry logic.

**Features**
- Automatic retry for HTTP 5xx (Internal Server Error) responses
- Automatic retry for RequestTimeout errors
- Configurable number of retry attempts (default: 3)
- Exponential backoff: 2s, 4s, 8s delays between retries

**Configuration**

```csharp
var options = LemonsqueezyClientOptions.From("your-api-key")
    .WithRetryCount(5); // Customize retry attempts (default: 3)

var client = LemonsqueezyClientFactory.Init(options);
```

The retry policy is automatically applied to all HTTP requests. Failed requests are retried transparently without any additional code required.

### Rate limit handling

The SDK automatically detects rate limit errors (HTTP 429):

```csharp
try
{
    var products = await client.ProductsResource()
        .ListAllProductsAsync(cancellationToken: cancellationToken);
}
catch (TooManyRequestsException ex)
{
    var message = ex.GetMessage();
    var details = ex.GetDetails();
    var errorCode = ex.GetErrorCode();
    
    Console.WriteLine($"Rate limit exceeded: {message}");
    Console.WriteLine($"Error code: {errorCode}");
    
    // Implement your retry logic
    await Task.Delay(TimeSpan.FromSeconds(60), cancellationToken);
    
    // Retry the request manually
    var products = await client.ProductsResource()
        .ListAllProductsAsync(cancellationToken: cancellationToken);
}
```

**Note:** Rate limit errors (HTTP 429) are not automatically retried to avoid overwhelming the API. You should implement custom retry logic with appropriate delays when handling `TooManyRequestsException`.

## Learning more

While this documentation provides a clear and simple overview of the SDK, you can explore the following resources to gain deeper insights into its internal workings:

### Source code

The complete source code is available on GitHub:

- **Repository**: [https://github.com/osirisgate/Osirisgate.Lemonsqueezy.git](https://github.com/osirisgate/Osirisgate.Lemonsqueezy.git)

You can browse the code, report issues.

### Test suite

The `Osirisgate.Lemonsqueezy.Tests` project contains comprehensive unit tests for all resources and features. These tests demonstrate:
- How to use each resource method
- Expected request/response patterns
- Error handling scenarios
- Webhook payload deserialization

Browse the test files to see practical examples of SDK usage and understand how different components interact.

### Demo API project

The `Osirisgate.Lemonsqueezy.Demo.Api` project provides a complete working example of:
- Dependency injection setup with various configuration options
- Webhook validation middleware integration
- Controller implementations using the SDK
- Real world usage patterns

This demo project serves as a reference implementation and can help you understand best practices for integrating the SDK into your ASP.NET Core applications.

Exploring the source code will help you understand the SDK's architecture, design decisions, and implementation details.

## About

### Author

- **Ulrich Geraud AHOGLA** - Software Engineer
- **Contact**: developer@osirisgate.com
- **Organization**: Osirisgate

### License

This project is licensed under the **MIT License** - see the LICENSE file for details.
