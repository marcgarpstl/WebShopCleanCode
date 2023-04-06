using WebShopCleanCode.GlobalMethods;

namespace WebShopCleanCode.States
{
    public class PurchaseMenu : IWebShopState
    {
        ShowCurrentUser show = new();
        UserActionResponse action = new();
        List<Product> products = new List<Product>();
        Database database = new Database();
        string info = "What would you like to purchase?";
        int currentChoice;
        int amountOfOptions;
        public Customer currentCustomer;

        public PurchaseMenu()
        {
            products = database.GetProducts();
            currentChoice = 1;
            amountOfOptions = products.Count;
        }
        public void CurrentMenu(WebShopContext context)
        {
            Console.WriteLine(info);
            currentCustomer = context.CurrentCustomer;

            PrintAllProducts();

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
            if(choice == "back")
            {
                context.ChangeMenu(new WaresMenu());
            }
            if (choice == "ok" | choice == "k" | choice == "o")
            {
                BuyProduct();
            }
        }
        public void PrintAllProducts()
        {
            for (int i = 0; i < amountOfOptions; i++)
            {
                Console.WriteLine(i + 1 + ": " + products[i].Name + ", " + products[i].Price + "kr");
            }
            Console.WriteLine("Your funds: " + currentCustomer.Funds);
        }
        public void BuyProduct()
        {
            int index = currentChoice - 1;
            Product product = products[index];
            if (product.InStock())
            {
                if (currentCustomer.CanAfford(product.Price))
                {
                    currentCustomer.Funds -= product.Price;
                    product.NrInStock--;
                    currentCustomer.Orders.Add(new Order(product.Name, product.Price, DateTime.Now));
                    action.PrintUserActionResponse("Successfully bought " + product.Name);
                }
                else
                {
                    action.PrintUserActionResponse("You cannot afford.");
                }
            }
            else
            {
                action.PrintUserActionResponse("Not in stock.");
            }
        }
    }
}
