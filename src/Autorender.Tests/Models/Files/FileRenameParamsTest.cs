using System;
using Autorender.Models.Files;

namespace Autorender.Tests.Models.Files;

public class FileRenameParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileRenameParams { FileNo = "2353377462", Name = "name" };

        string expectedFileNo = "2353377462";
        string expectedName = "name";

        Assert.Equal(expectedFileNo, parameters.FileNo);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void Url_Works()
    {
        FileRenameParams parameters = new() { FileNo = "2353377462", Name = "name" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://upload.autorender.io/api/v1/files/2353377462/rename"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileRenameParams { FileNo = "2353377462", Name = "name" };

        FileRenameParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
