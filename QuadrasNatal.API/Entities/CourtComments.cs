using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadrasNatal.API.Entities
{
    public class CourtComments : BaseEntity
    {
        public CourtComments(string content, int idCourt, int idUser)
         : base()
        {
            Content = content;
            IdCourt = idCourt;
            IdUser = idUser;
        }
        public string Content { get; private set; }
        public int IdCourt { get; private set; }
        public int IdUser { get; private set; }
        public Court Court { get; private set; }
        public User User { get; private set; }

    }
} 