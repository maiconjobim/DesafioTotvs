using DesafioTotvs.Application.Models;
using MediatR;

namespace DesafioTotvs.Application.Commands
{
    public class UpdateVehicleCommand :  IRequest<Response>
    {
        public VehicleModel Vehicle { get; }
        public UpdateVehicleCommand(VehicleModel vehicle)
        {
          Vehicle = vehicle;
        }
    }
}