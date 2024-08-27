using MediatR;
using Microsoft.EntityFrameworkCore;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Infrastructure.Persistence;

namespace QuadrasNatal.Application.Commands.DeleteBooking
{
    public class DeleteBookingHandler : IRequestHandler<DeleteBookingCommand, ResultViewModel>
    {
        private readonly QuadrasNatalDbContext _contextDb;
        public DeleteBookingHandler(QuadrasNatalDbContext contextDb )
        {
            _contextDb = contextDb;
        }
        public async Task<ResultViewModel> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _contextDb.Bookings.SingleOrDefaultAsync(b=> b.Id == request.Id);
            if (booking == null )
            {
                return ResultViewModel.Error("Projeto nao encontrado");
            }

            booking.SetAsDeleted();
            _contextDb.Bookings.Update(booking);
            await _contextDb.SaveChangesAsync();

            return ResultViewModel.Sucess();
        }
    }
}