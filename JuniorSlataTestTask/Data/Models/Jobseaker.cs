using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuniorSlataTestTask.Data.Models
{
    public class Jobseaker
    {
        public int id { get; set; }
        private string fullName, phoneNumber, position;
        private int taskId, hrManagerId;
        private DateTime timeToTask;

        public string FullName { get => fullName; set => fullName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Position { get => position; set => position = value; }
        public int TaskId { get => taskId; set => taskId = value; }
        public int HRManagerId { get => hrManagerId; set => hrManagerId = value; }
        public DateTime TimeToTask { get => timeToTask; set => timeToTask = value; }

        public Jobseaker()
        {
        }

        public Jobseaker(string name, string phone, string pos, DateTime taskTime)
        {
            FullName = name;
            PhoneNumber = phone;
            Position = pos;
            TimeToTask = taskTime;
            HRManagerId = (int)App.Current.Properties["AuthUserID"];
            using (AppContext db = new AppContext())
            {
                Task task = new Task(DateTime.UtcNow);
                db.Tasks.Add(task);
                db.SaveChanges();

                TaskId = db.Tasks.Where(t => t.JobseakerId == this.id).FirstOrDefault().id;
            }
        }
    }
}