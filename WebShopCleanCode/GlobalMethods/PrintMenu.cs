using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopCleanCode.States;

namespace WebShopCleanCode.GlobalMethods
{
    public class PrintMenu
    {
        List<string> options;
        public PrintMenu(List<string> options)
        {
            this.options = options;
        }
        public void Menu()
        {
            foreach (string option in options)
            {
                Console.WriteLine(option);
            }
        }
    }
}
