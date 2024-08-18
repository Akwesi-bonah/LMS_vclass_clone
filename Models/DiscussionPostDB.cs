using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vclass_clone.Models
{
    public class DiscussionPostDB
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid DiscussionTopicId { get; set; }

        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PostDate { get; set; }

        public virtual DiscussionTopicDB DiscussionTopic { get; set; }
        public virtual StudentDB Student { get; set; }

        public DiscussionPostDB()
        {
            Id = Guid.NewGuid();
            PostDate = DateTime.Now;
        }
    }
}