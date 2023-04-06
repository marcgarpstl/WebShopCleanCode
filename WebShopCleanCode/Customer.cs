using WebShopCleanCode.Proxy;

namespace WebShopCleanCode
{
    public class Customer : IProxyCustomer
    {
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

        public void PrintInfo()
        {

            Console.Write("\nUsername: " + Username + "");
            ShowPassword();
            ShowFirstName();
            ShowLastName();
            ShowEmail();
            ShowAge();
            ShowAddress();
            ShowPhoneNumber();
            Console.WriteLine(", Funds: " + Funds + "\n");

        }

        public string ShowPhoneNumber()
        {
            if (PhoneNumber != null)
            {
                Console.Write(", Phone Number: " + PhoneNumber);
                return PhoneNumber;
            }
            return "";
        }

        public string ShowAddress()
        {
            if (Address != null)
            {
                Console.Write(", Address: " + Address);
                return Address;
            }
            return "";
        }

        public int ShowAge()
        {
            if (Age != -1)
            {
                Console.Write(", Age: " + Age);
                return Age;
            }
            return -1;
        }

        public string ShowEmail()
        {
            if (Email != null)
            {
                Console.Write(", Email: " + Email);
                return Email;
            }
            return "";
        }

        public string ShowLastName()
        {
            if (LastName != null)
            {
                Console.Write(", Last Name: " + LastName);
                return LastName;
            }
            return "";
        }

        public string ShowFirstName()
        {
            if (FirstName != null)
            {
                Console.Write(", First Name: " + FirstName);
                return FirstName;
            }
            return "";
        }

        public string ShowPassword()
        {
            if (Password != null)
            {
                Console.Write(", Password: " + Password);
                return Password;
            }
            return "";
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
    }
}
