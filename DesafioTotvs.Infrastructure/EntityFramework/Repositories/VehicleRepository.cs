using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DesafioTotvs.Domain.Entities;
using DesafioTotvs.Domain.Repositories;
using DesafioTotvs.Domain.UnitOfWork;
using DesafioTotvs.Infrastructure.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DesafioTotvs.Infrastructure.EntityFramework.Repositories
{
  public class VehicleRepository : IVehicleRepository
  {
     private readonly VehicleDbContext _context;
     public IUnitOfWork UnitOfWork => _context;

    public VehicleRepository(VehicleDbContext context)
    {
      _context = context;
    }

    public void Add(Vehicle vehicle)
    {
      _context.Set<Vehicle>().Add(vehicle);
    }

    public void AddRange(IEnumerable<Vehicle> vehicles)
    {
      _context.Set<Vehicle>().AddRange(vehicles);
    }

    public async Task<Vehicle> GetVehicleByIdAsync(Guid vehicleId, CancellationToken cancellationToken = default)
    {
      return await _context.Set<Vehicle>()
                .FirstOrDefaultAsync(vehicle => vehicle.Id == vehicleId, cancellationToken: cancellationToken);
    }

    public async Task<Vehicle> GetVehicleByNameAsync(string name, CancellationToken cancellationToken = default)
    {
      return await _context.Set<Vehicle>()
                .FirstOrDefaultAsync(vehicle => vehicle.Name == name, cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<Vehicle>> GetVehiclesAsync(CancellationToken cancellationToken = default)
    {
      return await _context.Set<Vehicle>().ToListAsync(cancellationToken);
    }

    public void Remove(Vehicle vehicle)
    {
      _context.Set<Vehicle>().Remove(vehicle);
    }

    public void RemoveRange(IEnumerable<Vehicle> Vehicles)
    {
      _context.Set<Vehicle>().RemoveRange(Vehicles);
    }

    public void Update(Vehicle Vehicle)
    {
      _context.Set<Vehicle>().Update(Vehicle);
    }
  }
}