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

            PrintAllProducts(context);

            ManeuverLogics move = new ManeuverLogics(amountOfOptions, currentChoice);
            move.ManeuverLogic();

            show.LoggedInUser(context);

            Navigation naVi = new Navigation(amountOfOptions, currentChoice);
            naVi.Navigator(context, new PurchaseMenu());
            currentChoice = naVi.LeftAndRight();

        }
        public void PrintAllProducts(WebShopContext context)
        {
            for (int i = 0; i < amountOfOptions; i++)
            {
                Console.WriteLine(i + 1 + ": " + context.Products[i].Name + ", " + context.Products[i].Price + "kr");
            }
            Console.WriteLine("Your funds: " + context.CurrentCustomer.Funds);
        }
        public void BuyProduct(WebShopContext context, int currentChoice)
        {
            int index = currentChoice - 1;
            Product product = context.Products[index];
            if (product.InStock())
            {
                if (context.CurrentCustomer.CanAfford(product.Price))
                {
                    context.CurrentCustomer.Funds -= product.Price;
                    product.NrInStock--;
                    context.CurrentCustomer.Orders.Add(new Order(product.Name, product.Price, DateTime.Now));
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
