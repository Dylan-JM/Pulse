using MediatR;
using Pulse.Contacts.Domain.Entities;

namespace Pulse.Contacts.Application.Queries.GetAllContacts;

public class GetAllContactsQuery : IRequest<List<Contact>> { }
