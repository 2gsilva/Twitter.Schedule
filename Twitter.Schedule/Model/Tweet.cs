using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Twitter.Schedule.Model
{
    class Tweet
    {
        [JsonPropertyNameAttribute("id")]
        public int TweetId { get; set; }
        [JsonPropertyNameAttribute("text")]
        public string Text { get; set; }
        [JsonPropertyNameAttribute("author_id")]
        public string Authorid { get; set; }
    }
}
