using System;

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
                Console.WriteLine("3. User Profile");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisterUser();
                        break;
                    case 2:
                        LoginUser();
                        break;
                    case 3:
                        UserProfile();
                        break;
                    case 4:
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
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

            bool isCorrectMail = false;

            while (!isCorrectMail)
            {
                Console.Write("Enter your email: ");
                register.Email = Console.ReadLine();

                if (register.Email.Contains("@") && register.Email.Contains(".com"))
                {
                    Console.WriteLine("Email is valid");
                    isCorrectMail = true;
                }
                else
                {
                    Console.WriteLine("Email is invalid, please try again.");
                }
            }

            bool isCorrectPass = false;
            while (!isCorrectPass)
            {
                Console.Write("Enter your password: ");
                register.Password = Console.ReadLine();

                if (register.Password.Length < 8)
                {
                    Console.WriteLine("Password must contain at least 8 characters");
                }
                else
                {
                    isCorrectPass = true;
                }
            }

            registeredUser = register;
            Console.WriteLine("Registration successful");
            isRegistered = true;
        }

        private static void LoginUser()
        {
            if (!isRegistered)
            {
                Console.WriteLine("No registered user. Please register first.");
                return;
            }

            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (registeredUser.Username == username && registeredUser.Password == password)
            {
                Console.WriteLine("Login successful");
            }
            else
            {
                Console.WriteLine("Login failed");
            }
        }

        private static void UserProfile()
        {
            if (!isRegistered)
            {
                Console.WriteLine("No registered user. Please register first.");
                return;
            }

            Console.WriteLine("Welcome To User Profile");
            Console.WriteLine("1. View Profile");
            Console.WriteLine("2. Update Profile");
            Console.WriteLine("3. Delete Profile");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ViewProfile();
                    break;
                case 2:
                    UpdateProfile();
                    break;
                case 3:
                    DeleteProfile();
                    break;
                case 4:
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        private static void ViewProfile()
        {
            Console.WriteLine("User Profile");
            Console.WriteLine("First Name: " + registeredUser.FirstName);
            Console.WriteLine("Last Name: " + registeredUser.LastName);
            Console.WriteLine("Username: " + registeredUser.Username);
            Console.WriteLine("Email: " + registeredUser.Email);
        }

        private static void UpdateProfile()
        {
            Console.WriteLine("Update Profile");
            Console.Write("Enter your first name: ");
            registeredUser.FirstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            registeredUser.LastName = Console.ReadLine();
            Console.Write("Enter your username: ");
            registeredUser.Username = Console.ReadLine();

            bool isCorrectMail = false;
            while (!isCorrectMail)
            {
                Console.Write("Enter your email: ");
                registeredUser.Email = Console.ReadLine();

                if (registeredUser.Email.Contains("@") && registeredUser.Email.Contains(".com"))
                {
                    Console.WriteLine("Email is valid");
                    isCorrectMail = true;
                }
                else
                {
                    Console.WriteLine("Email is invalid, please try again.");
                }
            }

            bool isCorrectPass = false;
            while (!isCorrectPass)
            {
                Console.Write("Enter your password: ");
                registeredUser.Password = Console.ReadLine();

                if (registeredUser.Password.Length < 8)
                {
                    Console.WriteLine("Password must contain at least 8 characters");
                }
                else
                {
                    isCorrectPass = true;
                }
            }

            Console.WriteLine("Profile updated successfully");
        }

        private static void DeleteProfile()
        {
            registeredUser = new Register();
            isRegistered = false;
            Console.WriteLine("Profile deleted successfully");
        }

        private static void Exit()
        {
            Console.WriteLine("Exiting the program.");
            Environment.Exit(0);
        }
    }
}
