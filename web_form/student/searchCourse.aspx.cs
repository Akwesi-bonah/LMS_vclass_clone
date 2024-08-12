using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.student
{
    public partial class searchCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearchQuery.Text.Trim();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                using (var context = new LMSContext())
                {
                    // Search for courses based on the query
                    var results = context.Courses
                        .Where(c => c.Name.Contains(searchQuery) || c.Code.Contains(searchQuery))
                        .ToList();

                    if (results.Any())
                    {
                        rptSearchResults.DataSource = results;
                        rptSearchResults.DataBind();
                        lblNoResults.Visible = false;
                    }
                    else
                    {
                        rptSearchResults.DataSource = null;
                        rptSearchResults.DataBind();
                        lblNoResults.Visible = true;
                    }
                }
            }
        }

        

        protected void rptSearchResults_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "Enroll")
            {
                Guid courseId = Guid.Parse(e.CommandArgument.ToString());
                Session["SelectedCourseId"] = courseId;

                Response.Redirect(Page.GetRouteUrl("stuEnroll", null));

            }

        }
    }
}