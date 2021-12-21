﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Domain
{
    public class Rent
    {
        public int Id { get; set; }
        Car Car { get; set; }
        Customer Customer { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public double TotalCost { get; set; }
    }
}
