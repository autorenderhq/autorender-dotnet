using System;
using System.Threading;
using System.Threading.Tasks;
using Autorender.Core;
using Autorender.Models.Uploads;
using Autorender.Models.Uploads.Multipart;

namespace Autorender.Services.Uploads;

/// <summary>
/// Large file uploads via multipart
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMultipartService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMultipartServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMultipartService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Finalize a multipart upload after all parts have been uploaded. Assembles the
    /// parts and creates the file record.
    /// </summary>
    Task<Upload> Complete(
        MultipartCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Initiate a multipart upload session for large files. Returns presigned PUT URLs
    /// for each part. Upload each part to its URL in order, then call POST
    /// /api/v1/multipart/complete.
    /// </summary>
    Task<Session> Start(
        MultipartStartParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload a single part using one of the presigned URLs from POST
    /// /api/v1/multipart/start. Send raw bytes directly — do not include the AutoRender
    /// Authorization header, as auth is embedded in the presigned URL.
    /// </summary>
    Task UploadPart(
        MultipartUploadPartParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UploadPart(MultipartUploadPartParams, CancellationToken)"/>
    Task UploadPart(
        BinaryContent body,
        MultipartUploadPartParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMultipartService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMultipartServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMultipartServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/multipart/complete</c>, but is otherwise the
    /// same as <see cref="IMultipartService.Complete(MultipartCompleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Upload>> Complete(
        MultipartCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/multipart/start</c>, but is otherwise the
    /// same as <see cref="IMultipartService.Start(MultipartStartParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Session>> Start(
        MultipartStartParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1/multipart/parts</c>, but is otherwise the
    /// same as <see cref="IMultipartService.UploadPart(MultipartUploadPartParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> UploadPart(
        MultipartUploadPartParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UploadPart(MultipartUploadPartParams, CancellationToken)"/>
    Task<HttpResponse> UploadPart(
        BinaryContent body,
        MultipartUploadPartParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
