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
        private static HttpClient Client = new HttpClient();
        private static string RequestUri = "https://api.twitter.com/oauth2/token?grant_type=client_credentials";
        private  IConfiguration Configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<Authentication> GetAuthentication()
        {         
            var authenticationModel = new Authentication("Authorization", Configuration["Authentication:Basic"].ToString(), null); 

            // Headers
             Client.DefaultRequestHeaders.Add(authenticationModel.Username,
                authenticationModel.Basic);
            Client.DefaultRequestHeaders.Add("Accept-Encoding",
               "gzip, deflate, br");
            Client.DefaultRequestHeaders.Add("Connection",
               "keep-alive");

            // Serializar objeto
            var authenticationJson = new StringContent(
          JsonSerializer.Serialize(authenticationModel),
          Encoding.UTF8,
          "application/json"
          );

            using var httpResponse = await Client.PostAsync(RequestUri, authenticationJson);
            httpResponse.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<Authentication>(httpResponse.ToString());
        }
    }
}
