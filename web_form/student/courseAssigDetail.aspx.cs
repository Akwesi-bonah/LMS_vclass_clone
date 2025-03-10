﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.student
{
    public partial class courseAssigDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourseAndAssignmentDetails();
            }
        }

        private void LoadCourseAndAssignmentDetails()
        {
            string assignmentId = Session["AssignmentID"] as string;
            var studentId = Session["UserId"] as Guid?;

            if (Guid.TryParse(assignmentId, out Guid assignmentGuid))
            {
                using (var context = new LMSContext())
                {
                    // Fetch assignment and course details
                    var assignment = context.Assignments
                        .Where(a => a.Id == assignmentGuid)
                        .Select(a => new
                        {
                            a.Title,
                            a.Description,
                            a.DueDate,
                            a.FileName,
                            CourseTitle = a.Course.Name,
                            CourseDescription = a.Course.Description
                        })
                        .FirstOrDefault();

                    if (assignment != null)
                    {
                        // Set course details
                        lblCourseTitle.Text = assignment.CourseTitle;
                        lblCourseDescription.Text = assignment.CourseDescription;

                        // Set assignment details
                        lblAssignmentTitle.Text = assignment.Title;
                        lblAssignmentDescription.Text = assignment.Description;
                        lblAssignmentDueDate.Text = assignment.DueDate.ToString("MMMM dd, yyyy");
                        lnkAssignmentFile.NavigateUrl = "~/uploads/Assignments/" + assignment.FileName;

                        // Check if the student has already submitted this assignment
                        var submission = context.AssignmentSubmissions
                            .Where(s => s.AssignmentId == assignmentGuid && s.StudentId == studentId)
                            .FirstOrDefault();

                        if (submission != null)
                        {
                            pnlSubmissionStatus.Visible = true;
                            lblSubmissionDate.Text = submission.SubmissionDate.ToString("MMMM dd, yyyy HH:mm");
                        }

                        // Check if the deadline has passed
                        if (DateTime.Now > assignment.DueDate)
                        {
                            pnlDeadlinePassed.Visible = true;
                            pnlSubmissionForm.Visible = false;
                            btnResubmitAssignment.Visible = false;
                        }
                        else
                        {
                            pnlSubmissionForm.Visible = submission == null; 
                            btnResubmitAssignment.Visible = submission != null; 
                        }
                    }
                    else
                    {
                        // Handle assignment not found
                        Response.Redirect("~/ErrorPage.aspx");
                    }
                }
            }
        }

        protected void btnSubmitAssignment_Click(object sender, EventArgs e)
        {
            if (fileUploadSubmission.HasFile)
            {
                string filePath = "~/Uploads/Submission/" + fileUploadSubmission.FileName;
                fileUploadSubmission.SaveAs(Server.MapPath(filePath));

                string assignmentIdStr = Session["AssignmentID"] as string;
                var userId = (Guid)Session["UserId"];

                if (Guid.TryParse(assignmentIdStr, out Guid assignmentId))
                {
                    using (var context = new LMSContext())
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            // Get student ID using user ID
                            var student = context.Students.FirstOrDefault(st => st.UserId == userId);

                            if (student != null)
                            {
                                var existingSubmission = context.AssignmentSubmissions
                                    .FirstOrDefault(s => s.AssignmentId == assignmentId && s.StudentId == student.Id);

                                if (existingSubmission != null)
                                {
                                    // Update existing submission
                                    existingSubmission.Content = fileUploadSubmission.FileName;
                                    existingSubmission.SubmissionDate = DateTime.Now;
                                    existingSubmission.IsSubmitted = true;
                                }
                                else
                                {
                                    // Create new submission
                                    var submission = new AssignmentSubmissionDB
                                    {
                                        AssignmentId = assignmentId,
                                        StudentId = student.Id,
                                        Content = fileUploadSubmission.FileName,
                                        SubmissionDate = DateTime.Now,
                                        IsSubmitted = true
                                    };
                                    context.AssignmentSubmissions.Add(submission);
                                }

                                context.SaveChanges();
                                // Commit the transaction if everything is successful
                                transaction.Commit();
                            }
                            else
                            {
                                // Handle case where student is not found
                                Response.Redirect("~/ErrorPage.aspx");
                            }
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction if any error occurs
                            transaction.Rollback();
                            // Log the exception (ex) if necessary, and handle the error
                            Debug.WriteLine(ex.Message);
                            Response.Redirect("~/ErrorPage.aspx");
                        }
                    }

                    // Reload the page to reflect changes
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    // Handle the case where assignmentIdStr is not a valid GUID
                    Response.Redirect("~/ErrorPage.aspx");
                }
            }
        }


    }
}