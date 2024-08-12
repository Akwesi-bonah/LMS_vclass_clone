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

            try
            {
                using (var context = new LMSContext())
                {
                    // Fetch the user based on the provided email
                    UserDB user = context.Users.FirstOrDefault(u => u.Email == email);

                    // If user exists and the password is correct
                    if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                    {
                        // Set session variables
                        Session["UserId"] = user.Id;
                        Session["UserEmail"] = user.Email;

                        // Redirect to the appropriate page based on user role
                        System.Diagnostics.Debug.WriteLine("User Role: " + user.Role);

                        switch (user.Role)
                        {
                            case "Admin":
                                Response.Redirect(Page.GetRouteUrl("AdminDashboard", null));
                                break;
                            case "student":
                                Response.Redirect(Page.GetRouteUrl("StuDashboard", null));
                                break;
                            case "Facilitator":
                                Response.Redirect(Page.GetRouteUrl("FacDashboard", null));
                                break;
                            default:
                                lblErrorMessage.Text = "User role not recognized.";
                                lblErrorMessage.Visible = true;
                                break;
                        }
                    }
                    else
                    {
                        lblErrorMessage.Text = "Invalid email or password.";
                        lblErrorMessage.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional: integrate logging mechanism)
                lblErrorMessage.Text = "An unexpected error occurred. Please try again later.";
                lblErrorMessage.Visible = true;
            }
        }

    }
}