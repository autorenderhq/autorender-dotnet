using System;
using Autorender.Models.Uploads.Multipart;

namespace Autorender.Tests.Models.Uploads.Multipart;

public class MultipartCompleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MultipartCompleteParams { SessionID = "session_id" };

        string expectedSessionID = "session_id";

        Assert.Equal(expectedSessionID, parameters.SessionID);
    }

    [Fact]
    public void Url_Works()
    {
        MultipartCompleteParams parameters = new() { SessionID = "session_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://upload.autorender.io/api/v1/multipart/complete"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MultipartCompleteParams { SessionID = "session_id" };

        MultipartCompleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
