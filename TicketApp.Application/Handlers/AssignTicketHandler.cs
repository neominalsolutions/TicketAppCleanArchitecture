using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.Application.Dtos;
using TicketApp.Domain.Repositories;
using TicketApp.Domain.Services;

namespace TicketApp.Application.Handlers
{
  public class AssignTicketHandler : IRequestHandler<AssignTicketDto>
  {
    // ticket assignment operasyonun koordine edeceğim kod blogu.
    // Facade arayüz ile Domain işlemleri ile UI işlemlerini bir arada koordine eden bir servis görevi gördü.
    private readonly ITicketAssignment ticketAssignmentService;
    private readonly ITicketRepository ticketRepository;
    private readonly IEmployeeRepository employeeRepository;

    public AssignTicketHandler(ITicketAssignment ticketAssignment, ITicketRepository ticketRepository, IEmployeeRepository employeeRepository)
    {
      this.ticketAssignmentService = ticketAssignment;
      this.ticketRepository = ticketRepository;
      this.employeeRepository = employeeRepository;
    }

    public async Task Handle(AssignTicketDto request, CancellationToken cancellationToken)
    {

      var ticket = this.ticketRepository.FindById(request.TicketId);
      var employee = this.employeeRepository.FindById(request.EmployeeId);


      bool isAssignable = this.ticketAssignmentService.IsAssignable(employee,ticket, request.EstimatedTime);

      if(isAssignable)
      {
        employee.AssignTicket(ticket, request.EstimatedTime);
        // state değişen nesneyi database yansıtmış olduk
        this.employeeRepository.Update(employee);
      }

      await Task.CompletedTask;

    }
  }
}
