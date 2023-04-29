using WebShopCleanCode.States;

namespace WebShopCleanCode.GlobalMethods
{
    public class Navigation : IWebShopState
    {

        MainMenu menu = new();
        WaresMenu wares = new();
        CustomerMenu customer = new();
        PurchaseMenu purchase = new();
        SortMenu sort = new();
        LoginMenu login = new();
        SingleProductMenu single = new();
        UserActionResponse response = new();
        int amountOfOptions;
        int currentChoice;
        string choice;
        public Navigation(int amountOfOptions, int currentChoice)
        {
            this.amountOfOptions = amountOfOptions;
            this.currentChoice = currentChoice;
        }
        public void Navigator(WebShopContext context, IWebShopState state)
        {
            choice = Console.ReadLine().ToLower();

            if (choice == "b" | choice == "back")
            {
                BackChoices(context, state);
            }
            if (choice == "q" | choice == "quit")
            {
                Console.WriteLine("The console powers down. You are free to leave.");
                Environment.Exit(0);
            }
            if (choice == "ok" | choice == "k" | choice == "o")
            {
                OkChoices(context, state, currentChoice);
            }
        }

        public int LeftAndRight()
        {
            if (currentChoice > 1 && choice == "l" | choice == "left")
            {
                return currentChoice-1;
            }
            if (currentChoice < amountOfOptions && choice == "r" | choice == "right")
            {
                return currentChoice+1;
            }
            return 1;
        }

        private void OkChoices(WebShopContext context, IWebShopState state, int currentChoice)
        {
            if (state is MainMenu)
            {
                menu.MainOk(context, currentChoice);
            }
            if (state is WaresMenu)
            {
                wares.WaresOk(context, currentChoice);
            }
            if (state is CustomerMenu)
            {
                customer.CustomerOk(currentChoice, context);
            }
            if (state is PurchaseMenu)
            {
                purchase.BuyProduct(context, currentChoice);
            }
            if (state is SortMenu)
            {
                sort.SortOk(context, currentChoice);
            }
            if (state is LoginMenu)
            {
                login.LoginOk(context, currentChoice);
            }
            if(state is SingleProductMenu)
            {
                single.SingleItemOk(context, currentChoice);
            }
        }

        private void BackChoices(WebShopContext context, IWebShopState state)
        {
            if (state is MainMenu)
            {
                response.PrintUserActionResponse("You're already on the main menu.");
            }
            if (state is WaresMenu | state is LoginMenu)
            {
                context.ChangeMenu(new MainMenu());
            }
            if (state is PurchaseMenu | state is SortMenu | state is CustomerMenu | state is SingleProductMenu)
            {
                context.ChangeMenu(new WaresMenu());
            }
        }

    }
}
