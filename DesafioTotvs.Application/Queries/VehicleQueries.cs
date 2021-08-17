using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DesafioTotvs.Application.Models;
using DesafioTotvs.Domain.Repositories;


namespace DesafioTotvs.Application.Queries
{

  public class VehicleQueries : IVehicleQueries
  {
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;
    public VehicleQueries(IVehicleRepository vehicleRepository, IMapper mappper)
    {
      _vehicleRepository = vehicleRepository;
      _mapper = mappper;
    }

    public async Task<IEnumerable<RankedVehiclesModel>> RankedVehiclesQuery(decimal fuelPrice, decimal totalKmInCity, decimal totalKmInHighway)
    {
        var vehicles = await _vehicleRepository.GetVehiclesAsync();

        var rankedVehicleModels = vehicles
            .ToRankedVehiclesModels(fuelPrice, totalKmInCity, totalKmInHighway)
            .OrderBy(rankedVehiclesModel => rankedVehiclesModel.FuelTotalValueSpent);
            
        return rankedVehicleModels;
    }

    public async Task<Response> VehicleById(Guid id)
    {
      var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
      
      return new Response(_mapper.Map<VehicleModel>(vehicle));
    }

    public async Task<Response> VehicleByName(string name)
    {
       var vehicle = await _vehicleRepository.GetVehicleByNameAsync(name);
       return new Response(_mapper.Map<VehicleModel>(vehicle));
    }

    public async Task<Response> Vehicles()
    {
      var vehicles = await _vehicleRepository.GetVehiclesAsync();
      return new Response(_mapper.Map<IEnumerable<VehicleModel>>(vehicles));
    }
  }
}