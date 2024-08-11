using System;
using System.Collections.Generic;
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
                var assignmentId = Request.QueryString["AssignmentId"];
                if (Guid.TryParse(assignmentId, out var id))
                {
                    LoadAssignment(id);
                }
                else
                {
                    lblMessage.Text = "Invalid assignment ID.";
                    lblMessage.CssClass = "alert alert-danger";
                }
            }
        }

        private void LoadAssignment(Guid assignmentId)
        {
            using (var context = new LMSContext())
            {
                var assignment = context.Assignments.FirstOrDefault(a => a.Id == assignmentId);
                if (assignment != null)
                {
                    txtTitle.Text = assignment.Title;
                    txtDescription.Text = assignment.Description;
                }
                else
                {
                    lblMessage.Text = "Assignment not found.";
                    lblMessage.CssClass = "alert alert-danger";
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var assignmentId = Request.QueryString["AssignmentId"];
            if (Guid.TryParse(assignmentId, out var id))
            {
                using (var context = new LMSContext())
                {
                    var assignment = context.Assignments.FirstOrDefault(a => a.Id == id);
                    if (assignment != null)
                    {
                        assignment.Title = txtTitle.Text;
                        assignment.Description = txtDescription.Text;

                        context.SaveChanges();
                        lblMessage.Text = "Assignment updated successfully.";
                        lblMessage.CssClass = "alert alert-success";
                    }
                    else
                    {
                        lblMessage.Text = "Assignment not found.";
                        lblMessage.CssClass = "alert alert-danger";
                    }
                }
            }
            else
            {
                lblMessage.Text = "Invalid assignment ID.";
                lblMessage.CssClass = "alert alert-danger";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AssignmentList.aspx");
        }

    }
}