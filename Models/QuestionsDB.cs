using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vclass_clone.Models
{
        public class QuestionDB
        {
            [Key]
            public Guid Id { get; set; }

            [ForeignKey("Quiz")]
            public Guid QuizId { get; set; }
            public virtual QuizDB Quiz { get; set; }

            [Required]
            public string QuestionText { get; set; }

            [Required]
            public string Option1 { get; set; }

            [Required]
            public string Option2 { get; set; }

            public string Option3 { get; set; } = String.Empty;

            public string Option4 { get; set; } = String.Empty;

            [Required]
            public string Answer { get; set; }

            //public virtual ICollection<StudentQuizAnswer> StudentQuizAnswers { get; set; }



        public QuestionDB()
            {
                Id = Guid.NewGuid();
            }
    }

    
}

