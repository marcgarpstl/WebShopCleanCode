using WebShopCleanCode.GlobalMethods;

namespace WebShopCleanCode.States
{
    public class SortMenu : IWebShopState
    {
        ShowCurrentUser show = new();
        UserActionResponse action = new();
        public Database database = new Database();
        List<Product> products;
        List<string> options;
        string info = "How would you like to sort them?";
        int currentChoice;
        int amountOfOptions;

        public SortMenu()
        {
            products = database.GetProducts();
            currentChoice = 1;
            amountOfOptions = 4;
            options = new List<string>
            {
                "1. Sort by name, descending",
                "2. Sort by name, ascending",
                "3. Sort by price, descending",
                "4. Sort by price, ascending"
            };
        }
        public void CurrentMenu(WebShopContext context)
        {
            Console.WriteLine(info);          

            PrintMenu sort = new PrintMenu(options);
            sort.Menu();

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
                context.ChangeMenu(new WaresMenu());
            }
            if (choice == "q" | choice == "quit")
            {
                Console.WriteLine("The console powers down. You are free to leave.");
                Environment.Exit(0);
            }
            if (choice == "ok" | choice == "k" | choice == "o")
            {
                SortOk(context);
            }
        }
        private int SortOk(WebShopContext context)
        {
            if (currentChoice == 1)
            {
                InsertionSort("name", false);
                action.PrintUserActionResponse("Wares sorted.");
                context.Products = products;
                context.ChangeMenu(new WaresMenu());
            }

            if (currentChoice == 2)
            {
                InsertionSort("name", true);
                action.PrintUserActionResponse("Wares sorted.");
                context.Products = products;
                context.ChangeMenu(new WaresMenu());
            }
            if (currentChoice == 3)
            {
                InsertionSort("price", false);
                action.PrintUserActionResponse("Wares sorted.");
                context.Products = products;
                context.ChangeMenu(new WaresMenu());
            }
            if (currentChoice == 4)
            {
                InsertionSort("price", true);
                action.PrintUserActionResponse("Wares sorted.");
                context.Products = products;
                context.ChangeMenu(new WaresMenu());
            }
            return currentChoice;
        }
        public List<Product> InsertionSort(string variable, bool ascending)
        {
            if (variable.Equals("name"))
            {
                int length = products.Count;
                for (int i = 1; i < length; i++)
                {
                    Product temp = products[i];
                    int j = i - 1;
                    if (ascending)
                    {
                        while (j >= 0 && products[j].Name.CompareTo(temp.Name) > 0)
                        {
                            products[j + 1] = products[j];
                            j--;
                        }
                    }
                    else
                    {
                        while (j >= 0 && products[j].Name.CompareTo(temp.Name) < 0)
                        {
                            products[j + 1] = products[j];
                            j--;
                        }
                    }
                    products[j + 1] = temp;
                }
            }
            if (variable.Equals("price"))
            {
                int length = products.Count;
                for (int i = 1; i < length; i++)
                {
                    Product temp = products[i];
                    int j = i - 1;
                    if (ascending)
                    {
                        while (j >= 0 && products[j].Price.CompareTo(temp.Price) < 0)
                        {
                            products[j + 1] = products[j];
                            j--;
                        }
                    }
                    else
                    {
                        while (j >= 0 && products[j].Price.CompareTo(temp.Price) > 0)
                        {
                            products[j + 1] = products[j];
                            j--;
                        }
                    }
                    products[j + 1] = temp;
                }
            }
            return products;
        }
    }
}
