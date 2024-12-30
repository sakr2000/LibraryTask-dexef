using System.Text.Json.Serialization;

namespace LibraryTask_dexef.Shared.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        Admin,
        User
    }
}

