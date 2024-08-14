using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.facilitator
{
    public partial class addAssigment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddAssignment_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                if (string.IsNullOrEmpty(txtAssignmentTitle.Text.Trim()) ||
                    string.IsNullOrEmpty(txtAssignmentDescription.Text.Trim()) ||
                    !DateTime.TryParse(txtDueDate.Text, out DateTime dueDate))
                {
                    lblAssignmentMessage.Text = "Please fill all fields correctly.";
                    lblAssignmentMessage.CssClass = "alert alert-danger mt-3";
                    lblAssignmentMessage.Visible = true;
                    return;
                }

                // Retrieve CourseId from session
                if (Session["CourseId"] == null || !Guid.TryParse(Session["CourseId"].ToString(), out Guid courseId))
                {
                    lblAssignmentMessage.Text = "Invalid course. Please try again.";
                    lblAssignmentMessage.CssClass = "alert alert-danger mt-3";
                    lblAssignmentMessage.Visible = true;
                    return;
                }

                using (var context = new LMSContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            // Create the assignment
                            var assignment = new AssignmentDB
                            {
                                CourseId = courseId,
                                Title = txtAssignmentTitle.Text.Trim(),
                                Description = txtAssignmentDescription.Text.Trim(),
                                DueDate = dueDate
                            };

                            // Check if any files are uploaded
                            if (fileUploadAssignment.HasFile)
                            {
                                string uploadDir = "~/Uploads/Assignments/";
                                string serverPath = Server.MapPath(uploadDir);

                                // Ensure the directory exists
                                if (!Directory.Exists(serverPath))
                                {
                                    Directory.CreateDirectory(serverPath);
                                }

                                var file = fileUploadAssignment.PostedFile;
                                if (file.ContentLength > 524288000) // 500MB limit
                                {
                                    lblAssignmentMessage.Text = "Error: The file exceeds the 500MB size limit.";
                                    lblAssignmentMessage.CssClass = "alert alert-danger mt-3";
                                    lblAssignmentMessage.Visible = true;
                                    transaction.Rollback();
                                    return;
                                }

                                string fileName = Path.GetFileName(file.FileName);
                                string filePath = Path.Combine(serverPath, fileName);

                                file.SaveAs(filePath);

                                // Store file name in the database
                                assignment.FileName = fileName;
                            }

                            // Add the assignment to the database
                            context.Assignments.Add(assignment);
                            context.SaveChanges();

                            // Commit the transaction
                            transaction.Commit();

                            txtAssignmentTitle.Text = string.Empty;
                            txtAssignmentDescription.Text = string.Empty;
                            txtDueDate.Text = string.Empty;
                            fileUploadAssignment.Attributes.Clear();

                            lblAssignmentMessage.Text = "Assignment created successfully.";
                            lblAssignmentMessage.CssClass = "alert alert-success mt-3";
                            lblAssignmentMessage.Visible = true;

                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // Rollback the transaction in case of an error
                            lblAssignmentMessage.Text = $"Error: {ex.Message}";
                            lblAssignmentMessage.CssClass = "alert alert-danger mt-3";
                            lblAssignmentMessage.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblAssignmentMessage.Text = $"Error: {ex.Message}";
                lblAssignmentMessage.CssClass = "alert alert-danger mt-3";
                lblAssignmentMessage.Visible = true;
            }
        }

        
    }
}