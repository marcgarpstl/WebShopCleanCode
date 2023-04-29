using WebShopCleanCode.Proxy;

namespace WebShopCleanCode
{
    public class Customer : NotAIProxyCustomer
    {
        NotAIProxyCustomer customer = new NotACustomerProxy();
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Funds { get; set; }
        public List<Order> Orders { get; set; }
        public Customer(string username, string password, string firstName, string lastName, string email, int age, string address, string phoneNumber)
        {
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
            Address = address;
            PhoneNumber = phoneNumber;
            Orders = new List<Order>();
            Funds = 0;
        }

        public Customer()
        {
            
        }

        public bool CanAfford(int price)
        {
            return Funds >= price;
        }

        public bool CheckPassword(string password)
        {
            if (password == null)
            {
                return true;
            }
            return password.Equals(Password);
        }

        public void PrintInfo(WebShopContext context)
        {
            //customer = context.CurrentCustomer;
            Console.Write("\nUsername: " + Username + "");
            customer.GetPassword(context);
            customer.GetFirstName();
            customer.GetLastName();
            customer.GetAge();
            customer.GetAddress();
            customer.GetEmail();
            customer.GetPhoneNumber();
            Console.WriteLine("\nFunds: " + Funds + "\n");

        }

        public void PrintOrders()
        {
            Console.WriteLine();
            foreach (Order order in Orders)
            {
                order.PrintInfo();
            }
            if (!Orders.Any())
            {
                Console.WriteLine("No orders placed.");
            }

            Console.WriteLine();
        }

        public string GetPassword(WebShopContext context)
        {
            return Password;
        }

        public string GetFirstName()
        {
            
            return FirstName;
        }

        public string GetLastName()
        {
            return LastName;
        }

        public string GetEmail()
        {
            return Email;
        }

        public int GetAge()
        {
            return Age;
        }

        public string GetAddress()
        {
            return Address;
        }

        public string GetPhoneNumber()
        {
            return PhoneNumber;
        }
    }
}
