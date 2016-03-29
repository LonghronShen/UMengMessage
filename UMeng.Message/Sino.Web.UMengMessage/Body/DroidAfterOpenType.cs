using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    /// <summary>
    /// 通知点击之后的动作
    /// </summary>
    public enum DroidAfterOpenType
    {
        /// <summary>
        /// 打开应用
        /// </summary>
        go_app,

        /// <summary>
        /// 跳转到URL
        /// </summary>
        go_url,

        /// <summary>
        /// 打开特定的activity
        /// </summary>
        go_activity,

        /// <summary>
        /// 用户自定义内容
        /// </summary>
        go_custom
    }
}
