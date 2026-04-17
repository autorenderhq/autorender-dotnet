using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;

namespace Autorender.Models.Folders;

[JsonConverter(typeof(JsonModelConverter<FolderCreateResponse, FolderCreateResponseFromRaw>))]
public sealed record class FolderCreateResponse : JsonModel
{
    public string? FolderNo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("folder_no");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("folder_no", value);
        }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FolderNo;
        _ = this.Name;
    }

    public FolderCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderCreateResponse(FolderCreateResponse folderCreateResponse)
        : base(folderCreateResponse) { }
#pragma warning restore CS8618

    public FolderCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderCreateResponseFromRaw.FromRawUnchecked"/>
    public static FolderCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderCreateResponseFromRaw : IFromRawJson<FolderCreateResponse>
{
    /// <inheritdoc/>
    public FolderCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FolderCreateResponse.FromRawUnchecked(rawData);
}
