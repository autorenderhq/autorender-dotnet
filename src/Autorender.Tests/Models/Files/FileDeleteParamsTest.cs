using System;
using Autorender.Models.Files;

namespace Autorender.Tests.Models.Files;

public class FileDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileDeleteParams { FileNo = "2353377462" };

        string expectedFileNo = "2353377462";

        Assert.Equal(expectedFileNo, parameters.FileNo);
    }

    [Fact]
    public void Url_Works()
    {
        FileDeleteParams parameters = new() { FileNo = "2353377462" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://upload.autorender.io/api/v1/files/2353377462"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileDeleteParams { FileNo = "2353377462" };

        FileDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
