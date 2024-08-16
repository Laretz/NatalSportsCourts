using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuadrasNatal.API.Enums;

namespace QuadrasNatal.API.Entities
{
    public class Quadra : EntidadeBase
    {
        public int MyProperty { get; private set; }
        public bool Cobertura { get; private set; }
        public QuadraTamanhoEnum Tamanho { get; private set; }
    }
}