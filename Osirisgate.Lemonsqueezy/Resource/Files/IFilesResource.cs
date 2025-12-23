using Osirisgate.Lemonsqueezy.Resource.Files.Response;
using Osirisgate.Lemonsqueezy.Resource.Variants.Response;

namespace Osirisgate.Lemonsqueezy.Resource.Files;

/// <summary>
/// Interface for managing file-related operations in the Lemonsqueezy API.
/// </summary>
/// <remarks>
/// Developed by Osirisgate - Ulrich Geraud AHOGLA | Contact: developer@osirisgate.com
/// </remarks>
public interface IFilesResource
{
    /// <summary>Retrieves a specific file by ID.</summary>
    public Task<FileResponse> RetrieveFileAsync(int fileId, CancellationToken cancellationToken = default);

    /// <summary>Lists all files with optional filtering.</summary>
    public Task<FilesResponse> ListAllFilesAsync(Dictionary<string, object>? filters = null, CancellationToken cancellationToken = default);

    /// <summary>Retrieves the variant associated with a file.</summary>
    public Task<VariantResponse> RetrieveVariantAsync(int fileId, CancellationToken cancellationToken = default);
}
