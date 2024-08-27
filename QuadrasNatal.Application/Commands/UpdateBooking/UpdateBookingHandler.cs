using MediatR;
using Microsoft.EntityFrameworkCore;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Infrastructure.Persistence;

namespace QuadrasNatal.Application.Commands.UpdateBooking
{
    public class UpdateBookingHandler : IRequestHandler<UpdateBookingCommand, ResultViewModel>
    {
        private readonly QuadrasNatalDbContext _contextDb;
        public UpdateBookingHandler(QuadrasNatalDbContext contextDb )
        {
            _contextDb = contextDb;
        }
        public async Task<ResultViewModel> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
             var booking = await _contextDb.Bookings.SingleOrDefaultAsync(b=> b.Id == request.IdBooking);

            if (booking == null )
            {
                return ResultViewModel.Error("Projeto nao existe.");
            }

            booking.Update(request.Description, request.Sport);

            _contextDb.Bookings.Update(booking);
            await _contextDb.SaveChangesAsync();

            return ResultViewModel.Sucess();
        }
    }
}