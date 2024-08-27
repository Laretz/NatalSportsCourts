using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using QuadrasNatal.Application.Models;

namespace QuadrasNatal.Application.Commands.UpdateBooking
{
    public class UpdateBookingCommand : IRequest<ResultViewModel>
    {
        
        public int IdBooking { get; set; }
        public string Description{ get; set; }
        public string Sport { get; set; }
        
    }
}