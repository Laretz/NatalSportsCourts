namespace QuadrasNatal.Core.Entities
{
    public class Comment : BaseEntity
    {
        public Comment(string content, int idCourt, int idUser, int idBooking)
         : base()
        {
            Content = content;
            IdCourt = idCourt;
            IdUser = idUser;
            IdBooking = idBooking;
        }
        public string Content { get; private set; }
        public int IdCourt { get; private set; }
        public int IdUser { get; private set; }
        public int IdBooking { get; private set; } 

        public Court Court { get; private set; }
        public User User { get; private set; }
        public Booking Booking { get; private set; }
    }
}
