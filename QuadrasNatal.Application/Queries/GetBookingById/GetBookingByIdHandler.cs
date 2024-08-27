using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Infrastructure.Persistence;

namespace QuadrasNatal.Application.Queries.GetBookingById
{
    public class GetBookingByIdHandler : IRequestHandler<GetBookingByIdQuery, ResultViewModel<BookingViewModel>>
    {
        private readonly QuadrasNatalDbContext _contextDb;
        public GetBookingByIdHandler(QuadrasNatalDbContext contextDb )
            {
                 _contextDb = contextDb;
            }

        public async Task<ResultViewModel<BookingViewModel>> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
             var bookings = await _contextDb.Bookings
                .Include(b => b.User)
                .Include(b => b.Court)
                .Include(b => b.Comments)
                .SingleOrDefaultAsync(b=> b.Id == request.Id );

            if (bookings is null)
            {
                return ResultViewModel<BookingViewModel>.Error("Projeto nao existente.");
            }

            var model = BookingViewModel.FromEntity(bookings);

            return ResultViewModel<BookingViewModel>.Sucess(model);
        }
    }
}