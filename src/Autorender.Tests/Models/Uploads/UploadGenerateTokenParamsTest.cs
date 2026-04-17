using System;
using System.Collections.Generic;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.Uploads;

namespace Autorender.Tests.Models.Uploads;

public class UploadGenerateTokenParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UploadGenerateTokenParams
        {
            FileName = "avatar.jpg",
            AllowOverride = new()
            {
                Folder = true,
                Tags = true,
                Transform = true,
            },
            CustomID = "custom_id",
            Folder = "user-uploads/avatars",
            MaxFileSize = 5242880,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            RandomPrefix = true,
            Tags = ["string"],
            Transform = "w_400,h_400,fit_cover",
            TtlSeconds = 900,
        };

        string expectedFileName = "avatar.jpg";
        AllowOverride expectedAllowOverride = new()
        {
            Folder = true,
            Tags = true,
            Transform = true,
        };
        string expectedCustomID = "custom_id";
        string expectedFolder = "user-uploads/avatars";
        long expectedMaxFileSize = 5242880;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        bool expectedRandomPrefix = true;
        List<string> expectedTags = ["string"];
        string expectedTransform = "w_400,h_400,fit_cover";
        long expectedTtlSeconds = 900;

        Assert.Equal(expectedFileName, parameters.FileName);
        Assert.Equal(expectedAllowOverride, parameters.AllowOverride);
        Assert.Equal(expectedCustomID, parameters.CustomID);
        Assert.Equal(expectedFolder, parameters.Folder);
        Assert.Equal(expectedMaxFileSize, parameters.MaxFileSize);
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
        Assert.Equal(expectedTransform, parameters.Transform);
        Assert.Equal(expectedTtlSeconds, parameters.TtlSeconds);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UploadGenerateTokenParams { FileName = "avatar.jpg" };

        Assert.Null(parameters.AllowOverride);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_override"));
        Assert.Null(parameters.CustomID);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_id"));
        Assert.Null(parameters.Folder);
        Assert.False(parameters.RawBodyData.ContainsKey("folder"));
        Assert.Null(parameters.MaxFileSize);
        Assert.False(parameters.RawBodyData.ContainsKey("max_file_size"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.RandomPrefix);
        Assert.False(parameters.RawBodyData.ContainsKey("random_prefix"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
        Assert.Null(parameters.Transform);
        Assert.False(parameters.RawBodyData.ContainsKey("transform"));
        Assert.Null(parameters.TtlSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("ttl_seconds"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UploadGenerateTokenParams
        {
            FileName = "avatar.jpg",

            // Null should be interpreted as omitted for these properties
            AllowOverride = null,
            CustomID = null,
            Folder = null,
            MaxFileSize = null,
            Metadata = null,
            RandomPrefix = null,
            Tags = null,
            Transform = null,
            TtlSeconds = null,
        };

        Assert.Null(parameters.AllowOverride);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_override"));
        Assert.Null(parameters.CustomID);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_id"));
        Assert.Null(parameters.Folder);
        Assert.False(parameters.RawBodyData.ContainsKey("folder"));
        Assert.Null(parameters.MaxFileSize);
        Assert.False(parameters.RawBodyData.ContainsKey("max_file_size"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.RandomPrefix);
        Assert.False(parameters.RawBodyData.ContainsKey("random_prefix"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
        Assert.Null(parameters.Transform);
        Assert.False(parameters.RawBodyData.ContainsKey("transform"));
        Assert.Null(parameters.TtlSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("ttl_seconds"));
    }

    [Fact]
    public void Url_Works()
    {
        UploadGenerateTokenParams parameters = new() { FileName = "avatar.jpg" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://upload.autorender.io/api/v1/generate-token"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UploadGenerateTokenParams
        {
            FileName = "avatar.jpg",
            AllowOverride = new()
            {
                Folder = true,
                Tags = true,
                Transform = true,
            },
            CustomID = "custom_id",
            Folder = "user-uploads/avatars",
            MaxFileSize = 5242880,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            RandomPrefix = true,
            Tags = ["string"],
            Transform = "w_400,h_400,fit_cover",
            TtlSeconds = 900,
        };

        UploadGenerateTokenParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AllowOverrideTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AllowOverride
        {
            Folder = true,
            Tags = true,
            Transform = true,
        };

        bool expectedFolder = true;
        bool expectedTags = true;
        bool expectedTransform = true;

        Assert.Equal(expectedFolder, model.Folder);
        Assert.Equal(expectedTags, model.Tags);
        Assert.Equal(expectedTransform, model.Transform);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AllowOverride
        {
            Folder = true,
            Tags = true,
            Transform = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AllowOverride>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AllowOverride
        {
            Folder = true,
            Tags = true,
            Transform = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AllowOverride>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedFolder = true;
        bool expectedTags = true;
        bool expectedTransform = true;

        Assert.Equal(expectedFolder, deserialized.Folder);
        Assert.Equal(expectedTags, deserialized.Tags);
        Assert.Equal(expectedTransform, deserialized.Transform);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AllowOverride
        {
            Folder = true,
            Tags = true,
            Transform = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AllowOverride { };

        Assert.Null(model.Folder);
        Assert.False(model.RawData.ContainsKey("folder"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Transform);
        Assert.False(model.RawData.ContainsKey("transform"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AllowOverride { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AllowOverride
        {
            // Null should be interpreted as omitted for these properties
            Folder = null,
            Tags = null,
            Transform = null,
        };

        Assert.Null(model.Folder);
        Assert.False(model.RawData.ContainsKey("folder"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Transform);
        Assert.False(model.RawData.ContainsKey("transform"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AllowOverride
        {
            // Null should be interpreted as omitted for these properties
            Folder = null,
            Tags = null,
            Transform = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AllowOverride
        {
            Folder = true,
            Tags = true,
            Transform = true,
        };

        AllowOverride copied = new(model);

        Assert.Equal(model, copied);
    }
}
