using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    public enum StatusCode
    {
        /// <summary>
        /// 排队中
        /// </summary>
        Listing = 0,
        /// <summary>
        /// 发送中
        /// </summary>
        Sending = 1,
        /// <summary>
        /// 发送完成
        /// </summary>
        Sended = 2,
        /// <summary>
        /// 发送失败
        /// </summary>
        SendFail = 3,
        /// <summary>
        /// 被撤销
        /// </summary>
        Cancel = 4,
        /// <summary>
        /// 消息过期
        /// </summary>
        Expire = 5,
        /// <summary>
        /// 筛选结果为空
        /// </summary>
        FilterNone = 6,
        /// <summary>
        /// 定时任务尚未开始处理
        /// </summary>
        Policy = 7
    }
}
