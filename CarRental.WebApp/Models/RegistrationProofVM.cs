using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.WebApp.Models
{
    public class RegistrationProofVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter First Registration Proof!")]
        public DateTime FirstRegistrationDate { get; set; }
        [Required(ErrorMessage = "Enter Plate!")]
        public string Plate { get; set; }
    }
}
