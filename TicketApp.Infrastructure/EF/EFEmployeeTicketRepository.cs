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
  public class EFEmployeeTicketRepository : EFBaseRepository<EmployeeTicket, AppDbContext>, IEmployeeTicketRepository
  {
    public EFEmployeeTicketRepository(AppDbContext db) : base(db)
    {
    }



    public double GetDailyAssignedTicketHours(string employeeId)
    {
      throw new NotImplementedException();
    }

    public double GetWeeklyAssignedTicketHours(string employeeId)
    {
      throw new NotImplementedException();
    }

    
  }
}
