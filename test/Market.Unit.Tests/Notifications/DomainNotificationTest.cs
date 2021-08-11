using Market.Domain.Enums;
using Market.Domain.Notifications;
using Xunit;

namespace Market.Unit.Tests.Notifications
{
    public class DomainNotificationTest
    {
        [Fact(DisplayName = "Insert domain notification message")]
        public void InsertDomainNotificationMessageTest()
        {
            var notification = new DomainNotification();

            notification.AddNotification(DomainError.ValidationRequest.ToString(), "Domain error");

            Assert.True(notification.HasNotifications);
            Assert.NotEmpty(notification.Notifications);
        }

        [Fact(DisplayName = "Not insert domain notification message")]
        public void NotInsertDomainNotificationMessageTest()
        {
            var notification = new DomainNotification();

            Assert.False(notification.HasNotifications);
            Assert.Empty(notification.Notifications);
        }
    }
}
