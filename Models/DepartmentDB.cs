using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vclass_clone.Models
{
    public class DepartmentDB
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = " name is required.")]
        [StringLength(255, ErrorMessage = "name cannot be longer than 255 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(255, ErrorMessage = "Description  cannot be longer than 255 characters.")]
        public string Description { get; set; }
    }
}