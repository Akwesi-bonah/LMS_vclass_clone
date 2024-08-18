using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace vclass_clone.Models
{
    public class DiscussionTopicDB
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Discussion name is required ")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Course description is required.")]
        [StringLength(255, ErrorMessage = "Course description cannot be longer than 255 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Course id is required.")]
        public Guid CourseId { get; set; }

        public virtual CourseDB Course { get; set; }

        public virtual ICollection<DiscussionPostDB> Posts { get; set; }

        public DiscussionTopicDB()
        {
            Id = Guid.NewGuid();
            Posts = new List<DiscussionPostDB>();
        }
    }
}