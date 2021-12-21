using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Domain
{
    public class RegistrationProof
    {
        public int Id { get; set; }
        public DateTime FirstRegistrationDate { get; set; }
        public string Plate { get; set; }
        public Car Car { get; set; }
    }
}
