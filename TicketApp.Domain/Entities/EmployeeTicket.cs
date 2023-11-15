using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.Domain.SeedWork;

namespace TicketApp.Domain.Entities
{
  public class EmployeeTicket:Entity
  {
    public string TicketId { get; set; }
    public string EmployeId { get; set; }
    public int EstimatedTime { get; set; } // saat olarak

  }
}
