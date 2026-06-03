using ECommerce_System.Carts;

namespace ECommerce_System.Users
{
    public class User
    {
        public string Password { get; }
        public int Id { get; } = 0 ;
        public string UserType { get; protected set; }
        public string UserName { get; }
        public Cart Cart { get; protected set; }
        public User(string userName,string password, string userType)
        {
            if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException("Invalid User Name");
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("Invalid Password");
            //if (string.IsNullOrEmpty(userType) || (userType.ToString().ToLower() != "admin" && userType.ToString().ToLower() != "customer")) throw new ArgumentNullException("Invalid User type");
            this.UserName = userName;
            Password = password;
            UserType = userType;
            Id++;
        }

    }
    public class AdminUser : User
    {
        public AdminUser(string userName, string password, string userType) : base(userName, password, userType)
        {
            
        }
    }

    public class CustomerUser : User
    {
        public CustomerUser(string userName, string password, string userType) : base(userName, password, userType)
        {
            Cart = new Cart();
        }
    }
}
