using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuadrasNatal.API.Enums;

namespace QuadrasNatal.API.Entities
{
    public class Reserva : EntidadeBase
    {
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public string? Sport { get; private set; }
        public string? List<CourtComments> Comments { get; private set; }
        public int IdUser { get; private set; }
        public User Client { get; private set; }
        public int IdCourt { get; private set; }
        public SchedulingStatusEnum Status { get; private set; }
        

    }
}