using FluentAssertions;
using Moq;
using Pulse.Contacts.Application.Queries.GetAllContacts;
using Pulse.Contacts.Application.Queries.GetContactById;
using Pulse.Contacts.Domain.Entities;
using Pulse.Contacts.Domain.Repositories;
using Pulse.Contacts.Domain.ValueObjects;
using Xunit;

namespace Pulse.Contacts.Tests;

public class GetContactByIDHandlerTests
{
    [Fact]
    public async Task Handle_ReturnContactByIDFromRepository()
    {
        // Arrange
        var mockRepo = new Mock<IContactRepository>();
        var contact = new Contact("Test User", Email.Create("test@email.com"), "0777777");
        var id = Guid.NewGuid();
        mockRepo.Setup(r => r.GetById(id)).ReturnsAsync(contact);
        var query = new GetContactByIdQuery(id);
        var handler = new GetContactByIdHandler(mockRepo.Object);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Name.Should().Be("Test User");
    }
}
