using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopCleanCode.ProductProxy
{
    public interface IProductProxy
    {
        string GetName();
        int GetPrice();
        int GetNrInStock();
        string GetDescription();
    }
}
