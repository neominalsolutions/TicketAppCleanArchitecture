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
  public class EFTicketRepository : EFBaseRepository<Ticket, AppDbContext>, ITicketRepository
  {
    public EFTicketRepository(AppDbContext db) : base(db)
    {
    }
  }
}
