using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public bool SendRequest()
        {
            return true;
        }
    }
}
