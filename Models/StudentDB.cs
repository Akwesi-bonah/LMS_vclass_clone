using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vclass_clone.Models
{
    public class StudentDB
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Student number is required.")]
        [StringLength(20, ErrorMessage = "Student number cannot be longer than 20 characters.")]
        public string StudentNumber { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [StringLength(10, ErrorMessage = "Gender cannot be longer than 10 characters.")]
        public string Gender { get; set; }

        [StringLength(4, ErrorMessage = "Level cannot be longer than 4 characters.")]
        public string Level { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public virtual UserDB User { get; set; }

        public Guid? GroupId { get; set; }
        public virtual GroupDB Group { get; set; }

        // Navigation property for CourseEnrollments
        public virtual ICollection<CourseEnrollmentDB> Enrollments { get; set; }


        public StudentDB()
        {
            Id = Guid.NewGuid();
            Enrollments = new List<CourseEnrollmentDB>();

        }
    }


}