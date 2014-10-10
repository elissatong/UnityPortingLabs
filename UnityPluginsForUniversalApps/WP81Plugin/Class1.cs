using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityPlugins
{
    public class Class1
    {
        public static string GetMemoryUsageLimit
        {
            get
            {
                // WP8.1.
                ulong usageLimit = Windows.System.MemoryManager.AppMemoryUsageLimit;
                ulong bytesToMB = usageLimit / (1024 * 1024);
                return bytesToMB.ToString() + " MB";
            }
        }

        public static string GetMemoryCurrentUsage
        {
            get
            {
                // WP8.1.
                ulong currentUsage = Windows.System.MemoryManager.AppMemoryUsage;
                ulong bytesToMB = currentUsage / (1024 * 1024);
                return bytesToMB.ToString() + " MB";
            }
        }
    }
}
