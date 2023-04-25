namespace WebShopCleanCode.Builder
{
    public class CustomerBuilder : ICustomerBuilder
    {

        private Customer _customer = new();
        private GetUserInputClass _inputClass = new();

        //public CustomerBuilder NewCustomer()
        //{
        //    _customer.Username = SetUsername();
        //    _customer.Password = SetPassword();
        //    _customer.FirstName = SetFirstName();
        //    _customer.LastName = SetLastName();
        //    _customer.Email = SetEmail();
        //    _customer.Age = SetAge();
        //    _customer.Address = SetAddress();
        //    _customer.PhoneNumber = SetPhoneNumber();

        //    return this;
        //}
        public void SetUsername()
        {
            _customer.Username = _inputClass.GetUsernameInput();
        }
        public void SetPassword()
        {
            _customer.Password= _inputClass.GetStringInput("password");
        }
        public void SetFirstName()
        {
            _customer.FirstName = _inputClass.GetStringInput("first name");
        }
        public void SetLastName()
        {
            _customer.LastName = _inputClass.GetStringInput("last name");
        }
        public void SetEmail()
        {
            _customer.Email = _inputClass.GetStringInput("email");
        }
        public void SetAge()
        {
            _customer.Age = _inputClass.GetIntInput("age");
        }
        public void SetAddress()
        {
            _customer.Address = _inputClass.GetStringInput("address");
        }
        public void SetPhoneNumber()
        {
            _customer.PhoneNumber = _inputClass.GetStringInput("phonenumber");
        }
        public Customer Build()
        {
            SetUsername();
            SetPassword();
            SetFirstName();
            SetLastName();
            SetEmail();
            SetAge();
            SetAddress();
            SetPhoneNumber();
            return _customer;
        }
    }
}
