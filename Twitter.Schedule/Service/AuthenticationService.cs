using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
        private static string uri = "https://api.twitter.com/oauth2/token?grant_type=client_credentials";
       // private static IConfiguration configuration;

        public async Task<Authentication> GetAuthentication(Authentication authentication)
        {
            authentication.Username = "Pz8Qgw0j7dhypOJyiGgl0W8bO"; // configuration.GetSection("Authentication:ApiKey").Value; 
            authentication.Password = "Xk2AlFgQHBxOrX72CO94rmnIeA4uITZ5BC2mjloL5xpHCjXTZT";  //configuration.GetSection("Authentication:ApiSecretKey").Value;
                                                                                             //authentication.Authorization = "Basic";

            //var _jsonSerializerOptions = new JsonSerializerOptions();

            /*
               var authenticationJson = new StringContent(
                JsonConvert.SerializeObject(new
                {
                    authentication.Username,
                    authentication.Password
                }),
                //JsonSerializer.Serialize(authentication),
                Encoding.UTF8,
                "application/json"
                );
             */

            var authenticationJson = new StringContent(
           JsonSerializer.Serialize(authentication),
           Encoding.UTF8,
           "application/json"
           );

            using var httpResponse = await client.PostAsync(uri, authenticationJson);
            httpResponse.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<Authentication>(httpResponse.ToString());
        }
    }
}
