using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.WebApp.Models
{
    public class CustomerVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter SecondName!")]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Enter Birth Date!")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Enter Country!")]
        public string Country { get; set; }
        public CompanyVM Company { get; set; }
    }
}
