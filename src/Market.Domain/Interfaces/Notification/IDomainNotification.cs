using System.Collections.Generic;
using Market.Domain.Notification;

namespace Market.Domain.Interfaces.Notification
{
    public interface IDomainNotification
    {
        IReadOnlyCollection<NotificationMessage> Notifications { get; }
        bool HasNotifications { get; }
        void AddNotification(string key, string message);
    }
}