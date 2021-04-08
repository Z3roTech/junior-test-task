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

        public string Login { get => login; set => login = value; }

        public string Password { get => password; set => password = value; }

        public string Name { get => name; set => name = value; }

        public string Surname { get => surname; set => surname = value; }

        public Permissions Permission { get => permission; set => permission = value; }

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
    }
}