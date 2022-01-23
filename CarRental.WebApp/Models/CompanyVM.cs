using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.WebApp.Models
{
    public class CompanyVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Address!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Country!")]
        public string Country { get; set; }
    }
}
