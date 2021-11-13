using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Twitter.Schedule.Model;

namespace Twitter.Schedule.Service
{
    public class TweetService
    {
        private static HttpClient client = new HttpClient();
        private static string requestUri = null;
        private IConfiguration Configuration;

        public TweetService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<TweetsRetorno> GetTweets()
        {
            var authenticationModel = new Authentication("Authorization", null, Configuration["Authentication:Bearer"].ToString());

            requestUri = Configuration["Request:UriTweets"].ToString();

            // Headers
            client.DefaultRequestHeaders.Add(authenticationModel.Username,
                authenticationModel.Bearer);
            client.DefaultRequestHeaders.Add("Connection",
               "keep-alive");

            var response = await client.GetStringAsync(requestUri);

            ExportaJson(response);

            return JsonConvert.DeserializeObject<TweetsRetorno>(response);
        }

        private void ExportaJson (string respostaJson)
        {
            using (StreamWriter file = File.CreateText(@"C:\RepoPessoal\Twitter.Schedule\Twitter.Schedule\ArquivosJson\Tweet.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                
                serializer.Serialize(file, respostaJson);
            }
        }
    }
}
