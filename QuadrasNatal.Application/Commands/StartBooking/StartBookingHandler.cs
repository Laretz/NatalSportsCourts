using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Infrastructure.Persistence;

namespace QuadrasNatal.Application.Commands.StartBooking
{
    public class StartBookingHandler : IRequestHandler<StartBookingCommand, ResultViewModel>
    {
        private readonly QuadrasNatalDbContext _contextDb;
        public StartBookingHandler(QuadrasNatalDbContext contextDb )
        {
            _contextDb = contextDb;
        }
        public async Task<ResultViewModel> Handle(StartBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _contextDb.Bookings.SingleOrDefaultAsync(b=> b.Id == request.Id);
                if (booking == null )
            {
                return ResultViewModel.Error("Agendamento nao encontrado");
            }

            booking.Start();
            _contextDb.Bookings.Update(booking);
            await _contextDb.SaveChangesAsync();

            return ResultViewModel.Sucess();
        }
    }
}