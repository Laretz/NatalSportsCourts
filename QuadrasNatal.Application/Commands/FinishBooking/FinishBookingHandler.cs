using MediatR;
using Microsoft.EntityFrameworkCore;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Core.Repositories;
using QuadrasNatal.Infrastructure.Persistence;

namespace QuadrasNatal.Application.Commands.FinishBooking
{
    public class FinishBookingHandler : IRequestHandler<FinishBookingCommand, ResultViewModel>
    {
        private readonly IBookingRepository _repository;
        public FinishBookingHandler(IBookingRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(FinishBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _repository.GetById(request.Id);
            if (booking == null )
            {
                return ResultViewModel.Error("Agendamento nao encontrado");
            }

            booking.Finish();
        
            await _repository.Update(booking);
            
            return ResultViewModel.Sucess();
        }
    }
}