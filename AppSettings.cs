using System;

namespace AppleCore.Web.Configutation
{
    public class AppSettings
    {
        public string First { get; set; }
        public string Second { get; set; }
        public Car Car { get; set; }

        public class Car
        {
            public int NumberOfDoors { get; set; }
            public DateTime RegistrationDate { get; set; }
            public string Color { get; set; }
        }
    }
}
