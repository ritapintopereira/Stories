using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stories.Models
{
    public class Story
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("url")]
        public string Uri { get; set; }
        [JsonProperty("by")]
        public string PostedBy { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("score")]
        public int Score { get; set; }
        [JsonProperty("descendants")] 
        public int CommentCount { get; set; }
    }
}
