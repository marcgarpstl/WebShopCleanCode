using WebShopCleanCode.GlobalMethods;

namespace WebShopCleanCode.States
{
    public class MainMenu : IWebShopState
    {
        ShowCurrentUser show = new();
        UserActionResponse action = new();
        List<string> options;
        string info = "What would you like to do?";
        int currentChoice;
        int amountOfOptions;
        Customer currentCustomer;

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
            if (choice == "b" | choice == "back")
            {
                action.PrintUserActionResponse("You're already on the main menu.");
            }
            if (choice == "q" | choice == "quit")
            {
                Console.WriteLine("The console powers down. You are free to leave.");
                Environment.Exit(0);
            }
            if (choice == "ok" | choice == "k" | choice == "o")
            {
                MainOk(context, choice);
            }
        }
        private int MainOk(WebShopContext context, string choice)
        {
            if (currentChoice == 1)
            {
                context.ChangeMenu(new WaresMenu());
            }
            if (currentChoice == 2 && currentCustomer != null)
            {
                context.ChangeMenu(new CustomerMenu());
            }
            if (currentChoice == 2 && currentCustomer == null)
            {
                Console.WriteLine("Nobody is logged in!");
            }
            if (currentChoice == 3 && currentCustomer != null)
            {
                Console.WriteLine(context.CurrentCustomer.Username + " has logged out");
                context.CurrentCustomer = null;
            }
            if (currentChoice == 3 && currentCustomer == null)
            {
                context.ChangeMenu(new LoginMenu());
            }
            if (currentChoice == 4)
            {
                Console.WriteLine("The console powers down. You are free to leave.");
                Environment.Exit(0);
            }
            return currentChoice;
        }
    }
}

