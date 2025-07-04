using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Classes
{
    internal static class JsonOptions
    {
        internal static JsonSerializerOptions Options = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            IgnoreReadOnlyProperties = true,
            //DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };
    }
}
