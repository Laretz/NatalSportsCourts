using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Application.Notifications;
using QuadrasNatal.Infrastructure.Persistence;

namespace QuadrasNatal.Application.Commands.InsertBooking
{
    public class InsertBookingHandler : IRequestHandler <InsertBookingCommand, ResultViewModel<int>>
    {
        private readonly QuadrasNatalDbContext _contextDb;
        private readonly IMediator _mediator;
        public InsertBookingHandler(QuadrasNatalDbContext contextDb, IMediator mediator )
        {
            _contextDb = contextDb;
            _mediator = mediator;
        }
        public async Task<ResultViewModel<int>> Handle(InsertBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = request.ToEntity();

            await _contextDb.Bookings.AddAsync(booking);
            await _contextDb.SaveChangesAsync();

            var bookingCreated = new BookingCreatedNotification(booking.Id, booking.Description, booking.IdCourt );

            await _mediator.Publish(bookingCreated);

            return ResultViewModel<int>.Sucess(booking.Id);
        }

    }
}

