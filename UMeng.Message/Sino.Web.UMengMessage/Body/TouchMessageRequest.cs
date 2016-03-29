using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    /// <summary>
    /// IOS消息推送请求
    /// </summary>
    public class TouchMessageRequest : MessageRequest
    {
        [JsonProperty("payload")]
        public TouchPayLoad PayLoad { get; set; }
    }
}
