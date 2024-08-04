using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace vclass_clone.Models
{
    public class FacilitatorDB
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
        [StringLength(255, ErrorMessage = "Address cannot be longer than 50 characters.")]
        public string Address { get; set; }


     
        [Required]
        public Guid UserId { get; set; }
        public virtual UserDB User { get; set; }
        public virtual ICollection<CourseAssignmentDB> CourseAssignments { get; set; }
        public virtual DepartmentDB Department { get; set; }

        public FacilitatorDB()
        {
            Id = Guid.NewGuid();
            CourseAssignments = new List<CourseAssignmentDB>();
        }
    }
}