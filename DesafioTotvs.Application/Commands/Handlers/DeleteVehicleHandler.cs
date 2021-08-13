using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DesafioTotvs.Application.Models;
using DesafioTotvs.Domain.Repositories;
using MediatR;

namespace DesafioTotvs.Application.Commands.Handlers
{
  public class DeleteVehicleHandler : IRequestHandler<DeleteVehicleCommand, Response>
  {
    private readonly IVehicleRepository _vehicleRepository;

    public DeleteVehicleHandler(IVehicleRepository vehicleRepository)
    {
      _vehicleRepository = vehicleRepository;
    }

    public async Task<Response> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
       var vehicle = await _vehicleRepository.GetVehicleByIdAsync(request.Id);
       _vehicleRepository.Remove(vehicle);
      await _vehicleRepository.UnitOfWork.SaveEntitiesAsync();
      return new Response(request.Id);
    }
  }
}