using System.Collections.Generic;
using System.Linq;
using DesafioTotvs.Application.Models;
using DesafioTotvs.Domain.Entities;

namespace DesafioTotvs.Application.Queries
{
    public static class VehicleModelExtensions
    {
         public static RankedVehiclesModel ToRankedVehiclesModel(
            this Vehicle vehicle,
            decimal fuelPrice,
            decimal totalKmInCity,
            decimal totalKmInHighway)
        {
            return new RankedVehiclesModel
            {
                Id = vehicle.Id,
                Name = vehicle.Name,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Year = vehicle.ManufacturingDate.ToString("yyyy"),
                FuelQuantitySpent = vehicle.CalculateFuelQuantitySpent(totalKmInCity, totalKmInHighway),
                FuelTotalValueSpent = vehicle.CalculateFuelTotalValueSpent(fuelPrice, totalKmInCity, totalKmInHighway)
            };
        }

        public static IEnumerable<RankedVehiclesModel> ToRankedVehiclesModels(
            this IEnumerable<Vehicle> vehicles,
            decimal fuelPrice,
            decimal totalKmInCity,
            decimal totalKmInHighway)
        {
            return vehicles.Select(vehicle => vehicle
                .ToRankedVehiclesModel(fuelPrice, totalKmInCity, totalKmInHighway));
        }
    }
}