using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Core.Domain;

namespace CarRental.Infrastructure.Commands
{
    public class CreateRegistrationProof
    {
        public int Id { get; set; }
        public DateTime FirstRegistrationDate { get; set; }
        public string Plate { get; set; }
    }
}
