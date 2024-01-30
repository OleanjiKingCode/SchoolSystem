using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSystem.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.ViewModel.Lecturers
{
    public class LecturerVM
    {

        [DisplayName("Lecturer ID")]
        public int Id { get; set; }

        public string LecturerName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }


    }
}
