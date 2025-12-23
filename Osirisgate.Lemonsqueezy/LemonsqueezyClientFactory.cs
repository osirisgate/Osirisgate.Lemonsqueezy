namespace Osirisgate.Lemonsqueezy;

/// <summary>
/// Factory class for creating and initializing Lemonsqueezy client instances.
/// Provides static methods for instantiating the client with various configurations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public static class LemonsqueezyClientFactory
{
    /// <summary>
    /// Initializes a new instance of the Lemonsqueezy client with the specified API key.
    /// </summary>
    /// <param name="apiKey">The API key for authenticating with the Lemonsqueezy API.</param>
    /// <returns>A new instance of <see cref="ILemonsqueezyClient"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when apiKey is null or empty.</exception>
    public static ILemonsqueezyClient Init(string apiKey)
        => LemonsqueezyClient.Init(apiKey);

    /// <summary>
    /// Initializes a new instance of the Lemonsqueezy client with the specified options.
    /// </summary>
    /// <param name="options">The configuration options for the Lemonsqueezy client.</param>
    /// <returns>A new instance of <see cref="ILemonsqueezyClient"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when options is null.</exception>
    public static ILemonsqueezyClient Init(LemonsqueezyClientOptions options)
        => LemonsqueezyClient.Init(options);
}
