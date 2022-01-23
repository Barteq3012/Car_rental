using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.WebApp.Models
{
    public class CarVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Brand!")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Enter Model!")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Enter Production Date!")]
        public DateTime ProductionDate { get; set; }
        [Required(ErrorMessage = "Enter Country!")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Enter Mileage!")]
        public int Mileage { get; set; }
        [Required(ErrorMessage = "Enter RegistrationProof!")]
        public RegistrationProofVM RegistrationProof { get; set; }
    }
}
