using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Core.Domain;

namespace CarRental.Infrastructure.Commands
{
    public class UpdateCar
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public string Country { get; set; }
        public int Mileage { get; set; }
        public RegistrationProofCreate RegistrationProof { get; set; }

        public class RegistrationProofCreate
        {
            public int Id { get; set; }
            public DateTime FirstRegistrationDate { get; set; }
            public string Plate { get; set; }
        }
    }
}
