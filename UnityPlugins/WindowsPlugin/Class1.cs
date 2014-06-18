using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityPlugins
{
    class Class1
    {

        public static string GetDeviceName
        {
            get
            {
                return "Not Supported";
            }
        }

        public static void Load()
        {
            System.Reflection.Assembly.Load("");
        }
    }
}
