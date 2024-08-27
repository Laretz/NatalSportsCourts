using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadrasNatal.Application.Models

{
    public class UpdateQuadraInputModel
    {
        public string Name {get; set;}
        public string Description { get; set; }
        public string SurfaceType { get; set; }
        public int IdUsuario { get; set; }
        public int IdReserva { get; set; }
    }
}

