using System.ComponentModel.DataAnnotations;

namespace WebApiSample.DTOs
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password mismatch !")]
        public string  ConfirmPassword { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}