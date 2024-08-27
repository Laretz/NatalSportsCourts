using MediatR;
using Microsoft.EntityFrameworkCore;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Infrastructure.Persistence;

namespace QuadrasNatal.Application.Commands.FinishBooking
{
    public class FinishBookingHandler : IRequestHandler<FinishBookingCommand, ResultViewModel>
    {
        private readonly QuadrasNatalDbContext _contextDb;
        public FinishBookingHandler(QuadrasNatalDbContext contextDb )
        {
            _contextDb = contextDb;
        }
        public async Task<ResultViewModel> Handle(FinishBookingCommand request, CancellationToken cancellationToken)
        {
               var booking = await _contextDb.Bookings.SingleOrDefaultAsync(b=> b.Id == request.Id);
            if (booking == null )
            {
                return ResultViewModel.Error("Agendamento nao encontrado");
            }

            booking.Finish();
            _contextDb.Bookings.Update(booking);
            await _contextDb.SaveChangesAsync();
            
            return ResultViewModel.Sucess();
        }
    }
}