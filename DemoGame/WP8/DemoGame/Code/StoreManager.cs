using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

#if DEBUG
    using MockIAPLib;
    using Store = MockIAPLib;
#else
    using Windows.ApplicationModel.Store;
#endif


namespace DemoGame.Code
{
    public class StoreManager
    {
        private ListingInformation mListingInformation = null;
        public ListingInformation ListingInfo
        {
            get { return mListingInformation; }
            private set {}
        }

        private LicenseInformation mLicenseInformation = null;

        public StoreManager()
        {
            AppInit();
        }


#if DEBUG
        void AppInit()
        {
            SetupMockIAP();
        }

        private void SetupMockIAP()
        {
            MockIAP.Init();

            MockIAP.RunInMockMode(true);
            MockIAP.SetListingInformation(1, "en-us", "2D Platformer", "$0.00", "2D Platformer");
            
            var mockupLicenseInfo = App.GetResourceStream(new Uri("Assets\\Xmls\\MockupLicenseInfo.xml", UriKind.Relative));
            System.Xml.Linq.XDocument doc = System.Xml.Linq.XDocument.Load(mockupLicenseInfo.Stream);
            string xml = doc.ToString();

            MockIAP.PopulateIAPItemsFromXml(xml);

            GetListingInfo();

            // Add some more items manually.
            //ProductListing p = new ProductListing
            //{
            //    Name = "img.2",
            //    ImageUri = new Uri("/Res/Image/2.jpg", UriKind.Relative),
            //    ProductId = "img.2",
            //    ProductType = Windows.ApplicationModel.Store.ProductType.Durable,
            //    Keywords = new string[] { "image" },
            //    Description = "An image",
            //    FormattedPrice = "1.0",
            //    Tag = string.Empty
            //};
            //MockIAP.AddProductListing("img.2", p);

        }

#else
        void AppInit()
        {
            // some app initialization functions 

            // Get the license info
            mLicenseInformation = CurrentApp.LicenseInformation;

            // add event handler to catch changes in license state.
            mLicenseInformation.LicenseChanged += new LicenseChangedEventHandler(LicenseChangedEventHandler);

            // other app initialization functions
            GetListingInfo();
        }

        private void LicenseChangedEventHandler()
        {
            
        }

        


#endif


        private async void GetListingInfo()
        {
            //Load associated product listings
            try
            {
                mListingInformation = await CurrentApp.LoadListingInformationAsync();
            }
            catch (Exception e)
            {
                Debug.Assert(false, "StoreManager::GetListingInfo: " + e.Message + ", " + e.StackTrace);
            }

            if (mListingInformation != null)
            {
                // Dictionary<string, ProductListing> ListingInformation.ProductListings
                foreach (ProductListing info in mListingInformation.ProductListings.Values)
                {
                    Debug.WriteLine(info.Name + ", " + info.Description);
                }
            }
        }
        
        public string GetProductName(int index)
        {
            if (mListingInformation != null)
            {
                ProductListing info = mListingInformation.ProductListings.Values.ElementAt(index);
                return info.Name;
            }

            return "";
        }

        public string GetProductDescription(int index)
        {
            if (mListingInformation != null)
            {
                ProductListing info = mListingInformation.ProductListings.Values.ElementAt(index);
                return info.Description;
            }

            return "";
        }

        public string GetProductPrice(int index)
        {
            if (mListingInformation != null)
            {
                ProductListing info = mListingInformation.ProductListings.Values.ElementAt(index);
                return info.FormattedPrice;
            }

            return "";
        }

        public Uri GetProduct(int index)
        {
            if (mListingInformation != null)
            {
                ProductListing info = mListingInformation.ProductListings.Values.ElementAt(index);
                
                return info.ImageUri;
            }
            
            return null;
        }

        public async Task<bool> BuyProduct(string productId)
        {
            if (mListingInformation != null)
            {
                var product = mListingInformation.ProductListings.FirstOrDefault(p => p.Value.ProductId == productId); // && p.Value.ProductType == ProductType.Consumable);

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
                    Debug.WriteLine(ex.Message);
                }
            }

            return false;
        }

    }

}
