using Microsoft.EntityFrameworkCore;
using Pulse.Contacts.Application.Commands.CreateContact;
using Pulse.Contacts.Domain.Repositories;
using Pulse.Contacts.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateContactCommand).Assembly)
);

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactListRepository, ContactListRepository>();

builder.Services.AddDbContext<ContactsDbContext>(options =>
    options.UseInMemoryDatabase("contactsDB")
);

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
