using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace UnityPlugins
{
    public class StoreManager
    {
        public static void AppInit()
        {

        }

        public static string GetListingInfo()
        {
            return "N/A";
        }

        public static bool BuyProduct(string productId)
        {
            return false;
        }

        public static string GetProductId(int index)
        {
            return "Temp Id";
        }

        public static string GetProductName(int index)
        {
            return "Temp Name";
        }

        public static string GetProductDescription(int index)
        {
            return "Temp Description";
        }

        public static string GetProductPrice(int index)
        {
            return "$0.00";
        }

        public static Uri GetProduct(int index)
        {
            return new Uri("http://cdn.marketplaceimages.windowsphone.com/v8/images/ad5ce88e-645d-4009-a477-884f6c465a35?hw=419527684&imagetype=icon_iap");
        }

        public static int GetCount()
        {
            return 0;
        }
    }
}
