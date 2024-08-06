using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace vclass_clone.Models
{
    public class GroupDB
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "name is required.")]
        [StringLength(255, ErrorMessage = "name cannot be longer than 255 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(255, ErrorMessage = "Description  cannot be longer than 255 characters.")]
        public string Description { get; set; }

        // Foreign key property
        public Guid DepartmentId { get; set; }
        public virtual DepartmentDB Department { get; set; }

        public virtual ICollection<StudentDB> Students { get; set; }

        public GroupDB()
        {
            Id = Guid.NewGuid();
            Students = new List<StudentDB>();
        }

    }
}