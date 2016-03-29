using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    /// <summary>
    /// 发送类型
    /// </summary>
    public enum SendType
    {
        /// <summary>
        /// 单播
        /// </summary>
        unicast,
        /// <summary>
        /// 列播
        /// </summary>
        listcast,
        /// <summary>
        /// 文件播
        /// </summary>
        filecast,
        /// <summary>
        /// 广播
        /// </summary>
        broadcast,
        /// <summary>
        /// 组播
        /// </summary>
        groupcast,
        /// <summary>
        /// 自定义
        /// </summary>
        customizedcast
    }
}
