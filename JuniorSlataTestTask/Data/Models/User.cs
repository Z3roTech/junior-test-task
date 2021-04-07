using JuniorSlataTestTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorSlataTestTask
{
    internal class User
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
    }
}