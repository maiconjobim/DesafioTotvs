using System;
using DesafioTotvs.Application.Commands;
using DesafioTotvs.Application.Commands.Validators;
using DesafioTotvs.Domain.Entities;
using DesafioTotvs.Domain.Repositories;
using Moq;
using Xunit;

namespace DesafioTotvs.UnitTests.Application
{
    public class DeleteVehicleCommandTests
    {
        [Fact]
        public void ShouldBeInvalidDeleteVehicleCommand()
        {
          var vehicleId = Guid.Empty;
          //Given
          var command = new DeleteVehicleCommand(vehicleId);
          var mock = new Mock<IVehicleRepository>();
          //When
          var validator = new DeleteVehicleCommandValidator(mock.Object);
          var result = validator.Validate(command);
          //Then
          Assert.False(result.IsValid);
        }


        [Fact]
        public void ShouldReturnsErrorIfNotFoundVehicle()
        {
          var vehicleId = Guid.NewGuid();
          //Given
          var command = new DeleteVehicleCommand(vehicleId);
          var mock = new Mock<IVehicleRepository>();
          //When
          var validator = new DeleteVehicleCommandValidator(mock.Object);
          var result = validator.Validate(command);
          //Then
          Assert.False(result.IsValid);
        }

        [Fact]
        public void ShouldBeValidDeleteVehicleCommand()
        {
          var vehicleId = Guid.NewGuid();
          var mockVehicle = new Vehicle(
            "xpto",
            "xpto",
            "xpto",
            DateTime.Now,
            10,
            10
          );
          //Given
          var command = new DeleteVehicleCommand(vehicleId);
          var mockRepository = new Mock<IVehicleRepository>();
            mockRepository.Setup( x=> x.GetVehicleByIdAsync(vehicleId,default)).ReturnsAsync(mockVehicle);
          //When
          var validator = new DeleteVehicleCommandValidator(mockRepository.Object);
          var result = validator.Validate(command);
          //Then
          Assert.True(result.IsValid);
        }
    }
}