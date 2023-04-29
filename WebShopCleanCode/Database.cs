using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopCleanCode
{
    public class Database
    {
        // We just pretend this accesses a real database.
        private List<Product> productsInDatabase;
        private List<Customer> customersInDatabase;
        public Database()
        {
            productsInDatabase = new List<Product>();
            productsInDatabase.Add(new Product("Mirror", 300, 2, "If you want to see something beatuful on the wall."));
            productsInDatabase.Add(new Product("Car", 2000000, 2, "When life goes slow, this can make you wrom wrom."));
            productsInDatabase.Add(new Product("Candle", 50, 2, "Lights up even the darkest places."));
            productsInDatabase.Add(new Product("Computer", 100000, 2, "Advanced futuristic tech. Cool stuff."));
            productsInDatabase.Add(new Product("Game", 599, 2,"Make you haha, if you kill some n00bs."));
            productsInDatabase.Add(new Product("Painting", 399, 2,"Blue, green, yellow, red, take a chance and you will maybe get the color you want"));
            productsInDatabase.Add(new Product("Chair", 500, 2,"Standing seems overrated, siting is fun. Sit down."));
            productsInDatabase.Add(new Product("Table", 1000, 2,"Place something nice on this, and not on the floor. Maybe some floortiles."));
            productsInDatabase.Add(new Product("Bed", 20000, 2,"Gogo sleepy sleep, nighttime relaxing."));

            customersInDatabase = new List<Customer>();
            customersInDatabase.Add(new Customer("jimmy", "jimisthebest", "Jimmy", "Jamesson", "jj@mail.com", 22, "Big Street 5", "123456789"));
            customersInDatabase.Add(new Customer("jake", "jake123", "Jake", null, null, 0, null, null));
        }

        public List<Product> GetProducts()
        {
            return productsInDatabase;
        }

        public Product GetProduct(string name)
        {
            int index = 0;
            for (int i = 0; i < productsInDatabase.Count; i++)
            {
                if (productsInDatabase[i].Name == name)
                {
                    index = i;
                }
            }
            return productsInDatabase[index];
        }

        public List<Customer> GetCustomers()
        {
            return customersInDatabase;
        }
    }
}
