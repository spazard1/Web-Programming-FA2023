using Mario.Entities;
using Newtonsoft.Json;
using Polly;
using System.Diagnostics;
using System.Net;

namespace Mario.Services
{
    public class ExternalMarioService
    {
        private readonly HttpClient httpClient = new();

        public async Task<ExternalMarioEntity?> GetMarioLevelResultAsync()
        {
            var policy = Policy.HandleInner<HttpRequestException>((ex) =>
            {
                return ex?.StatusCode == HttpStatusCode.ServiceUnavailable;
            }).WaitAndRetryAsync(5, retryAttempt =>
                TimeSpan.FromMilliseconds(100 * Math.Pow(2, retryAttempt))
            ,(ex, timeSpan, context) =>
            {
                Debug.WriteLine("We are trying again! " + ex.Message);
            });

            string? responseString = null;

            await policy.ExecuteAsync(async () =>
            {
                var response = await httpClient.GetAsync("https://webprogrammingmario.azurewebsites.net/api/mario/jump");
                response.EnsureSuccessStatusCode();
                responseString = await response.Content.ReadAsStringAsync();
            });

            if (responseString == null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<ExternalMarioEntity?>(responseString);
        }
    }
}
