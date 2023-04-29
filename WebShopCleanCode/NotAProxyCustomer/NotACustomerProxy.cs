namespace WebShopCleanCode.Proxy
{
    public class NotACustomerProxy : NotAIProxyCustomer
    {
        private Customer customer;

        public NotACustomerProxy()
        {

        }
        public void MakeCustomerContext(WebShopContext context)
        {
            customer = context.CurrentCustomer;
        }
        public string GetAddress()
        {
            if (customer.Address != null)
            {
                ShowAddress();
            }
            return null;
        }

        private void ShowAddress()
        {
            Console.Write("\nAddress: " + customer.Address);
        }

        public int GetAge()
        {
            if (customer.Age != 0)
            {
                ShowAge();
            }
            return 0;
        }

        private void ShowAge()
        {
            Console.Write("\nAge :" + customer.Age);
        }

        public string GetEmail()
        {
            if (customer.Email != null)
            {
                ShowEmail();
            }
            return null;
        }

        private void ShowEmail()
        {
            Console.Write("\nEmail: " + customer.Email);
        }

        public string GetFirstName()
        {
            if (customer.FirstName != null)
            {
                ShowFirstName();
            }
            return null;
        }

        private void ShowFirstName()
        {
            Console.Write("\nFirstname: " + customer.FirstName);
        }

        public string GetLastName()
        {
            if (customer.GetLastName != null)
            {
                ShowLastName();
            }
            return null;
        }

        private void ShowLastName()
        {
            Console.Write("\nLastname: " + customer.LastName);
        }

        public string GetPassword(WebShopContext context)
        {
            MakeCustomerContext(context);
            if (customer.Password != null)
            {
                ShowPassword();
            }
            return null;
        }

        private void ShowPassword()
        {
            Console.Write("\nPassword: " + customer.Password + "");
        }

        public string GetPhoneNumber()
        {
            if (customer.PhoneNumber != null)
            {
                ShowPhoneNumber();
            }
            return null;
        }

        private void ShowPhoneNumber()
        {
            Console.Write("\nPhonenumber: " + customer.PhoneNumber + "");
        }
    }
}
