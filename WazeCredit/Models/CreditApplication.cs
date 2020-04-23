using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WazeCredit.Models
{
    public class CreditApplication
    {
        public int Id { get; set; }
        [Required]
        public string SSN { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Required]
        public int PostalCode { get; set; }
        [Required]
        public double Salary { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public string Name { get; set; }
        public double CreditApproved { get; set; }
    }
}
