using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage
{
    /// <summary>
    /// 辅助工具类
    /// </summary>
    public static class Utility
    {
        public static string MD5(string method,string url,string body,string secret)
        {
            StringBuilder str = new StringBuilder();
            str.Append(method);
            str.Append(url);
            str.Append(body);
            str.Append(secret);
            var md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(Encoding.UTF8.GetBytes(str.ToString()));
            str.Clear();
            md5.Clear();
            for (int i = 0; i < result.Length; i++)
            {
                str.Append(Convert.ToString(result[i], 16).PadLeft(2, '0'));
            }
            return str.ToString().PadLeft(32, '0');
        }

        public static string GetDeviceToken(params string[] deviceToken)
        {
            StringBuilder str = new StringBuilder();
            bool isFirst = false;
            foreach (string item in deviceToken)
            {
                if (!isFirst)
                {
                    isFirst = true;
                    str.Append(item);
                }
                else
                {
                    str.Append("," + item);
                }
            }
            return str.ToString();
        }

        public static int GetTimeStamp()
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (int)(DateTime.Now - startTime).TotalSeconds;
        }
    }
}
