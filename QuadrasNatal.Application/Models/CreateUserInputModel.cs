using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadrasNatal.Application.Models

{
    public class CreateUserInputModel
    {
        public string FullName { get;  set; }
        public string Email { get;  set; }
        public DateTime BithDate { get;  set; }
    }
}