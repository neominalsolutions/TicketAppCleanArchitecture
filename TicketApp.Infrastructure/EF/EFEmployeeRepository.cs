using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.Domain.Entities;
using TicketApp.Domain.Repositories;
using TicketApp.Persistance.EF.Contexts;

namespace TicketApp.Infrastructure.EF
{
  public class EFEmployeeRepository : EFBaseRepository<Employee, AppDbContext>, IEmployeeRepository
  {
    public EFEmployeeRepository(AppDbContext db) : base(db)
    {
    }

    public override void Create(Employee entity)
    {
      base.Create(entity);
    }
  }
}
