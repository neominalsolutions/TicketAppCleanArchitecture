using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.Domain.Entities;
using TicketApp.Persistance.EF.Configurations;

namespace TicketApp.Persistance.EF.Contexts
{
  public class AppDbContext:DbContext
  {

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<EmployeeTicket> EmployeeTickets { get; set; }


    public AppDbContext()
    {

    }

    // Model generate edilirken yapılacak konfigürasyonları yansıttığımız kısım
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
      base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TicketAppDb;uid=sa;pwd=1234");

      base.OnConfiguring(optionsBuilder);
    }
  }
}
