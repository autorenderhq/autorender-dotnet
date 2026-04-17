using System.Collections.Generic;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.Uploads.Multipart;

namespace Autorender.Tests.Models.Uploads.Multipart;

public class SessionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Session
        {
            PartSize = 0,
            Parts = ["https://example.com"],
            SessionID = "session_id",
        };

        long expectedPartSize = 0;
        List<string> expectedParts = ["https://example.com"];
        string expectedSessionID = "session_id";

        Assert.Equal(expectedPartSize, model.PartSize);
        Assert.NotNull(model.Parts);
        Assert.Equal(expectedParts.Count, model.Parts.Count);
        for (int i = 0; i < expectedParts.Count; i++)
        {
            Assert.Equal(expectedParts[i], model.Parts[i]);
        }
        Assert.Equal(expectedSessionID, model.SessionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Session
        {
            PartSize = 0,
            Parts = ["https://example.com"],
            SessionID = "session_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Session>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Session
        {
            PartSize = 0,
            Parts = ["https://example.com"],
            SessionID = "session_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Session>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedPartSize = 0;
        List<string> expectedParts = ["https://example.com"];
        string expectedSessionID = "session_id";

        Assert.Equal(expectedPartSize, deserialized.PartSize);
        Assert.NotNull(deserialized.Parts);
        Assert.Equal(expectedParts.Count, deserialized.Parts.Count);
        for (int i = 0; i < expectedParts.Count; i++)
        {
            Assert.Equal(expectedParts[i], deserialized.Parts[i]);
        }
        Assert.Equal(expectedSessionID, deserialized.SessionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Session
        {
            PartSize = 0,
            Parts = ["https://example.com"],
            SessionID = "session_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Session { };

        Assert.Null(model.PartSize);
        Assert.False(model.RawData.ContainsKey("part_size"));
        Assert.Null(model.Parts);
        Assert.False(model.RawData.ContainsKey("parts"));
        Assert.Null(model.SessionID);
        Assert.False(model.RawData.ContainsKey("session_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Session { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Session
        {
            // Null should be interpreted as omitted for these properties
            PartSize = null,
            Parts = null,
            SessionID = null,
        };

        Assert.Null(model.PartSize);
        Assert.False(model.RawData.ContainsKey("part_size"));
        Assert.Null(model.Parts);
        Assert.False(model.RawData.ContainsKey("parts"));
        Assert.Null(model.SessionID);
        Assert.False(model.RawData.ContainsKey("session_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Session
        {
            // Null should be interpreted as omitted for these properties
            PartSize = null,
            Parts = null,
            SessionID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Session
        {
            PartSize = 0,
            Parts = ["https://example.com"],
            SessionID = "session_id",
        };

        Session copied = new(model);

        Assert.Equal(model, copied);
    }
}
