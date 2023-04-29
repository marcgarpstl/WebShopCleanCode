using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopCleanCode.ProductProxy
{
    public class ProxyProduct : IProductProxy
    {
        Product product;
        Database db;
        string name;


        public ProxyProduct(string name)
        {
               this.name = name;
        }

        public void Load()
        {
            if (product == null)
            {
                product = db.GetProduct(name);
            }
        }

        public string GetDescription()
        {
            Load();
            return product.GetDescription();
        }

        public string GetName()
        {
            Load();
            return product.GetName();
        }

        public int GetNrInStock()
        {
            Load();
            return product.GetNrInStock();
        }

        public int GetPrice()
        {
            Load();
            return product.GetPrice();
        }
    }
}
