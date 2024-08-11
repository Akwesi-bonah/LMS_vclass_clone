using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vclass_clone.Models
{
    public class CourseMaterialDB
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Material title is required.")]
        [StringLength(150, ErrorMessage = "Title cannot be longer than 150 characters.")]
        public string Title { get; set; }

        
        public string Content { get; set; }

        [Required]
        public Guid CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual CourseDB Course { get; set; }

        // Navigation property for related files
        public virtual ICollection<CourseMaterialFileDB> Files { get; set; }

        public DateTime UploadedDate { get; set; } = DateTime.Now;

        public CourseMaterialDB()
        {
            Id = Guid.NewGuid();

            Files = new List<CourseMaterialFileDB>();

        }
    }

}