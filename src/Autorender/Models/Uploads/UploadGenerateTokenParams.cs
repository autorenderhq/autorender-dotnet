using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;

namespace Autorender.Models.Uploads;

/// <summary>
/// Generate a short-lived signed token that allows a browser or mobile client to
/// upload directly to AutoRender without exposing your secret API key. The token
/// encodes upload policy (folder, tags, transforms, file size limit). No file record
/// is created until the token is used.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UploadGenerateTokenParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Filename for the upload (e.g., avatar.jpg)
    /// </summary>
    public required string FileName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("file_name");
        }
        init { this._rawBodyData.Set("file_name", value); }
    }

    /// <summary>
    /// Which policy fields the uploader may override
    /// </summary>
    public AllowOverride? AllowOverride
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<AllowOverride>("allow_override");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("allow_override", value);
        }
    }

    /// <summary>
    /// Custom identifier for the file
    /// </summary>
    public string? CustomID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("custom_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("custom_id", value);
        }
    }

    /// <summary>
    /// Destination folder path
    /// </summary>
    public string? Folder
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("folder");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("folder", value);
        }
    }

    /// <summary>
    /// Maximum allowed file size in bytes
    /// </summary>
    public long? MaxFileSize
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("max_file_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("max_file_size", value);
        }
    }

    /// <summary>
    /// Custom metadata to attach
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Add a random prefix to the filename
    /// </summary>
    public bool? RandomPrefix
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("random_prefix");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("random_prefix", value);
        }
    }

    /// <summary>
    /// Tags to apply to the uploaded file
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Transformation string applied on upload
    /// </summary>
    public string? Transform
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("transform");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("transform", value);
        }
    }

    /// <summary>
    /// Token lifetime in seconds (default: 300)
    /// </summary>
    public long? TtlSeconds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("ttl_seconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("ttl_seconds", value);
        }
    }

    public UploadGenerateTokenParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadGenerateTokenParams(UploadGenerateTokenParams uploadGenerateTokenParams)
        : base(uploadGenerateTokenParams)
    {
        this._rawBodyData = new(uploadGenerateTokenParams._rawBodyData);
    }
#pragma warning restore CS8618

    public UploadGenerateTokenParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadGenerateTokenParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UploadGenerateTokenParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(UploadGenerateTokenParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/generate-token")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Which policy fields the uploader may override
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AllowOverride, AllowOverrideFromRaw>))]
public sealed record class AllowOverride : JsonModel
{
    public bool? Folder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("folder");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("folder", value);
        }
    }

    public bool? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tags", value);
        }
    }

    public bool? Transform
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("transform");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transform", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Folder;
        _ = this.Tags;
        _ = this.Transform;
    }

    public AllowOverride() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AllowOverride(AllowOverride allowOverride)
        : base(allowOverride) { }
#pragma warning restore CS8618

    public AllowOverride(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AllowOverride(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AllowOverrideFromRaw.FromRawUnchecked"/>
    public static AllowOverride FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AllowOverrideFromRaw : IFromRawJson<AllowOverride>
{
    /// <inheritdoc/>
    public AllowOverride FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AllowOverride.FromRawUnchecked(rawData);
}
