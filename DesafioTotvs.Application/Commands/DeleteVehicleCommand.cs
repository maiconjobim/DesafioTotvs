using System;
using DesafioTotvs.Application.Models;
using MediatR;

namespace DesafioTotvs.Application.Commands
{
    public class DeleteVehicleCommand : IRequest<Response>
    {
      public Guid Id { get; }
      public DeleteVehicleCommand(Guid id)
      {
        Id = id;
      }

    }
}