using System;
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
          var car = new Vehicle("TESLA model X","TESLA","modelx",DateTime.Now,10,8);
          
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
    }
}