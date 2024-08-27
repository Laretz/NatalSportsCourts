using MediatR;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Core.Repositories;

namespace QuadrasNatal.Application.Commands.UpdateBooking
{
    public class UpdateBookingHandler : IRequestHandler<UpdateBookingCommand, ResultViewModel>
    {
        private readonly IBookingRepository _repository;
        public UpdateBookingHandler(IBookingRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _repository.GetById(request.IdBooking);

            if (booking == null )
            {
                return ResultViewModel.Error("Projeto nao existe.");
            }

            booking.Update(request.Description, request.Sport);

           
            await _repository.Update(booking);

            return ResultViewModel.Sucess();
        }
    }
}