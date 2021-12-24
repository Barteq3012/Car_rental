using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Infrastructure.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public string Country { get; set; }
        public int Mileage { get; set; }
        public RegistrationProofDTO RegistrationProofDTO  { get; set; }
    }
}
