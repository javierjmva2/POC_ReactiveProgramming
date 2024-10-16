using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC_ReactiveProgramming.Implementation.NdJson;
using POC_ReactiveProgramming.Interface.Lichess;
using POC_ReactiveProgramming.Models.Lichess;
using System.Net.Http.Json;

namespace POC_ReactiveProgramming.Implementation.Lichess
{
    public class LichessQuery : ILichessQuery
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly IConfiguration _configuration;

        public LichessQuery(IServiceProvider serviceProvider)
        {
            _configuration = serviceProvider.GetService<IConfiguration>();
        }

        public async Task GetInfoTvByChannel(string channel, IObserver<ResponseTV> observer)
        {
            using (HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, new Uri($"{_configuration.GetSection("Lichess:ApiUrlBase").Value}{string.Format(_configuration.GetSection("Lichess:EndPoint").Value, channel)}")))
            {
                using (HttpResponseMessage response = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();


                    await foreach (ResponseTV responseTV in response.Content!.ReadFromNdjsonAsync<ResponseTV>())
                    {
                        try
                        {
                            //Send to Observer
                            observer.OnNext(responseTV);
                        }
                        catch (Exception)
                        {
                        }
                    }

                    observer.OnCompleted();

                }
            }

        }
    }
}
