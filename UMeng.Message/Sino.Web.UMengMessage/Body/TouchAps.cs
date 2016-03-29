using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    public class TouchAps
    {
        [JsonProperty("alert")]
        public string Alert { get; set; }

        [JsonProperty("badge", NullValueHandling = NullValueHandling.Ignore)]
        public int Badge { get; set; }

        [JsonProperty("sound", NullValueHandling = NullValueHandling.Ignore)]
        public string Sound { get; set; }

        [JsonProperty("content-available", NullValueHandling = NullValueHandling.Ignore)]
        public int ContentAvailable { get; set; }

        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }
    }
}
