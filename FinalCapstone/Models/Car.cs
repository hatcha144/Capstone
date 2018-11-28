using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace FinalCapstone.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public Car(string Make, string Model, int Year, string Color)
        {
            this.ID = ID;
            this.Make = Make;
            this.Model = Model;
            this.Year = Year;
            this.Color = Color;
        }
        public Car()
        {

        }
    }
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}
