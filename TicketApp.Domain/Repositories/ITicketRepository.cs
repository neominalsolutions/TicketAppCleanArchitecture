using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.Domain.Entities;

namespace TicketApp.Domain.Repositories
{
  public interface ITicketRepository:IRepository<Ticket>
  {
  }
}
