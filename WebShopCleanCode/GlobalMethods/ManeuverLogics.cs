using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopCleanCode.GlobalMethods
{
    public class ManeuverLogics
    {
        int amountOfOptions;
        int currentChoice;
        public ManeuverLogics(int amountOfOptions, int currentChoice)
        {
            this.amountOfOptions = amountOfOptions;
            this.currentChoice = currentChoice;
        }

        public void ManeuverLogic()
        {
            for (int i = 0; i < amountOfOptions; i++)
            {
                Console.Write(i + 1 + "\t");
            }
            Console.WriteLine();
            for (int i = 1; i < currentChoice; i++)
            {
                Console.Write("\t");
            }
            Console.WriteLine("|");
            Console.WriteLine("Your buttons are Left, Right, OK, Back and Quit.");

        }
    }
}
