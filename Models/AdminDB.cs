using System;
using System.ComponentModel.DataAnnotations;

namespace vclass_clone
{
    public class AdminDB
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(50, ErrorMessage = "Phone number cannot be longer than 50 characters.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(50, ErrorMessage = "Address cannot be longer than 50 characters.")]
        public string Address { get; set; }


        [Required]
        public Guid UserId { get; set; }
        public virtual UserDB User { get; set; }

        public AdminDB()
        {
            Id = Guid.NewGuid();

        }
    }
}
