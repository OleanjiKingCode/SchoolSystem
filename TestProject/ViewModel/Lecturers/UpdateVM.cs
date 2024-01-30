using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SchoolSystem.Models;

namespace SchoolSystem.ViewModel.Lecturers
{
    public class UpdateVM
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Lecturer First and Last Name are Required")]
        [MaxLength(50, ErrorMessage = "Name should not be more than 50 Characters")]
        public string LecturerName { get; set; }

        [Required(ErrorMessage = "Phone Number Missing")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Missing")]
        public string Email { get; set; }
    }
}
