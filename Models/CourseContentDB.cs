using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vclass_clone.Models
{
    public class CourseContentDB
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Content title is required.")]
        [StringLength(150, ErrorMessage = "Title cannot be longer than 150 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content description is required.")]
        public string Description { get; set; }

        [Required]
        public Guid CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual CourseDB Course { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}