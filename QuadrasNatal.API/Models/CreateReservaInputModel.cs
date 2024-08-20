using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuadrasNatal.API.Entities;

namespace QuadrasNatal.API.Models
{
    public class CreateReservaInputModel
    {
        public string Description { get; set; }
        public string Sport { get; set; }
        public int IdUser { get; set; }
        public int IdCourt { get; set; }


        public Booking ToEntity()
            => new (Description, Sport, IdUser, IdCourt);
        
    }
}


 