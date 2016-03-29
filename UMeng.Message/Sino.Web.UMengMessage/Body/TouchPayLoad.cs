using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage.Body
{
    /// <summary>
    /// 通知主体
    /// </summary>
    public class TouchPayLoad : Dictionary<string, object>
    {
        public TouchAps Aps { get; set; }

        [OnSerializing]
        internal void OnSerializing(StreamingContext context)
        {
            this.Add("aps", this.Aps);
        }
    }
}
