using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    /// <summary>
    /// 发送通知后返回的数据
    /// </summary>
    public class MessageResponse
    {
        /// <summary>
        /// 返回结果，"SUCCESS"或"FAIL"
        /// </summary>
        [JsonProperty("ret")]
        public string Ret { get; set; }

        [JsonProperty("data")]
        public MessageResponseBody Data { get; set; }
    }
}
