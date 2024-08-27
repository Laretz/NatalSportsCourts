using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadrasNatal.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime bithDate)
         : base()
        {
            FullName = fullName;
            Email = email;
            BithDate = bithDate;
            Active = true;

            Bookings = [];
            Comments = [];
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }
        public DateTime BithDate { get; private set; }

        public List<Booking> Bookings { get; private set; }
        public List<Comments> Comments { get; private set; }
    }
}