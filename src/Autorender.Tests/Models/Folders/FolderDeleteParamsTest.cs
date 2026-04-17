using System;
using Autorender.Models.Folders;

namespace Autorender.Tests.Models.Folders;

public class FolderDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FolderDeleteParams { FolderNo = "my8JeLg4tr" };

        string expectedFolderNo = "my8JeLg4tr";

        Assert.Equal(expectedFolderNo, parameters.FolderNo);
    }

    [Fact]
    public void Url_Works()
    {
        FolderDeleteParams parameters = new() { FolderNo = "my8JeLg4tr" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://upload.autorender.io/api/v1/folders/my8JeLg4tr"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FolderDeleteParams { FolderNo = "my8JeLg4tr" };

        FolderDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
