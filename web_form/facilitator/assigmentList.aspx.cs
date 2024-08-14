using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;
using System.Text.RegularExpressions;


namespace vclass_clone.web_form.facilitator
{
    public partial class assigmentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAssignments();
            }
        }

        private void LoadAssignments()
        {
            try
            {
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
                    // Retrieve assignments for the specific course from the database
                    var assignments = context.Assignments
                                             .Where(a => a.CourseId == courseId)
                                             .ToList();

                    if (assignments.Count == 0)
                    {
                        lblAssignmentMessage.Text = "No assignments found for this course.";
                        lblAssignmentMessage.CssClass = "alert alert-info mt-3";
                        lblAssignmentMessage.Visible = true;
                    }

                    // Bind the assignments to the GridView
                    gvAssignments.DataSource = assignments;
                    gvAssignments.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log it and show an error message)
                lblAssignmentMessage.Text = $"Error loading assignments: {ex.Message}";
                lblAssignmentMessage.CssClass = "alert alert-danger mt-3";
                lblAssignmentMessage.Visible = true;
            }
        }


    protected void gvAssignments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                string contentId = e.CommandArgument.ToString();

                if (!string.IsNullOrEmpty(contentId))
                {
                    Session["AssignId"] = contentId;
                    // Redirect to the edit page
                    Response.Redirect(Page.GetRouteUrl("FacCourseAssignEdit", null));
                }
                else
                {
                    lblAssignmentMessage.Text = "Course or content ID is missing.";
                    lblAssignmentMessage.CssClass = "alert alert-danger";
                    lblAssignmentMessage.Visible = true;
                }
            }
            else if (e.CommandName == "ViewSubmissions")
            {
                string contentId = e.CommandArgument.ToString();

                if (!string.IsNullOrEmpty(contentId))
                {
                    Session["AssignId"] = contentId;
                    // Redirect to the edit page
                    Response.Redirect(Page.GetRouteUrl("FacCourseAssignSubmission", null));
                }
                else
                {
                    lblAssignmentMessage.Text = "Course or content ID is missing.";
                    lblAssignmentMessage.CssClass = "alert alert-danger";
                    lblAssignmentMessage.Visible = true;
                }
            }
        }

        protected void btnAddAssignment_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.GetRouteUrl("FacCourseAssignAdd", null));
        }
    }
}