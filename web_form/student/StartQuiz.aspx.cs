using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.student
{
    public partial class StartQuiz : Page
    {
        private Dictionary<Guid, int> questionIndexMap;

        private int CurrentPage
        {
            get => (int)(ViewState["CurrentPage"] ?? 0);
            set => ViewState["CurrentPage"] = value;
        }

        private int TotalPages
        {
            get => (int)(ViewState["TotalPages"] ?? 1);
            set => ViewState["TotalPages"] = value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadQuiz();
        }

        private void LoadQuiz()
        {
            var quizId = Session["SelectedQuizId"] as string;
            var studentId = (Guid)Session["UserId"];

            if (Guid.TryParse(quizId, out var parsedQuizId))
                using (var context = new LMSContext())
                {
                    var questions = context.Questions
                        .Where(q => q.QuizId == parsedQuizId)
                        .OrderBy(q => q.Id)
                        .ToList();

                    // Create mapping from GUID to integer index
                    questionIndexMap = questions.Select((q, index) => new { q.Id, Index = index })
                        .ToDictionary(x => x.Id, x => x.Index);

                    TotalPages = questions.Count; // Number of questions

                    rptQuestions.DataSource = questions;
                    rptQuestions.DataBind();

                    // Restore saved progress
                    //LoadSavedProgress(studentId, parsedQuizId);
                    DisplayPage(CurrentPage);
                }
        }


        private void DisplayPage(int pageIndex)
        {
            var questionPages = rptQuestions.Controls.OfType<RepeaterItem>().ToList();
            for (var i = 0; i < questionPages.Count; i++) questionPages[i].Visible = i == pageIndex;

            lblPageNumber.Text = $"Page {CurrentPage + 1} of {TotalPages}";

            btnPrevious.Enabled = CurrentPage > 0;
            btnNext.Enabled = CurrentPage < TotalPages - 1;
        }

        //private void SaveProgress()
        //{
        //    var quizId = Request.QueryString["quizId"];
        //    var studentId = (Guid)Session["UserId"];
        //   // var selectedOption = rblOptions.SelectedValue;

        //    using (var context = new LMSContext())
        //    {
        //        var progress = context.StudentQuizProgresses
        //            .FirstOrDefault(p => p.QuizId == Guid.Parse(quizId) && p.StudentId == studentId);

        //        if (progress == null)
        //        {
        //            progress = new StudentQuizProgress
        //            {
        //                QuizId = Guid.Parse(quizId),
        //                StudentId = studentId
        //            };
        //            context.StudentQuizProgresses.Add(progress);
        //        }

        //        progress.CurrentQuestionIndex = CurrentPage;
        //        var questionId = GetCurrentQuestionId(); // Method to get the current question ID
        //        if (selectedOption != null)
        //        {
        //            if (progress.Answers.ContainsKey(questionId))
        //            {
        //                progress.Answers[questionId] = selectedOption;
        //            }
        //            else
        //            {
        //                progress.Answers.Add(questionId, selectedOption);
        //            }
        //        }

        //        context.SaveChanges();
        //    }
        //}

        private Guid GetCurrentQuestionId()
        {
            var questionItems = rptQuestions.Controls.OfType<RepeaterItem>().ToList();
            var currentItem = questionItems[CurrentPage];
            var questionId = new Guid(((HiddenField)currentItem.FindControl("hfQuestionId")).Value);
            return questionId;
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 0)
            {
                CurrentPage--;
                DisplayPage(CurrentPage);
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (CurrentPage < TotalPages - 1)
            {
                CurrentPage++;
                DisplayPage(CurrentPage);
            }
        }
    }
}