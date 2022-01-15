
namespace GoogleApi.Test
{
    internal static class Extensions
    {
        private static System.Text.Json.JsonSerializerOptions settings = new System.Text.Json.JsonSerializerOptions()
        {
            WriteIndented = true,
            PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
        };

        internal static string ToJson(this object subject)
        {
            return System.Text.Json.JsonSerializer.Serialize(subject, settings);
        }
    }

}