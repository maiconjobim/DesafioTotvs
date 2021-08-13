using System;
using System.Threading;
using System.Threading.Tasks;
using DesafioTotvs.Domain.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace DesafioTotvs.Application.Commands.Validators
{
    public class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
    {

        public UpdateVehicleCommandValidator(IVehicleRepository vehicleRepository)
        {
          base.RuleFor(x => x.Vehicle.Name)
              .NotEmpty()
              .WithMessage("Name is required");
          
          base.RuleFor(x => x.Vehicle.Id)
              .MustAsync(async (id, cancellationToken) =>
              {
                  var vehicle = await vehicleRepository.GetVehicleByIdAsync(id, cancellationToken);
                  return vehicle is not null;
              })
              .WithMessage("Not Found Vehicle");
          
          base.RuleFor(x => x.Vehicle.Model)
              .NotEmpty()
              .WithMessage("Model is required");
          
          base.RuleFor(x => x.Vehicle.Brand)
              .NotEmpty()
              .WithMessage("Brand is required");
          
          base.RuleFor(x => x.Vehicle.AverageFuelConsumptionCity)
            .GreaterThan(0)
            .WithMessage("AverageFuelConsumptionCity is required");
          
          base.RuleFor(x => x.Vehicle.AverageFuelConsumptionHighway)
            .GreaterThan(0)
            .WithMessage("AverageFuelConsumptionHighway is required");
          
          base.RuleFor(x => x.Vehicle.ManufacturingDate)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("AverageFuelConsumptionHighway is required");
        }
  }
}