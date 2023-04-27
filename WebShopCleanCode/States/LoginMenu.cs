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
        string username;
        string password;
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

            Navigation naVi = new Navigation(amountOfOptions, currentChoice);
            naVi.Navigator(context, new LoginMenu());
            currentChoice = naVi.LeftAndRight();

        }

        public void LoginOk(WebShopContext context, int currentChoice)
        {
            if (currentChoice == 1)
            {
                username = MagicKeyBoardAppear("username");
                context.username = username;
            }
            if (currentChoice == 2 && currentCustomer == null)
            {
                password = MagicKeyBoardAppear("password");
                context.password = password;
            }
            if (currentChoice == 3 && context.CurrentCustomer != null)
            {
                Console.WriteLine(context.CurrentCustomer.Username + " has logged out");
                context.CurrentCustomer = null;
            }
            if (currentChoice == 3 && currentCustomer == null)
            {
                if (context.username == null || context.password == null)
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
                if (context.username.Equals(customer.Username) && customer.CheckPassword(context.password))
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
            Customer newCustomer = newUser.Build();
            customers.Add(newCustomer);
            return newCustomer;
        }
    }
}
