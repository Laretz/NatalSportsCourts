using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadrasNatal.API.Models
{
    public class UpdateQuadraInputModel
    {
        public string Title {get; set;}
        public string Description { get; set; }
        public int IdUsuario { get; set; }
        public int IdReserva { get; set; }
    }
}