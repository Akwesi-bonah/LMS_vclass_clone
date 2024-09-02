using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vclass_clone.Models
{
    public class QuizSubmissionDB
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid QuizId { get; set; }
        public virtual QuizDB Quiz { get; set; }

        [Required]
        public Guid StudentId { get; set; }
        public virtual StudentDB Student { get; set; }

        public DateTime SubmissionDate { get; set; }

        public int Score { get; set; } = 0;

        public bool IsCompleted { get; set; } = false; // Indicates if the student has completed the quiz

        public QuizSubmissionDB()
        {
            Id = Guid.NewGuid();
            SubmissionDate = DateTime.Now;
        }
    }
}