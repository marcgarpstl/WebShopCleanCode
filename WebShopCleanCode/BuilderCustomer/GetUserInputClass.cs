namespace WebShopCleanCode.Builder
{

    public class GetUserInputClass
    {
        private WebShop shop = new();
        Database db = new();

        public string GetUsernameInput()
        {
            string newUsername;
            while (true)
            {
                Console.WriteLine("Please write your username.");
                newUsername = Console.ReadLine();
                List<Customer> customers = db.GetCustomers();
                bool userNameExist = false;
                foreach (Customer customer in customers)
                {
                    if (customer.Username.Equals(newUsername))
                    {
                        shop.PrintUserActionResponse("Username already exists.");
                        userNameExist = true;
                        break;
                    }
                }
                if (!userNameExist)
                {
                    return newUsername;
                }
            }
        }
        public string GetStringInput(string messege)
        {
            Console.WriteLine("Do you want a(n) " + messege + "? y/n");
            string choice = Console.ReadLine();
            if (choice.Equals("y"))
            {
                return GetUserInfo(messege);
            }
            return "";
        }
        public string GetUserInfo(string messege)
        {
            while (true)
            {
                Console.WriteLine("Please write your " + messege + ".");
                string inputStr = Console.ReadLine();
                if (inputStr.Equals(""))
                {
                    shop.PrintUserActionResponse("Please actually write something.");
                    continue;
                }
                else
                {
                    return inputStr;
                }
            }
        }
        public int GetIntInput(string messege)
        {
            Console.WriteLine("Do you want an " + messege + "? y/n");
            string choice = Console.ReadLine();
            if (choice.Equals("y"))
            {
                return GetUserAgeInfo(messege);
            }
            return 0;
        }
        private int GetUserAgeInfo(string messege)
        {
            while (true)
            {
                Console.WriteLine("Please write your " + messege + ".");
                string ageString = Console.ReadLine();
                try
                {
                    int inputInt = int.Parse(ageString);
                    return inputInt;
                }
                catch (FormatException e)
                {
                    shop.PrintUserActionResponse("Please write a number.");
                    continue;
                }
            }
        }
    }
}
