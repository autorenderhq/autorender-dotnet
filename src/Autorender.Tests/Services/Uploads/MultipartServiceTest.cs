using System.Text;
using System.Threading.Tasks;

namespace Autorender.Tests.Services.Uploads;

public class MultipartServiceTest : TestBase
{
    [Fact]
    public async Task Complete_Works()
    {
        var upload = await this.client.Uploads.Multipart.Complete(
            new() { SessionID = "session_id" },
            TestContext.Current.CancellationToken
        );
        upload.Validate();
    }

    [Fact]
    public async Task Start_Works()
    {
        var session = await this.client.Uploads.Multipart.Start(
            new()
            {
                FileName = "file_name",
                Format = "format",
                Size = 0,
            },
            TestContext.Current.CancellationToken
        );
        session.Validate();
    }

    [Fact]
    public async Task UploadPart_Works()
    {
        await this.client.Uploads.Multipart.UploadPart(
            Encoding.UTF8.GetBytes("Example data"),
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
