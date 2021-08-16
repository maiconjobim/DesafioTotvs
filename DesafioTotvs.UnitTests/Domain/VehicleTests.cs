using System;
using System.Collections.Generic;
using DesafioTotvs.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace DesafioTotvs.UnitTests.Domain
{
    public class VehicleTests
    {
        [Fact]
        public void VehicleShouldChangeAttributes()
        {
            var car = new Vehicle("TESLA model X", "TESLA", "modelx", DateTime.Now, 10, 8);

            car.Rename("fox")
              .FromBrand("Volkswagen")
              .WithModel("fox summer")
              .FromManufacturingDate(DateTime.MaxValue)
              .ChangeCityAverageFuelConsumption(15)
              .ChangeHighwayAverageFuelConsumption(11);

            car.Name.Should().Be("fox");
            car.Brand.Should().Be("Volkswagen");
            car.Model.Should().Be("fox summer");
            car.ManufacturingDate.Should().Be(DateTime.MaxValue);
            car.AverageFuelConsumptionCity.Should().Be(15);
            car.AverageFuelConsumptionHighway.Should().Be(11);

        }

        [Theory]
        [InlineData(6, 11, 10, 2)]
        [InlineData(3, 11, 10, 2)]
        [InlineData(5.90, 22, 20, 4)]
        public void ShouldBeCorrectCalculateFuelQuantitySpent(decimal fuelPrice, decimal totalKmInCity, decimal totalKmInHighway, decimal fuelQuantitySpent)
        {
            var vehicles = new Vehicle("camaro amarelo", "ford", "camaro", DateTime.Now, 11, 10);

            vehicles.CalculateFuelQuantitySpent(fuelPrice, totalKmInCity, totalKmInHighway).Should().Be(fuelQuantitySpent);
        }

        [Theory]
        [InlineData(6, 11, 10, 12)]
        [InlineData(3, 11, 10, 6)]
        [InlineData(5.90, 22, 20, 23.6)]
        public void ShouldBeCorrectCalculateFuelTotalValueSpent(decimal fuelPrice, decimal totalKmInCity, decimal totalKmInHighway, decimal fuelTotalValueSpent)
        {
            var vehicles = new Vehicle("camaro amarelo", "ford", "camaro", DateTime.Now, 11, 10);

            vehicles.CalculateFuelTotalValueSpent(fuelPrice, totalKmInCity, totalKmInHighway).Should().Be(fuelTotalValueSpent);
        }
    }
}