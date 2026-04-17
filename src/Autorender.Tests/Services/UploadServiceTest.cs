using System.Text;
using System.Threading.Tasks;

namespace Autorender.Tests.Services;

public class UploadServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var upload = await this.client.Uploads.Create(
            new() { File = Encoding.UTF8.GetBytes("Example data"), FileName = "file_name" },
            TestContext.Current.CancellationToken
        );
        upload.Validate();
    }

    [Fact]
    public async Task CreateFromUrl_Works()
    {
        var upload = await this.client.Uploads.CreateFromUrl(
            new() { RemoteUrl = "remote_url" },
            TestContext.Current.CancellationToken
        );
        upload.Validate();
    }

    [Fact]
    public async Task CreateWithToken_Works()
    {
        var upload = await this.client.Uploads.CreateWithToken(
            "up_tok_01JHD8X4BX3HQM8NFMD9ZCQ9QN",
            Encoding.UTF8.GetBytes("Example data"),
            new(),
            TestContext.Current.CancellationToken
        );
        upload.Validate();
    }

    [Fact]
    public async Task GenerateToken_Works()
    {
        var response = await this.client.Uploads.GenerateToken(
            new() { FileName = "avatar.jpg" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
