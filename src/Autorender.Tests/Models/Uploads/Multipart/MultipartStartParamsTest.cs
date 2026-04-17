using System;
using System.Collections.Generic;
using System.Text.Json;
using Autorender.Models.Uploads.Multipart;

namespace Autorender.Tests.Models.Uploads.Multipart;

public class MultipartStartParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MultipartStartParams
        {
            FileName = "file_name",
            Format = "format",
            Size = 0,
            CustomID = "custom_id",
            Folder = "folder",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            RandomPrefix = true,
            Tags = ["string"],
            TtlSeconds = 0,
        };

        string expectedFileName = "file_name";
        string expectedFormat = "format";
        long expectedSize = 0;
        string expectedCustomID = "custom_id";
        string expectedFolder = "folder";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        bool expectedRandomPrefix = true;
        List<string> expectedTags = ["string"];
        long expectedTtlSeconds = 0;

        Assert.Equal(expectedFileName, parameters.FileName);
        Assert.Equal(expectedFormat, parameters.Format);
        Assert.Equal(expectedSize, parameters.Size);
        Assert.Equal(expectedCustomID, parameters.CustomID);
        Assert.Equal(expectedFolder, parameters.Folder);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Metadata[item.Key]));
        }
        Assert.Equal(expectedRandomPrefix, parameters.RandomPrefix);
        Assert.NotNull(parameters.Tags);
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], parameters.Tags[i]);
        }
        Assert.Equal(expectedTtlSeconds, parameters.TtlSeconds);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MultipartStartParams
        {
            FileName = "file_name",
            Format = "format",
            Size = 0,
        };

        Assert.Null(parameters.CustomID);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_id"));
        Assert.Null(parameters.Folder);
        Assert.False(parameters.RawBodyData.ContainsKey("folder"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.RandomPrefix);
        Assert.False(parameters.RawBodyData.ContainsKey("random_prefix"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
        Assert.Null(parameters.TtlSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("ttl_seconds"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MultipartStartParams
        {
            FileName = "file_name",
            Format = "format",
            Size = 0,

            // Null should be interpreted as omitted for these properties
            CustomID = null,
            Folder = null,
            Metadata = null,
            RandomPrefix = null,
            Tags = null,
            TtlSeconds = null,
        };

        Assert.Null(parameters.CustomID);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_id"));
        Assert.Null(parameters.Folder);
        Assert.False(parameters.RawBodyData.ContainsKey("folder"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.RandomPrefix);
        Assert.False(parameters.RawBodyData.ContainsKey("random_prefix"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
        Assert.Null(parameters.TtlSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("ttl_seconds"));
    }

    [Fact]
    public void Url_Works()
    {
        MultipartStartParams parameters = new()
        {
            FileName = "file_name",
            Format = "format",
            Size = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://upload.autorender.io/api/v1/multipart/start"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MultipartStartParams
        {
            FileName = "file_name",
            Format = "format",
            Size = 0,
            CustomID = "custom_id",
            Folder = "folder",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            RandomPrefix = true,
            Tags = ["string"],
            TtlSeconds = 0,
        };

        MultipartStartParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
