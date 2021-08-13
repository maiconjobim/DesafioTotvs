using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioTotvs.Application.Models;

namespace DesafioTotvs.Application.Queries
{
    public interface IVehicleQueries
    {
       Task<IEnumerable<RankedVehiclesModel>> RankedVehiclesQuery(decimal fuelPrice, decimal totalKmInCity, decimal totalKmInHighway);
       Task<IEnumerable<VehicleModel>> Vehicles();
    }
}