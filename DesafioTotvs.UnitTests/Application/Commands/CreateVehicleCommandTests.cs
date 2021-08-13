using System;
using System.Threading.Tasks;
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
    public class CreateVehicleCommandTests
    {
       [Fact]
        public void ShouldBeInValidVehicleCommand()
        {
          //Given
          var command = new CreateVehicleCommand(new VehicleModel());
          var mock = new Mock<IVehicleRepository>();
          //When
          var validator = new CreateVehicleCommandValidator(mock.Object);
          var result = validator.Validate(command);
          //Then
          Assert.False(result.IsValid);
        }
        
        [Fact]
         public void ShouldBeValidVehicleCommand()
        {
          //Given
          var command = new CreateVehicleCommand(new VehicleModel{
            Name = "Rapidão",
            Brand = "Ferrari",
            Model = "xpto",
            ManufacturingDate = DateTime.Now,
            AverageFuelConsumptionCity = 10,
            AverageFuelConsumptionHighway = 8,
          });
          var mock = new Mock<IVehicleRepository>();
          //When
          var validator = new CreateVehicleCommandValidator(mock.Object);
          var result = validator.Validate(command);
          //Then
          Assert.True(result.IsValid);
        }
        
        [Fact]
         public void ShouldReturnErrorWhenVehicleAlreadyExists()
        {
          //Given
          var vehicle = new VehicleModel{
            Name = "Rapidão",
            Brand = "Ferrari",
            Model = "xpto",
            ManufacturingDate = DateTime.Now,
            AverageFuelConsumptionCity = 10,
            AverageFuelConsumptionHighway = 8,
          };

          var command = new CreateVehicleCommand(vehicle);
          var mockVehicle = new Vehicle(
            vehicle.Name,
            vehicle.Brand,
            vehicle.Model,
            vehicle.ManufacturingDate,
            vehicle.AverageFuelConsumptionCity,
            vehicle.AverageFuelConsumptionHighway
          );
          var mockRepository = new Mock<IVehicleRepository>();
            mockRepository.Setup( x=> x.GetVehicleByNameAsync(vehicle.Name,default)).ReturnsAsync(mockVehicle);
          //When
          var validator = new CreateVehicleCommandValidator(mockRepository.Object);
          var result = validator.Validate(command);
          //Then
          Assert.False(result.IsValid);
          result.Errors.Should().Contain(x => x.ErrorMessage == "Vehicle with this name already exists");
        }
    }
}