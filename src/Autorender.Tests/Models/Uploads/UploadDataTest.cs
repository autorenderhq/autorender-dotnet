using System.Text.Json;
using Autorender.Core;
using Autorender.Models.Uploads;

namespace Autorender.Tests.Models.Uploads;

public class UploadDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadData
        {
            ID = "id",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            Height = 0,
            Name = "name",
            Path = "path",
            Url = "url",
            Width = 0,
            WorkspaceNo = "workspace_no",
        };

        string expectedID = "id";
        string expectedFileNo = "file_no";
        long expectedFileSize = 0;
        string expectedFormat = "format";
        long expectedHeight = 0;
        string expectedName = "name";
        string expectedPath = "path";
        string expectedUrl = "url";
        long expectedWidth = 0;
        string expectedWorkspaceNo = "workspace_no";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedFileNo, model.FileNo);
        Assert.Equal(expectedFileSize, model.FileSize);
        Assert.Equal(expectedFormat, model.Format);
        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedWidth, model.Width);
        Assert.Equal(expectedWorkspaceNo, model.WorkspaceNo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UploadData
        {
            ID = "id",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            Height = 0,
            Name = "name",
            Path = "path",
            Url = "url",
            Width = 0,
            WorkspaceNo = "workspace_no",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UploadData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadData
        {
            ID = "id",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            Height = 0,
            Name = "name",
            Path = "path",
            Url = "url",
            Width = 0,
            WorkspaceNo = "workspace_no",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UploadData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedFileNo = "file_no";
        long expectedFileSize = 0;
        string expectedFormat = "format";
        long expectedHeight = 0;
        string expectedName = "name";
        string expectedPath = "path";
        string expectedUrl = "url";
        long expectedWidth = 0;
        string expectedWorkspaceNo = "workspace_no";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedFileNo, deserialized.FileNo);
        Assert.Equal(expectedFileSize, deserialized.FileSize);
        Assert.Equal(expectedFormat, deserialized.Format);
        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedWidth, deserialized.Width);
        Assert.Equal(expectedWorkspaceNo, deserialized.WorkspaceNo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UploadData
        {
            ID = "id",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            Height = 0,
            Name = "name",
            Path = "path",
            Url = "url",
            Width = 0,
            WorkspaceNo = "workspace_no",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UploadData { Height = 0, Width = 0 };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.FileNo);
        Assert.False(model.RawData.ContainsKey("file_no"));
        Assert.Null(model.FileSize);
        Assert.False(model.RawData.ContainsKey("file_size"));
        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.WorkspaceNo);
        Assert.False(model.RawData.ContainsKey("workspace_no"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UploadData { Height = 0, Width = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UploadData
        {
            Height = 0,
            Width = 0,

            // Null should be interpreted as omitted for these properties
            ID = null,
            FileNo = null,
            FileSize = null,
            Format = null,
            Name = null,
            Path = null,
            Url = null,
            WorkspaceNo = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.FileNo);
        Assert.False(model.RawData.ContainsKey("file_no"));
        Assert.Null(model.FileSize);
        Assert.False(model.RawData.ContainsKey("file_size"));
        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.WorkspaceNo);
        Assert.False(model.RawData.ContainsKey("workspace_no"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UploadData
        {
            Height = 0,
            Width = 0,

            // Null should be interpreted as omitted for these properties
            ID = null,
            FileNo = null,
            FileSize = null,
            Format = null,
            Name = null,
            Path = null,
            Url = null,
            WorkspaceNo = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UploadData
        {
            ID = "id",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            Name = "name",
            Path = "path",
            Url = "url",
            WorkspaceNo = "workspace_no",
        };

        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UploadData
        {
            ID = "id",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            Name = "name",
            Path = "path",
            Url = "url",
            WorkspaceNo = "workspace_no",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UploadData
        {
            ID = "id",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            Name = "name",
            Path = "path",
            Url = "url",
            WorkspaceNo = "workspace_no",

            Height = null,
            Width = null,
        };

        Assert.Null(model.Height);
        Assert.True(model.RawData.ContainsKey("height"));
        Assert.Null(model.Width);
        Assert.True(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UploadData
        {
            ID = "id",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            Name = "name",
            Path = "path",
            Url = "url",
            WorkspaceNo = "workspace_no",

            Height = null,
            Width = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UploadData
        {
            ID = "id",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            Height = 0,
            Name = "name",
            Path = "path",
            Url = "url",
            Width = 0,
            WorkspaceNo = "workspace_no",
        };

        UploadData copied = new(model);

        Assert.Equal(model, copied);
    }
}
