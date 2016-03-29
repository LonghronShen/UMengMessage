using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    /// <summary>
    /// 状态查询回应
    /// </summary>
    public class StatusResponse
    {
        [JsonProperty("ret")]
        public string Ret { get; set; }

        [JsonProperty("data")]
        public StatusResponseBody Data { get; set; }
    }
}
