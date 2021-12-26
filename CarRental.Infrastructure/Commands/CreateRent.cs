﻿using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Core.Domain;

namespace CarRental.Infrastructure.Commands
{
    public class CreateRent
    {
        public int Id { get; set; }
        Car Car { get; set; }
        Customer Customer { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public double TotalCost { get; set; }
    }
}
