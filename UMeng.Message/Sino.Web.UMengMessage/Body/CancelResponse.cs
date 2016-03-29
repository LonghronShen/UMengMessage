using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    /// <summary>
    /// 取消推送回应
    /// </summary>
    public class CancelResponse
    {
        [JsonProperty("ret")]
        public string Ret { get; set; }

        [JsonProperty("data")]
        public CancelResponseBody Data { get; set; }
    }
}
