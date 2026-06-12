using Moq;
using Pulse.Contacts.Application.Commands.DeleteContact;
using Pulse.Contacts.Domain.Repositories;
using Xunit;

namespace Pulse.Contacts.Tests;

public class DeleteContactHandlerTests
{
    [Fact]
    public async Task Handle_WithValidCommand_DeleteContactFromRepository()
    {
        var mockRepo = new Mock<IContactRepository>();
        var command = new DeleteContactCommand(Guid.NewGuid());
        var handler = new DeleteContactHandler(mockRepo.Object);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        mockRepo.Verify(r => r.Remove(command.ContactId), Times.Once);
    }
}
