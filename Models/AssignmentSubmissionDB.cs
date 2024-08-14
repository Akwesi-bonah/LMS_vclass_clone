using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vclass_clone.Models
{
    public class AssignmentSubmissionDB
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid AssignmentId { get; set; }

        [ForeignKey("AssignmentId")]
        public virtual AssignmentDB Assignment { get; set; }

        [Required]
        public Guid StudentId { get; set; } 

        [ForeignKey("StudentId")]
        public virtual StudentDB Student { get; set; } 

        public string Content { get; set; }

        public DateTime SubmissionDate { get; set; } = DateTime.Now;
        public bool IsSubmitted { get; set; } = false;


        public AssignmentSubmissionDB()
        {
            Id = Guid.NewGuid();
        }
    }
}