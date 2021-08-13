using System;
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
        public async Task<IActionResult> GetAllVehicles()
        {
           var response = await _vehicleQueries.Vehicles();
           return ReturnOk(response);
        }
        
        [HttpGet("Vehicle/{id}")]
        public async Task<IActionResult> GetVehicleById([FromRoute] Guid id)
        {
           var response = await _vehicleQueries.VehicleById(id);
           return ReturnOk(response);
        }

         [HttpGet("Vehicle/name/{name}")]
        public async Task<IActionResult> GetVehicleByName([FromRoute] string name)
        {
           var response = await _vehicleQueries.VehicleByName(name);
           return ReturnOk(response);
        }

         [HttpGet("RankedVehicles")]
        public async Task<IEnumerable<RankedVehiclesModel>> GetRankedVehicles(decimal fuelPrice, decimal totalKmInCity, decimal totalKmInHighway)
        {
           var response = await _vehicleQueries.RankedVehiclesQuery(fuelPrice,totalKmInCity,totalKmInHighway);
           return response;
        }

        [HttpPost("Vehicle")]
        public async Task<IActionResult> CreateVehicle(VehicleModel vehicle)
        {
           var response = await _mediator.Send(new CreateVehicleCommand(vehicle));
           return ReturnCreated(response);
        }

        [HttpPut("Vehicle")]
        public async Task<IActionResult> UpdateVehicle(VehicleModel vehicle)
        {
           var response = await _mediator.Send(new UpdateVehicleCommand(vehicle));
           return ReturnAccepted(response);
        }


        [HttpDelete("Vehicle")]
        public async Task<IActionResult> DeleteteVehicle(Guid id)
        {
           var response = await _mediator.Send(new DeleteVehicleCommand(id));
           return ReturnAccepted(response);
        }

         private IActionResult ReturnOk(Response response)
        {
            return FormatActionResult(Ok(response), response);
        }
         private IActionResult ReturnCreated(Response response)
        {
            return FormatActionResult(Created(""
                    , response)
                , response);
        }
        private IActionResult ReturnAccepted(Response response)
        {
            return FormatActionResult(Accepted(response), response);
        }
         private IActionResult FormatActionResult(IActionResult actionResult, Response response)
        {
            return response.IsErrorResponse() ? BadRequest(response) : actionResult;
        }

    }
}