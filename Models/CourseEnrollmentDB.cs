using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vclass_clone.Models
{
    public class CourseEnrollmentDB
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public Guid StudentId { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        // Optional: Store additional information like grades, enrollment status, etc.
        public string Status { get; set; }

        // Navigation Properties
        public virtual CourseDB Course { get; set; }
        public virtual StudentDB Student { get; set; }

        // Constructor
        public CourseEnrollmentDB()
        {
            Id = Guid.NewGuid();
        }
    }
}