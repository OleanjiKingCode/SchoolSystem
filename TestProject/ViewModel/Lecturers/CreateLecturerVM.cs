using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace SchoolSystem.ViewModel.Lecturers
{
    public class CreateLecturerVM
    {
        [Required(ErrorMessage = "Lecturer First and Last Name are Required")]
        [MaxLength(50, ErrorMessage = "Name should not be more than 50 Characters")]
        public string LecturerName { get; set; }

  

        [Required(ErrorMessage = "Phone Number Missing")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Missing")]
        [EmailAddress]
        public string Email { get; set; }


    }
}
