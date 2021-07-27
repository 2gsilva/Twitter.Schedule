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
        private static string uri = "https://api.twitter.com/2/tweets/search/recent?query=%23firjan OR @firjan&expansions=author_id";

        public async Task<Tweet> GetTweets()
        {
            var requisicao = await client.GetStringAsync(uri);

            return JsonConvert.DeserializeObject<Tweet>(requisicao);
        }
    }
}
