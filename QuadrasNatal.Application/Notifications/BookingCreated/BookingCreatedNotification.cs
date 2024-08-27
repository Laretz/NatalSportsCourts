using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace QuadrasNatal.Application.Notifications
{
    public class BookingCreatedNotification : INotification
    {
        public BookingCreatedNotification(int id, string? description, int idCourt)
        {
            Id = id;
            Description = description;
            IdCourt = idCourt;

        }

        public int Id { get; private set; }
        public int IdCourt { get; private set; }
        public string? Description { get; private set; }
    }
}