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
    public partial class AssignmentEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadAssignmentDetails();
            }
        }

        private void loadAssignmentDetails()
        {
            string assignId = Session["AssignId"] as string;

            if (!string.IsNullOrEmpty(assignId))
            {
                try
                {
                    Guid assigneGuid = Guid.Parse(assignId);

                    using (var context = new LMSContext())
                    {
                        var assignment = context.Assignments.FirstOrDefault(ca => ca.Id == assigneGuid);

                        if (assignment != null)
                        {
                            // Populate the form fields
                            txtAssignmentTitle.Text = assignment.Title;
                            txtAssignmentDescription.Text = assignment.Description;
                            txtDueDate.Text = assignment.DueDate.ToString("yyyy-MM-ddTHH:mm");
                        }
                        else
                        {
                            lblAssignmentMessage.Text = "Assignment not found.";
                            lblAssignmentMessage.CssClass = "alert alert-danger mt-3";
                            lblAssignmentMessage.Visible = true;
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
            else
            {
                lblAssignmentMessage.Text = "Assignment ID is missing.";
                lblAssignmentMessage.CssClass = "alert alert-danger mt-3";
                lblAssignmentMessage.Visible = true;
            }
        }


        protected void btnUpdateAssignment_Click(object sender, EventArgs e)
        {
            try
            {
                string assignId = Session["AssignId"] as string;

                if (!string.IsNullOrEmpty(assignId) && Guid.TryParse(assignId, out Guid assigneGuid))
                {
                    using (var context = new LMSContext())
                    {
                        var assignment = context.Assignments
                            .FirstOrDefault(ca => ca.Id == assigneGuid);

                        if (assignment != null)
                        {
                            assignment.Title = txtAssignmentTitle.Text.Trim();
                            assignment.Description = txtAssignmentDescription.Text.Trim();
                            assignment.DueDate = DateTime.Parse(txtDueDate.Text);

                            if (fileUploadAssignment.HasFile)
                            {
                                string uploadDir = "~/Uploads/Assignments/";
                                string serverPath = Server.MapPath(uploadDir);

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
                                    return;
                                }

                                string fileName = Path.GetFileName(file.FileName);
                                string filePath = Path.Combine(serverPath, fileName);

                                file.SaveAs(filePath);

                                // Store file name in the database
                                assignment.FileName = fileName;
                            }

                            context.SaveChanges();

                            lblAssignmentMessage.Text = "Assignment updated successfully.";
                            lblAssignmentMessage.CssClass = "alert alert-success mt-3";
                            lblAssignmentMessage.Visible = true;
                        }
                        else
                        {
                            lblAssignmentMessage.Text = "Assignment not found.";
                            lblAssignmentMessage.CssClass = "alert alert-danger mt-3";
                            lblAssignmentMessage.Visible = true;
                        }
                    }
                }
                else
                {
                    lblAssignmentMessage.Text = "Invalid assignment ID.";
                    lblAssignmentMessage.CssClass = "alert alert-danger mt-3";
                    lblAssignmentMessage.Visible = true;
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