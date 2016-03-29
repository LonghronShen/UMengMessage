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
    /// 消息内容主体
    /// </summary>
    public class DroidPayLoadBody
    {
        /// <summary>
        /// 必填，通知栏提示文字
        /// </summary>
        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        /// <summary>
        /// 必填，通知标题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 必填，通知文字描述
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// 可选，状态栏图表ID
        /// </summary>
        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        /// <summary>
        /// 可选，通知栏拉开后左侧图标ID
        /// </summary>
        [JsonProperty("largeIcon", NullValueHandling = NullValueHandling.Ignore)]
        public string LargeIcon { get; set; }

        /// <summary>
        /// 可选，通知栏大图标URL链接
        /// </summary>
        [JsonProperty("img", NullValueHandling = NullValueHandling.Ignore)]
        public string Img { get; set; }

        /// <summary>
        /// 可选，通知栏声音
        /// </summary>
        [JsonProperty("sound", NullValueHandling = NullValueHandling.Ignore)]
        public string Sound { get; set; }

        /// <summary>
        /// 可选，默认为0，用于标识该通知采用的样式
        /// 需要开发者在SDK中实现自定义通知栏样式
        /// </summary>
        [JsonProperty("builder_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? BuilderId { get; set; }

        /// <summary>
        /// 可选，收到通知时是否震动，默认为true
        /// </summary>
        [JsonProperty("play_vibrate", NullValueHandling = NullValueHandling.Ignore)]
        public string PlayVibrate { get; set; }

        /// <summary>
        /// 可选，收到通知时是否闪灯，默认为true
        /// </summary>
        [JsonProperty("play_lights", NullValueHandling = NullValueHandling.Ignore)]
        public string PlayLights { get; set; }

        /// <summary>
        /// 可选，收到通知时是否发出声音，默认为true
        /// </summary>
        [JsonProperty("play_sound", NullValueHandling = NullValueHandling.Ignore)]
        public string PlaySound { get; set; }

        /// <summary>
        /// 必填，点击通知后的行为
        /// </summary>
        [JsonProperty("after_open")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DroidAfterOpenType AfterOpen { get; set; }

        /// <summary>
        /// 可选，当after_open为go_url时必填
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        /// <summary>
        /// 可选，当after_open为go_activity时必填
        /// </summary>
        [JsonProperty("activity", NullValueHandling = NullValueHandling.Ignore)]
        public string Activity { get; set; }

        /// <summary>
        /// 可选，当display_type=message，或
        /// display_type=notification且after_open为go_custom时必填
        /// </summary>
        [JsonProperty("custom", NullValueHandling = NullValueHandling.Ignore)]
        public object Custom { get; set; }
    }
}
