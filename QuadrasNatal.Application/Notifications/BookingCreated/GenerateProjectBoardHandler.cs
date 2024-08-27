using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace QuadrasNatal.Application.Notifications.BookingCreated
{
    public class GenerateProjectBoardHandler : INotificationHandler<BookingCreatedNotification>
    {
        public Task Handle(BookingCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Criando painel para o projeto {notification.Description}");
            return Task.CompletedTask;
        }
    }
}