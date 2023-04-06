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
        public List<Product> Products = new();

        public WebShopContext()
        {
            _state = new MainMenu();
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

