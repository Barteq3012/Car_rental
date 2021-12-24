using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Infrastructure.DTO
{
    public class RegistrationProofDTO
    {
        public int Id { get; set; }
        public DateTime FirstRegistrationDate { get; set; }
        public string Plate { get; set; }
    }
}
