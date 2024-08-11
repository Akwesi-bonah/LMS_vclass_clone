using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vclass_clone.Models
{
    public class CourseMaterialFileDB
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "File path is required.")]
        public string FilePath { get; set; }

        [Required(ErrorMessage = "File name is required.")]
        public string FileName { get; set; }

        public Guid MaterialId { get; set; }

        [ForeignKey("MaterialId")]
        public virtual CourseMaterialDB CourseMaterial { get; set; }

        public DateTime UploadedDate { get; set; } = DateTime.Now;

        
        public CourseMaterialFileDB()
        {
            Id = Guid.NewGuid();
        }
    }

}