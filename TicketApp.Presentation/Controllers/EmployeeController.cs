using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketApp.Application.Dtos;

namespace TicketApp.Presentation.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeeController : ControllerBase
  {
    // kulemiz
    private readonly IMediator mediator;

    public EmployeeController(IMediator mediator)
    {
      this.mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> AssignTicket([FromBody] AssignTicketDto request)
    {
      await this.mediator.Send(request); // yönelendirme
      // Ticket Assigmnet Handler yönlendirme indirection özelliğini kullanmış oluyoruz.

      return Ok();
    }

  }
}
