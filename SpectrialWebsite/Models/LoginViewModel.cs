namespace SpectrialWebsite.Models
{
    using System.ComponentModel.DataAnnotations;      

    public class LoginViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "This field must be a valid email")]
        public string Email { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(255)]
        public string Content { get; set; }
    }
}