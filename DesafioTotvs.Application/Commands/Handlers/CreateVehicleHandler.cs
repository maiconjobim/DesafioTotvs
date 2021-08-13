using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DesafioTotvs.Application.Models;
using DesafioTotvs.Domain.Entities;
using DesafioTotvs.Domain.Repositories;
using MediatR;

namespace DesafioTotvs.Application.Commands.Handlers
{
  public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand,Response>
  {
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mappper;

    public CreateVehicleHandler(IVehicleRepository vehicleRepository, IMapper mappper)
    {
      _vehicleRepository = vehicleRepository;
      _mappper = mappper;
    }

    public async Task<Response> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
      var vehicle = _mappper.Map<Vehicle>(request.Vehicle);
      _vehicleRepository.Add(vehicle);
      await _vehicleRepository.UnitOfWork.SaveEntitiesAsync();
      return new Response(request.Vehicle);
    }
  }
}