namespace ECommerce_System
{
    public class Users
    {
        public string Password { get; }
        public int Id { get; } = 0 ;
        public string UserType { get; protected set; }
        public string UserName { get; }

        public Users(string userName,string password)
        {
            if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException("Invalid User Name");
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("Invalid Password");
            //if (string.IsNullOrEmpty(userType) || (userType.ToString().ToLower() != "admin" && userType.ToString().ToLower() != "customer")) throw new ArgumentNullException("Invalid User type");
            this.UserName = userName;
            Password = password;
            Id++;
        }

    }
    public class AdminUser : Users
    {
        public AdminUser(string userName, string password, string userType) : base(userName, password)
        {
            UserType = userType;
        }
    }

    public class CustomerUser : Users
    {
        public CustomerUser(string userName, string password, string userType) : base(userName, password)
        {
            UserType = userType;
        }
    }
}
