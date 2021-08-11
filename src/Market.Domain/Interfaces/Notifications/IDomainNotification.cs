using System.Collections.Generic;
using Market.Domain.Notifications;

namespace Market.Domain.Interfaces.Notifications
{
    public interface IDomainNotification
    {
        IReadOnlyCollection<NotificationMessage> Notifications { get; }
        bool HasNotifications { get; }
        void AddNotification(string key, string message);
    }
}
