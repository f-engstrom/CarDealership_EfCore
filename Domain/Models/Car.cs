using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership_EfCore.Domain.Models
{
    class Car
    {

        public int Id { get; private set; }
        public string RegistrationNumber { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string ProductionYear { get; private set; }
        public string Price { get; private set; }

        public Car(string registrationNumber, string brand, string model, string productionYear, string price)
        {
            RegistrationNumber = registrationNumber;
            Brand = brand;
            Model = model;
            ProductionYear = productionYear;
            Price = price;
        }

        Car() { }
    }
}
