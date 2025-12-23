using Osirisgate.Lemonsqueezy.Resource.Files.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Files;

/// <summary>
/// Implementation of the Files resource for managing file-related operations.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public sealed class FilesResource(ILemonsqueezyClient client) : Resource(client), IFilesResource
{
    /// <inheritdoc/>
    public async Task<FileResponse> RetrieveFileAsync(int fileId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<FileResponse>(uri: $"/files/{fileId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FilesResponse> ListAllFilesAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default)
    {
        return await GetAsync<FilesResponse>(uri: "/files", filters: filters, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VariantResponse> RetrieveVariantAsync(int fileId, CancellationToken cancellationToken = default)
    {
        return await GetAsync<VariantResponse>(uri: $"/files/{fileId}/variant", cancellationToken: cancellationToken);
    }
}
