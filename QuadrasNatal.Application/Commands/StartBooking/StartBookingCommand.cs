using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using QuadrasNatal.Application.Models;

namespace QuadrasNatal.Application.Commands.StartBooking
{
    public class StartBookingCommand : IRequest<ResultViewModel>
    {
        public StartBookingCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}