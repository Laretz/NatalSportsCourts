using MediatR;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Core.Repositories;


namespace QuadrasNatal.Application.Commands.DeleteBooking
{
    public class DeleteBookingHandler : IRequestHandler<DeleteBookingCommand, ResultViewModel>
    {
        private readonly IBookingRepository _repository;
        public DeleteBookingHandler(IBookingRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _repository.GetById(request.Id);

            if (booking == null )
            {
                return ResultViewModel.Error("Projeto nao encontrado");
            }

            booking.SetAsDeleted();
            await _repository.Update(booking);

            return ResultViewModel.Sucess();
        }
    }
}


