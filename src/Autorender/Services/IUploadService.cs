using System;
using System.Threading;
using System.Threading.Tasks;
using Autorender.Core;
using Autorender.Models.Uploads;

namespace Autorender.Services;

/// <summary>
/// Upload files to your workspace
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IUploadService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUploadServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUploadService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Upload a file to your AutoRender workspace with optional transformations, tags,
    /// and folder organization
    /// </summary>
    Task<Upload> Create(
        UploadCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Download a file from a remote HTTP/HTTPS URL and store it in your AutoRender
    /// workspace. Supports optional transformations and metadata.
    /// </summary>
    Task<Upload> CreateFromUrl(
        UploadCreateFromUrlParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload a file directly from a browser or mobile client using a token from POST
    /// /api/v1/generate-token. Send raw file bytes as the request body. Filename and
    /// upload policy are taken from the token.
    /// </summary>
    Task<Upload> CreateWithToken(
        UploadCreateWithTokenParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateWithToken(UploadCreateWithTokenParams, CancellationToken)"/>
    Task<Upload> CreateWithToken(
        string token,
        BinaryContent body,
        UploadCreateWithTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generate a short-lived signed token that allows a browser or mobile client to
    /// upload directly to AutoRender without exposing your secret API key. The token
    /// encodes upload policy (folder, tags, transforms, file size limit). No file
    /// record is created until the token is used.
    /// </summary>
    Task<UploadGenerateTokenResponse> GenerateToken(
        UploadGenerateTokenParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUploadService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUploadServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUploadServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/uploads</c>, but is otherwise the
    /// same as <see cref="IUploadService.Create(UploadCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Upload>> Create(
        UploadCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/uploads/remote</c>, but is otherwise the
    /// same as <see cref="IUploadService.CreateFromUrl(UploadCreateFromUrlParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Upload>> CreateFromUrl(
        UploadCreateFromUrlParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/uploads/{token}</c>, but is otherwise the
    /// same as <see cref="IUploadService.CreateWithToken(UploadCreateWithTokenParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Upload>> CreateWithToken(
        UploadCreateWithTokenParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateWithToken(UploadCreateWithTokenParams, CancellationToken)"/>
    Task<HttpResponse<Upload>> CreateWithToken(
        string token,
        BinaryContent body,
        UploadCreateWithTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/generate-token</c>, but is otherwise the
    /// same as <see cref="IUploadService.GenerateToken(UploadGenerateTokenParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UploadGenerateTokenResponse>> GenerateToken(
        UploadGenerateTokenParams parameters,
        CancellationToken cancellationToken = default
    );
}
