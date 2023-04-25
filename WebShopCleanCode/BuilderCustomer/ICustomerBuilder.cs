namespace WebShopCleanCode.Builder
{
    public interface ICustomerBuilder
    {
        void SetUsername();
        void SetPassword();
        void SetFirstName();
        void SetLastName();
        void SetEmail();
        void SetAge();
        void SetAddress();
        void SetPhoneNumber();
        Customer Build();
    }
}
