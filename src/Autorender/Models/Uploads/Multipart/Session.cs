using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;

namespace Autorender.Models.Uploads.Multipart;

[JsonConverter(typeof(JsonModelConverter<Session, SessionFromRaw>))]
public sealed record class Session : JsonModel
{
    /// <summary>
    /// Part size in bytes
    /// </summary>
    public long? PartSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("part_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("part_size", value);
        }
    }

    /// <summary>
    /// Presigned PUT URLs in order, one per part
    /// </summary>
    public IReadOnlyList<string>? Parts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("parts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "parts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Session UUID; required for the complete call
    /// </summary>
    public string? SessionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("session_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("session_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PartSize;
        _ = this.Parts;
        _ = this.SessionID;
    }

    public Session() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Session(Session session)
        : base(session) { }
#pragma warning restore CS8618

    public Session(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Session(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SessionFromRaw.FromRawUnchecked"/>
    public static Session FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SessionFromRaw : IFromRawJson<Session>
{
    /// <inheritdoc/>
    public Session FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Session.FromRawUnchecked(rawData);
}
