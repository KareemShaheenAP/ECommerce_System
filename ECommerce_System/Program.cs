using ECommerce_System.Carts;
using ECommerce_System.Orders;
using ECommerce_System.Payment;
using ECommerce_System.Users;
using ECommerce_System.Products;
using System.ComponentModel;

namespace ECommerce_System
{
    enum UserLogin
    {
        Register, Login, View
    }
    enum UserType
    {
        Admin, Customer
    }
    enum PaymentOption
    {
        [Description("Creidt Card")] Credit,Paypal,Cash

    }
    public class Program
    {
        static List<User> users = new List<User>();
        static List<Product> products = new List<Product>();
        
        static void ViewProduct()
        {
            foreach (Product product in products)
            {
                Console.WriteLine("ID: " + product.Id + " - Name: " + product.Name + " - Price: " + product.Price + " - Stock: " + product.StockQuantity
                );
            }
        }
        static bool DeleteProduct(int productId)
        {
            foreach (Product product in products)
            {
                if (product.Id == productId)
                {
                    products.Remove(product);
                    return true;
                }
            }
            return false;
        }
        static bool UpdateProduct(int productId)
        {
            foreach (Product product in products)
            {
                if (product.Id == productId)
                {
                    Console.Write("Product Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Price: ");
                    double price = double.Parse(Console.ReadLine());
                    Console.Write("Stock Quantity: ");
                    int stock = int.Parse(Console.ReadLine());
                    product.Name = name;
                    product.Price = price;
                    product.StockQuantity = stock;
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n---Please Choose from below");
                Console.WriteLine("01-Register");
                Console.WriteLine("02-Login");
                Console.WriteLine("03-View Users");
                var selection = int.TryParse(Console.ReadLine(), out int entry);
                UserLogin userselection = (UserLogin)entry - 1;
                Console.Clear();
                var userName = "";
                var userPassword = "";
                switch (userselection)
                {
                    case UserLogin.Register:
                        Console.WriteLine("\n---Enter UserName:");
                        userName = Console.ReadLine();
                        Console.WriteLine("Enter Password:");
                        userPassword = Console.ReadLine();
                        Console.WriteLine("Enter Type: {1 = Admin / 2 = Customer}");
                        selection = int.TryParse(Console.ReadLine(), out int usertype);
                        UserType selectedType = (UserType)usertype - 1;
                        string Usertype = "";
                        switch (selectedType)
                        {
                            case UserType.Admin:
                                Usertype = "Admin";
                                break;
                            case UserType.Customer:
                                Usertype = "Customer";
                                break;
                            default:
                                Console.WriteLine("\n---Invalid Selection, Aborted");
                                return;
                        }
                        bool UserAlreadyExist = false;
                        foreach (User user in users)
                        {
                            if (user.UserName == userName)
                            {
                                UserAlreadyExist = true;
                                break;
                            }
                        }
                        if (UserAlreadyExist)
                        {
                            Console.WriteLine("user with same name already exist");
                        }
                        else
                        {
                            User RegisteredUser;
                            if (Usertype == "Customer")
                            {
                                RegisteredUser = new CustomerUser(userName, userPassword, Usertype);
                                var c = (CustomerUser)RegisteredUser;
                            }
                            else
                            {
                                RegisteredUser = new AdminUser(userName, userPassword, Usertype);
                                var c = (AdminUser)RegisteredUser;
                            }
                            
                            users.Add(RegisteredUser);
                            Console.WriteLine("\n---Account Created successfully");
                        }
                        break;
                    case UserLogin.Login:
                        Console.WriteLine("\n---Enter UserName:");
                        userName = Console.ReadLine();
                        //
                        Console.WriteLine("Enter Password:");
                        userPassword = Console.ReadLine();
                        //
                        User logginUser = null;
                        foreach (var user in users)
                        {
                            if (user.UserName == userName && user.Password == userPassword)
                            {
                                logginUser = user;
                                break;
                            }
                        }
                        if (logginUser is null)
                        {
                            Console.WriteLine("\n---Invalid username or password.");
                            break;
                        }
                        if (logginUser.UserType == "Admin")
                        {
                            while (logginUser != null)
                            {
                                Console.WriteLine("\n--- Admin Menu ---");
                                Console.WriteLine("1. Add Product");
                                Console.WriteLine("2. Update Product");
                                Console.WriteLine("3. Delete Product");
                                Console.WriteLine("4. View Products");
                                Console.WriteLine("5. Logout");
                                Console.Write("Selection: ");
                                int choice = int.Parse(Console.ReadLine());

                                switch (choice)
                                {
                                    case 1:
                                        Console.Write("\n---Product Name: ");
                                        string name = Console.ReadLine();
                                        Console.Write("Price: ");
                                        double price = double.Parse(Console.ReadLine());
                                        Console.Write("Stock Quantity: ");
                                        int stock = int.Parse(Console.ReadLine());
                                        Product product = new Product(products.Count + 1, name, price, stock);
                                        products.Add(product);
                                        Console.WriteLine("\n---Product Added Successfully");
                                        break;

                                    case 2:
                                        Console.WriteLine("\n--- Products ---");
                                        ViewProduct();
                                        Console.Write("Enter Product ID to update: ");
                                        int updatePoductId = int.Parse(Console.ReadLine());
                                        if (UpdateProduct(updatePoductId))
                                        {
                                            Console.WriteLine("\n---Product Updated");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n---Invalid Product ID");
                                        }
                                        break;

                                    case 3:
                                        Console.WriteLine("\n--- Products ---");
                                        ViewProduct();
                                        Console.Write("\n---Enter Product ID to delete: ");
                                        int deletePoductId = int.Parse(Console.ReadLine());
                                        if (DeleteProduct(deletePoductId))
                                        {
                                            Console.WriteLine("\n---Product Removed");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n---Invalid Product ID");
                                        }
                                        break;

                                    case 4:
                                        Console.WriteLine("\n--- Products ---");
                                        ViewProduct();
                                        break;

                                    case 5:
                                        Console.Clear();
                                        logginUser = null;
                                        break;

                                    default:
                                        break;
                                }
                            }
                        }
                        else if (logginUser.UserType == "Customer")
                        {
                            Cart cart = logginUser.Cart;
                            while (logginUser != null)
                            {
                                Console.WriteLine("\n--- Customer Menu ---");
                                Console.WriteLine("1. View Products");
                                Console.WriteLine("2. Add To Cart");
                                Console.WriteLine("3. Remove From Cart");
                                Console.WriteLine("4. View Cart");
                                Console.WriteLine("5. Checkout");
                                Console.WriteLine("6. Logout");

                                int choice = int.Parse(Console.ReadLine());

                                switch (choice)
                                {
                                    case 1:
                                        Console.WriteLine("\n--- Products ---");
                                        ViewProduct();
                                        break;
                                    case 2:
                                        Console.WriteLine("\n--- Products ---");
                                        ViewProduct();
                                        Console.Write("\n---Enter Product ID: ");
                                        int addPoductId = int.Parse(Console.ReadLine());
                                        Console.Write("Enter Product Qty: ");
                                        int addProductQty = int.Parse(Console.ReadLine());
                                        bool Productfound = false;
                                        foreach (Product product in products)
                                        {
                                            if (product.Id == addPoductId)
                                            {
                                                Productfound = true;
                                                if (cart.AddToCart(product, addProductQty))
                                                {
                                                    Console.WriteLine("\n---Product has been added.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\n---Product is not enough in stock to add");
                                                }
                                                break;
                                            }
                                        }
                                        if (!Productfound)
                                        {
                                            Console.WriteLine("\n---Invalid product id");
                                        }
                                        break;
                                    case 3:
                                        if (!cart.ViewItems())
                                        {
                                            break;
                                        }
                                        Console.Write("\n---Enter Product ID to remove: ");
                                        int removePoductId = int.Parse(Console.ReadLine());
                                        if (cart.RemoveFromCart(removePoductId))
                                        {
                                            Console.WriteLine("\n---Product has been removed");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n---Invalid Product ID");
                                        }
                                        break;
                                    case 4:
                                        cart.ViewItems();
                                        Console.WriteLine("\n---Total Price");
                                        cart.CalculateTotalPrice();
                                        break;
                                    case 5:
                                        if (cart.Items.Count == 0)
                                        {
                                            Console.WriteLine("\n---No available cart items to check out");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n---Select Payment method");
                                            Console.WriteLine("1. Creidt Card");
                                            Console.WriteLine("2. PayPal");
                                            Console.WriteLine("3. Cash");
                                            var payment = int.TryParse(Console.ReadLine(), out int paymentselection);
                                            PaymentOption paymentOption = (PaymentOption)paymentselection - 1;
                                            IPayment paymentmethod = null;
                                            switch (paymentOption)
                                            {
                                                case PaymentOption.Credit:
                                                    paymentmethod = new CreditCardPayment();
                                                    break;
                                                case PaymentOption.Paypal:
                                                    paymentmethod = new PayPalPayment();
                                                    break;
                                                case PaymentOption.Cash:
                                                    paymentmethod = new CashPayment();
                                                    break;
                                                default:
                                                    break;
                                            }
                                            Order order = new Order(cart.Items, cart.CalculateTotalPrice());
                                            OrderService orderService = new OrderService();
                                            orderService.ProcessOrder(order, paymentmethod);
                                            cart.Items.Clear();
                                        }                     
                                        break;
                                    case 6:
                                       
                                        Console.Clear();
                                        logginUser = null;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        break;
                    case UserLogin.View:
                        if (users.Count == 0) Console.WriteLine("\n---No user available");
                        else
                        {
                            foreach (User user in users)
                            {
                                Console.WriteLine($"ID: {user.Id} - Name: {user.UserName} - Password: {user.Password} - Type:{user.UserType}");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
