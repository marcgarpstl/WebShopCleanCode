namespace WebShopCleanCode.Proxy
{
    public class CustomerProxy : IProxyCustomer
    {
        Customer _customer;
        public string ShowAddress()
        {
            return _customer.ShowAddress();
        }

        public int ShowAge()
        {
            return _customer.ShowAge();
        }

        public string ShowEmail()
        {
            return _customer.ShowEmail();
        }

        public string ShowFirstName()
        {
            return _customer.ShowFirstName();
        }

        public string ShowLastName()
        {
            return _customer.ShowLastName();
        }

        public string ShowPassword()
        {
            return _customer.ShowPassword();
        }

        public string ShowPhoneNumber()
        {
            return _customer.ShowPhoneNumber();
        }
    }
}
