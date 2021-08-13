using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DesafioTotvs.Application.Models;
using DesafioTotvs.Domain.Entities;
using DesafioTotvs.Domain.Repositories;
using MediatR;

namespace DesafioTotvs.Application.Commands.Handlers
{
  public class UpdateVehicleHandler : IRequestHandler<UpdateVehicleCommand, Response>
  {
      private readonly IVehicleRepository _vehicleRepository;
      private readonly IMapper _mappper;

    public UpdateVehicleHandler(IVehicleRepository vehicleRepository, IMapper mappper)
    {
      _vehicleRepository = vehicleRepository;
      _mappper = mappper;
    }

    public async Task<Response> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
      
      var vehicle = await _vehicleRepository.GetVehicleByIdAsync(request.Vehicle.Id);
      var (name,brand,model,ManufacturingDate,averageFuelConsumptionCity,averageFuelConsumptionHighway) = request.Vehicle;

      vehicle.Rename(name)
        .FromBrand(brand)
        .WithModel(model)
        .FromManufacturingDate(ManufacturingDate)
        .ChangeCityAverageFuelConsumption(averageFuelConsumptionCity)
        .ChangeHighwayAverageFuelConsumption(averageFuelConsumptionHighway);
        
      await _vehicleRepository.UnitOfWork.SaveEntitiesAsync();
      return new Response(request.Vehicle);
    }
  }
}