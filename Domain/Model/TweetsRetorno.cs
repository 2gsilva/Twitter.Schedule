using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Twitter.Schedule.Model
{
    public class TweetsRetorno
    {
        [JsonProperty("data")]
          public List<Tweet> Data { get; set; }
    }
}
