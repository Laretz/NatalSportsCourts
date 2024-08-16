using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadrasNatal.API.Models
{
    public class CreateQuadraInputModel
    {
        public string Nome {get; set;}
        public string Descricao { get; set; }
        public string TipoSuperficie { get; set; }
        public bool Cobertura { get;  set; }
        public bool Iluminação { get;  set; }
        public List<string> Esportes { get; private set; } = new List<string>();

    }
}