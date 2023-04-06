using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopCleanCode.States;

namespace WebShopCleanCode
{
    public class WebShopCleanCodeClass
    {
        bool running = true;
        public Database database = new Database();
        public List<Product> products = new List<Product>();
        public List<Customer> customers = new List<Customer>();

        public WebShopCleanCodeClass()
        {
            products = database.GetProducts();
            customers = database.GetCustomers();
        }
        public void Run()
        {
            Console.WriteLine("Welcome to the WebShop!");
            WebShopContext context = new WebShopContext();
            while (running)
            {
                context.CurrentMenu();
            }
        }
    }
}
