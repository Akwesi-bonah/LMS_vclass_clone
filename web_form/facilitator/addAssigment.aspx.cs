using System;
using System.Collections.Generic;
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

        protected void btnCreateAssignment_Click(object sender, EventArgs e)
        {
            
                string courseId = Request.QueryString["courseId"];
                string assignmentTitle = txtAssignmentTitle.Text.Trim();
                string assignmentDescription = txtAssignmentDescription.Text.Trim();
                DateTime dueDate;

                if (!string.IsNullOrEmpty(courseId) && !string.IsNullOrEmpty(assignmentTitle) && DateTime.TryParse(txtDueDate.Text, out dueDate))
                {
                    using (var context = new LMSContext())
                    {
                        Guid courseGuid = Guid.Parse(courseId);
                        var assignment = new AssignmentDB
                        {
                            CourseId = courseGuid,
                            Title = assignmentTitle,
                            Description = assignmentDescription,
                            DueDate = dueDate
                        };
                        context.Assignments.Add(assignment);
                        context.SaveChanges();
                        lblAssignmentMessage.Text = "Assignment created successfully.";
                        lblAssignmentMessage.Visible = true;
                    }
                }
                else
                {
                    lblAssignmentMessage.Text = "Please fill all fields correctly.";
                    lblAssignmentMessage.Visible = true;
                }
            

        }
    }
}