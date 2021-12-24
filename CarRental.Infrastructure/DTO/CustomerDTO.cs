using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Infrastructure.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public CompanyDTO CompanyDTO  { get; set; }

    }
}
