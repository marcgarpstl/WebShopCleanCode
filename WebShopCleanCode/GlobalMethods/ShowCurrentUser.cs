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
