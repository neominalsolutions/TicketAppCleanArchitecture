using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TicketApp.Domain.SeedWork;

namespace TicketApp.Domain.Entities
{
  // POCO class olmalı db veya herhangi bir teknoloji bağımlılığı olmamalı.

  //[Table("Calisanlar")]
  public class Employee:Entity
  {
    //[Column(Name="Ad",TypeName = "nvarchar")]
    public string Name { get; set; }

    public string SurName { get; set; }
    
    private List<EmployeeTicket> tickets = new List<EmployeeTicket>();

    public IReadOnlyList<EmployeeTicket> Tickets => tickets;

    // Information Export
    // Creator
    public void AssignTicket(Ticket ticket, int estimatedTime)
    {
      tickets.Add(new EmployeeTicket { 
        TicketId = ticket.Id,
        EmployeId = this.Id,
        EstimatedTime = estimatedTime,
        AssignedAt = DateTime.Now
      });
    }

  }
}
