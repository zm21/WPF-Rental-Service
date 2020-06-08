namespace RentalService.Users
{
    public class RegisterMViewModel
    {
        private RegisterModel registerModel;
        public RegisterModel RegisterModel
        {
            get => registerModel;
            set
            {
                registerModel = value;
            }
        }
        public RegisterMViewModel()
        {
            RegisterModel = new RegisterModel();
        }
    }
}
