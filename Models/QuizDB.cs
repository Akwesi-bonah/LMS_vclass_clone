using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vclass_clone.Models
{
    public class QuizDB
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Course")]
        public Guid? CourseId { get; set; }
        public string Course { get; set; }

        [Required]
        [MaxLength(60)]
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime DueDate { get; set; }

        //public virtual ICollection<Question> Questions { get; set; }

    }

    



}