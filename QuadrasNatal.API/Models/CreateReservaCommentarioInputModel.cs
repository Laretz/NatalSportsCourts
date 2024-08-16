using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadrasNatal.API.Models
{
    public class CreateReservaCommentarioInputModel
    {
        public string Conteudo { get; set; }
        public int IdReserva { get; set; }
        public int IdUsuario { get; set; }
    }
}