﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Domain
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}