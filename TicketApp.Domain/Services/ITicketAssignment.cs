using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.Domain.Entities;

namespace TicketApp.Domain.Services
{
  public interface ITicketAssignment
  {
    // şu çalışan için şu süreli ticket ataması yapılabilir mi
    bool IsAssignable(Employee employee, Ticket ticket, int estimatedTime);
   
  }
}
