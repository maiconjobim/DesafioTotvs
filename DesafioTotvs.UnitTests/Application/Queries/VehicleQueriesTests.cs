using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DesafioTotvs.Application.Queries;
using DesafioTotvs.Domain.Entities;
using DesafioTotvs.Domain.Repositories;
using FluentAssertions;
using Moq;
using Xunit;

namespace DesafioTotvs.UnitTests.Application.Queries
{
    public class RankedVehiclesTests
    {
        [Theory]
        [InlineData(6, 11, 10, 2, 12)]
        [InlineData(3, 11, 10, 2, 6)]
        [InlineData(5.90, 22, 20, 4, 23.6)]
        public async void FuelQuantitySpentAndFuelTotalValueSpentShouldBeCorrect(decimal fuelPrice, decimal totalKmInCity, decimal totalKmInHighway, decimal fuelQuantitySpent, decimal fuelTotalValueSpent)
        {
          var vehicles = new  List<Vehicle>{
            new Vehicle("camaro amarelo","ford","camaro",DateTime.Now,11,10),
          };
          var mockMapper = new Mock<IMapper>();
          var mockRepo = new Mock<IVehicleRepository>();
            mockRepo.Setup( x=> x.GetVehiclesAsync(default)).ReturnsAsync(vehicles);
          var queries = new VehicleQueries(mockRepo.Object,mockMapper.Object);
          var rankedVehicles = await queries.RankedVehiclesQuery(fuelPrice,totalKmInCity,totalKmInHighway);
          
          rankedVehicles.ToList()
            .Should()
            .Contain(vehicle => vehicle.FuelQuantitySpent == fuelQuantitySpent && vehicle.FuelTotalValueSpent == fuelTotalValueSpent);
        }
        
    }
}