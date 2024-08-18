using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.facilitator
{
    public partial class DiscussionPosts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var topicId = new Guid(Request.QueryString["topicId"]);
                LoadDiscussionPosts(topicId);
            }
        }

        private void LoadDiscussionPosts(Guid topicId)
        {
            using (var context = new LMSContext())
            {
                var posts = context.DiscussionPosts
                    .Where(p => p.DiscussionTopicId == topicId)
                    .Include(p => p.Student)
                    .ToList();

                PostsRepeater.DataSource = posts;
                PostsRepeater.DataBind();
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            var topicId = new Guid(Request.QueryString["topicId"]);
            var studentId = (Guid)Session["Userid"];

            using (var context = new LMSContext())
            {
                var post = new DiscussionPostDB
                {
                    DiscussionTopicId = topicId,
                    StudentId = studentId,
                    Content = txtPostContent.Text
                };

                context.DiscussionPosts.Add(post);
                context.SaveChanges();
            }

            LoadDiscussionPosts(topicId); // Refresh the post list
        }
    }
}