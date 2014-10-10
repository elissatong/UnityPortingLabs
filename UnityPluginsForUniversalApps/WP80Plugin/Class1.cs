using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace UnityPlugins
{
    public class Class1
    {
        public static string GetMemoryUsageLimit
        {
            get
            {
                // WP8.0.
                ulong committedLimit = Windows.Phone.System.Memory.MemoryManager.ProcessCommittedLimit;
                return committedLimit.ToString();

            }
        }

        public static string GetMemoryCurrentUsage
        {
            get
            {
                // WP8.0.
                ulong committedBytes = Windows.Phone.System.Memory.MemoryManager.ProcessCommittedBytes;
                return committedBytes.ToString();

            }
        }
    }
}
