﻿using WebShopCleanCode.GlobalMethods;

namespace WebShopCleanCode.States
{
    public class CustomerMenu : IWebShopState
    {
        ShowCurrentUser show = new();
        UserActionResponse action = new();
        public Database database = new Database();
        public List<Product> products = new List<Product>();
        public List<Customer> customers = new List<Customer>();
        List<string> options;
        string info = "What would you like to do?";
        int currentChoice;
        int amountOfOptions;
        Customer currentCustomer;

        public CustomerMenu()
        {
            products = database.GetProducts();
            customers = database.GetCustomers();
            currentChoice = 1;
            amountOfOptions = 4;
            options = new List<string>
            {
                "1. See orders",
                "2. See customer info",
                "3. Add funds",
                "4. Quit"
            };
        }
        public void CurrentMenu(WebShopContext context)
        {
            Console.WriteLine(info);
            currentCustomer = context.CurrentCustomer;

            PrintMenu customer = new PrintMenu(options);
            customer.Menu();

            ManeuverLogics move = new ManeuverLogics(amountOfOptions, currentChoice);
            move.ManeuverLogic();

            show.LoggedInUser(context);

            Navigation naVi = new Navigation(amountOfOptions, currentChoice);
            naVi.Navigator(context, new CustomerMenu());
            currentChoice = naVi.LeftAndRight();

        }

        public void CustomerOk(int currentChoice, WebShopContext context)
        {
            if (currentChoice == 1)
            {
                context.CurrentCustomer.PrintOrders();
            }
            if (currentChoice == 2)
            {
                context.CurrentCustomer.PrintInfo(context);
            }
            if (currentChoice == 3)
            {
                AddFunds(context);
            }
            if (currentChoice == 4)
            {
                Environment.Exit(0);
            }
        }
        public void AddFunds(WebShopContext context)
        {
            Console.WriteLine("How many funds would you like to add?");
            string amountString = Console.ReadLine();
            try
            {
                int amount = int.Parse(amountString);
                if (amount < 0)
                {
                    action.PrintUserActionResponse("Don't add negative amounts.");
                }
                else
                {
                    context.CurrentCustomer.Funds += amount;
                    action.PrintUserActionResponse(amount + " added to your profile.");
                }
            }
            catch (FormatException e)
            {
                action.PrintUserActionResponse("Please write a number next time.");
            }
        }
    }
}
