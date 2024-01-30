using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models
{
    public class Lecturer
    {
        public int Id { get; set; }
        public string LecturerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
