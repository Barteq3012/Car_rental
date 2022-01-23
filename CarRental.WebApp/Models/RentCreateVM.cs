using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.WebApp.Models
{
    public class RentCreateVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Car!")]
        public int CarId { get; set; }
        [Required(ErrorMessage = "Enter Customer!")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Enter Rent Date!")]
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        [Required(ErrorMessage = "Enter Total Cost!")]
        public double TotalCost { get; set; }
    }
}
