using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    public class StatusResponseBody
    {
        [JsonProperty("task_id")]
        public string TaskId { get; set; }

        /// <summary>
        /// 消息状态
        /// </summary>
        [JsonProperty("status")]
        public StatusCode Status { get; set; }

        /// <summary>
        /// 消息总数
        /// </summary>
        [JsonProperty("total_count")]
        public int? TotalCount { get; set; }

        /// <summary>
        /// 消息受理数
        /// </summary>
        [JsonProperty("accept_count")]
        public int? AcceptCount { get; set; }

        /// <summary>
        /// 消息实际发送数
        /// </summary>
        [JsonProperty("sent_count")]
        public int? SentCount { get; set; }

        /// <summary>
        /// 打开数
        /// </summary>
        [JsonProperty("open_count")]
        public int? OpenCount { get; set; }

        /// <summary>
        /// 忽略数
        /// </summary>
        [JsonProperty("dismiss_count")]
        public int? DismissCount { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
    }
}
