using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vclass_clone.Models
{
    public class CourseAssignmentDB
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid CourseId { get; set; }

        public virtual CourseDB Course { get; set; }

        [Required]
        public Guid FacilitatorId { get; set; }
        public virtual FacilitatorDB Facilitator { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }


        public CourseAssignmentDB()
        {
            Id = Guid.NewGuid();
        }
    }
}