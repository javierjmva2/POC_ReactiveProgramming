using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_ReactiveProgramming.Models.FenService
{
    public class RequestModel
    {
        [JsonProperty("fen")]
        public string Fen { get; set; }

        [JsonProperty("last_move")]
        public string Last_Move { get; set; }
    }
}
