using WebShopCleanCode.ProductProxy;

namespace WebShopCleanCode
{
    public class Product : IProductProxy
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int NrInStock { get; set; }
        public string Desciption { get; set; }
        public Product(string name, int price, int nrInStock, string desciption)
        {
            Name = name;
            Price = price;
            NrInStock = nrInStock;
            Desciption = desciption;
        }
        public bool InStock()
        {
            return NrInStock > 0;
        }
        public void PrintInfo()
        {
            Console.WriteLine(Name + ": " + Price + "kr");
        }

        public string GetName()
        {
            return Name;
        }

        public int GetPrice()
        {
            return Price;
        }

        public int GetNrInStock()
        {
            return NrInStock;
        }

        public string GetDescription()
        {
            return Desciption;
        }
    }
}
