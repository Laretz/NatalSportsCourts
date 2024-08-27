using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using QuadrasNatal.Application.Models;

namespace QuadrasNatal.Application.Commands.DeleteBooking
{
    public class DeleteBookingCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public DeleteBookingCommand(int id)
        {
            Id = id;
        }
    }
}