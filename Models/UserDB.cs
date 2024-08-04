using System;
using System.ComponentModel.DataAnnotations;

namespace vclass_clone
{
    public class UserDB
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(255, ErrorMessage = "Password cannot be longer than 255 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        [StringLength(20, ErrorMessage = "Role cannot be longer than 20 characters.")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(10, ErrorMessage = "Status cannot be longer than 10 characters.")]
        public string Status { get; set; }
        public object Admin { get; internal set; }

        public UserDB()
        {
            Id = Guid.NewGuid();
        }
    }
}
