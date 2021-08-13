using DesafioTotvs.Domain.Repositories;
using FluentValidation;

namespace DesafioTotvs.Application.Commands.Validators
{
    public class DeleteVehicleCommandValidator : AbstractValidator<DeleteVehicleCommand>
    {
        public DeleteVehicleCommandValidator(IVehicleRepository vehicleRepository)
        {
          base.RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");

          base.RuleFor(x => x.Id)
            .MustAsync(async (id, cancellationToken) =>
            {
                var vehicle = await vehicleRepository.GetVehicleByIdAsync(id, cancellationToken);
                return vehicle is not null;
            })
            .WithMessage("Vehicle Not Exists");
        }
    }
}