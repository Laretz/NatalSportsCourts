using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadrasNatal.API.Models
{
    public class CreateReservaInputModel
    {
        
        public int IdUsuario { get; set; }
        public int IdQuadra { get; set; }
        public string Esporte { get; set; }
    }
}