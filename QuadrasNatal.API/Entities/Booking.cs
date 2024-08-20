using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuadrasNatal.API.Enums;

namespace QuadrasNatal.API.Entities
{
    public class Booking : BaseEntity
    {
        public Booking(string description, string sport, int idUser, int idCourt)
         : base()
        {
            Description = description;
            Sport = sport;
            IdUser = idUser;
            IdCourt = idCourt;

            Status = SchedulingStatusEnum.Created;
            Comments = [];
        }

        public string Description { get; private set; }
        public string Sport { get; private set; }
        public Court Court  { get; private set; }
        public User User { get; private set; }
        public int IdUser { get; private set; }
        public int IdCourt { get; private set; }
         public SchedulingStatusEnum Status { get; private set; }
        public DateTime? StartDateTime { get; private set; }
        public DateTime? EndDateTime { get; private set; }

        public List<CourtComments> Comments { get; private set; }
        
        public void Cancel()
        {
            if (Status == SchedulingStatusEnum.InProgress)
            {
                Status = SchedulingStatusEnum.Cancelled;
            }
        }

        public void Start()
        {
            if (Status == SchedulingStatusEnum.Created)
            {
                Status = SchedulingStatusEnum.InProgress;
                StartDateTime = DateTime.Now;
            }
        }
        public void Update(string description, string sport)
        {
            Description = description;
            Sport = sport;
        }

    }
}