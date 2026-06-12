using MediatR;
using Pulse.Contacts.Application.DTOs;

namespace Pulse.Contacts.Application.Queries.GetAllContacts;

public class GetAllContactsQuery : IRequest<List<ContactDto>> { }
