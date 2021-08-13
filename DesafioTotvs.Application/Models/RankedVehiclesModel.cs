using System;

namespace DesafioTotvs.Application.Models
{
    public class RankedVehiclesModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public decimal FuelQuantitySpent { get; set; }
        public decimal FuelTotalValueSpent { get; set; }
    }
}