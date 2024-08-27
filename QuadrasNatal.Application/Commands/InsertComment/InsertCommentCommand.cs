using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using QuadrasNatal.Application.Models;

namespace QuadrasNatal.Application.Commands.InsertComment
{
    public class InsertCommentCommand : IRequest<ResultViewModel>
    {
        
        public string? Content { get; set; }
        public int IdCourt { get; set; }
        public int IdUser { get; set; }
        public int IdBooking { get;  set; } 
    }
}