
using QuadrasNatal.Core.Entities;

namespace QuadrasNatal.Application.Models
{
    public class CreateBookingInputModel
    {
        public string Description { get; set; }
        public string Sport { get; set; }
        public int IdUser { get; set; }
        public int IdCourt { get; set; }


        public Booking ToEntity()
            => new (Description, Sport, IdUser, IdCourt);
        
    }
}


 