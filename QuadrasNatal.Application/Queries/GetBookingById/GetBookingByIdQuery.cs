using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using QuadrasNatal.Application.Models;

namespace QuadrasNatal.Application.Queries.GetBookingById
{
    public class GetBookingByIdQuery : IRequest< ResultViewModel<BookingViewModel>>
    {
        public GetBookingByIdQuery(int id)
        {
            Id = id;
        }

        public int Id {get; set;}
    }
}