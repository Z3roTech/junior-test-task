using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuniorSlataTestTask.Data.Models
{
    public class Task
    {
        public int id { get; set; }

        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public bool Completeness { get; set; }

        public virtual Jobseaker Jobseaker { get; set; }
    }
}