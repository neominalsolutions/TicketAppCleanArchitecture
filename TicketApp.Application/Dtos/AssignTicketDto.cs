using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp.Application.Dtos
{
  public class AssignTicketDto:IRequest
  {
    [Range(1,6,ErrorMessage = "Günlük Min 1 Mak 6 saatlik bir iş ataması yapılabilir")]
    public int EstimatedTime { get; set; }

    [Required(ErrorMessage = "Ticket bilgisi boş geçilemez")]
    public string TicketId { get; set; }

    [Required(ErrorMessage = "EmployeeId Boş geçilemez")]
    public string EmployeeId { get; set; }

  }
}
