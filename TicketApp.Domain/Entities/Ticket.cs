using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.Domain.SeedWork;

namespace TicketApp.Domain.Entities
{
  public class Ticket:Entity
  {
    public string Title { get; set; }
    public string Description { get; set; }

  }
}
