using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.WebApp.Models
{
    public class RentVM
    {
        public int Id { get; set; }
        public CarVM Car { get; set; }
        public CustomerVM Customer { get; set; }
        [Required(ErrorMessage = "Enter Rent Date!")]
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        [Required(ErrorMessage = "Enter Total Cost!")]
        public double TotalCost { get; set; }
    }
}
