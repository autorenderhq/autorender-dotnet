using System.Text.Json;
using Autorender.Core;
using Autorender.Models.Uploads;

namespace Autorender.Tests.Models.Uploads;

public class UploadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Upload
        {
            Data = new()
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
            },
            Success = true,
        };

        UploadData expectedData = new()
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
        bool expectedSuccess = true;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Upload
        {
            Data = new()
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
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Upload>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Upload
        {
            Data = new()
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
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Upload>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        UploadData expectedData = new()
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
        bool expectedSuccess = true;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Upload
        {
            Data = new()
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
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Upload
        {
            Data = new()
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
            },
            Success = true,
        };

        Upload copied = new(model);

        Assert.Equal(model, copied);
    }
}
