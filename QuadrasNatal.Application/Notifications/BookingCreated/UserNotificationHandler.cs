using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace QuadrasNatal.Application.Notifications.BookingCreated
{
    public class UserNotificationHandler : INotificationHandler<BookingCreatedNotification>
    {
        public Task Handle(BookingCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Notificando os usuários sobre novo Agendamento");

            return Task.CompletedTask;
        }
    }
}