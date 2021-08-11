using System.Collections.Generic;
using System.Threading.Tasks;
using Market.API.Filters;
using Market.Domain.Enums;
using Market.Domain.Interfaces.Notifications;
using Market.Domain.Notifications;
using Market.Unit.Tests.Filters.Setup;
using Microsoft.AspNetCore.Mvc.Filters;
using Moq;
using Xunit;

namespace Market.Unit.Tests.Filters
{
    public class DomainNotificationFilterTest
    {
        private readonly Mock<IDomainNotification> _domainNotificationMock;
        private readonly Mock<IFilterMetadata> _filterMetadataMock;

        public DomainNotificationFilterTest()
        {
            _domainNotificationMock = new Mock<IDomainNotification>();
            _filterMetadataMock = new Mock<IFilterMetadata>();
        }

        [Fact(DisplayName = "Execute domain notification filter when has notification domain")]
        public async Task ExecuteDomainNotificationFilterWhenHasNotificationDomainTest()
        {
            _domainNotificationMock.Setup(setup => setup.HasNotifications)
                .Returns(true);

            _domainNotificationMock.Setup(setup => setup.Notifications)
                .Returns(new List<NotificationMessage>
                {
                    new(DomainError.ValidationRequest.ToString(), "Error test")
                });

            var context = FilterSetup.CreateResultExecutingContext(_filterMetadataMock.Object);
            var next = new ResultExecutionDelegate(() =>
                Task.FromResult(FilterSetup.CreateResultExecutedContext(context)));

            var filter = new DomainNotificationFilter(_domainNotificationMock.Object);

            await filter.OnResultExecutionAsync(context, next);

            Assert.False(context.Cancel);
        }

        [Fact(DisplayName = "Execute domain notification filter when no has notification domain")]
        public async Task ExecuteDomainNotificationFilterWhenNoHasNotificationDomainTest()
        {
            _domainNotificationMock.Setup(setup => setup.HasNotifications)
                .Returns(false);

            var context = FilterSetup.CreateResultExecutingContext(_filterMetadataMock.Object);
            var next = new ResultExecutionDelegate(() =>
                Task.FromResult(FilterSetup.CreateResultExecutedContext(context)));

            var filter = new DomainNotificationFilter(_domainNotificationMock.Object);

            await filter.OnResultExecutionAsync(context, next);

            Assert.False(context.Cancel);
        }
    }
}