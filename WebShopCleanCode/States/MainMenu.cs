using WebShopCleanCode.GlobalMethods;

namespace WebShopCleanCode.States
{
    public class MainMenu : IWebShopState
    {
        ShowCurrentUser show = new();
        //UserActionResponse action = new();
        List<string> options;
        string info = "What would you like to do?";
        public string menu = "main";
        Customer currentCustomer;
        int currentChoice;
        int amountOfOptions;


        public MainMenu()
        {
            currentChoice = 1;
            amountOfOptions = 4;
            options = new List<string>
            {
                "1. See Wares",
                "2. Customer info",
                "3. Logout",
                "4. Quit"
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

            PrintMenu main = new PrintMenu(options);
            main.Menu();

            ManeuverLogics move = new ManeuverLogics(amountOfOptions, currentChoice);
            move.ManeuverLogic();

            show.LoggedInUser(context);

            Navigation naVi = new Navigation(amountOfOptions, currentChoice);
            naVi.Navigator(context, new MainMenu());
            currentChoice = naVi.LeftAndRight();
            
        }
        public void MainOk(WebShopContext context, int currentChoice)
        {
            if (currentChoice == 1) 
            {
                context.ChangeMenu(new WaresMenu());
            }
            if (currentChoice == 2 && context.CurrentCustomer != null)
            {
                context.ChangeMenu(new CustomerMenu());
            }
            if (currentChoice == 2 && context.CurrentCustomer == null)
            {
                Console.WriteLine("Nobody is logged in!");
            }
            if (currentChoice == 3 && context.CurrentCustomer != null)
            {
                Console.WriteLine(context.CurrentCustomer.Username + " has logged out");
                context.CurrentCustomer = null;
            }
            if (currentChoice == 3 && context.CurrentCustomer == null)
            {
                context.ChangeMenu(new LoginMenu());
            }
            if (currentChoice == 4)
            {
                Console.WriteLine("The console powers down. You are free to leave.");
                Environment.Exit(0);
            }
        }
    }
}

