using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuadrasNatal.Core.Enums;

namespace QuadrasNatal.Core.Entities
{
    public class Court : BaseEntity
    {
        public Court(string name, string description, string surfaceType, bool hasCover, bool lighting, bool available) 
         : base()
        {
            Name = name;
            Description = description;
            SurfaceType = surfaceType;
            HasCover = hasCover;
            Lighting = lighting;
            Available = available;

            Comments = [];
            Reservations = [];
        }

        public string Name  { get; private set; }
        public string Description { get; private set; }
        public string SurfaceType { get; private set; }
        public bool HasCover { get; private set; }
        public bool Lighting { get; private set; }
        public bool Available { get; private set; }
        public List<Booking> Reservations { get; private set; }
        public List<Comment> Comments { get; set; }
        public CourtSizeEnum Size { get; private set; }
        public void Update(string name, string description, string surfaceType)
        {
            Name = name;
            Description = description;
            SurfaceType = surfaceType;
        }
    }
}