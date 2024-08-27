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
    public class GetAllBookingsQuery : IRequest<ResultViewModel <List<BookingViewModel>>>
    {
        
    } 
}