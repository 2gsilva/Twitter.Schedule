using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Twitter.Schedule.Model
{
    class Authentication
    {
        public string Username { get; set; } 
        public string Basic { get; set; }
        public string Bearer { get; set; }
        [JsonPropertyName("access_token")]
        public string BeareToken { get; set; }

        public Authentication(string username, string basic, string bearer)
        {
            this.Username = username;
            this.Basic = basic;
            this.Bearer = bearer;
        }
    }
}
