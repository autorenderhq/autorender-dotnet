using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Autorender.Core;
using Autorender.Exceptions;
using Autorender.Models.Uploads;
using Autorender.Models.Uploads.Multipart;

namespace Autorender.Services.Uploads;

/// <inheritdoc/>
public sealed class MultipartService : IMultipartService
{
    readonly Lazy<IMultipartServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMultipartServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAutorenderClient _client;

    /// <inheritdoc/>
    public IMultipartService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MultipartService(this._client.WithOptions(modifier));
    }

    public MultipartService(IAutorenderClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MultipartServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Upload> Complete(
        MultipartCompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Complete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Session> Start(
        MultipartStartParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Start(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task UploadPart(
        MultipartUploadPartParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.UploadPart(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task UploadPart(
        BinaryContent body,
        MultipartUploadPartParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.UploadPart(parameters with { Body = body }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MultipartServiceWithRawResponse : IMultipartServiceWithRawResponse
{
    readonly IAutorenderClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMultipartServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MultipartServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MultipartServiceWithRawResponse(IAutorenderClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Upload>> Complete(
        MultipartCompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MultipartCompleteParams> request = new()
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
    public async Task<HttpResponse<Session>> Start(
        MultipartStartParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MultipartStartParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var session = await response.Deserialize<Session>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    session.Validate();
                }
                return session;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> UploadPart(
        MultipartUploadPartParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Body == null)
        {
            throw new AutorenderInvalidDataException("'parameters.Body' cannot be null");
        }

        HttpRequest<MultipartUploadPartParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> UploadPart(
        BinaryContent body,
        MultipartUploadPartParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UploadPart(parameters with { Body = body }, cancellationToken);
    }
}
