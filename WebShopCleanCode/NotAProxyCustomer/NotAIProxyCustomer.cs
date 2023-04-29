namespace WebShopCleanCode.Proxy
{
    public interface NotAIProxyCustomer
    {
        string GetPassword(WebShopContext context);
        string GetFirstName();
        string GetLastName();
        string GetEmail();
        int GetAge();
        string GetAddress();
        string GetPhoneNumber();
    }
}
