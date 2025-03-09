using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;
using System.Net.Mail;


namespace vclass_clone.web_form.auth
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }



        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Basic validation
            if (string.IsNullOrEmpty(email))
            {
                lblErrorMessage.Text = "Email cannot be empty.";
                lblErrorMessage.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                lblErrorMessage.Text = "Password cannot be empty.";
                lblErrorMessage.Visible = true;
                return;
            }

            // Validate email format
            if (!IsValidEmail(email))
            {
                lblErrorMessage.Text = "Invalid email format.";
                lblErrorMessage.Visible = true;
                return;
            }

            try
            {
                using (var context = new LMSContext())
                {
                    UserDB user = context.Users.FirstOrDefault(u => u.Email == email);

                    if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                    {
                        //if (user.lastLogin == null)
                        //{
                        //    //Response.Redirect(Page.GetRouteUrl("ChangePassword", null));
                        //    return; 
                        //}

                        user.lastLogin = DateTime.Now;
                        context.SaveChanges();

                        Session["UserId"] = user.Id;
                        Session["UserEmail"] = user.Email;

                        System.Diagnostics.Debug.WriteLine("User Role: " + user.Role);

                        switch (user.Role)
                        {
                            case "Admin":
                                Response.Redirect(Page.GetRouteUrl("AdminDashboard", null));
                                break;
                            case "Student":
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
                lblErrorMessage.Text = $"An unexpected error occurred. Please try again later. {ex.Message}";
                lblErrorMessage.Visible = true;
            }
        }

    }
}