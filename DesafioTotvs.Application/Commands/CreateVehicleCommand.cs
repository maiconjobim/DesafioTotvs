using DesafioTotvs.Application.Models;
using MediatR;

namespace DesafioTotvs.Application.Commands
{
    public class CreateVehicleCommand : IRequest<Response>
    {
        public VehicleModel Vehicle { get; }
        public CreateVehicleCommand(VehicleModel vehicle)
        {
          Vehicle = vehicle;
        }
    }
}