using System;

namespace DesafioTotvs.Application.Models
{
    public class VehicleModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public decimal AverageFuelConsumptionCity { get; set; }
        public decimal AverageFuelConsumptionHighway { get; set; }

        public void Deconstruct(out string name, out string brand , out string model, out DateTime manufacturingDate, out decimal averageFuelConsumptionCity, out decimal averageFuelConsumptionHighway)
        {
          name = Name;
          brand = Brand;
          model = Model;
          manufacturingDate = ManufacturingDate;
          averageFuelConsumptionCity = AverageFuelConsumptionCity;
          averageFuelConsumptionHighway = AverageFuelConsumptionHighway;
        }

    }
}