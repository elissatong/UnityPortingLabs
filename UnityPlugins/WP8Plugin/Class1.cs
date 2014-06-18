using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityPlugins
{
    class Class1
    {
        public static string GetDeviceName
        {
            get
            {
                return Microsoft.Phone.Info.DeviceStatus.DeviceName;
            }
        }

        public static void Load()
        {
            System.Reflection.Assembly.Load("");
        }
    }
}
