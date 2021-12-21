using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public Company Company { get; set; }

    }
}
