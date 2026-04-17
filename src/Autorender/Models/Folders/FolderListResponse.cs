using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;

namespace Autorender.Models.Folders;

[JsonConverter(typeof(JsonModelConverter<FolderListResponse, FolderListResponseFromRaw>))]
public sealed record class FolderListResponse : JsonModel
{
    public IReadOnlyList<FolderListItem>? Folders
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FolderListItem>>("folders");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<FolderListItem>?>(
                "folders",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Folders ?? [])
        {
            item.Validate();
        }
    }

    public FolderListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderListResponse(FolderListResponse folderListResponse)
        : base(folderListResponse) { }
#pragma warning restore CS8618

    public FolderListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderListResponseFromRaw.FromRawUnchecked"/>
    public static FolderListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderListResponseFromRaw : IFromRawJson<FolderListResponse>
{
    /// <inheritdoc/>
    public FolderListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FolderListResponse.FromRawUnchecked(rawData);
}
