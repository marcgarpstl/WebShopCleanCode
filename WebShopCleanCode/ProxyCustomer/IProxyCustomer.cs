namespace WebShopCleanCode.Proxy
{
    public interface IProxyCustomer
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
