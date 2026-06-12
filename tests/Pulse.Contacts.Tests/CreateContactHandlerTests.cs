using Moq;
using Pulse.Contacts.Application.Commands.CreateContact;
using Pulse.Contacts.Domain.Entities;
using Pulse.Contacts.Domain.Repositories;
using Xunit;

namespace Pulse.Contacts.Tests;

public class CreateContactHandlerTests
{
    [Fact]
    public async Task Handle_WithValidCommand_AddsContactToRepository()
    {
        var mockRepo = new Mock<IContactRepository>();
        var command = new CreateContactCommand("Test User", "test@email.com", "0777777");
        var handler = new CreateContactHandler(mockRepo.Object);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        mockRepo.Verify(r => r.Add(It.IsAny<Contact>()), Times.Once);
    }
}
