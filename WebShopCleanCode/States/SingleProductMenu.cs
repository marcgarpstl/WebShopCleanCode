using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopCleanCode.GlobalMethods;
using WebShopCleanCode.ProductProxy;

namespace WebShopCleanCode.States
{
    public class SingleProductMenu : IWebShopState
    {
        ShowCurrentUser show = new();
        UserActionResponse action = new();
        List<Product> products = new List<Product>();
        Database database = new Database();
        string info = "What item would you like to see detailes about?";
        int currentChoice;
        int amountOfOptions;

        public SingleProductMenu()
        {
            products = database.GetProducts();
            currentChoice = 1;
            amountOfOptions = products.Count;
        }

        public void CurrentMenu(WebShopContext context)
        {
            
            Console.WriteLine(info);

            PrintProducts(context);

            ManeuverLogics move = new ManeuverLogics(amountOfOptions, currentChoice);
            move.ManeuverLogic();

            show.LoggedInUser(context);

            Navigation naVi = new Navigation(amountOfOptions, currentChoice);
            naVi.Navigator(context, new SingleProductMenu());
            currentChoice = naVi.LeftAndRight();

        }
        public void PrintProducts(WebShopContext context)
        {
            int i = 1;
            foreach (Product product in context.Products)
            {
                Console.Write(i + ". ");
                product.PrintInfo();
                i++;
            }
            Console.WriteLine();
        }

        public void SingleItemOk(WebShopContext context, int currentChoice)
        {
            int index = currentChoice - 1;
            Product product = context.Products[index];
            action.PrintUserActionResponse("Product name: " + product.GetName() +
                "\n" + 
                "There are: " + product.GetNrInStock() + " in stock." + 
                "\n" +
                "Price: " + product.GetPrice() + "kr" + 
                "\n" +
                "Description: " + product.GetDescription());
        }
    }

    
}
