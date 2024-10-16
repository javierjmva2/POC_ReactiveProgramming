using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC_ReactiveProgramming.Interface.FanService;
using POC_ReactiveProgramming.Models.FenService;
using System.Net.Http.Headers;

namespace POC_ReactiveProgramming.Implementation.FenService
{
    public class FenService: IFenService
    {
        private readonly static HttpClient _httpClient = new HttpClient();
        private readonly IConfiguration configuration;

        public FenService(IServiceProvider serviceProvider)
        {
            configuration = serviceProvider.GetService<IConfiguration>();
        }

        public async Task<string> GetImageAsync(RequestModel requestModel)
        {
            using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, configuration.GetSection("ConverterFen:UrlAPI").Value))
            {
                httpRequestMessage.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(requestModel), new MediaTypeHeaderValue("application/json"));

                var response = await _httpClient.SendAsync(httpRequestMessage);
                return $"data:image/png;base64, {Convert.ToBase64String(await response.Content.ReadAsByteArrayAsync())}";
            }
        }
    }
}
