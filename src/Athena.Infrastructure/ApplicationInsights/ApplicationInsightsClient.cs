using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using System.Net.Http;
using System.Net.Http.Headers;


namespace Athena.Infrastructure.ApplicationInsights
{
    public class ApplicationInsightsClient
    {
        private const string URL =
        "https://api.applicationinsights.io/v1/apps/{0}/{1}/{2}?{3}";
        private readonly HttpClient _httpClient;

        public ApplicationInsightsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string GetTelemetry(string appid, string apikey,
                string queryType, string queryPath, string parameterString)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("x-api-key", apikey);
            var req = string.Format(URL, appid, queryType, queryPath, parameterString);
            HttpResponseMessage response = _httpClient.GetAsync(req).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return response.ReasonPhrase;
            }
        }
    }

}
