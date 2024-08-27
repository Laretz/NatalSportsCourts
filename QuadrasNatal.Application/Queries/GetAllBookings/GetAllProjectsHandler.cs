using MediatR;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Core.Repositories;

namespace QuadrasNatal.Application.Queries.GetAllBookings
{
    public class GetAllBookingsHandler : IRequestHandler<GetAllBookingsQuery, ResultViewModel<List<BookingViewModel>>>
    {
     
        private readonly IBookingRepository _repository;
        public GetAllBookingsHandler(IBookingRepository repository)
        {
            _repository = repository;
        }
    public async Task<ResultViewModel<List<BookingViewModel>>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
    {
            var bookings = await _repository.GetAll();

            var model = bookings.Select(BookingViewModel.FromEntity).ToList();
            
            return ResultViewModel<List<BookingViewModel>>.Sucess(model);
        }
    }
}