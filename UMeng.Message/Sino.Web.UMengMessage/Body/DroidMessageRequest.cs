using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    /// <summary>
    /// Android消息推送请求
    /// </summary>
    public class DroidMessageRequest : MessageRequest
    {
        public DroidMessageRequest()
        {
            PayLoad = new DroidPayLoad();
        }

        /// <summary>
        /// 必填，消息内容
        /// </summary>
        [JsonProperty("payload")]
        public DroidPayLoad PayLoad { get; set; }
    }
}
