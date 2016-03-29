using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    /// <summary>
    /// 上传文件回应
    /// </summary>
    public class UploadResponse
    {
        [JsonProperty("ret")]
        public string Ret { get; set; }

        [JsonProperty("data")]
        public UploadResponseBody Data { get; set; }
    }
}
