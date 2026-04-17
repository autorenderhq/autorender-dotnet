using System;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.Folders;

namespace Autorender.Tests.Models.Folders;

public class FolderListItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FolderListItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FolderNo = "folder_no",
            Name = "name",
            TotalItems = 0,
            TotalSize = 0,
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFolderNo = "folder_no";
        string expectedName = "name";
        long expectedTotalItems = 0;
        long expectedTotalSize = 0;

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFolderNo, model.FolderNo);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTotalItems, model.TotalItems);
        Assert.Equal(expectedTotalSize, model.TotalSize);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FolderListItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FolderNo = "folder_no",
            Name = "name",
            TotalItems = 0,
            TotalSize = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderListItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FolderListItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FolderNo = "folder_no",
            Name = "name",
            TotalItems = 0,
            TotalSize = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderListItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFolderNo = "folder_no";
        string expectedName = "name";
        long expectedTotalItems = 0;
        long expectedTotalSize = 0;

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFolderNo, deserialized.FolderNo);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTotalItems, deserialized.TotalItems);
        Assert.Equal(expectedTotalSize, deserialized.TotalSize);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FolderListItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FolderNo = "folder_no",
            Name = "name",
            TotalItems = 0,
            TotalSize = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FolderListItem { };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.FolderNo);
        Assert.False(model.RawData.ContainsKey("folder_no"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.TotalItems);
        Assert.False(model.RawData.ContainsKey("total_items"));
        Assert.Null(model.TotalSize);
        Assert.False(model.RawData.ContainsKey("total_size"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FolderListItem { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FolderListItem
        {
            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            FolderNo = null,
            Name = null,
            TotalItems = null,
            TotalSize = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.FolderNo);
        Assert.False(model.RawData.ContainsKey("folder_no"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.TotalItems);
        Assert.False(model.RawData.ContainsKey("total_items"));
        Assert.Null(model.TotalSize);
        Assert.False(model.RawData.ContainsKey("total_size"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FolderListItem
        {
            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            FolderNo = null,
            Name = null,
            TotalItems = null,
            TotalSize = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FolderListItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FolderNo = "folder_no",
            Name = "name",
            TotalItems = 0,
            TotalSize = 0,
        };

        FolderListItem copied = new(model);

        Assert.Equal(model, copied);
    }
}
