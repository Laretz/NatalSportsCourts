using QuadrasNatal.Core.Enums;

namespace QuadrasNatal.Core.Entities
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

            Status = BookingStatusEnum.Created;
            Comments = [];
        }

        public string Description { get; private set; }
        public string Sport { get; private set; }
        public Court Court  { get; private set; }
        public User User { get; private set; }
        public int IdUser { get; private set; }
        public int IdCourt { get; private set; }
         public BookingStatusEnum Status { get; private set; }
        public DateTime? StartDateTime { get; private set; }
        public DateTime? EndDateTime { get; private set; }

        public List<Comments> Comments { get; private set; }
        
        public void Cancel()
        {
            if (Status == BookingStatusEnum.InProgress)
            {
                Status = BookingStatusEnum.Cancelled;
            }
        }

        public void Start()
        {
            if (Status == BookingStatusEnum.Created)
            {
                Status = BookingStatusEnum.InProgress;
                StartDateTime = DateTime.Now;
            }
        }
        public void Update(string description, string name)
        {
            Description = description;
            Sport = name;
        }

        public void Finish()
        {
            Status = BookingStatusEnum.Completed;
            EndDateTime = DateTime.Now;
        }

    }
}
