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

        [Required]
        public Guid? CourseId { get; set; }
        public virtual CourseDB Course { get; set; }

        [Required]
        [MaxLength(60)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime DueDate { get; set; }

        public TimeSpan Duration { get; set; } 
        public int MaxAttempts { get; set; } = 1; 
        public bool IsPublished { get; set; } = false; 
        public int PassingScore { get; set; } = 50; 
        public int TotalMarks { get; set; }
        public virtual ICollection<QuestionDB> Questions { get; set; }
        public virtual ICollection<QuizSubmissionDB> QuizSubmissions { get; set; } 
        public virtual ICollection<StudentQuizProgress> StudentQuizProgresses { get; set; } 
        public QuizDB()
        {
            Id = Guid.NewGuid();
            Questions = new List<QuestionDB>();
            QuizSubmissions = new List<QuizSubmissionDB>();
            StudentQuizProgresses = new List<StudentQuizProgress>();
        }
    }




}