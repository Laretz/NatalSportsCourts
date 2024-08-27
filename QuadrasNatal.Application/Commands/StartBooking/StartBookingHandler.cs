using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Core.Repositories;
using QuadrasNatal.Infrastructure.Persistence;

namespace QuadrasNatal.Application.Commands.StartBooking
{
    public class StartBookingHandler : IRequestHandler<StartBookingCommand, ResultViewModel>
    {
        private readonly IBookingRepository _repository;
        public StartBookingHandler(IBookingRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(StartBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _repository.GetById(request.Id);
                if (booking == null )
                {
                    return ResultViewModel.Error("Agendamento nao encontrado");
                }

            booking.Start();
            await _repository.Update(booking);

            return ResultViewModel.Sucess();
        }
    }
}