using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    /// <summary>
    /// 返回结果主体
    /// </summary>
    public class MessageResponseBody
    {
        #region 成功时返回的参数

        [JsonProperty("msg_id")]
        public string MsgId { get; set; }

        [JsonProperty("task_id")]
        public string TaskId { get; set; }

        #endregion

        #region 调用失败返回的参数

        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        #endregion

        [JsonProperty("thirdparty_id")]
        public string ThirdPartyId { get; set; }
    }
}
