using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuadrasNatal.Core.Entities;
namespace QuadrasNatal.Application.Models
{
    public class CreateQuadraInputModel
    {
        public string Nome {get; set;}
        public string Descricao { get; set; }
        public string TipoSuperficie { get; set; }
        public bool Cobertura { get;  set; }
        public bool Iluminação { get;  set; }
        public bool Disponivel { get; set; }
        public List<string> Esportes { get;  set;} 

        public Court ToEntity() 
            => new (Nome, Descricao, TipoSuperficie, Cobertura, Iluminação, Disponivel); 

    }
}