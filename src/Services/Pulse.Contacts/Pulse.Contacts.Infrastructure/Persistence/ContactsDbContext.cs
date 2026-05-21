using Microsoft.EntityFrameworkCore;
using Pulse.Contacts.Domain.Entities;

namespace Pulse.Contacts.Infrastructure.Persistence;

public class ContactsDbContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactList> ContactLists { get; set; }

    public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
        : base(options) { }
}
