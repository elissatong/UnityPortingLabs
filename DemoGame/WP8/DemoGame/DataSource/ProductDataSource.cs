using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGame.DataSource
{
    public class ProductDataSource
    {
        private string name = "";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description = "";
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string formattedPrice = "";
        public string FormattedPrice
        {
            get { return formattedPrice; }
            set { formattedPrice = value; }
        }

        private string productId = "";
        public string ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        private Uri imageUri = null;
        public Uri ImageUri
        {
            get { return imageUri; }
            set { imageUri = value; }
        }

        public ProductDataSource(string n, string d, string p, string id, Uri img)
        {
            name = n;
            description = d;
            formattedPrice = p;
            productId = id;
            imageUri = img;
        }

    }
}
