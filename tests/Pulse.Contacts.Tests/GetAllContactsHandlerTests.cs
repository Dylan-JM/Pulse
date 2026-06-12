using FluentAssertions;
using Moq;
using Pulse.Contacts.Application.Queries.GetAllContacts;
using Pulse.Contacts.Domain.Entities;
using Pulse.Contacts.Domain.Repositories;
using Pulse.Contacts.Domain.ValueObjects;
using Xunit;

namespace Pulse.Contacts.Tests;

public class GetAllContactsHandlerTests
{
    [Fact]
    public async Task Handle_ReturnsAllContactsFromRepository()
    {
        // Arrange
        var mockRepo = new Mock<IContactRepository>();
        var contacts = new List<Contact>
        {
            new Contact("Test User", Email.Create("test@email.com"), "0777777"),
        };
        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(contacts);
        var query = new GetAllContactsQuery();
        var handler = new GetAllContactsHandler(mockRepo.Object);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().HaveCount(1);
        result[0].Name.Should().Be("Test User");
    }
}
