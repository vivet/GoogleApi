using System;
using System.IO;
using Newtonsoft.Json;

namespace GoogleApi.Extensions
{
    public static class StreamExtension
    {
        public static T JsonDeserialize<T>(this Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            var jsonSerializer = new JsonSerializer();

            using (var streamReader = new StreamReader(stream))
            {
                return (T)jsonSerializer.Deserialize(streamReader, typeof(T));
            }
        }
    }
}