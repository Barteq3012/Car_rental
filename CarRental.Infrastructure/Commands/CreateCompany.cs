using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Core.Domain;

namespace CarRental.Infrastructure.Commands
{
    public class CreateCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}
