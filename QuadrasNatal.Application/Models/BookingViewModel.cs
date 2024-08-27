using QuadrasNatal.Core.Entities;

namespace QuadrasNatal.Application.Models
{
    public class BookingViewModel
    { public BookingViewModel(int id, string description, string sport, int idCourt, string courtName, string clientName, string status, List<Comment> comments)
        {
            Id = id;
            Description = description;
            Sport = sport;
            IdCourt = idCourt;
            CourtName = courtName;
            ClientName = clientName;
            Status = status;
            Comments = comments.Select(c => c.Content).ToList();
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public string Sport { get; private set; }
        public int IdCourt { get; private set; }
        public string CourtName { get; private set; }
        public string ClientName { get; private set; }
        public string Status { get; private set; }
        public List<string> Comments { get; private set; }

        public static BookingViewModel FromEntity(Booking entity) 
            =>  new (entity.Id, entity.Description, entity.Sport, 
            entity.IdCourt, entity.Court.Name, entity.User.FullName, 
            entity.Status.ToString(), entity.Comments);
    }
}