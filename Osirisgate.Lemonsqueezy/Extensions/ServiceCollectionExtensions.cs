using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Osirisgate.Lemonsqueezy.Events.Webhook;
using Osirisgate.Lemonsqueezy.Exception;

namespace Osirisgate.Lemonsqueezy.Extensions;

/// <summary>
/// Extension methods for configuring Lemonsqueezy services in dependency injection containers.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public static class ServiceCollectionExtensions
{
    private const string ConfigurationSection = "Lemonsqueezy";
    private const string ApiKeyConfigurationKey = $"{ConfigurationSection}:ApiKey";
    private const string BaseUrlConfigurationKey = $"{ConfigurationSection}:BaseUrl";
    private const string TimeoutConfigurationKey = $"{ConfigurationSection}:Timeout";
    private const string RetryCountConfigurationKey = $"{ConfigurationSection}:RetryCount";
    private const string WebhookSecretConfigurationKey = $"{ConfigurationSection}:WebhookSecret";

    /// <summary>
    /// Registers the Lemonsqueezy client with API key only (uses default options).
    /// Reads the API key from configuration under "Lemonsqueezy:ApiKey".
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <returns>The service collection for chaining.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the API key is not found in configuration.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the API key is null or empty (validation done in LemonsqueezyClientFactory.Init).</exception>
    public static IServiceCollection AddLemonsqueezy(this IServiceCollection services)
    {
        services.AddSingleton(serviceProvider =>
        {
            var config = serviceProvider.GetRequiredService<IConfiguration>();
            var apiKey = config[ApiKeyConfigurationKey];
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new Exception.InvalidOperationException(new Dictionary<string, object>
                {
                    ["message"] = $"{ApiKeyConfigurationKey} is required in configuration",
                    ["details"] = new Dictionary<string, object>
                    {
                        ["configurationKey"] = ApiKeyConfigurationKey
                    }
                });
            }

            return LemonsqueezyClientFactory.Init(apiKey);
        });

        return services;
    }

    /// <summary>
    /// Registers the Lemonsqueezy client with full configuration options.
    /// Reads configuration from "Lemonsqueezy" section in appsettings.json.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <returns>The service collection for chaining.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the API key is not found in configuration.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the API key is null or empty (validation done in LemonsqueezyClientOptions.From).</exception>
    public static IServiceCollection AddLemonsqueezyWithOptions(this IServiceCollection services)
    {
        services.AddSingleton(serviceProvider =>
        {
            var config = serviceProvider.GetRequiredService<IConfiguration>();
            var apiKey = config[ApiKeyConfigurationKey];
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new Exception.InvalidOperationException(new Dictionary<string, object>
                {
                    ["message"] = $"{ApiKeyConfigurationKey} is required in configuration",
                    ["details"] = new Dictionary<string, object>
                    {
                        ["configurationKey"] = ApiKeyConfigurationKey
                    }
                });
            }

            var options = LemonsqueezyClientOptions.From(apiKey)
                .WithBaseUrl(config[BaseUrlConfigurationKey] ?? LemonsqueezyClientOptions.DefaultBaseUrl)
                .WithTimeout(TimeSpan.FromSeconds(
                    int.TryParse(config[TimeoutConfigurationKey], out var timeout) ? timeout : LemonsqueezyClientOptions.DefaultTimeoutSeconds
                ))
                .WithRetryCount(int.TryParse(config[RetryCountConfigurationKey], out var retryCount) ? retryCount : LemonsqueezyClientOptions.DefaultRetryCount);

            return LemonsqueezyClientFactory.Init(options);
        });

        return services;
    }

    /// <summary>
    /// Registers the Lemonsqueezy client with explicit options.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <param name="options">The configuration options for the Lemonsqueezy client.</param>
    /// <returns>The service collection for chaining.</returns>
    /// <exception cref="ArgumentNullException">Thrown when options is null or when ApiKey is not set.</exception>
    public static IServiceCollection AddLemonsqueezy(this IServiceCollection services, LemonsqueezyClientOptions options)
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

        services.AddSingleton(_ => LemonsqueezyClientFactory.Init(options));
        return services;
    }

    /// <summary>
    /// Registers the Lemonsqueezy client with an API key string.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <param name="apiKey">The API key for authenticating with the Lemonsqueezy API.</param>
    /// <returns>The service collection for chaining.</returns>
    /// <exception cref="ArgumentNullException">Thrown when apiKey is null or empty.</exception>
    public static IServiceCollection AddLemonsqueezy(this IServiceCollection services, string apiKey)
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

        services.AddSingleton(_ => LemonsqueezyClientFactory.Init(apiKey));
        return services;
    }

    /// <summary>
    /// Registers the webhook signature validator service.
    /// Reads the webhook secret from configuration under "Lemonsqueezy:WebhookSecret".
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <returns>The service collection for chaining.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the webhook secret is not found in configuration.</exception>
    public static IServiceCollection AddLemonsqueezyWebhookValidator(this IServiceCollection services)
    {
        services.AddSingleton<IWebhookSignatureValidator>(serviceProvider =>
        {
            var config = serviceProvider.GetRequiredService<IConfiguration>();
            var secret = config[WebhookSecretConfigurationKey];
            if (string.IsNullOrEmpty(secret))
            {
                throw new Exception.InvalidOperationException(new Dictionary<string, object>
                {
                    ["message"] = $"{WebhookSecretConfigurationKey} is required in configuration",
                    ["details"] = new Dictionary<string, object>
                    {
                        ["configurationKey"] = WebhookSecretConfigurationKey
                    }
                });
            }
            return new WebhookSignatureValidator(secret);
        });

        return services;
    }

    /// <summary>
    /// Registers the webhook signature validator service with an explicit secret.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <param name="webhookSecret">The webhook secret for validating signatures.</param>
    /// <returns>The service collection for chaining.</returns>
    /// <exception cref="ArgumentNullException">Thrown when webhookSecret is null or empty.</exception>
    public static IServiceCollection AddLemonsqueezyWebhookValidator(this IServiceCollection services, string webhookSecret)
    {
        if (string.IsNullOrEmpty(webhookSecret))
        {
            throw new Exception.ArgumentNullException(new Dictionary<string, object>
            {
                ["message"] = "Webhook secret cannot be null or empty.",
                ["details"] = new Dictionary<string, object>
                {
                    ["parameterName"] = nameof(webhookSecret)
                }
            });
        }

        services.AddSingleton<IWebhookSignatureValidator>(_ => new WebhookSignatureValidator(webhookSecret));
        return services;
    }
}
