using Microsoft.EntityFrameworkCore;
using Pulse.Contacts.Domain.Entities;
using Pulse.Contacts.Domain.ValueObjects;

namespace Pulse.Contacts.Infrastructure.Persistence;

public class ContactsDbContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactList> ContactLists { get; set; }

    public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Contact>()
            .Property(c => c.Email)
            .HasConversion(
                email => email.Value, // Email → string (saving)
                value => Email.Create(value) // string → Email (loading)
            );
    }
}
