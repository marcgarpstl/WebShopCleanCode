using WebShopCleanCode.Builder;
using WebShopCleanCode.GlobalMethods;

namespace WebShopCleanCode.States
{
    public class LoginMenu : IWebShopState
    {
        ShowCurrentUser show = new();
        UserActionResponse action = new();
        List<Customer> customers = new List<Customer>();
        public Database database = new Database();
        List<string> options;
        string info = "Please submit username and password.";
        int currentChoice;
        int amountOfOptions;
        string username = null;
        string password = null;
        Customer currentCustomer;

        public LoginMenu()
        {
            customers = database.GetCustomers();
            currentChoice = 1;
            amountOfOptions = 4;
            options = new List<string>
            {
                "1. Set Username",
                "2. Set Password",
                "3. Logout",
                "4. Register"
            };
        }
        public void CurrentMenu(WebShopContext context)
        {
            Console.WriteLine(info);
            currentCustomer = context.CurrentCustomer;
            if (currentCustomer == null)
            {
                options[2] = "3. Login";
            }

            PrintMenu login = new PrintMenu(options);
            login.Menu();

            ManeuverLogics move = new ManeuverLogics(amountOfOptions, currentChoice);
            move.ManeuverLogic();

            show.LoggedInUser(context);

            Navigator(context);
        }
        private void Navigator(WebShopContext context)
        {
            string choice = Console.ReadLine().ToLower();
            if (currentChoice > 1 && choice == "l" | choice == "left")
            {
                currentChoice--;
            }
            if (currentChoice < amountOfOptions && choice == "r" | choice == "right")
            {
                currentChoice++;
            }
            if (choice == "back" | choice == "b")
            {
                context.ChangeMenu(new MainMenu());
            }
            if (choice == "q" | choice == "quit")
            {
                Console.WriteLine("The console powers down. You are free to leave.");
                Environment.Exit(0);
            }
            if (choice == "ok" | choice == "k" | choice == "o")
            {
                LoginOk(context);
            }
        }
        private int LoginOk(WebShopContext context)
        {
            if (currentChoice == 1)
            {
                username = MagicKeyBoardAppear("username");
            }
            if (currentChoice == 2 && currentCustomer == null)
            {
                password = MagicKeyBoardAppear("password");
            }
            if (currentChoice == 3 && currentCustomer != null)
            {
                Console.WriteLine(context.CurrentCustomer.Username + " has logged out");
                context.CurrentCustomer = null;
            }
            if (currentChoice == 3 && currentCustomer == null)
            {
                if (username == null || password == null)
                {
                    action.PrintUserActionResponse("Incomplete data.");
                }
                else
                {
                    LoginCheck(context);
                    context.ChangeMenu(new MainMenu());
                }
            }
            if (currentChoice == 4)
            {
                Customer newCustomer = AddCustomer();
                context.CurrentCustomer = newCustomer;
                action.PrintUserActionResponse(newCustomer.Username + " successfully added and is now logged in.");
            }
            return currentChoice;
        }
        public string MagicKeyBoardAppear(string name)
        {
            Console.WriteLine("A keyboard appears.");
            Console.WriteLine("Please input your " + name + ".");
            string input = Console.ReadLine();
            Console.WriteLine();
            return input;
        }
        public void LoginCheck(WebShopContext context)
        {
            bool found = false;
            foreach (Customer customer in customers)
            {
                if (username.Equals(customer.Username) && customer.CheckPassword(password))
                {
                    action.PrintUserActionResponse(customer.Username + " logged in.");
                    currentCustomer = customer;
                    context.CurrentCustomer = currentCustomer;
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                action.PrintUserActionResponse("Invalid credentials.");
            }
        }
        public Customer AddCustomer()
        {
            CustomerBuilder newUser = new CustomerBuilder();
            Customer newCustomer = newUser.NewCustomer().Build();
            customers.Add(newCustomer);
            return newCustomer;
        }
    }
}
