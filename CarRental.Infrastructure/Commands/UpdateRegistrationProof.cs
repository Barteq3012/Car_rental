using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Core.Domain;

namespace CarRental.Infrastructure.Commands
{
    public class UpdateRegistrationProof
    {
        public DateTime FirstRegistrationDate { get; set; }
        public string Plate { get; set; }
    }
}
