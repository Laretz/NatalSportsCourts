using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuadrasNatal.Application.Models;
using QuadrasNatal.Infrastructure.Persistence;

namespace QuadrasNatal.Application.Queries.GetAllBookings
{
    public class GetAllBookingsHandler : IRequestHandler<GetAllBookingsQuery, ResultViewModel<List<BookingViewModel>>>
    {
     
            private readonly QuadrasNatalDbContext _contextDb;
            public GetAllBookingsHandler(QuadrasNatalDbContext contextDb )
            {
                 _contextDb = contextDb;
            }
    public async Task<ResultViewModel<List<BookingViewModel>>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
    {
            var bookings = await _contextDb.Bookings
            .Include(b => b.User)
            .Include(b => b.Court)
            .Include(b => b.Comments)
            .Where(b => !b.IsDeleted )
            .ToListAsync();

            var model = bookings.Select(BookingViewModel.FromEntity).ToList();
            
            return ResultViewModel<List<BookingViewModel>>.Sucess(model);
        }
    }
}