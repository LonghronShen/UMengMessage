using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sino.Web.UMengMessage;
using System.Threading.Tasks;
using Sino.Web.UMengMessage.Body;

namespace UMengMessageUnitTest
{
    [TestClass]
    public class UMessageTest
    {
        private UMessage _droid;
        private UMessage _touch;

        [TestInitialize]
        public void Init()
        {
            _droid = new UMessage("-", "-");
            _touch = new UMessage("-", "-");
        }

        [TestMethod]
        public async Task SendDroidBroadcastMessageTest()
        {
            var result = await _droid.SendDroidBroadcastMessage("测试广播推送通知", "广播推送通知", "测试广播推送通知");

            Assert.AreEqual(result.Ret, Ret.SUCCESS);
        }

        [TestMethod]
        public async Task SendDroidListcastMessageTest()
        {
            var result = await _droid.SendDroidListcastMessage("测试列播推送通知", "列播推送通知", "测试列播推送通知", "test", "-");

            Assert.AreEqual(result.Ret, Ret.SUCCESS);
        }

        [TestMethod]
        public async Task SendTouchBroadcastMessageTest()
        {
            var result = await _touch.SendTouchBroadcastMessage("测试广播推送通知", 1);

            Assert.AreEqual(result.Ret, Ret.SUCCESS);
        }

        [TestMethod]
        public async Task SendTouchListcastMessageTest()
        {
            var result = await _touch.SendTouchListcastMessage("测试列播推送通知", 1, "test", "-");

            Assert.AreEqual(result.Ret, Ret.SUCCESS);
        }

        [TestMethod]
        public async Task QueryMessageStatusTest()
        {
            var result = await _droid.SendDroidBroadcastMessage("测试查询通知状态", "查询通知状态", "测试查询通知状态");

            Assert.AreEqual(result.Ret, Ret.SUCCESS);

            var status = await _droid.QueryMessageStatus(result.Data.TaskId);

            Assert.AreEqual(status.Ret, Ret.SUCCESS);
        }

        [TestMethod]
        public async Task CancelSendMessageTest()
        {
            var result = await _droid.SendDroidBroadcastMessage("测试取消通知", "取消通知", "测试取消通知状态");

            Assert.AreEqual(result.Ret, Ret.SUCCESS);

            var cancel = await _droid.CancelSendMessage(result.Data.TaskId);

            Assert.AreEqual(cancel.Ret, Ret.SUCCESS);
        }

        [TestMethod]
        public async Task UploadTest()
        {
            var upload = await _droid.Upload("test1\ntest2");

            Assert.AreEqual(upload.Ret, Ret.SUCCESS);
        }
    }
}
