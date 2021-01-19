using System;
using System.Collections.Generic;
using System.Text;
using CarDealership_EfCore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealership_EfCore.Data
{
    class CarDealerShipContext : DbContext
    {
        public DbSet<Car> Car { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=Car_DealerShip;Trusted_Connection=True");
        }

    }
}
