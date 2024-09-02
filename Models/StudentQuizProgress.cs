using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vclass_clone.web_form.views;

namespace vclass_clone.Models
{
    public class StudentQuizProgress
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Quiz")]
        public Guid QuizId { get; set; }
        public virtual QuizDB Quiz { get; set; }

        [ForeignKey("Student")]
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int CurrentQuestionIndex { get; set; }
        public Dictionary<Guid, string> Answers { get; set; } = new Dictionary<Guid, string>();

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public StudentQuizProgress()
        {
            Id = Guid.NewGuid();
        }
    }

}