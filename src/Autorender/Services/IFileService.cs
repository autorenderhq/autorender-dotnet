using System;
using System.Threading;
using System.Threading.Tasks;
using Autorender.Core;
using Autorender.Models.Files;

namespace Autorender.Services;

/// <summary>
/// Manage files in your workspace
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve detailed information about a specific file by its file number.
    /// </summary>
    Task<FileObject> Retrieve(
        FileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FileRetrieveParams, CancellationToken)"/>
    Task<FileObject> Retrieve(
        string fileNo,
        FileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a file's tags and/or metadata. Tags are merged — add_tags appends,
    /// remove_tags removes. Metadata is merged with existing values.
    /// </summary>
    Task<FileUpdateResponse> Update(
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(FileUpdateParams, CancellationToken)"/>
    Task<FileUpdateResponse> Update(
        string fileNo,
        FileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Paginated list of files in the workspace. Filter by folder, path prefix, name,
    /// or tags. Sort by various fields.
    /// </summary>
    Task<FileListResponse> List(
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently delete a file from the workspace.
    /// </summary>
    Task<FileDeleteResponse> Delete(
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(FileDeleteParams, CancellationToken)"/>
    Task<FileDeleteResponse> Delete(
        string fileNo,
        FileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Rename a file. The server preserves the file extension (e.g., supplying
    /// "product" renames to "product.jpg").
    /// </summary>
    Task<FileRenameResponse> Rename(
        FileRenameParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Rename(FileRenameParams, CancellationToken)"/>
    Task<FileRenameResponse> Rename(
        string fileNo,
        FileRenameParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/files/{fileNo}</c>, but is otherwise the
    /// same as <see cref="IFileService.Retrieve(FileRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileObject>> Retrieve(
        FileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FileRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<FileObject>> Retrieve(
        string fileNo,
        FileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /api/v1/files/{fileNo}</c>, but is otherwise the
    /// same as <see cref="IFileService.Update(FileUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileUpdateResponse>> Update(
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(FileUpdateParams, CancellationToken)"/>
    Task<HttpResponse<FileUpdateResponse>> Update(
        string fileNo,
        FileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/files</c>, but is otherwise the
    /// same as <see cref="IFileService.List(FileListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileListResponse>> List(
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/files/{fileNo}</c>, but is otherwise the
    /// same as <see cref="IFileService.Delete(FileDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileDeleteResponse>> Delete(
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(FileDeleteParams, CancellationToken)"/>
    Task<HttpResponse<FileDeleteResponse>> Delete(
        string fileNo,
        FileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /api/v1/files/{fileNo}/rename</c>, but is otherwise the
    /// same as <see cref="IFileService.Rename(FileRenameParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileRenameResponse>> Rename(
        FileRenameParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Rename(FileRenameParams, CancellationToken)"/>
    Task<HttpResponse<FileRenameResponse>> Rename(
        string fileNo,
        FileRenameParams parameters,
        CancellationToken cancellationToken = default
    );
}
