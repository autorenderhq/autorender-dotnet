using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;

namespace Autorender.Models.Folders;

[JsonConverter(typeof(JsonModelConverter<FolderListItem, FolderListItemFromRaw>))]
public sealed record class FolderListItem : JsonModel
{
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

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

    public long? TotalItems
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_items", value);
        }
    }

    /// <summary>
    /// Total size of items in bytes
    /// </summary>
    public long? TotalSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_size", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.FolderNo;
        _ = this.Name;
        _ = this.TotalItems;
        _ = this.TotalSize;
    }

    public FolderListItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderListItem(FolderListItem folderListItem)
        : base(folderListItem) { }
#pragma warning restore CS8618

    public FolderListItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderListItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderListItemFromRaw.FromRawUnchecked"/>
    public static FolderListItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderListItemFromRaw : IFromRawJson<FolderListItem>
{
    /// <inheritdoc/>
    public FolderListItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FolderListItem.FromRawUnchecked(rawData);
}
