using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    /// <summary>
    /// 发送策略
    /// </summary>
    public class Policy
    {
        /// <summary>
        /// 可选，定时发送时间
        /// 格式为 YYYY-MM-DD hh:mm:ss
        /// </summary>
        [JsonProperty("start_time", NullValueHandling = NullValueHandling.Ignore)]
        public string StartTime { get; set; }

        /// <summary>
        /// 可选，消息过期时间
        /// </summary>
        [JsonProperty("expire_time", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpireTime { get; set; }

        /// <summary>
        /// 可选，发送限速，每秒发送的最大条数
        /// </summary>
        [JsonProperty("max_send_num", NullValueHandling = NullValueHandling.Ignore)]
        public int MaxSendNum { get; set; }

        /// <summary>
        /// 可选，开发者对消息的唯一标识
        /// </summary>
        [JsonProperty("out_biz_no", NullValueHandling = NullValueHandling.Ignore)]
        public string OutBizNo { get; set; }
    }
}
