using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

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
            using (var context = new LMSContext())
            {
                var assignments = context.Assignments.ToList();
                gvAssignments.DataSource = assignments;
                gvAssignments.DataBind();
            }
        }

        protected void gvAssignments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                var assignmentId = e.CommandArgument.ToString();
                Response.Redirect($"~/EditAssignment.aspx?AssignmentId={assignmentId}");
            }
            else if (e.CommandName == "ViewSubmissions")
            {
                var assignmentId = e.CommandArgument.ToString();
                Response.Redirect($"~/SubmissionList.aspx?AssignmentId={assignmentId}");
            }
        }

    }
}