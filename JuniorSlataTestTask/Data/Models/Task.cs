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
        private DateTime dateTimeStart, dateTimeEnd;
        private bool completeness;
        private int mentorId;
        private int jobseakerId;
        private string mentorSurname;

        public DateTime DateTimeStart { get => dateTimeStart; set => dateTimeStart = value; }
        public DateTime DateTimeEnd { get => dateTimeEnd; set => dateTimeEnd = value; }
        public bool Completeness { get => completeness; set => completeness = value; }
        public int MentorId { get => mentorId; set => mentorId = value; }
        public int JobseakerId { get => jobseakerId; set => jobseakerId = value; }
        public string MentorSurname { get => mentorSurname; set => mentorSurname = value; }

        public Task()
        {
        }

        public Task(DateTime startTime)
        {
            DateTimeStart = startTime;
            Completeness = false;
        }

        public void CompleteTask(DateTime endTime)
        {
            MentorId = (int)App.Current.Properties["AuthUserID"];
            using (AppContext db = new AppContext())
            {
                MentorSurname = db.Users.Where(m => m.id == MentorId).FirstOrDefault().Surname;
            }
            DateTimeEnd = endTime;
            Completeness = true;
        }
    }
}