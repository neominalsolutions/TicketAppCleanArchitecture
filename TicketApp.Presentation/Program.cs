using TicketApp.Application.Handlers;
using TicketApp.Domain.Repositories;
using TicketApp.Domain.Services;
using TicketApp.Infrastructure.EF;
using TicketApp.Persistance.EF.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// reflection ile application katmanýndaki AssignTicketHandler sýnýfýnýn bulunduðu assembly container içerisine load et.

builder.Services.AddDbContext<AppDbContext>(); // database register et.

builder.Services.AddMediatR(opt =>
{
  opt.RegisterServicesFromAssemblyContaining<AssignTicketHandler>();
});

builder.Services.AddScoped<IEmployeeRepository, EFEmployeeRepository>();
builder.Services.AddScoped<ITicketRepository, EFTicketRepository>();
builder.Services.AddScoped<IEmployeeTicketRepository, EFEmployeeTicketRepository>();
builder.Services.AddScoped<ITicketAssignment, TicketAssignmentService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
