using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_ReactiveProgramming.Models.Lichess
{
    public class ResponseTV
    {
        [JsonProperty("t")]
        public string T { get; set; }

        [JsonProperty("d")]
        public ResponseTV_D D { get; set; }
    }

    public class ResponseTV_D
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("orientation")]
        public string Orientation { get; set; }

        [JsonProperty("players")]
        public ResponseTV_Player[] Players { get; set; }

        [JsonProperty("fen")]
        public string Fen { get; set; }

        [JsonProperty("image")]
        public string Image{ get; set; }

        [JsonProperty("lm")]
        public string Lm { get; set; }

        [JsonProperty("wc")]
        public int Wc { get; set; }

        [JsonProperty("bc")]
        public int Bc { get; set; }
    }

    public class ResponseTV_Player
    {
        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("seconds")]
        public int Seconds { get; set; }
        public ResponseTV_Player_User User { get; set; }
    }

    public class ResponseTV_Player_User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
