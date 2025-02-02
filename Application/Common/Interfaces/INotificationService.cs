using Domain.Entities;

namespace Application.Common.Interfaces;

public interface INotificationService
{
    Task SendAsync(MessageDto message);
}