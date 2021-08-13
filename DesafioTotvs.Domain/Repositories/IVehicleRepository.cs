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

        void Add(Vehicle Vehicle);

        void AddRange(IEnumerable<Vehicle> Vehicles);

        void Remove(Guid id);

        void RemoveRange(IEnumerable<Guid> Vehicles);

        void Update(Vehicle Vehicle);

        Task<Vehicle> GetVehicleByIdAsync(Guid VehicleId, CancellationToken cancellationToken = default);

        Task<Vehicle> GetVehicleByNameAsync(string name, CancellationToken cancellationToken = default);
        
        Task<IEnumerable<Vehicle>> GetVehiclesAsync(CancellationToken cancellationToken = default);
        
        //Task<IEnumerable<>> GetRankedVehiclesByFuelComsumptionAsync(decimal fuelPrice , decimal totalCityKm,decimal totalHighwayKm ,CancellationToken cancellationToken = default);
         
    }
}