using SchoolSystem.ViewModel.Lecturers;
using System.ComponentModel.DataAnnotations;


namespace SchoolSystem.ViewModel.Accounts
{
    public class RegisterVM : CreateLecturerVM
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password",
            ErrorMessage = "Passwords do not match")]

        public string ConfirmPassword { get; set; }

    }
}
