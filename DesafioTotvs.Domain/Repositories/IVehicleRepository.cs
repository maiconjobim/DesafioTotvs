using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DesafioTotvs.Domain.Entities;
using DesafioTotvs.Domain.UnitOfWork;

namespace DesafioTotvs.Domain.Repositories
{
    public interface IVehicleRepository
    {
       IUnitOfWork UnitOfWork { get; }

        void Add(Vehicle vehicle);

        void AddRange(IEnumerable<Vehicle> vehicles);

        void Remove(Vehicle vehicle);

        void RemoveRange(IEnumerable<Vehicle> vehicles);

        void Update(Vehicle vehicle);

        Task<Vehicle> GetVehicleByIdAsync(Guid vehicleId, CancellationToken cancellationToken = default);

        Task<Vehicle> GetVehicleByNameAsync(string name, CancellationToken cancellationToken = default);
        
        Task<IEnumerable<Vehicle>> GetVehiclesAsync(CancellationToken cancellationToken = default);
        
        //Task<IEnumerable<>> GetRankedVehiclesByFuelComsumptionAsync(decimal fuelPrice , decimal totalCityKm,decimal totalHighwayKm ,CancellationToken cancellationToken = default);
         
    }
}