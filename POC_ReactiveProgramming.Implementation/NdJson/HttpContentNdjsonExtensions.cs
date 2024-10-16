using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace POC_ReactiveProgramming.Implementation.NdJson
{
    internal static class HttpContentNdjsonExtensions
    {
        private static readonly JsonSerializerOptions _serializerOptions
            = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

        public static async IAsyncEnumerable<TValue> ReadFromNdjsonAsync<TValue>(this HttpContent content)
        {
            if (content is null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            string? mediaType = content.Headers.ContentType?.MediaType;

            if (mediaType is null || !mediaType.Equals("application/x-ndjson", StringComparison.OrdinalIgnoreCase))
            {
                throw new NotSupportedException();
            }

            Stream contentStream = await content.ReadAsStreamAsync().ConfigureAwait(false);

            using (contentStream)
            {
                using (StreamReader contentStreamReader = new StreamReader(contentStream))
                {
                    while (!contentStreamReader.EndOfStream)
                    {
                        string json = await contentStreamReader.ReadLineAsync()
                            .ConfigureAwait(false);
                        yield return JsonSerializer.Deserialize<TValue>(json, _serializerOptions);
                    }
                }
            }
        }
    }
}
