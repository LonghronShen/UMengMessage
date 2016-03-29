using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    /// <summary>
    /// 取消推送回应主体
    /// </summary>
    public class CancelResponseBody
    {
        [JsonProperty("task_id")]
        public string TaskId { get; set; }

        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
    }
}
