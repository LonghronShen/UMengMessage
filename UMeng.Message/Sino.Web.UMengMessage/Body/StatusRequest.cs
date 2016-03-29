using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    /// <summary>
    /// 推送状态查询
    /// </summary>
    public class StatusRequest
    {
        [JsonProperty("appkey")]
        public string AppKey { get; set; }

        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; }

        [JsonProperty("task_id")]
        public string TaskId { get; set; }
    }
}
