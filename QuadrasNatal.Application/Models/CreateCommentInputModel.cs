using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadrasNatal.Application.Models
{
    public class CreateCommentInputModel
    {
        public string? Content { get; set; }
        public int IdCourt { get; set; }
        public int IdUser { get; set; }
        public int IdBooking { get;  set; } 
    }
}