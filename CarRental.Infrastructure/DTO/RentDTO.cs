using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Infrastructure.DTO
{
    public class RentDTO
    {
        public int Id { get; set; }
        public CarDTO Car  { get; set; }
        public CustomerDTO Customer  { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public double TotalCost { get; set; }
    }
}
