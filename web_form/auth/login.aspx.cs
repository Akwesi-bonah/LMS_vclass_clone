using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.auth
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            using (var context = new LMSContext())
            {
                UserDB user = context.Users.FirstOrDefault(u => u.Email == email);

                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    
                    Session["UserId"] = user.Id;
                    Session["UserEmail"] = user.Email;

                    // Redirect to the appropriate page based on user role
                    if (user.Role == "Admin")
                    {
                        Response.Redirect(Page.GetRouteUrl("AdminDashboard", null));
                    }
                    else if (user.Role == "Student")
                    {
                        Response.Redirect("~/StudentDashboard.aspx");
                    }
                    else if (user.Role == "Facilitator")
                    {
                        Response.Redirect("~/FacilitatorDashboard.aspx");
                    }
                }
                else
                {
                    lblErrorMessage.Text = "Invalid email or password.";
                    lblErrorMessage.Visible = true;
                }
            }
        }
    }
}