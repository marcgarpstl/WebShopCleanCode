using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopCleanCode.Proxy
{
    public interface IProxyCustomer
    {
        public string ShowPassword();
        public string ShowFirstName();
        public string ShowLastName();
        public string ShowEmail();
        public int ShowAge();
        public string ShowAddress();
        public string ShowPhoneNumber();
    }
}
