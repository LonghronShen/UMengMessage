using Newtonsoft.Json;
using Sino.Web.UMengMessage.Body;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Web.UMengMessage
{
    public class UMessage
    {
        private static readonly string SendUrl = "http://msg.umeng.com/api/send";
        private static readonly string StatusUrl = "http://msg.umeng.com/api/status";
        private static readonly string CancelUrl = "http://msg.umeng.com/api/cancel";
        private static readonly string UploadUrl = "http://msg.umeng.com/api/upload";

        private string _appkey;
        private string _secret;

        public UMessage(string appkey,string secret)
        {
            if (String.IsNullOrWhiteSpace(appkey))
                throw new ArgumentNullException("AppKey");
            if (String.IsNullOrWhiteSpace(secret))
                throw new ArgumentNullException("Secart");

            _appkey = appkey;
            _secret = secret;
        }

        /// <summary>
        /// 发送Android推送通知
        /// </summary>
        public async Task<MessageResponse> SendDroidMessage(DroidMessageRequest msg)
        {
            CheckDroidMessageRequest(msg);

            return await SendRequest<MessageResponse, DroidMessageRequest>(SendUrl, msg);
        }

        /// <summary>
        /// 发送Android广播推送
        /// </summary>
        /// <param name="ticker">通知栏提示文字</param>
        /// <param name="title">通知标题</param>
        /// <param name="text">通知文字描述</param>
        public async Task<MessageResponse> SendDroidBroadcastMessage(string ticker, string title, string text)
        {
            if (String.IsNullOrWhiteSpace(ticker))
                throw new ArgumentNullException("ticker");
            if (String.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title");
            if (String.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException("text");

            DroidMessageRequest msg = new DroidMessageRequest
            {
                AppKey = _appkey,
                TimeStamp = Utility.GetTimeStamp().ToString(),
                SendType = SendType.broadcast,
                PayLoad = new DroidPayLoad
                {
                    DisplayType = DroidDisplayType.notification,
                    Body = new DroidPayLoadBody
                    {
                        Ticker = ticker,
                        Title = title,
                        Text = text,
                        AfterOpen = DroidAfterOpenType.go_app
                    }
                }
            };

#if DEBUG
            msg.ProductionMode = "false";
#endif

            return await SendDroidMessage(msg);
        }

        /// <summary>
        /// 发送Android列播推送
        /// </summary>
        /// <param name="ticker">通知栏提示文字</param>
        /// <param name="title">通知标题</param>
        /// <param name="text">通知文字描述</param>
        /// <param name="aliastype">列播类型</param>
        /// <param name="alias">列播参数</param>
        public async Task<MessageResponse> SendDroidListcastMessage(string ticker, string title, string text,string aliastype,params string[] alias)
        {
            if (String.IsNullOrWhiteSpace(ticker))
                throw new ArgumentNullException("ticker");
            if (String.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title");
            if (String.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException("text");
            if (String.IsNullOrWhiteSpace(aliastype))
                throw new ArgumentNullException("aliastype");
            if (alias == null || alias.Length <= 0)
                throw new ArgumentNullException("alias");

            DroidMessageRequest msg = new DroidMessageRequest
            {
                AppKey = _appkey,
                TimeStamp = Utility.GetTimeStamp().ToString(),
                SendType = SendType.customizedcast,
                Alias = Utility.GetDeviceToken(alias),
                AliasType = aliastype,
                PayLoad = new DroidPayLoad
                {
                    DisplayType = DroidDisplayType.notification,
                    Body = new DroidPayLoadBody
                    {
                        Ticker = ticker,
                        Title = title,
                        Text = text,
                        AfterOpen = DroidAfterOpenType.go_app
                    }
                }
            };

#if DEBUG
            msg.ProductionMode = "false";
#endif

            return await SendDroidMessage(msg);
        }

        /// <summary>
        /// 发送IOS推送通知
        /// </summary>
        public async Task<MessageResponse> SendTouchMessage(TouchMessageRequest msg)
        {
            CheckTouchMessageRequest(msg);

            return await SendRequest<MessageResponse, TouchMessageRequest>(SendUrl, msg);
        }

        /// <summary>
        /// 发送IOS广播推送
        /// </summary>
        /// <param name="alert">通知标题</param>
        /// <param name="badge">徽章数</param>
        public async Task<MessageResponse> SendTouchBroadcastMessage(string alert, int badge)
        {
            if (String.IsNullOrWhiteSpace(alert))
                throw new ArgumentNullException("alert");
            if (badge < 0)
                throw new ArgumentOutOfRangeException("badge");

            TouchMessageRequest msg = new TouchMessageRequest
            {
                AppKey = _appkey,
                TimeStamp = Utility.GetTimeStamp().ToString(),
                SendType = SendType.broadcast,
                PayLoad = new TouchPayLoad
                {
                    Aps = new TouchAps
                    {
                        Alert = alert,
                        Badge = badge
                    }
                }
            };

#if DEBUG
            msg.ProductionMode = "false";
#endif

            return await SendTouchMessage(msg);
        }

        /// <summary>
        /// 发送IOS列播推送
        /// </summary>
        /// <param name="alert">通知标题</param>
        /// <param name="badge">徽章数</param>
        /// <param name="aliastype">列播类型</param>
        /// <param name="alias">列播参数</param>
        public async Task<MessageResponse> SendTouchListcastMessage(string alert, int badge, string aliastype, params string[] alias)
        {
            if (String.IsNullOrWhiteSpace(alert))
                throw new ArgumentNullException("alert");
            if (badge < 0)
                throw new ArgumentOutOfRangeException("badge");
            if (String.IsNullOrWhiteSpace(aliastype))
                throw new ArgumentNullException("aliastype");
            if (alias == null || alias.Length <= 0)
                throw new ArgumentNullException("alias");

            TouchMessageRequest msg = new TouchMessageRequest
            {
                AppKey = _appkey,
                TimeStamp = Utility.GetTimeStamp().ToString(),
                SendType = SendType.customizedcast,
                Alias = Utility.GetDeviceToken(alias),
                AliasType = aliastype,
                PayLoad = new TouchPayLoad
                {
                    Aps = new TouchAps
                    {
                        Alert = alert,
                        Badge = badge
                    }
                }
            };

#if DEBUG
            msg.ProductionMode = "false";
#endif

            return await SendTouchMessage(msg);
        }

        /// <summary>
        /// 查询通知状态
        /// </summary>
        public async Task<StatusResponse> QueryMessageStatus(StatusRequest msg)
        {
            CheckStatusRequest(msg);

            return await SendRequest<StatusResponse, StatusRequest>(StatusUrl, msg);
        }

        /// <summary>
        /// 查询通知状态
        /// </summary>
        /// <param name="taskid">通知编号</param>
        public async Task<StatusResponse> QueryMessageStatus(string taskid)
        {
            if (String.IsNullOrWhiteSpace(taskid))
                throw new ArgumentNullException("taskid");

            StatusRequest msg = new StatusRequest
            {
                AppKey = _appkey,
                TimeStamp = Utility.GetTimeStamp().ToString(),
                TaskId = taskid
            };

            return await QueryMessageStatus(msg);
        }

        /// <summary>
        /// 取消发送的通知
        /// </summary>
        public async Task<CancelResponse> CancelSendMessage(CancelRequest msg)
        {
            CheckCancelRequest(msg);

            return await SendRequest<CancelResponse, CancelRequest>(CancelUrl, msg);
        }

        /// <summary>
        /// 取消发送的通知
        /// </summary>
        /// <param name="taskid">通知编号</param>
        public async Task<CancelResponse> CancelSendMessage(string taskid)
        {
            if (String.IsNullOrWhiteSpace(taskid))
                throw new ArgumentNullException("taskid");

            CancelRequest msg = new CancelRequest
            {
                AppKey = _appkey,
                TimeStamp = Utility.GetTimeStamp().ToString(),
                TaskId = taskid
            };

            return await CancelSendMessage(msg);
        }

        /// <summary>
        /// 上传附件
        /// </summary>
        /// <param name="content">附件内容</param>
        public async Task<UploadResponse> Upload(string content)
        {
            if (String.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException("content");

            UploadRequest msg = new UploadRequest
            {
                AppKey = _appkey,
                TimeStamp = Utility.GetTimeStamp().ToString(),
                Content = content
            };

            return await Upload(msg);
        }

        /// <summary>
        /// 上传附件
        /// </summary>
        public async Task<UploadResponse> Upload(UploadRequest msg)
        {
            CheckUploadRequest(msg);

            return await SendRequest<UploadResponse, UploadRequest>(UploadUrl, msg);
        }

        private async Task<R> SendRequest<R, T>(string url, T body)
        {
            string strBody = JsonConvert.SerializeObject(body, Formatting.None);
            string sign = Utility.MD5("POST", url, strBody, _secret);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?sign=" + sign);
            request.Method = "POST";
            StreamWriter sw = new StreamWriter(await request.GetRequestStreamAsync());
            sw.Write(strBody);
            sw.Flush();
            HttpWebResponse response = null;
            R msgBody = default(R);
            try
            {
                response = (HttpWebResponse)await request.GetResponseAsync();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string result = sr.ReadToEnd();
                msgBody = JsonConvert.DeserializeObject<R>(result);
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    StreamReader sr = new StreamReader(ex.Response.GetResponseStream());
                    string result = sr.ReadToEnd();
                    msgBody = JsonConvert.DeserializeObject<R>(result);
                }
            }
            return msgBody;
        }

        #region 请求参数验证

        private void CheckDroidMessageRequest(DroidMessageRequest request)
        {
            CheckMessageRequest(request);

            if (request.PayLoad.DisplayType == DroidDisplayType.message)
            {
                if (request.PayLoad.Body.Custom != null)
                    throw new ArgumentNullException("Custom");
            }
            else
            {
                var b = request.PayLoad.Body;
                if (String.IsNullOrWhiteSpace(b.Ticker))
                    throw new ArgumentNullException("Ticker");

                if (String.IsNullOrWhiteSpace(b.Title))
                    throw new ArgumentNullException("Title");

                if (String.IsNullOrWhiteSpace(b.Text))
                    throw new ArgumentNullException("Text");

                if (b.AfterOpen == DroidAfterOpenType.go_url)
                    if (String.IsNullOrWhiteSpace(b.Url))
                        throw new ArgumentNullException("Url");

                if (b.AfterOpen == DroidAfterOpenType.go_activity)
                    if (String.IsNullOrWhiteSpace(b.Activity))
                        throw new ArgumentNullException("Activity");

                if (b.AfterOpen == DroidAfterOpenType.go_custom)
                    if (b.Custom == null)
                        throw new ArgumentNullException("Custom");
            }
        }

        private void CheckTouchMessageRequest(TouchMessageRequest request)
        {
            CheckMessageRequest(request);

            if (String.IsNullOrWhiteSpace(request.PayLoad.Aps.Alert))
                throw new ArgumentNullException("Alert");
        }

        private void CheckMessageRequest(MessageRequest request)
        {
            if (String.IsNullOrWhiteSpace(request.AppKey))
                throw new ArgumentNullException("AppKey");
            
            if (String.IsNullOrWhiteSpace(request.TimeStamp))
                throw new ArgumentNullException("TimeStamp");
            
            if (request.SendType == SendType.listcast || request.SendType == SendType.unicast)
                if (String.IsNullOrWhiteSpace(request.DeviceTokens))
                    throw new ArgumentNullException("DeviceTokens");

            if (request.SendType == SendType.customizedcast)
                if (String.IsNullOrWhiteSpace(request.AliasType))
                    throw new ArgumentNullException("AliasType");
        }

        private void CheckStatusRequest(StatusRequest request)
        {
            if (String.IsNullOrWhiteSpace(request.AppKey))
                throw new ArgumentNullException("AppKey");

            if (String.IsNullOrWhiteSpace(request.TimeStamp))
                throw new ArgumentNullException("TimeStamp");

            if (String.IsNullOrWhiteSpace(request.TaskId))
                throw new ArgumentNullException("TaskId");
        }

        private void CheckCancelRequest(CancelRequest request)
        {
            if (String.IsNullOrWhiteSpace(request.AppKey))
                throw new ArgumentNullException("AppKey");

            if (String.IsNullOrWhiteSpace(request.TimeStamp))
                throw new ArgumentNullException("TimeStamp");

            if (String.IsNullOrWhiteSpace(request.TaskId))
                throw new ArgumentNullException("TaskId");
        }

        private void CheckUploadRequest(UploadRequest request)
        {
            if (String.IsNullOrWhiteSpace(request.AppKey))
                throw new ArgumentNullException("AppKey");

            if (String.IsNullOrWhiteSpace(request.TimeStamp))
                throw new ArgumentNullException("TimeStamp");

            if (String.IsNullOrWhiteSpace(request.Content))
                throw new ArgumentNullException("Content");
        }

        #endregion
    }
}
