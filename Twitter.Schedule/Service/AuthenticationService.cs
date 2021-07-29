using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Twitter.Schedule.Model;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Twitter.Schedule.Service
{
    class AuthenticationService
    {
        private static HttpClient client = new HttpClient();
        private static string requestUri = "https://api.twitter.com/oauth2/token?grant_type=client_credentials";
       // private static IConfiguration configuration;

        public async Task<Authentication> GetAuthentication(Authentication authentication)
        {

            authentication.Username = "Pz8Qgw0j7dhypOJyiGgl0W8bO"; // configuration.GetSection("Authentication:ApiKey").Value; 
            authentication.Password = "Xk2AlFgQHBxOrX72CO94rmnIeA4uITZ5BC2mjloL5xpHCjXTZT";  //configuration.GetSection("Authentication:ApiSecretKey").Value;
                                                                                             //authentication.Authorization = "Basic";
            var authenticationJson = new StringContent(
           JsonSerializer.Serialize(authentication),
           Encoding.UTF8,
           "application/json"
           );

            // Headers
             client.DefaultRequestHeaders.Add("Authorization",
                "Basic UHo4UWd3MGo3ZGh5cE9KeWlHZ2wwVzhiTzpYazJBbEZnUUhCeE9yWDcyQ085NHJtbkllQTR1SVRaNUJDMm1qbG9MNXhwSENqWFRaVA==");
            client.DefaultRequestHeaders.Add("Accept-Encoding",
               "gzip, deflate, br");
            client.DefaultRequestHeaders.Add("Connection",
               "keep-alive");

            using var httpResponse = await client.PostAsync(requestUri, authenticationJson);
            httpResponse.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<Authentication>(httpResponse.ToString());
        }
    }
}
