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
    private readonly IMapper _mappper;

    public async Task<Response> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
       _vehicleRepository.Remove(request.Id);
      await _vehicleRepository.UnitOfWork.SaveEntitiesAsync();
      return new Response(request.Id);
    }
  }
}