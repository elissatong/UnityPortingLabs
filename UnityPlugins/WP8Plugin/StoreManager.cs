using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//#if DEBUG
//using MockIAPLib;
//using Store = MockIAPLib;
//#else

using Windows.ApplicationModel.Store;


namespace UnityPlugins
{
    public class StoreManager
    {
        private static ListingInformation mListingInformation = null;
        public static ListingInformation ListingInfo
        {
            get { return mListingInformation; }
            private set { }
        }

        private static LicenseInformation mLicenseInformation = null;

        public static void AppInit()
        {
            // some app initialization functions 

            // Get the license info
            mLicenseInformation = CurrentApp.LicenseInformation;

            // add event handler to catch changes in license state.
            //mLicenseInformation.LicenseChanged += new LicenseChangedEventHandler(LicenseChangedEventHandler);

            // other app initialization functions
            //GetListingInfo();
        }

        private static void LicenseChangedEventHandler()
        {
            
        }




        #region UseAsyncCalls

        public static string GetListingInfo()
        {
            var result = GetListingInfoAsync();
            result.Wait();
            return result.Result;
        }

        public static bool BuyProduct(string productId)
        {
            var result = BuyProductAsync(productId);
            result.Wait();
            return result.Result;
        }

        #endregion // UseAsyncCalls

        #region AsyncWP8Api

        private static async Task<string> GetListingInfoAsync()
        {
            //Load associated product listings
            try
            {
                mListingInformation = await CurrentApp.LoadListingInformationAsync();
            }
            catch (Exception e)
            {
                return e.Message;
                //Debug.Assert(false, "StoreManager::GetListingInfo: " + e.Message + ", " + e.StackTrace);
            }

            return "";
        }
        public static async Task<bool> BuyProductAsync(string productId)
        {
            if (mListingInformation != null && mListingInformation.ProductListings != null && mListingInformation.ProductListings.Count > 0)
            {
                var product = mListingInformation.ProductListings.FirstOrDefault(p => p.Value.ProductId == productId);

                try
                {
                    string receipt = await CurrentApp.RequestProductPurchaseAsync(product.Value.ProductId, true);
                    if (CurrentApp.LicenseInformation.ProductLicenses[product.Value.ProductId].IsActive)
                    {
                        CurrentApp.ReportProductFulfillment(product.Value.ProductId);
                        // TO DO: 
                        // add your code here to increment or unlock your game data
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    //Debug.WriteLine(ex.Message);
                }
            }

            return false;
        }

        #endregion // AsyncWP8Api

        #region ProductDefinition

        public static string GetProductId(int index)
        {
            if (mListingInformation != null && mListingInformation.ProductListings != null && mListingInformation.ProductListings.Count > 0)
            {
                ProductListing info = mListingInformation.ProductListings.Values.ElementAt(index);
                return info.ProductId;
            }

            return "N/A";
        }

        public static string GetProductName(int index)
        {
            if (mListingInformation != null && mListingInformation.ProductListings != null && mListingInformation.ProductListings.Count > 0)
            {
                ProductListing info = mListingInformation.ProductListings.Values.ElementAt(index);
                return info.Name;
            }

            return "N/A";
        }

        public static string GetProductDescription(int index)
        {
            if (mListingInformation != null)
            {
                ProductListing info = mListingInformation.ProductListings.Values.ElementAt(index);
                return info.Description;
            }

            return "N/A";
        }

        public static string GetProductPrice(int index)
        {
            if (mListingInformation != null && mListingInformation.ProductListings != null && mListingInformation.ProductListings.Count > 0)
            {
                ProductListing info = mListingInformation.ProductListings.Values.ElementAt(index);
                return info.FormattedPrice;
            }

            return "N/A";
        }

        public static Uri GetProduct(int index)
        {
            if (mListingInformation != null && mListingInformation.ProductListings != null && mListingInformation.ProductListings.Count > 0)
            {
                ProductListing info = mListingInformation.ProductListings.Values.ElementAt(index);

                return info.ImageUri;
            }

            return null;
        }

        public static int GetCount()
        {
            if (mListingInformation != null && mListingInformation.ProductListings != null && mListingInformation.ProductListings.Count > 0)
            {
                return mListingInformation.ProductListings.Values.Count();
            }
            return 0;
        }
        #endregion //ProductDefinition



        //#if DEBUG

        //        public static void AppInit()
        //        {

        //        }

        //        public static void AppInit(string xmlFile)
        //        {
        //            MockIAP.Init();

        //            MockIAP.RunInMockMode(true);
        //            MockIAP.SetListingInformation(1, "en-us", "2D Platformer", "$0.00", "2D Platformer");

        //            System.Xml.Linq.XDocument doc = System.Xml.Linq.XDocument.Load(xmlFile);
        //            string xml = doc.ToString();

        //            MockIAP.PopulateIAPItemsFromXml(xml);
        //        }

        //#endif
    }
}
