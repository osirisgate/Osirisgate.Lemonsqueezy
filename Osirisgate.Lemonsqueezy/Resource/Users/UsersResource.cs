using Osirisgate.Lemonsqueezy.Resource.Users.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Users;

/// <summary>
/// Implementation of the Users resource for managing user-related operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class UsersResource(ILemonsqueezyClient client) : Resource(client), IUsersResource
{
    /// <summary>
    /// Retrieves the currently authenticated user's information.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the user response.</returns>
    public async Task<UserResponse> RetrieveUserAsync(CancellationToken cancellationToken = default)
    {
        return await GetAsync<UserResponse>(uri: "users/me", cancellationToken: cancellationToken);
    }
}
