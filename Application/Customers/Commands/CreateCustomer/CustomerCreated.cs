using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Customers.Commands.CreateCustomer;


public class CustomerCreated : INotification
{
    public string CustomerId { get; set; }

    public class Handler : INotificationHandler<CustomerCreated>
    {
        private readonly INotificationService _notificationService;

        public Handler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Handle(CustomerCreated notification, CancellationToken cancellationToken)
        {
            var message = new MessageDto
            {
                From = "system@domain.com",
                To = "admin@domain.com",
                Subject = "New Customer Created",
                Body = $"A new customer with ID {notification.CustomerId} has been created."
            };
            
            await _notificationService.SendAsync(new MessageDto());
        }
    }
}