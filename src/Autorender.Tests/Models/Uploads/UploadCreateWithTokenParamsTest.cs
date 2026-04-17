using System;
using System.Text;
using Autorender.Core;
using Autorender.Models.Uploads;

namespace Autorender.Tests.Models.Uploads;

public class UploadCreateWithTokenParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent body = Encoding.UTF8.GetBytes("Example data");

        var parameters = new UploadCreateWithTokenParams
        {
            Token = "up_tok_01JHD8X4BX3HQM8NFMD9ZCQ9QN",
            Body = body,
        };

        string expectedToken = "up_tok_01JHD8X4BX3HQM8NFMD9ZCQ9QN";
        BinaryContent expectedBody = body;

        Assert.Equal(expectedToken, parameters.Token);
        Assert.Equal(expectedBody, parameters.Body);
    }

    [Fact]
    public void Url_Works()
    {
        UploadCreateWithTokenParams parameters = new()
        {
            Token = "up_tok_01JHD8X4BX3HQM8NFMD9ZCQ9QN",
            Body = Encoding.UTF8.GetBytes("Example data"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://upload.autorender.io/api/v1/uploads/up_tok_01JHD8X4BX3HQM8NFMD9ZCQ9QN"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UploadCreateWithTokenParams
        {
            Token = "up_tok_01JHD8X4BX3HQM8NFMD9ZCQ9QN",
            Body = Encoding.UTF8.GetBytes("Example data"),
        };

        UploadCreateWithTokenParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
