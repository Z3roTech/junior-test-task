using JuniorSlataTestTask.Data.Models;
using System;
using System.Text.RegularExpressions;

namespace JuniorSlataTestTask
{
    public class User
    {
        public int id { get; set; }
        private string login, password, name, surname;
        private Permissions permission;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public Permissions Permission
        {
            get { return permission; }
            set { permission = value; }
        }

        public User()
        {
        }

        public User(string login, string password, string name, string surname)
        {
            Login = login;
            Password = password;
            Name = name;
            Surname = surname;
            Permission = Permissions.User;
        }

        public void ChangePermissions(Permissions newPerm)
        {
            Permission = newPerm;
        }

        public void ChangePassword(string newPassword)
        {
            if (String.IsNullOrEmpty(newPassword)) return;
            if (new Regex("[^a-zA-Z0-9]").IsMatch(newPassword)) return;
            if (newPassword.Length < 8) return;
            Password = newPassword;
        }
    }
}