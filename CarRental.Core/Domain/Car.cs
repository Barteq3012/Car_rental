using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Domain
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public string Country { get; set; }
        public int Mileage { get; set; }
        public RegistrationProof RegistrationProof { get; set; }
    }
}
