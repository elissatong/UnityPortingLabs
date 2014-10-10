using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;

using DemoGame.DataSource;
using System.Collections.ObjectModel;

#if DEBUG
    using MockIAPLib;
    using Store = MockIAPLib;
#else
using Windows.ApplicationModel.Store;
#endif


namespace DemoGame.Hud
{
    public partial class StorePage : PhoneApplicationPage
    {
        ObservableCollection<ProductDataSource> products = new ObservableCollection<ProductDataSource>();

        public StorePage()
        {
            InitializeComponent();
            llsProducts.ItemsSource = products;

            if (App.sStoreManager.ListingInfo != null)
            {
                int numOfProducts = App.sStoreManager.ListingInfo.ProductListings.Count();
                for (int i = 0; i < numOfProducts; ++i)
                {
                    ProductListing product = App.sStoreManager.ListingInfo.ProductListings.Values.ElementAt(i);
                    products.Add(new ProductDataSource(product.Name, product.Description, product.FormattedPrice, product.ProductId, product.ImageUri));
                }

            }

        }

        private void btnShop_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            StackPanel panel = (StackPanel)btn.Parent;
            string productId = panel.Tag.ToString();

            if (!String.IsNullOrEmpty(productId))
            {
                var isSuccess = App.sStoreManager.BuyProduct(productId);
                if (isSuccess.Result)
                {
                    txtPurchaseMsg.Text = "Successfully purchased: " + productId;
                }
            }

        }


    }
}