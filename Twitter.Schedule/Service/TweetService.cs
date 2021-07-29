using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Twitter.Schedule.Model;

namespace Twitter.Schedule.Service
{
    class TweetService
    {
        private static HttpClient client = new HttpClient();
        private static string requestUri = "https://api.twitter.com/2/tweets/search/recent?query=%23firjan&expansions=author_id";

        public async Task<TweetsRetorno> GetTweets()
        {

            // Headers
            client.DefaultRequestHeaders.Add("Authorization",
                "Bearer AAAAAAAAAAAAAAAAAAAAAEF9RwEAAAAAGF5TKCtPB%2BreOJGaji8s%2FtfMykQ%3DpPnmGNtwuTw5w20SaZmYowu9FZltYwddl0hpMe48qh4ZWViXUN");
            client.DefaultRequestHeaders.Add("Connection",
               "keep-alive");


            var response = await client.GetStringAsync(requestUri); 

            return JsonConvert.DeserializeObject<TweetsRetorno>(response);
        }
    }
}
