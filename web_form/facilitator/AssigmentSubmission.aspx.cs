using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.facilitator
{
    public partial class AssigmentSubmission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var assignmentId = Request.QueryString["AssignmentId"];
                if (Guid.TryParse(assignmentId, out var id))
                {
                    //LoadSubmissions(id);
                }
                else
                {
                    // Handle error
                }
            }
        }

        //private void LoadSubmissions(Guid assignmentId)
        //{
        //    using (var context = new LMSContext())
        //    {
        //        var submissions = context.AssignmentSubmissions
        //            .Where(s => s.AssignmentId == assignmentId)
        //            .Include(s => s.Files)
        //            .ToList();

        //        gvSubmissions.DataSource = submissions;
        //        gvSubmissions.DataBind();
        //    }
        //}

    }
}