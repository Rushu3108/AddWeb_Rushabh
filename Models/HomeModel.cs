using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class HomeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter First Name")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LName { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter EmailID")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Please Enter DOB")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
    }
}