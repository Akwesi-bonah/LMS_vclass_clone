using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI;

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

        public DateTime Duration { get; set; }

        public virtual ICollection<QuestionDB> Questions { get; set; }

        public QuizDB()
        {
            Id = Guid.NewGuid();
            Questions = new List<QuestionDB>();
        }

    }





}