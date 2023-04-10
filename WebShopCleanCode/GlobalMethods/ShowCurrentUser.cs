using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopCleanCode.GlobalMethods
{
    public class ShowCurrentUser
    {  
        public void LoggedInUser(WebShopContext context)
        {
            if (context.CurrentCustomer == null)
            {
                Console.WriteLine("Nobody is logged in");
            }
            else
            {
                Console.WriteLine(context.CurrentCustomer.Username + " is logged in");
            }
        }
    }
}
