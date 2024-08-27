using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Application.Notifications;
using QuadrasNatal.Core.Repositories;

namespace QuadrasNatal.Application.Commands.InsertBooking
{
    public class InsertBookingHandler : IRequestHandler <InsertBookingCommand, ResultViewModel<int>>
    {
        private readonly IMediator _mediator;
        private readonly IBookingRepository _repository;
        public InsertBookingHandler(IMediator mediator, IBookingRepository repository )
        {
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<ResultViewModel<int>> Handle(InsertBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = request.ToEntity();
            await _repository.Add(booking);

            var bookingCreated = new BookingCreatedNotification(booking.Id, booking.Description, booking.IdCourt );
            await _mediator.Publish(bookingCreated);

            return ResultViewModel<int>.Sucess(booking.Id);
        }

    }
}

