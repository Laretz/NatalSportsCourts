using MediatR;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Core.Entities;

namespace QuadrasNatal.Application.Commands.InsertBooking
{
    public class InsertBookingCommand : IRequest<ResultViewModel<int>>
    {
        public string Description { get; set; }
        public string Sport { get; set; }
        public int IdUser { get; set; }
        public int IdCourt { get; set; }


        public Booking ToEntity()
            => new (Description, Sport, IdUser, IdCourt);
    }
}