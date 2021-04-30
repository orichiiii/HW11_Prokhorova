using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Task1
{
    public class UserService
    {
        private static readonly Dictionary<string, string> _users = new Dictionary<string, string> { { "admin", "admin" }, { "system", "system" } };
        private static bool _isLogin;

        public void ChooseAction()
        {
            WriteLine("The company welcomes you!Please choose the action:\n(R) Registration, (L) Login, (LG) Logout.");
            var userOperation = ReadLine();

            switch (userOperation?.ToLower())
            {
                case "r": Registration(); break;
                case "l": Login(); break;
                case "lg": Logout(); break;
                default: throw new ArgumentException($"Invalid operation {userOperation}.");
            }
        }

        public void Login()
        {
            if (!_isLogin)
            {
                WriteLine("Please, enter your login:");
                var login = ReadLine();
                if (!ValidateLogin(ref login))
                    return;

                WriteLine("Please, enter the password.");
                var password = ReadLine();
                if (!ValidatePassword(login, password))
                    return;

                if (IsUserAdmin(login, password))
                {
                    WriteLine($"You have been successfully logged in the system as admin with login {login}.");
                    AdminFunctions();
                }
                else
                    WriteLine($"You have been successfully logged in the system as user with login {login}.");
                _isLogin = true;
            }
            else
                WriteLine("You are logged in the system.");
        }

        public bool ValidateLogin(ref string login)
        {
            while (!IsLoginExist(login))
            {
                WriteLine("Do you want try again? Y/N");
                if (ReadLine().ToLower() == "y")
                {
                    WriteLine("Please, enter your login again:");
                    login = ReadLine();
                }
                else
                    return false;
            }

            return true;
        }

        public bool IsLoginExist(string login)
        {
            var result = _users.Keys.Any(key => key.Equals(login));

            if (!result)
                WriteLine($"User with login {login} does not exist in the system.");

            return result;
        }

        public bool ValidatePassword(string login, string password)
        {
            while (!IsPasswordCorrect(login, password))
            {
                WriteLine("Do you want try again? Y/N");
                if (ReadLine().ToLower() == "y")
                {
                    WriteLine("Please, enter your password again:");
                    password = ReadLine();
                }
                else
                    return false;
            }

            return true;
        }

        public bool IsPasswordCorrect(string login, string password)
        {
            var result = _users[login].Equals(password);

            if (!result)
                WriteLine("Password is incorrect.");

            return result;
        }

        public void Registration()
        {
            if (!_isLogin)
            {
                WriteLine("Please, enter the login:");
                var login = ReadLine();

                WriteLine("Please, enter the password:");
                var password = ReadLine();

                if (!_users.TryAdd(login, password))
                    WriteLine($"User with login {login} already exists.");
                else
                {
                    WriteLine($"You have been successfully registered in the system as user with login {login}.");
                    Login();
                }
            }
            else
                WriteLine("You are already logged in the system.");
        }

        public void Logout()
        {
            if (_isLogin)
            {
                WriteLine("You are successfully logout from the system.");
                _isLogin = false;
            }
            else
                WriteLine("You are not logged in the system.");
        }

        public bool IsUserAdmin(string login, string password)
        {
            if (login == "admin" & password == "admin")
            {
                return true;
            }
            return false;
        }

        public void AdminFunctions()
        {
            WriteLine("Please choose the action:\n (Ch) change the password of user, (D) delete user.");
            var adminOperation = ReadLine();

            switch (adminOperation?.ToLower())
            {
                case "ch": ChangePassword(); break;
                case "d": DeleteUser(); break;
                default: throw new ArgumentException($"Invalid operation {adminOperation}.");
            }
        }

        public void DeleteUser()
        {
            Write("Enter username: ");
            var name = ReadLine();

            var result = _users.Keys.Any(key => key.Equals(name));
            if (result)
                _users.Remove(name);
            else
                WriteLine($"User with login {name} does not exist in the system.");
        }

        public void ChangePassword()
        {
            Write("Enter username: ");
            var name = ReadLine();

            var result = _users.Keys.Any(key => key.Equals(name));
            if (result)
            {
                Write($"Enter new password for {name}");
                var newPassword = ReadLine();

                _users[name] = newPassword;
            }
        }
    }
}
