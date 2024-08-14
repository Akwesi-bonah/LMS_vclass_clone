using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vclass_clone.Models
{
    public class AssignmentDB
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Assignment title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Assignment description is required.")]
        public string Description { get; set; }

        [Required]
        public Guid CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual CourseDB Course { get; set; }



        public DateTime DueDate { get; set; }

        public string FileName {get; set; }

        // Navigation property
        public virtual ICollection<AssignmentSubmissionDB> Submissions { get; set; }

        public AssignmentDB()
        {
            Id = Guid.NewGuid();
            Submissions = new List<AssignmentSubmissionDB>();
        }
    }

}