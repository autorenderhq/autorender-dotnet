using System;
using Autorender.Models.Folders;

namespace Autorender.Tests.Models.Folders;

public class FolderListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FolderListParams { ParentFolderNo = "sD1LvqoDzG" };

        string expectedParentFolderNo = "sD1LvqoDzG";

        Assert.Equal(expectedParentFolderNo, parameters.ParentFolderNo);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FolderListParams { };

        Assert.Null(parameters.ParentFolderNo);
        Assert.False(parameters.RawQueryData.ContainsKey("parent_folder_no"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FolderListParams
        {
            // Null should be interpreted as omitted for these properties
            ParentFolderNo = null,
        };

        Assert.Null(parameters.ParentFolderNo);
        Assert.False(parameters.RawQueryData.ContainsKey("parent_folder_no"));
    }

    [Fact]
    public void Url_Works()
    {
        FolderListParams parameters = new() { ParentFolderNo = "sD1LvqoDzG" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://upload.autorender.io/api/v1/folders?parent_folder_no=sD1LvqoDzG"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FolderListParams { ParentFolderNo = "sD1LvqoDzG" };

        FolderListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
