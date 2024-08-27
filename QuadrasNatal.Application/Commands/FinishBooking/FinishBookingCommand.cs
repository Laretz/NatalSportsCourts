using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using QuadrasNatal.Application.Models;

namespace QuadrasNatal.Application.Commands.FinishBooking
{
    public class FinishBookingCommand :IRequest<ResultViewModel>
    {
        public FinishBookingCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}