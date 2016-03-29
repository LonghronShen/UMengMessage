using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    /// <summary>
    /// 消息内容
    /// </summary>
    public class DroidPayLoad
    {
        public DroidPayLoad()
        {
            Body = new DroidPayLoadBody();
        }

        /// <summary>
        /// 必填，消息类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("display_type")]
        public DroidDisplayType DisplayType { get; set; }

        /// <summary>
        /// 必填，消息内容主体
        /// </summary>
        [JsonProperty("body")]
        public DroidPayLoadBody Body { get; set; }

        /// <summary>
        /// 可选，用户自定义key-value
        /// 当display_type=notification生效
        /// </summary>
        [JsonProperty("extra", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Extra { get; set; }
    }
}
