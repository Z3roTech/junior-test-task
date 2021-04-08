using JuniorSlataTestTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace JuniorSlataTestTask
{
    public class User
    {
        public int id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Permissions Permission { get; set; }
    }
}