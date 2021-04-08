using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace JuniorSlataTestTask.Data.Models
{
    public class Jobseaker
    {
        public int id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string TimeToTask { get; set; }
        public int TaskId { get; set; }

        private Task task;

        public Task Task
        {
            get
            {
                if (task != null) return task;
                using (AppContext db = new AppContext())
                {
                    if (task == null)
                        task = db.Tasks.Where(t => t.id == TaskId).FirstOrDefault();
                    return task;
                };
            }
            set
            {
                task = value;
            }
        }

        public int? ManagerId { get; set; }
        private User manager;

        [NotMapped]
        public User Manager
        {
            get
            {
                if (manager != null) return manager;
                using (AppContext db = new AppContext())
                {
                    if (manager == null)
                        Manager = db.Users.Where(t => t.id == ManagerId).FirstOrDefault();
                    return manager;
                };
            }
            set
            {
                manager = value;
            }
        }

        public int? MentorId { get; set; }
        private User mentor;

        [NotMapped]
        public User Mentor
        {
            get
            {
                if (mentor != null) return mentor;
                using (AppContext db = new AppContext())
                {
                    if (mentor == null)
                        mentor = db.Users.Where(t => t.id == MentorId).FirstOrDefault();
                    return mentor;
                };
            }
            set
            {
                mentor = value;
            }
        }
    }
}