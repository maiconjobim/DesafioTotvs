using System;
using DesafioTotvs.Application.Commands;
using DesafioTotvs.Application.Commands.Validators;
using DesafioTotvs.Application.Models;
using DesafioTotvs.Domain.Entities;
using DesafioTotvs.Domain.Repositories;
using FluentAssertions;
using Moq;
using Xunit;

namespace DesafioTotvs.UnitTests.Application
{
    public class UpdateVehicleCommandTests
    {
        [Fact]
        public void ShouldBeInvalidUpdateVehicleCommand()
        {
          //Given
          var command = new UpdateVehicleCommand(new VehicleModel());
          var mock = new Mock<IVehicleRepository>();
          //When
          var validator = new UpdateVehicleCommandValidator(mock.Object);
          var result = validator.Validate(command);
          //Then
          Assert.False(result.IsValid);
        }
        
        [Fact]
         public void ShouldBeValidUpdateVehicleCommand()
        {
          //Given
          var vehicleModel = new VehicleModel{
            Id = Guid.NewGuid(),
            Name = "Rapidão",
            Brand = "Ferrari",
            Model = "xpto",
            ManufacturingDate = DateTime.Now,
            AverageFuelConsumptionCity = 10,
            AverageFuelConsumptionHighway = 8,
          };
          
          var mockVehicle = new Vehicle(
            vehicleModel.Name,
            vehicleModel.Brand,
            vehicleModel.Model,
            vehicleModel.ManufacturingDate,
            vehicleModel.AverageFuelConsumptionCity,
            vehicleModel.AverageFuelConsumptionHighway
          );
          var command = new UpdateVehicleCommand(vehicleModel);

          var mockRepository = new Mock<IVehicleRepository>();
            mockRepository.Setup( x=> x.GetVehicleByIdAsync(vehicleModel.Id,default)).ReturnsAsync(mockVehicle);
          //When
          var validator = new UpdateVehicleCommandValidator(mockRepository.Object);
          var result = validator.Validate(command);
          //Then
          Assert.True(result.IsValid);
        }
        
        [Fact]
         public void ShouldReturnErrorWhenVehicleNotExists()
        {
          //Given
          var vehicle = new VehicleModel{
            Id = Guid.NewGuid(),
            Name = "Rapidão",
            Brand = "Ferrari",
            Model = "xpto",
            ManufacturingDate = DateTime.Now,
            AverageFuelConsumptionCity = 10,
            AverageFuelConsumptionHighway = 8,
          };

          var command = new UpdateVehicleCommand(vehicle);
         
      

          var mockRepository = new Mock<IVehicleRepository>();
            mockRepository.Setup( x=> x.GetVehicleByIdAsync(vehicle.Id,default));
          
          //When
          var validator = new UpdateVehicleCommandValidator(mockRepository.Object);
          var result = validator.Validate(command);
          //Then
          Assert.False(result.IsValid);
          result.Errors.Should().Contain(x => x.ErrorMessage == "Not Found Vehicle");
        }
    }
}