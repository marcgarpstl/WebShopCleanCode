namespace WebShopCleanCode
{
    public class WebShop
    {
        bool running = true;
        public Database database = new Database();
        public List<Product> products = new List<Product>();
        public List<Customer> customers = new List<Customer>();



        public string currentMenu;
        public int currentChoice;
        public int amountOfOptions;
        public string option1;
        public string option2;
        public string option3;
        public string option4;
        public string info;




        string username = null;
        string password = null;
        Customer currentCustomer;




        public WebShop()
        {
            products = database.GetProducts();
            customers = database.GetCustomers();

        }



        public void Run()
        {


            Console.WriteLine("Welcome to the WebShop!");
            //MainMenu();
            while (running)
            {
                Console.WriteLine(info);
                PrintOptions();
                CurrentChoice();


                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "left":
                    case "l":
                        if (currentChoice > 1)
                        {
                            currentChoice--;

                        }
                        break;
                    case "right":
                    case "r":
                        if (currentChoice < amountOfOptions)
                        {
                            currentChoice++;

                        }
                        break;
                    case "ok":
                    case "k":
                    case "o":
                        if (currentMenu.Equals("main menu"))
                        {
                            switch (currentChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    WaresMenu();
                                    break;
                                case 2:
                                    Console.Clear();
                                    CustomerMenu();
                                    break;
                                case 3:
                                    Console.Clear();
                                    LoginMenu();
                                    break;
                                default:
                                    PrintUserActionResponse("Not an option.");
                                    break;
                            }
                        }
                        else if (currentMenu.Equals("customer menu"))
                        {
                            switch (currentChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    currentCustomer.PrintOrders();
                                    break;
                                case 2:
                                    Console.Clear();
                                    currentCustomer.PrintInfo();
                                    break;
                                case 3:
                                    Console.Clear();
                                    AddFunds();
                                    break;
                                default:
                                    PrintUserActionResponse("Not an option.");
                                    break;
                            }
                        }
                        else if (currentMenu.Equals("sort menu"))
                        {
                            bool back = true;
                            switch (currentChoice)
                            {
                                case 1:
                                    bubbleSortReplacedWithInsertionSort("name", false);
                                    PrintUserActionResponse("Wares sorted.");
                                    break;
                                case 2:
                                    bubbleSortReplacedWithInsertionSort("name", true);
                                    PrintUserActionResponse("Wares sorted.");
                                    break;
                                case 3:
                                    bubbleSortReplacedWithInsertionSort("price", false);
                                    PrintUserActionResponse("Wares sorted.");
                                    break;
                                case 4:
                                    bubbleSortReplacedWithInsertionSort("price", true);
                                    PrintUserActionResponse("Wares sorted.");
                                    break;
                                default:
                                    back = false;
                                    PrintUserActionResponse("Not an option.");
                                    break;
                            }
                            if (back)
                            {
                                WaresMenu();
                            }
                        }
                        else if (currentMenu.Equals("wares menu"))
                        {
                            switch (currentChoice)
                            {
                                case 1:
                                    Console.Clear();
                                    PrintProducts();
                                    break;
                                case 2:
                                    Console.Clear();
                                    PurchaseMenu();
                                    break;
                                case 3:
                                    Console.Clear();
                                    SortMenu();
                                    break;
                                case 4:
                                    Console.Clear();
                                    LoginMenu();
                                    break;
                                case 5:
                                    break;
                                default:
                                    PrintUserActionResponse("Not an option.");
                                    break;
                            }
                        }
                        else if (currentMenu.Equals("login menu"))
                        {
                            switch (currentChoice)
                            {
                                case 1:
                                    username = MagicKeyBoardAppear("username");
                                    break;
                                case 2:
                                    password = MagicKeyBoardAppear("password");
                                    break;
                                case 3:
                                    if (username == null || password == null)
                                    {
                                        PrintUserActionResponse("Incomplete data.");
                                    }
                                    else
                                        LoginCheck();
                                    break;
                                case 4:
                                    // Would have liked to be able to quit at any time in here.
                                    //choice = "";
                                    //bool next = false;
                                    //string newPassword = null;
                                    //string firstName = null;
                                    //string lastName = null;
                                    //string email = null;
                                    //int age = -1;
                                    //string address = null;
                                    //string phoneNumber = null;
                                    //Customer newCustomer = AddCustomer();
                                    //currentCustomer = newCustomer;
                                    //PrintUserActionResponse(newCustomer.Username + " successfully added and is now logged in.");
                                    break;

                                default:
                                    PrintUserActionResponse("Not an option.");
                                    break;
                            }
                        }
                        else if (currentMenu.Equals("purchase menu"))
                        {
                            PurchaseProduct();
                            BuyProduct();
                        }
                        break;
                    case "back":
                    case "b":
                        if (currentMenu.Equals("main menu"))
                        {
                            PrintUserActionResponse("You're already on the main menu.");
                        }
                        else if (currentMenu.Equals("purchase menu"))
                        {
                            Console.Clear();
                            WaresMenu();
                        }
                        else
                        {

                        }
                        break;

                    case "quit":
                    case "q":
                        Console.WriteLine("The console powers down. You are free to leave.");
                        return;
                    default:
                        Console.WriteLine("That is not an applicable option.");
                        break;
                }
            }
        }

        //public void MainMenu()
        //{
        //    WebShopContext currentMenuState = new WebShopContext();
        //    currentMenuState.CurrentMenu();
        //    if (currentCustomer != null)
        //    {
        //        option3 = "Logout";
        //    }
        //}

        //public Customer AddCustomer()
        //{
        //    CustomerBuilder newUser = new CustomerBuilder();
        //    Customer newCustomer = newUser.NewCustomer().Build();
        //    customers.Add(newCustomer);
        //    return newCustomer;
        //}

        public void BuyProduct()
        {
            int index = currentChoice - 1;
            Product product = products[index];
            if (product.InStock())
            {
                if (currentCustomer.CanAfford(product.Price))
                {
                    currentCustomer.Funds -= product.Price;
                    product.NrInStock--;
                    currentCustomer.Orders.Add(new Order(product.Name, product.Price, DateTime.Now));
                    PrintUserActionResponse("Successfully bought " + product.Name);
                }
                else
                {
                    PrintUserActionResponse("You cannot afford.");
                }
            }
            else
            {
                PrintUserActionResponse("Not in stock.");
            }
        }

        public void LoginCheck()
        {
            Console.Clear();
            bool found = false;
            foreach (Customer customer in customers)
            {
                if (username.Equals(customer.Username) && customer.CheckPassword(password))
                {
                    PrintUserActionResponse(customer.Username + " logged in.");
                    currentCustomer = customer;
                    found = true;
                    Access();
                    break;
                }
            }
            if (found == false)
            {
                PrintUserActionResponse("Invalid credentials.");
            }
        }

        public void Access()
        {

            if (currentCustomer == null)
            {
                LoginMenu();
            }
            else
            {
                option3 = "Logout";
            }

        }

        public void LoginMenu()
        {
            //if (currentCustomer == null)
            //{
            //    currentMenuState = new LoginMenu();
            //    currentMenuState.ChangeMenu(ref currentMenu, ref option1, ref option2, ref option3, ref option4, ref info, ref currentChoice, ref amountOfOptions);
            //}
            //else
            //{
            //    option4 = "Logout";
            //    PrintUserActionResponse(currentCustomer.Username + " logged out.");
            //    currentCustomer = null;
            //    currentChoice = 1;
            //}
        }

        public void SortMenu()
        {
            //currentMenuState = new SortMenu();
            //currentMenuState.ChangeMenu(ref currentMenu, ref option1, ref option2, ref option3, ref option4, ref info, ref currentChoice, ref amountOfOptions);
        }

        public void PurchaseMenu()
        {
            if (currentCustomer != null)
            {
                //currentMenuState = new PurchaseMenu();
                //currentMenuState.ChangeMenu(ref currentMenu, ref option1, ref option2, ref option3, ref option4, ref info, ref currentChoice, ref amountOfOptions);

            }
            else
            {
                PrintUserActionResponse("You must be logged in to purchase wares.");
                currentChoice = 1;
            }
        }

        public void PrintProducts()
        {
            Console.Clear();
            foreach (Product product in products)
            {
                product.PrintInfo();
            }
            Console.WriteLine();
        }

        public void AddFunds()
        {
            Console.WriteLine("How many funds would you like to add?");
            string amountString = Console.ReadLine();
            try
            {
                int amount = int.Parse(amountString);
                if (amount < 0)
                {
                    PrintUserActionResponse("Don't add negative amounts.");
                }
                else
                {
                    currentCustomer.Funds += amount;
                    PrintUserActionResponse(amount + " added to your profile.");
                }
            }
            catch (FormatException e)
            {
                PrintUserActionResponse("Please write a number next time.");
            }
        }

        public void CustomerMenu()
        {
            if (currentCustomer != null)
            {

            }
            else
            {
                PrintUserActionResponse("Nobody is logged in.");
            }
        }

        public void WaresMenu()
        {


            if (currentCustomer != null)
            {
                option4 = "Logout";
            }
        }


        public void CurrentChoice()
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
        }

        public void PrintOptions()
        {
            if (currentMenu != "purchase menu")
            {
                Console.WriteLine("1: " + option1);
                Console.WriteLine("2: " + option2);
                if (amountOfOptions > 2)
                {
                    Console.WriteLine("3: " + option3);
                }
                if (amountOfOptions > 3)
                {
                    Console.WriteLine("4: " + option4);
                }
            }
            else
            {
                PurchaseProduct();
            }
        }

        public void PurchaseProduct()
        {
            for (int i = 0; i < amountOfOptions; i++)
            {
                Console.WriteLine(i + 1 + ": " + products[i].Name + ", " + products[i].Price + "kr");
            }
            Console.WriteLine("Your funds: " + currentCustomer.Funds);
        }

        public string MagicKeyBoardAppear(string name)
        {
            Console.Clear();
            Console.WriteLine("A keyboard appears.");
            Console.WriteLine("Please input your " + name + ".");
            string input = Console.ReadLine();
            Console.WriteLine();
            Console.Clear();
            return input;

        }

        public void PrintUserActionResponse(string response)
        {
            Console.WriteLine("\n" + response + "\n");
        }

        public void bubbleSortReplacedWithInsertionSort(string variable, bool ascending)
        {
            if (variable.Equals("name"))
            {
                int length = products.Count;
                for (int i = 1; i < length; i++)
                {
                    Product temp = products[i];
                    int j = i - 1;
                    if (ascending)
                    {
                        while (j >= 0 && products[j].Name.CompareTo(temp.Name) > 0)
                        {
                            products[j + 1] = products[j];
                            j--;
                        }

                    }
                    else
                    {
                        while (j >= 0 && products[j].Name.CompareTo(temp.Name) < 0)
                        {
                            products[j + 1] = products[j];
                            j--;
                        }
                    }
                    products[j + 1] = temp;
                }
            }
            if (variable.Equals("price"))
            {
                int length = products.Count;
                for (int i = 1; i < length; i++)
                {
                    Product temp = products[i];
                    int j = i - 1;
                    if (ascending)
                    {
                        while (j >= 0 && products[j].Price.CompareTo(temp.Price) < 0)
                        {
                            products[j + 1] = products[j];
                            j--;
                        }
                    }
                    else
                    {
                        while (j >= 0 && products[j].Price.CompareTo(temp.Price) > 0)
                        {
                            products[j + 1] = products[j];
                            j--;
                        }
                    }
                    products[j + 1] = temp;
                }
            }
        }

    }
}
