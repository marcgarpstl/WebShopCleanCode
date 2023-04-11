using WebShopCleanCode.GlobalMethods;

namespace WebShopCleanCode.States
{
    public class WaresMenu : IWebShopState
    {
        ShowCurrentUser show = new();
        UserActionResponse action = new();
        List<string> options;
        string info = "What would you like to do?";
        int currentChoice;
        int amountOfOptions;
        Customer currentCustomer;

        public WaresMenu()
        {
            currentChoice = 1;
            amountOfOptions = 4;
            options = new List<string>
            {
                "1. See all wares",
                "2. Purchase a ware",
                "3. Sort wares",
                "4. Login"
            };
        }
        public void CurrentMenu(WebShopContext context)
        {
            Console.WriteLine(info);
            currentCustomer = context.CurrentCustomer;

            PrintMenu wares = new PrintMenu(options);
            wares.Menu();

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
            if (choice == "back")
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
                WaresOk(context);
            }
        }

        private void WaresOk(WebShopContext context)
        {
            if (currentChoice == 1)
            {
                PrintProducts(context);
            }
            if (currentChoice == 2 && currentCustomer != null)
            {
                context.ChangeMenu(new PurchaseMenu());
            }
            if (currentChoice == 2 && currentCustomer == null)
            {
                action.PrintUserActionResponse("You must be logged in to purchase wares.");
            }
            if (currentChoice == 3)
            {
                context.ChangeMenu(new SortMenu());
            }
            if (currentChoice == 4)
            {
                context.ChangeMenu(new LoginMenu());
            }
        }

        public void PrintProducts(WebShopContext context)
        {
            foreach (Product product in context.Products)
            {
                product.PrintInfo();
            }
            Console.WriteLine();
        }
    }
}
