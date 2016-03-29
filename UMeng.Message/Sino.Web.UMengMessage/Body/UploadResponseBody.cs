using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    public class UploadResponseBody
    {
        [JsonProperty("file_id")]
        public string FileId { get; set; }

        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
    }
}
