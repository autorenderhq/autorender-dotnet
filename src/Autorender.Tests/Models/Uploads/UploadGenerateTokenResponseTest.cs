using System.Collections.Generic;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.Uploads;

namespace Autorender.Tests.Models.Uploads;

public class UploadGenerateTokenResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadGenerateTokenResponse
        {
            Token = "up_tok_01JHD8X4BX3HQM8NFMD9ZCQ9QN",
            ExpireAt = 0,
            Policy = new()
            {
                AllowOverride = new()
                {
                    Folder = true,
                    Tags = true,
                    Transform = true,
                },
                Folder = "folder",
                MaxFileSize = 0,
                Tags = ["string"],
                Transform = "transform",
            },
            PublicKey = "public_key",
            Signature = "signature",
            WorkspaceID = "workspace_id",
        };

        string expectedToken = "up_tok_01JHD8X4BX3HQM8NFMD9ZCQ9QN";
        long expectedExpireAt = 0;
        Policy expectedPolicy = new()
        {
            AllowOverride = new()
            {
                Folder = true,
                Tags = true,
                Transform = true,
            },
            Folder = "folder",
            MaxFileSize = 0,
            Tags = ["string"],
            Transform = "transform",
        };
        string expectedPublicKey = "public_key";
        string expectedSignature = "signature";
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedToken, model.Token);
        Assert.Equal(expectedExpireAt, model.ExpireAt);
        Assert.Equal(expectedPolicy, model.Policy);
        Assert.Equal(expectedPublicKey, model.PublicKey);
        Assert.Equal(expectedSignature, model.Signature);
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UploadGenerateTokenResponse
        {
            Token = "up_tok_01JHD8X4BX3HQM8NFMD9ZCQ9QN",
            ExpireAt = 0,
            Policy = new()
            {
                AllowOverride = new()
                {
                    Folder = true,
                    Tags = true,
                    Transform = true,
                },
                Folder = "folder",
                MaxFileSize = 0,
                Tags = ["string"],
                Transform = "transform",
            },
            PublicKey = "public_key",
            Signature = "signature",
            WorkspaceID = "workspace_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UploadGenerateTokenResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadGenerateTokenResponse
        {
            Token = "up_tok_01JHD8X4BX3HQM8NFMD9ZCQ9QN",
            ExpireAt = 0,
            Policy = new()
            {
                AllowOverride = new()
                {
                    Folder = true,
                    Tags = true,
                    Transform = true,
                },
                Folder = "folder",
                MaxFileSize = 0,
                Tags = ["string"],
                Transform = "transform",
            },
            PublicKey = "public_key",
            Signature = "signature",
            WorkspaceID = "workspace_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UploadGenerateTokenResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToken = "up_tok_01JHD8X4BX3HQM8NFMD9ZCQ9QN";
        long expectedExpireAt = 0;
        Policy expectedPolicy = new()
        {
            AllowOverride = new()
            {
                Folder = true,
                Tags = true,
                Transform = true,
            },
            Folder = "folder",
            MaxFileSize = 0,
            Tags = ["string"],
            Transform = "transform",
        };
        string expectedPublicKey = "public_key";
        string expectedSignature = "signature";
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.Equal(expectedExpireAt, deserialized.ExpireAt);
        Assert.Equal(expectedPolicy, deserialized.Policy);
        Assert.Equal(expectedPublicKey, deserialized.PublicKey);
        Assert.Equal(expectedSignature, deserialized.Signature);
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UploadGenerateTokenResponse
        {
            Token = "up_tok_01JHD8X4BX3HQM8NFMD9ZCQ9QN",
            ExpireAt = 0,
            Policy = new()
            {
                AllowOverride = new()
                {
                    Folder = true,
                    Tags = true,
                    Transform = true,
                },
                Folder = "folder",
                MaxFileSize = 0,
                Tags = ["string"],
                Transform = "transform",
            },
            PublicKey = "public_key",
            Signature = "signature",
            WorkspaceID = "workspace_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UploadGenerateTokenResponse { };

        Assert.Null(model.Token);
        Assert.False(model.RawData.ContainsKey("token"));
        Assert.Null(model.ExpireAt);
        Assert.False(model.RawData.ContainsKey("expire_at"));
        Assert.Null(model.Policy);
        Assert.False(model.RawData.ContainsKey("policy"));
        Assert.Null(model.PublicKey);
        Assert.False(model.RawData.ContainsKey("public_key"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
        Assert.Null(model.WorkspaceID);
        Assert.False(model.RawData.ContainsKey("workspace_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UploadGenerateTokenResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UploadGenerateTokenResponse
        {
            // Null should be interpreted as omitted for these properties
            Token = null,
            ExpireAt = null,
            Policy = null,
            PublicKey = null,
            Signature = null,
            WorkspaceID = null,
        };

        Assert.Null(model.Token);
        Assert.False(model.RawData.ContainsKey("token"));
        Assert.Null(model.ExpireAt);
        Assert.False(model.RawData.ContainsKey("expire_at"));
        Assert.Null(model.Policy);
        Assert.False(model.RawData.ContainsKey("policy"));
        Assert.Null(model.PublicKey);
        Assert.False(model.RawData.ContainsKey("public_key"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
        Assert.Null(model.WorkspaceID);
        Assert.False(model.RawData.ContainsKey("workspace_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UploadGenerateTokenResponse
        {
            // Null should be interpreted as omitted for these properties
            Token = null,
            ExpireAt = null,
            Policy = null,
            PublicKey = null,
            Signature = null,
            WorkspaceID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UploadGenerateTokenResponse
        {
            Token = "up_tok_01JHD8X4BX3HQM8NFMD9ZCQ9QN",
            ExpireAt = 0,
            Policy = new()
            {
                AllowOverride = new()
                {
                    Folder = true,
                    Tags = true,
                    Transform = true,
                },
                Folder = "folder",
                MaxFileSize = 0,
                Tags = ["string"],
                Transform = "transform",
            },
            PublicKey = "public_key",
            Signature = "signature",
            WorkspaceID = "workspace_id",
        };

        UploadGenerateTokenResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PolicyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Policy
        {
            AllowOverride = new()
            {
                Folder = true,
                Tags = true,
                Transform = true,
            },
            Folder = "folder",
            MaxFileSize = 0,
            Tags = ["string"],
            Transform = "transform",
        };

        PolicyAllowOverride expectedAllowOverride = new()
        {
            Folder = true,
            Tags = true,
            Transform = true,
        };
        string expectedFolder = "folder";
        long expectedMaxFileSize = 0;
        List<string> expectedTags = ["string"];
        string expectedTransform = "transform";

        Assert.Equal(expectedAllowOverride, model.AllowOverride);
        Assert.Equal(expectedFolder, model.Folder);
        Assert.Equal(expectedMaxFileSize, model.MaxFileSize);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedTransform, model.Transform);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Policy
        {
            AllowOverride = new()
            {
                Folder = true,
                Tags = true,
                Transform = true,
            },
            Folder = "folder",
            MaxFileSize = 0,
            Tags = ["string"],
            Transform = "transform",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Policy>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Policy
        {
            AllowOverride = new()
            {
                Folder = true,
                Tags = true,
                Transform = true,
            },
            Folder = "folder",
            MaxFileSize = 0,
            Tags = ["string"],
            Transform = "transform",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Policy>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        PolicyAllowOverride expectedAllowOverride = new()
        {
            Folder = true,
            Tags = true,
            Transform = true,
        };
        string expectedFolder = "folder";
        long expectedMaxFileSize = 0;
        List<string> expectedTags = ["string"];
        string expectedTransform = "transform";

        Assert.Equal(expectedAllowOverride, deserialized.AllowOverride);
        Assert.Equal(expectedFolder, deserialized.Folder);
        Assert.Equal(expectedMaxFileSize, deserialized.MaxFileSize);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedTransform, deserialized.Transform);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Policy
        {
            AllowOverride = new()
            {
                Folder = true,
                Tags = true,
                Transform = true,
            },
            Folder = "folder",
            MaxFileSize = 0,
            Tags = ["string"],
            Transform = "transform",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Policy { Transform = "transform" };

        Assert.Null(model.AllowOverride);
        Assert.False(model.RawData.ContainsKey("allow_override"));
        Assert.Null(model.Folder);
        Assert.False(model.RawData.ContainsKey("folder"));
        Assert.Null(model.MaxFileSize);
        Assert.False(model.RawData.ContainsKey("max_file_size"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Policy { Transform = "transform" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Policy
        {
            Transform = "transform",

            // Null should be interpreted as omitted for these properties
            AllowOverride = null,
            Folder = null,
            MaxFileSize = null,
            Tags = null,
        };

        Assert.Null(model.AllowOverride);
        Assert.False(model.RawData.ContainsKey("allow_override"));
        Assert.Null(model.Folder);
        Assert.False(model.RawData.ContainsKey("folder"));
        Assert.Null(model.MaxFileSize);
        Assert.False(model.RawData.ContainsKey("max_file_size"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Policy
        {
            Transform = "transform",

            // Null should be interpreted as omitted for these properties
            AllowOverride = null,
            Folder = null,
            MaxFileSize = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Policy
        {
            AllowOverride = new()
            {
                Folder = true,
                Tags = true,
                Transform = true,
            },
            Folder = "folder",
            MaxFileSize = 0,
            Tags = ["string"],
        };

        Assert.Null(model.Transform);
        Assert.False(model.RawData.ContainsKey("transform"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Policy
        {
            AllowOverride = new()
            {
                Folder = true,
                Tags = true,
                Transform = true,
            },
            Folder = "folder",
            MaxFileSize = 0,
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Policy
        {
            AllowOverride = new()
            {
                Folder = true,
                Tags = true,
                Transform = true,
            },
            Folder = "folder",
            MaxFileSize = 0,
            Tags = ["string"],

            Transform = null,
        };

        Assert.Null(model.Transform);
        Assert.True(model.RawData.ContainsKey("transform"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Policy
        {
            AllowOverride = new()
            {
                Folder = true,
                Tags = true,
                Transform = true,
            },
            Folder = "folder",
            MaxFileSize = 0,
            Tags = ["string"],

            Transform = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Policy
        {
            AllowOverride = new()
            {
                Folder = true,
                Tags = true,
                Transform = true,
            },
            Folder = "folder",
            MaxFileSize = 0,
            Tags = ["string"],
            Transform = "transform",
        };

        Policy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PolicyAllowOverrideTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PolicyAllowOverride
        {
            Folder = true,
            Tags = true,
            Transform = true,
        };

        bool expectedFolder = true;
        bool expectedTags = true;
        bool expectedTransform = true;

        Assert.Equal(expectedFolder, model.Folder);
        Assert.Equal(expectedTags, model.Tags);
        Assert.Equal(expectedTransform, model.Transform);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PolicyAllowOverride
        {
            Folder = true,
            Tags = true,
            Transform = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PolicyAllowOverride>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PolicyAllowOverride
        {
            Folder = true,
            Tags = true,
            Transform = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PolicyAllowOverride>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedFolder = true;
        bool expectedTags = true;
        bool expectedTransform = true;

        Assert.Equal(expectedFolder, deserialized.Folder);
        Assert.Equal(expectedTags, deserialized.Tags);
        Assert.Equal(expectedTransform, deserialized.Transform);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PolicyAllowOverride
        {
            Folder = true,
            Tags = true,
            Transform = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PolicyAllowOverride { };

        Assert.Null(model.Folder);
        Assert.False(model.RawData.ContainsKey("folder"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Transform);
        Assert.False(model.RawData.ContainsKey("transform"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PolicyAllowOverride { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PolicyAllowOverride
        {
            // Null should be interpreted as omitted for these properties
            Folder = null,
            Tags = null,
            Transform = null,
        };

        Assert.Null(model.Folder);
        Assert.False(model.RawData.ContainsKey("folder"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Transform);
        Assert.False(model.RawData.ContainsKey("transform"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PolicyAllowOverride
        {
            // Null should be interpreted as omitted for these properties
            Folder = null,
            Tags = null,
            Transform = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PolicyAllowOverride
        {
            Folder = true,
            Tags = true,
            Transform = true,
        };

        PolicyAllowOverride copied = new(model);

        Assert.Equal(model, copied);
    }
}
