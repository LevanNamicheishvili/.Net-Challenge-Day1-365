using System;
using System.Security.Principal;

namespace StudentManagementSystem
{
    public class Register
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Register()
        {
            Id = 0;
            FirstName = "";
            LastName = "";
            Username = "";
            Email = "";
            Password = "";
        }
    }

    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Login()
        {
            Username = "";
            Password = "";
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Student(Register register)
        {
            Id = register.Id;
            FirstName = register.FirstName;
            LastName = register.LastName;
            Email = register.Email;
            Password = register.Password;
        }
    }

    class Program
    {
        private static Register registeredUser = new Register();
        private static bool isRegistered = false;

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        RegisterUser();
                        break;
                    case 2:
                        LoginUser();
                        break;
               
                    case 3:
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        public static void Clear()
        {
            Thread.Sleep(1000);
            Console.Clear();
        }

        private static void RegisterUser()
        {
            Register register = new Register();

            Console.Write("Enter your first name: ");
            register.FirstName = Console.ReadLine();

            Console.Write("Enter your last name: ");
            register.LastName = Console.ReadLine();

            Console.Write("Enter your username: ");
            register.Username = Console.ReadLine();

            while (true)
            {
                Console.Write("Enter your email: ");
                register.Email = Console.ReadLine();

                if (IsValidEmail(register.Email))
                {
                    Console.WriteLine("Email is valid");
                    break;
                }
                else
                {
                    Console.WriteLine("Email is invalid, please try again.");
                }
            }

            while (true)
            {
                Console.Write("Enter your password: ");
                register.Password = Console.ReadLine();

                if (register.Password.Length >= 8)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Password must contain at least 8 characters");
                }
            }

            registeredUser = register;
            Console.WriteLine("Registration successful");
            Clear();
            isRegistered = true;
        }

        private static void LoginUser()
        {
            if (!isRegistered)
            {
                Console.WriteLine("No registered user. Please register first.");
                Clear();
                return;
            }

            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (registeredUser.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                registeredUser.Password == password)
            {
                Console.WriteLine("Login successful");
                Clear();
                while (true)
                {
                    
                    Console.WriteLine("Welcome To User Profile");

                    Console.WriteLine("1. View Profile");
                    Console.WriteLine("2. Update Profile");
                    Console.WriteLine("3. Delete Profile");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choice: ");

                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("Invalid choice. Please enter a number.");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            Clear();
                            ViewProfile();
                            break;
                        case 2:
                            UpdateProfile();
                            break;
                        case 3:
                            DeleteProfile();
                            return;
                        case 4:
                            Clear();
                            return;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                
                }
            }
            else
            {
                Console.WriteLine("Login failed, try again !");
                Clear();
            }
        }


        private static void ViewProfile()
        {
            int columnWidth = Math.Max("First Name".Length, registeredUser.FirstName.Length);
            columnWidth = Math.Max(columnWidth, "Last Name".Length);
            columnWidth = Math.Max(columnWidth, registeredUser.LastName.Length);
            columnWidth = Math.Max(columnWidth, "Username".Length);
            columnWidth = Math.Max(columnWidth, registeredUser.Username.Length);
            columnWidth = Math.Max(columnWidth, "Email".Length);
            columnWidth = Math.Max(columnWidth, registeredUser.Email.Length);
            columnWidth += 2; 

       
            Console.WriteLine(new string('-', columnWidth * 2 + 3));
            Console.WriteLine("| {0,-" + columnWidth + "} | {1,-" + columnWidth + "} |", "Property", "Value");
            Console.WriteLine(new string('-', columnWidth * 2 + 3));

            Console.WriteLine("| {0,-" + columnWidth + "} | {1,-" + columnWidth + "} |", "First Name", registeredUser.FirstName);
            Console.WriteLine("| {0,-" + columnWidth + "} | {1,-" + columnWidth + "} |", "Last Name", registeredUser.LastName);
            Console.WriteLine("| {0,-" + columnWidth + "} | {1,-" + columnWidth + "} |", "Username", registeredUser.Username);
            Console.WriteLine("| {0,-" + columnWidth + "} | {1,-" + columnWidth + "} |", "Email", registeredUser.Email);

            Console.WriteLine(new string('-', columnWidth * 2 + 3));
        }



        private static void UpdateProfile()
        {
            Console.WriteLine("Update Profile");

            Register tempRegister = new Register();
            tempRegister.Id = registeredUser.Id;

            Console.Write("Enter your first name: ");
            tempRegister.FirstName = Console.ReadLine();

            Console.Write("Enter your last name: ");
            tempRegister.LastName = Console.ReadLine();

            Console.Write("Enter your username: ");
            tempRegister.Username = Console.ReadLine();

            while (true)
            {
                Console.Write("Enter your email: ");
                tempRegister.Email = Console.ReadLine();

                if (IsValidEmail(tempRegister.Email))
                {
                    Console.WriteLine("Email is valid");
                    break;
                }
                else
                {
                    Console.WriteLine("Email is invalid, please try again.");
                }
            }

            while (true)
            {
                Console.Write("Enter your password: ");
                tempRegister.Password = Console.ReadLine();

                if (tempRegister.Password.Length >= 8)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Password must contain at least 8 characters");
                }
            }

            registeredUser = tempRegister;
            Console.WriteLine("Profile updated successfully");
        }



        private static void DeleteProfile()
        {
            registeredUser = new Register();
            isRegistered = false;
            Console.WriteLine("Profile deleted successfully");
            
            Clear();

        }

        private static void Exit()
        {
            Console.WriteLine("Exiting the program.");
            Environment.Exit(0);

        }

        

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
