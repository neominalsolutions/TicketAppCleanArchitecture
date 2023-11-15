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
      return table.Where(x => x.AssignedAt.Date == DateTime.Now.Date && x.EmployeId == employeeId).Sum(x=> x.EstimatedTime);
    }

    public double GetWeeklyAssignedTicketHours(string employeeId)
    {
      int dayIndex = (int)(DateTime.Now).DayOfWeek; // 0-6
      DateTime startDate = DateTime.Now.AddDays(-dayIndex);
      DateTime endDate = DateTime.Now.AddDays(7-dayIndex);

      return table.Where(x => x.AssignedAt.Date >= startDate.Date && x.AssignedAt.Date <= endDate.Date && x.EmployeId == employeeId).Sum(x => x.EstimatedTime);
    }

    
  }
}
