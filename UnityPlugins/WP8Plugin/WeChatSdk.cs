using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MicroMsg.sdk;

namespace UnityPlugins
{
    public class WeChatSdk
    {
        private static string mAppId = "";
        public static string AppId 
        {
            get { return mAppId; }
            set { mAppId = value; }
        }

        public static void SetAppId(string id)
        {
            mAppId = id;
        }

        public static bool SendRequest()
        {
            bool isSuccess = false;
            //try
            //{
            //    int scene = SendMessageToWX.Req.WXSceneSession; //发给微信朋友
            //    WXTextMessage message = new WXTextMessage();
            //    message.Title = "文本";
            //    message.Text = "这是一段文本内容";
                
            //    SendMessageToWX.Req req = new SendMessageToWX.Req(message, scene);
            //    IWXAPI api = WXAPIFactory.CreateWXAPI(mAppId);
            //    isSuccess = api.SendReq(req);
            //}
            //catch (WXException ex)
            //{
            //    // Handle errors
            //    Console.WriteLine(ex.Message);
            //}

            return isSuccess;
        }

    }
}
