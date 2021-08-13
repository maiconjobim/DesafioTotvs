using System;
using DesafioTotvs.Domain.Repositories;
using FluentValidation;

namespace DesafioTotvs.Application.Commands.Validators
{
    public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandValidator(IVehicleRepository vehicleRepository)
        {
            base.RuleFor(x => x.Vehicle.Name)
                .NotEmpty()
                .WithMessage("Name is required");
            
            base.RuleFor(x => x.Vehicle.Name)
                .MustAsync(async (name, cancellationToken) =>
                {
                    var vehicle = await vehicleRepository.GetVehicleByNameAsync(name, cancellationToken);
                    return vehicle is null;
                })
                .WithMessage("Vehicle with this name already exists");
           
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