using Mario.Entities;
using Newtonsoft.Json;

namespace Mario.Services
{
    public class ExternalMarioService
    {
        private readonly HttpClient httpClient = new();

        public async Task<ExternalMarioEntity?> GetMarioLevelResultAsync()
        {
            var response = await httpClient.GetAsync("https://www.google.com");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ExternalMarioEntity?>(responseString);
        }
    }
}
