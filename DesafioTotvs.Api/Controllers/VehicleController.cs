using System.Collections.Generic;
using System.Threading.Tasks;
using DesafioTotvs.Application.Commands;
using DesafioTotvs.Application.Models;
using DesafioTotvs.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTotvs.Api.Controllers
{
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleQueries _vehicleQueries;
        private readonly IMediator _mediator;
        public VehicleController(IVehicleQueries vehicleQueries, IMediator mediator)
        {
          _vehicleQueries = vehicleQueries;
          _mediator = mediator;
        }

        [HttpGet("Vehicles")]
        public async Task<IEnumerable<VehicleModel>> GetAllVehicles()
        {
           var response = await _vehicleQueries.Vehicles();
           return response;
        }

        [HttpPost("Vehicle")]
        public async Task<Response> CreateVehicle(VehicleModel vehicle)
        {
           var response = await _mediator.Send(new CreateVehicleCommand(vehicle));
           return response;
        }

        [HttpPut("Vehicle")]
        public async Task<Response> UpdateVehicle(VehicleModel vehicle)
        {
           var response = await _mediator.Send(new UpdateVehicleCommand(vehicle));
           return response;
        }
    }
}