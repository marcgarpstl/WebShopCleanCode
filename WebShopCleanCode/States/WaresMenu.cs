﻿using WebShopCleanCode.GlobalMethods;

namespace WebShopCleanCode.States
{
    public class WaresMenu : IWebShopState
    {
        ShowCurrentUser show = new();
        UserActionResponse action = new();
        List<string> options;
        Database db = new();
        string info = "What would you like to do?";
        int currentChoice;
        int amountOfOptions;
        Customer currentCustomer;

        public WaresMenu()
        {
            currentChoice = 1;
            amountOfOptions = 4;
            options = new List<string>
            {
                "1. See all wares",
                "2. Purchase a ware",
                "3. Sort wares",
                "4. Logout"
            };
        }
        public void CurrentMenu(WebShopContext context)
        {
            Console.WriteLine(info);
            currentCustomer = context.CurrentCustomer;
            if (currentCustomer == null)
            {
                options[3] = "4. Login";
            }

            PrintMenu wares = new PrintMenu(options);
            wares.Menu();

            ManeuverLogics move = new ManeuverLogics(amountOfOptions, currentChoice);
            move.ManeuverLogic();

            show.LoggedInUser(context);

            Navigation naVi = new Navigation(amountOfOptions, currentChoice);
            naVi.Navigator(context, new WaresMenu());
            currentChoice = naVi.LeftAndRight();

        }
   

        public void WaresOk(WebShopContext context, int currentChoice)
        {
            if (currentChoice == 1)
            {
                context.ChangeMenu(new SingleProductMenu());
            }
            if (currentChoice == 2 && context.CurrentCustomer != null)
            {
                context.ChangeMenu(new PurchaseMenu());
            }
            if (currentChoice == 2 && context.CurrentCustomer == null)
            {
                action.PrintUserActionResponse("You must be logged in to purchase wares.");
            }
            if (currentChoice == 3)
            {
                context.ChangeMenu(new SortMenu());
            }
            if (currentChoice == 4 && context.CurrentCustomer != null)
            {
                Console.WriteLine(context.CurrentCustomer.Username + " has logged out");
                context.CurrentCustomer = null;
                context.username = null;
                context.password = null;
            }
            if (currentChoice == 4 && context.CurrentCustomer == null)
            {
                context.ChangeMenu(new LoginMenu());
            }
        }


    }
}
