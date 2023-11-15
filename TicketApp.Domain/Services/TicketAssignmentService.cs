using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.Domain.Entities;
using TicketApp.Domain.Repositories;

namespace TicketApp.Domain.Services
{
  public class TicketAssignmentService : ITicketAssignment
  {
    // Haftalık 30 saat üstü atama yapılamaz
    // günlük 6 saat üstü atama yapılmaz

    private IEmployeeTicketRepository employeeTicketRepository;

    public TicketAssignmentService(IEmployeeTicketRepository employeeTicketRepository)
    {
      this.employeeTicketRepository = employeeTicketRepository;

    }

    public bool IsAssignable(Employee employee, Ticket ticket, int estimatedTime)
    {
      // Günlük atanan ticketlerı bul toplam 6 saati geçememli
      // Haftalık ticket toplamanını bul esitamatedTime ile birlikte toplamda 30 saati geçmemeli.

     double dailyTotalHour =  this.employeeTicketRepository.GetDailyAssignedTicketHours(employee.Id);

      double weeklyTotalHour = this.employeeTicketRepository.GetWeeklyAssignedTicketHours(employee.Id);

      if ((dailyTotalHour + estimatedTime) >  6)
      {
        throw new Exception("Günlük 6 saat üzerinde bir atama yapılamaz");
      }

      if((weeklyTotalHour + estimatedTime) > 30)
      {
        throw new Exception("Haftalık 30 saat üzerinde bir atama yapılamaz");
      }


      return true;

    }
  }
}
