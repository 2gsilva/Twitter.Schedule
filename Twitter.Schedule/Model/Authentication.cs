using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Twitter.Schedule.Model
{
    class Authentication
    {
        // public string Authorization { get; set; }
        // API Key
        [JsonPropertyName("username")]
        public string Username { get; set; }
        // API Secret Key
        [JsonPropertyName("password")]
        public string Password { get; set; }
       // [JsonPropertyName("access_token")]
       // public string BeareToken { get; set; }
    }
}
