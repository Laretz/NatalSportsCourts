using MediatR;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Core.Repositories;

namespace QuadrasNatal.Application.Queries.GetBookingById
{
    public class GetBookingByIdHandler : IRequestHandler<GetBookingByIdQuery, ResultViewModel<BookingViewModel>>
    {
        private readonly IBookingRepository _repository;
        public GetBookingByIdHandler(IBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<BookingViewModel>> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
             var bookings = await _repository.GetDetailsById(request.Id);

            if (bookings is null)
            {
                return ResultViewModel<BookingViewModel>.Error("Projeto nao existente.");
            }

            var model = BookingViewModel.FromEntity(bookings);

            return ResultViewModel<BookingViewModel>.Sucess(model);
        }
    }
}