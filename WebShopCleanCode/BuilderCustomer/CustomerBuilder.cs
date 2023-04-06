namespace WebShopCleanCode.Builder
{
    public class CustomerBuilder : ICustomerBuilder
    {

        private Customer _customer;
        private GetUserInputClass _inputClass;

        public CustomerBuilder()
        {
            _customer = new Customer();
            _inputClass = new GetUserInputClass();
        }
        public CustomerBuilder NewCustomer()
        {
            _customer.Username = _inputClass.GetUsernameInput();
            _customer.Password = _inputClass.GetUserInfo("password");
            _customer.FirstName = _inputClass.GetUserInfo("first name");
            _customer.LastName = _inputClass.GetUserInfo("last name");
            _customer.Email = _inputClass.GetUserInfo("email");
            _customer.Age = _inputClass.GetIntInput("age");
            _customer.Address = _inputClass.GetStringInput("address");
            _customer.PhoneNumber = _inputClass.GetStringInput("phonenumber");

            return this;
        }
        public Customer Build()
        {
            return _customer;
        }
    }
}
