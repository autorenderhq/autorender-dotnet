using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;

namespace Autorender.Models.Files;

[JsonConverter(typeof(JsonModelConverter<FileDeleteResponse, FileDeleteResponseFromRaw>))]
public sealed record class FileDeleteResponse : JsonModel
{
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
    }

    public FileDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileDeleteResponse(FileDeleteResponse fileDeleteResponse)
        : base(fileDeleteResponse) { }
#pragma warning restore CS8618

    public FileDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileDeleteResponseFromRaw.FromRawUnchecked"/>
    public static FileDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileDeleteResponseFromRaw : IFromRawJson<FileDeleteResponse>
{
    /// <inheritdoc/>
    public FileDeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileDeleteResponse.FromRawUnchecked(rawData);
}
