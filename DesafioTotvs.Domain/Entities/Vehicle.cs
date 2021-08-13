using System;

namespace DesafioTotvs.Domain.Entities
{
    public class Vehicle : Entity
    {
        public string Name { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public DateTime ManufacturingDate { get; private set; }
        public decimal AverageFuelConsumptionCity { get; private set; }
        public decimal AverageFuelConsumptionHighway { get; private set; }

        private Vehicle()
        {

        }
        public Vehicle(
         string name,
         string brand,
         string model,
         DateTime manufacturingDate,
         decimal averageFuelConsumptionCity,
         decimal averageFuelConsumptionHighway)
        {
            Name = name;
            Brand = brand;
            Model = model;
            ManufacturingDate = manufacturingDate;
            AverageFuelConsumptionCity = averageFuelConsumptionCity;
            AverageFuelConsumptionHighway = averageFuelConsumptionHighway;
        }

        public Vehicle Rename(string name)
        {
            Name = name;
            return this;
        }
        public Vehicle FromBrand(string brand)
        {
            Brand = brand;
            return this;
        }

        public Vehicle WithModel(string model)
        {
            Model = model;
            return this;
        }
        public Vehicle FromManufacturingDate(DateTime date)
        {
            ManufacturingDate = date;
            return this;
        }
        public Vehicle ChangeCityAverageFuelConsumption(decimal average)
        {
            AverageFuelConsumptionCity = average;
            return this;
        }
        public Vehicle ChangeHighwayAverageFuelConsumption(decimal average)
        {
            AverageFuelConsumptionHighway = average;
            return this;
        }
    }
}