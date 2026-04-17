using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Autorender.Core;
using Autorender.Exceptions;
using Autorender.Models.Uploads;
using Autorender.Services.Uploads;

namespace Autorender.Services;

/// <inheritdoc/>
public sealed class UploadService : IUploadService
{
    readonly Lazy<IUploadServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUploadServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAutorenderClient _client;

    /// <inheritdoc/>
    public IUploadService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UploadService(this._client.WithOptions(modifier));
    }

    public UploadService(IAutorenderClient client)
    {
        _client = client;

        _withRawResponse = new(() => new UploadServiceWithRawResponse(client.WithRawResponse));
        _multipart = new(() => new MultipartService(client));
    }

    readonly Lazy<IMultipartService> _multipart;
    public IMultipartService Multipart
    {
        get { return _multipart.Value; }
    }

    /// <inheritdoc/>
    public async Task<Upload> Create(
        UploadCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Upload> CreateFromUrl(
        UploadCreateFromUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateFromUrl(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Upload> CreateWithToken(
        UploadCreateWithTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateWithToken(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Upload> CreateWithToken(
        string token,
        BinaryContent body,
        UploadCreateWithTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateWithToken(
            parameters with
            {
                Token = token,
                Body = body,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<UploadGenerateTokenResponse> GenerateToken(
        UploadGenerateTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GenerateToken(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class UploadServiceWithRawResponse : IUploadServiceWithRawResponse
{
    readonly IAutorenderClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUploadServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UploadServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UploadServiceWithRawResponse(IAutorenderClientWithRawResponse client)
    {
        _client = client;

        _multipart = new(() => new MultipartServiceWithRawResponse(client));
    }

    readonly Lazy<IMultipartServiceWithRawResponse> _multipart;
    public IMultipartServiceWithRawResponse Multipart
    {
        get { return _multipart.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Upload>> Create(
        UploadCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UploadCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var upload = await response.Deserialize<Upload>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    upload.Validate();
                }
                return upload;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Upload>> CreateFromUrl(
        UploadCreateFromUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UploadCreateFromUrlParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var upload = await response.Deserialize<Upload>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    upload.Validate();
                }
                return upload;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Upload>> CreateWithToken(
        UploadCreateWithTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Token == null)
        {
            throw new AutorenderInvalidDataException("'parameters.Token' cannot be null");
        }
        if (parameters.Body == null)
        {
            throw new AutorenderInvalidDataException("'parameters.Body' cannot be null");
        }

        HttpRequest<UploadCreateWithTokenParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var upload = await response.Deserialize<Upload>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    upload.Validate();
                }
                return upload;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Upload>> CreateWithToken(
        string token,
        BinaryContent body,
        UploadCreateWithTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateWithToken(
            parameters with
            {
                Token = token,
                Body = body,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UploadGenerateTokenResponse>> GenerateToken(
        UploadGenerateTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UploadGenerateTokenParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<UploadGenerateTokenResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
