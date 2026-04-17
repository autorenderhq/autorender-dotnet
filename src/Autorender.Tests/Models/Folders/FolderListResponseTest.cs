using System;
using System.Collections.Generic;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.Folders;

namespace Autorender.Tests.Models.Folders;

public class FolderListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FolderListResponse
        {
            Folders =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FolderNo = "folder_no",
                    Name = "name",
                    TotalItems = 0,
                    TotalSize = 0,
                },
            ],
        };

        List<FolderListItem> expectedFolders =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FolderNo = "folder_no",
                Name = "name",
                TotalItems = 0,
                TotalSize = 0,
            },
        ];

        Assert.NotNull(model.Folders);
        Assert.Equal(expectedFolders.Count, model.Folders.Count);
        for (int i = 0; i < expectedFolders.Count; i++)
        {
            Assert.Equal(expectedFolders[i], model.Folders[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FolderListResponse
        {
            Folders =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FolderNo = "folder_no",
                    Name = "name",
                    TotalItems = 0,
                    TotalSize = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FolderListResponse
        {
            Folders =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FolderNo = "folder_no",
                    Name = "name",
                    TotalItems = 0,
                    TotalSize = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FolderListItem> expectedFolders =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FolderNo = "folder_no",
                Name = "name",
                TotalItems = 0,
                TotalSize = 0,
            },
        ];

        Assert.NotNull(deserialized.Folders);
        Assert.Equal(expectedFolders.Count, deserialized.Folders.Count);
        for (int i = 0; i < expectedFolders.Count; i++)
        {
            Assert.Equal(expectedFolders[i], deserialized.Folders[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FolderListResponse
        {
            Folders =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FolderNo = "folder_no",
                    Name = "name",
                    TotalItems = 0,
                    TotalSize = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FolderListResponse { };

        Assert.Null(model.Folders);
        Assert.False(model.RawData.ContainsKey("folders"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FolderListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FolderListResponse
        {
            // Null should be interpreted as omitted for these properties
            Folders = null,
        };

        Assert.Null(model.Folders);
        Assert.False(model.RawData.ContainsKey("folders"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FolderListResponse
        {
            // Null should be interpreted as omitted for these properties
            Folders = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FolderListResponse
        {
            Folders =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FolderNo = "folder_no",
                    Name = "name",
                    TotalItems = 0,
                    TotalSize = 0,
                },
            ],
        };

        FolderListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
