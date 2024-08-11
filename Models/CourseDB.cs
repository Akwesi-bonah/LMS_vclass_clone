using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vclass_clone.Models
{
    public class CourseDB
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Course name is required.")]
        [StringLength(100, ErrorMessage = "Course name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Course code is required.")]
        [StringLength(20, ErrorMessage = "Course code cannot be longer than 20 characters.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Course description is required.")]
        [StringLength(255, ErrorMessage = "Course description cannot be longer than 255 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Course level is required.")]
        [StringLength(4, ErrorMessage = "Level cannot be longer than 4 characters.")]
        public string Level { get; set; }


        [StringLength(20, ErrorMessage = "Enrollment key cannot be more than 20 character.")]
        public string EnrollmentKey { set; get; } = string.Empty;

        public string ImagePath { get; set; }

        public virtual ICollection<CourseAssignmentDB> CourseAssignments { get; set; }

        // Constructor to initialize default values
        public CourseDB()
        {
            Id = Guid.NewGuid();
            CourseAssignments = new List<CourseAssignmentDB>();
        }
    }
}