using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    /// <summary>
    /// 上传文件请求
    /// </summary>
    public class UploadRequest
    {
        [JsonProperty("appkey")]
        public string AppKey { get; set; }

        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
