using System;
using System.Text;
using Autorender.Core;
using Autorender.Models.Uploads.Multipart;

namespace Autorender.Tests.Models.Uploads.Multipart;

public class MultipartUploadPartParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent body = Encoding.UTF8.GetBytes("Example data");

        var parameters = new MultipartUploadPartParams { Body = body };

        BinaryContent expectedBody = body;

        Assert.Equal(expectedBody, parameters.Body);
    }

    [Fact]
    public void Url_Works()
    {
        MultipartUploadPartParams parameters = new()
        {
            Body = Encoding.UTF8.GetBytes("Example data"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://upload.autorender.io/api/v1/multipart/parts"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MultipartUploadPartParams
        {
            Body = Encoding.UTF8.GetBytes("Example data"),
        };

        MultipartUploadPartParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
