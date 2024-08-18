using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.facilitator
{
    public partial class DiscussionTopics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDiscussionTopics();
            }
        }

        private void LoadDiscussionTopics()
        {
            string courseIdstr = Session["CourseId"] as string;
            if (Guid.TryParse(courseIdstr, out Guid courseId))
            {
                using (var context = new LMSContext())
                {
                    var topics = context.DiscussionTopics
                        .Where(t => t.CourseId == courseId)
                        .ToList();

                    TopicsRepeater.DataSource = topics;
                    TopicsRepeater.DataBind();
                }

            }

             
        }

        protected void btnCreateTopic_Click(object sender, EventArgs e)
        {
            string courseIdstr = Session["CourseId"] as string;
            if(Guid.TryParse(courseIdstr, out Guid courseId))
                {
                using (var context = new LMSContext())
                {
                    var topic = new DiscussionTopicDB
                    {
                        Title = txtTitle.Text,
                        Description = txtDescription.Text,
                        CourseId = courseId
                    };

                    context.DiscussionTopics.Add(topic);
                    context.SaveChanges();
                }


            }


            Response.Redirect(Request.RawUrl);
        }
    }
}