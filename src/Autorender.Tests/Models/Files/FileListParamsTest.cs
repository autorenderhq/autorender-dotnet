using System;
using System.Text.Json;
using Autorender.Core;
using Autorender.Exceptions;
using Autorender.Models.Files;

namespace Autorender.Tests.Models.Files;

public class FileListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileListParams
        {
            FolderNo = "folder_no",
            Limit = 0,
            Name = "name",
            Page = 0,
            Path = "path",
            SortField = SortField.FileSize,
            SortOrder = SortOrder.Asc,
            Tags = "tags",
        };

        string expectedFolderNo = "folder_no";
        long expectedLimit = 0;
        string expectedName = "name";
        long expectedPage = 0;
        string expectedPath = "path";
        ApiEnum<string, SortField> expectedSortField = SortField.FileSize;
        ApiEnum<string, SortOrder> expectedSortOrder = SortOrder.Asc;
        string expectedTags = "tags";

        Assert.Equal(expectedFolderNo, parameters.FolderNo);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedPath, parameters.Path);
        Assert.Equal(expectedSortField, parameters.SortField);
        Assert.Equal(expectedSortOrder, parameters.SortOrder);
        Assert.Equal(expectedTags, parameters.Tags);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileListParams { };

        Assert.Null(parameters.FolderNo);
        Assert.False(parameters.RawQueryData.ContainsKey("folder_no"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawQueryData.ContainsKey("name"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Path);
        Assert.False(parameters.RawQueryData.ContainsKey("path"));
        Assert.Null(parameters.SortField);
        Assert.False(parameters.RawQueryData.ContainsKey("sort_field"));
        Assert.Null(parameters.SortOrder);
        Assert.False(parameters.RawQueryData.ContainsKey("sort_order"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawQueryData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FileListParams
        {
            // Null should be interpreted as omitted for these properties
            FolderNo = null,
            Limit = null,
            Name = null,
            Page = null,
            Path = null,
            SortField = null,
            SortOrder = null,
            Tags = null,
        };

        Assert.Null(parameters.FolderNo);
        Assert.False(parameters.RawQueryData.ContainsKey("folder_no"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawQueryData.ContainsKey("name"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Path);
        Assert.False(parameters.RawQueryData.ContainsKey("path"));
        Assert.Null(parameters.SortField);
        Assert.False(parameters.RawQueryData.ContainsKey("sort_field"));
        Assert.Null(parameters.SortOrder);
        Assert.False(parameters.RawQueryData.ContainsKey("sort_order"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawQueryData.ContainsKey("tags"));
    }

    [Fact]
    public void Url_Works()
    {
        FileListParams parameters = new()
        {
            FolderNo = "folder_no",
            Limit = 0,
            Name = "name",
            Page = 0,
            Path = "path",
            SortField = SortField.FileSize,
            SortOrder = SortOrder.Asc,
            Tags = "tags",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://upload.autorender.io/api/v1/files?folder_no=folder_no&limit=0&name=name&page=0&path=path&sort_field=file_size&sort_order=asc&tags=tags"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileListParams
        {
            FolderNo = "folder_no",
            Limit = 0,
            Name = "name",
            Page = 0,
            Path = "path",
            SortField = SortField.FileSize,
            SortOrder = SortOrder.Asc,
            Tags = "tags",
        };

        FileListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SortFieldTest : TestBase
{
    [Theory]
    [InlineData(SortField.FileSize)]
    [InlineData(SortField.Name)]
    [InlineData(SortField.CreatedAt)]
    [InlineData(SortField.UpdatedAt)]
    public void Validation_Works(SortField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SortField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SortField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AutorenderInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SortField.FileSize)]
    [InlineData(SortField.Name)]
    [InlineData(SortField.CreatedAt)]
    [InlineData(SortField.UpdatedAt)]
    public void SerializationRoundtrip_Works(SortField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SortField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SortField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SortField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SortField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SortOrderTest : TestBase
{
    [Theory]
    [InlineData(SortOrder.Asc)]
    [InlineData(SortOrder.Desc)]
    public void Validation_Works(SortOrder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SortOrder> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SortOrder>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AutorenderInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SortOrder.Asc)]
    [InlineData(SortOrder.Desc)]
    public void SerializationRoundtrip_Works(SortOrder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SortOrder> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SortOrder>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SortOrder>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SortOrder>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
