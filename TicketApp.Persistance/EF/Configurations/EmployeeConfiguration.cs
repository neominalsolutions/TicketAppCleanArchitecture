using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.Domain.Entities;

namespace TicketApp.Persistance.EF.Configurations
{
  public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
  {
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
      builder.ToTable("Calisanlar");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Name).HasColumnName("Ad").HasMaxLength(20);
      builder.Property(x => x.SurName).HasColumnName("Soyad").HasMaxLength(20);

      builder.HasMany(x => x.Tickets);
    }
  }
}
