using Osirisgate.Lemonsqueezy.Resource.Users.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Users;

/// <summary>
/// Interface for managing user-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface IUsersResource
{
    /// <summary>
    /// Retrieves the currently authenticated user's information.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the user response.</returns>
    public Task<UserResponse> RetrieveUserAsync(CancellationToken cancellationToken = default);
}
