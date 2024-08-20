using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadrasNatal.API.Entities
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

            Reservas = [];
            Comments = [];
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }
        public DateTime BithDate { get; private set; }

        public List<Booking> Reservas { get; private set; }
        public List<CourtComments> Comments { get; private set; }
    }
}