using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace QuadrasNatal.API.Entities
{
    public abstract class EntidadeBase
    {
        public EntidadeBase()
        {
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        public void SetAsDeleted() => IsDeleted = true;
    }
}