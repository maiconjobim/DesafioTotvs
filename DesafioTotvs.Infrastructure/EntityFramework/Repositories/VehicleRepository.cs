using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DesafioTotvs.Domain.Entities;
using DesafioTotvs.Domain.Repositories;
using DesafioTotvs.Domain.UnitOfWork;

namespace DesafioTotvs.Infrastructure.EntityFramework.Repositories
{
  public class VehicleRepository : IVehicleRepository
  {
    public IUnitOfWork UnitOfWork => throw new NotImplementedException();

    public void Add(Vehicle Vehicle)
    {
      throw new NotImplementedException();
    }

    public void AddRange(IEnumerable<Vehicle> Vehicles)
    {
      throw new NotImplementedException();
    }

    public Task<Vehicle> GetVehicleByIdAsync(Guid VehicleId, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }

    public Task<Vehicle> GetVehicleByNameAsync(string name, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Vehicle>> GetVehiclesAsync(CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }

    public void Remove(Guid id)
    {
      throw new NotImplementedException();
    }

    public void RemoveRange(IEnumerable<Guid> Vehicles)
    {
      throw new NotImplementedException();
    }

    public void Update(Vehicle Vehicle)
    {
      throw new NotImplementedException();
    }
  }
}