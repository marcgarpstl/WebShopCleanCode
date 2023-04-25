using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace WebShopCleanCode.GlobalMethods
{
    public class Navigation  // Inprogress
    {
        int amountOfOptions;
        int currentChoice;
        public Navigation(int amountOfOptions, int currentChoice)
        {
            this.amountOfOptions = amountOfOptions;
            this.currentChoice = currentChoice;
        }

        public int Navigator()
        {
            string choice = Console.ReadLine().ToLower();
            if (currentChoice > 1 && choice == "l" | choice == "left")
            {
                return currentChoice--;
            }
            if (currentChoice < amountOfOptions && choice == "r" | choice == "right")
            {
                return currentChoice++;
            }
            if (choice == "q" | choice == "quit")
            {
                Console.WriteLine("The console powers down. You are free to leave.");
                Environment.Exit(0);
            }
            return currentChoice;
        }
    }
}
