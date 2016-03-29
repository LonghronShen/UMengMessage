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
    /// 消息通知基础类
    /// </summary>
    public abstract class MessageRequest
    {
        /// <summary>
        /// 必填，应用唯一标识
        /// </summary>
        [JsonProperty("appkey")]
        public string AppKey { get; set; }

        /// <summary>
        /// 必填，时间截，10位或13位
        /// </summary>
        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; }

        /// <summary>
        /// 必填，消息发送类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public SendType SendType { get; set; }

        /// <summary>
        /// 选填，设备唯一标识
        /// 当type为UniCast时，必填，表示指定的单个设备
        /// 当type为ListCast时，必填，要求不超过500个，
        /// 多个device_token以英文逗号
        /// </summary>
        [JsonProperty("device_tokens", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceTokens { get; set; }

        /// <summary>
        /// 可选，当type为CustomizedCast时必填
        /// 由客户端的SetAlias指定
        /// </summary>
        [JsonProperty("alias_type", NullValueHandling = NullValueHandling.Ignore)]
        public string AliasType { get; set; }

        /// <summary>
        /// 可选，当type为CustomizedCast时必填
        /// 由客户端SetAlias指定
        /// </summary>
        [JsonProperty("alias", NullValueHandling = NullValueHandling.Ignore)]
        public string Alias { get; set; }

        /// <summary>
        /// 可选，当type为FileCast时必填
        /// </summary>
        [JsonProperty("file_id", NullValueHandling = NullValueHandling.Ignore)]
        public string FileId { get; set; }

        /// <summary>
        /// 可选，终端用户筛选条件
        /// </summary>
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public object Filter { get; set; }

        /// <summary>
        /// 可选，发送策略
        /// </summary>
        [JsonProperty("policy", NullValueHandling = NullValueHandling.Ignore)]
        public Policy Policy { get; set; }

        /// <summary>
        /// 可选，正式/测试模式
        /// </summary>
        [JsonProperty("production_mode", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductionMode { get; set; }

        /// <summary>
        /// 可选，发送消息描述
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// 可选，开发者自定义消息标识ID
        /// </summary>
        [JsonProperty("thirdparty_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ThirdPartyId { get; set; }
    }
}
