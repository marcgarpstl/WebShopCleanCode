using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopCleanCode.States;

namespace WebShopCleanCode
{
    public class WebShopContext
    {
        private IWebShopState _state;
        public Customer CurrentCustomer { get; set; }
        public Database Database = new Database();
        public List<Product> Products = new List<Product>();
        public string username { get; set; }
        public string password { get; set; }

        public WebShopContext()
        {
            Products = Database.GetProducts();
            _state = new MainMenu();
            username = string.Empty;
            password = string.Empty;
        }
        public void CurrentMenu()
        {
            _state.CurrentMenu(this);
            
        }
        public void ChangeMenu(IWebShopState newMenu) 
        {
            _state = newMenu;
        }
    }
}

