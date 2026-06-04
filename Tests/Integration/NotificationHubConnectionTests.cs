using Microsoft.AspNetCore.SignalR;
using Moq;
using Notification.Application.Interfaces;
using Notification.Infrastructure.Hubs;

namespace Notification.Tests.Integration
{
    public class NotificationHubConnectionTests
    {
        private readonly Mock<IHubCallerClients<INotificationHub>> _clientsMock = new();
        private readonly Mock<IGroupManager> _groupsMock = new();
        private readonly Mock<HubCallerContext> _contextMock = new();
        private readonly NotificationHub _hub;

        public NotificationHubConnectionTests()
        {
            _hub = new NotificationHub
            {
                Clients = _clientsMock.Object,
                Groups = _groupsMock.Object,
                Context = _contextMock.Object
            };
        }

        [Fact]
        public async Task JoinRecipientGroup_AddsConnectionToGroup()
        {
            var connectionId = Guid.NewGuid().ToString();
            var recipientId = Guid.NewGuid().ToString();

            _contextMock.Setup(c => c.ConnectionId).Returns(connectionId);
            _groupsMock
                .Setup(g => g.AddToGroupAsync(connectionId, recipientId, default))
                .Returns(Task.CompletedTask);

            await _hub.JoinRecipientGroup(recipientId);

            _groupsMock.Verify(
                g => g.AddToGroupAsync(connectionId, recipientId, default),
                Times.Once);
        }

        [Fact]
        public async Task LeaveRecipientGroup_RemovesConnectionFromGroup()
        {
            var connectionId = Guid.NewGuid().ToString();
            var recipientId = Guid.NewGuid().ToString();

            _contextMock.Setup(c => c.ConnectionId).Returns(connectionId);
            _groupsMock
                .Setup(g => g.RemoveFromGroupAsync(connectionId, recipientId, default))
                .Returns(Task.CompletedTask);

            await _hub.LeaveRecipientGroup(recipientId);

            _groupsMock.Verify(
                g => g.RemoveFromGroupAsync(connectionId, recipientId, default),
                Times.Once);
        }
    }
}
