using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    /// <summary>
    /// 取消消息推送
    /// </summary>
    public class CancelRequest
    {
        [JsonProperty("appkey")]
        public string AppKey { get; set; }

        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; }

        [JsonProperty("task_id")]
        public string TaskId { get; set; }
    }
}
