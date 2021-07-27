using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Twitter.Schedule.Model
{
    class Tweet
    {
        [JsonPropertyName("id")]
        public int TweetId { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("author_id")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
