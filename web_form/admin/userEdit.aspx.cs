using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.include;
using vclass_clone.Models;

namespace vclass_clone.web_form.admin
{
    public partial class adminUpdate : System.Web.UI.Page
    {
        string adminIdstr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the ID from query string
                if (!IsPostBack)
                {
                     adminIdstr = Session["AdminId"] as string;
                    Guid adminId;
                    if (Guid.TryParse(adminIdstr, out adminId))
                    {
                        LoadAdminData(adminId);
                    }
                    else
                    {
                        lblError.Text = $"Invalid Admin ID.{adminId} " ;
                        lblError.Visible = true;
                    }
                }
            }
        }

        private void LoadAdminData(Guid adminId)
        {
            try
            {
                using (var context = new LMSContext())
                {
                    var admin = context.Admins.Include("User").SingleOrDefault(a => a.Id == adminId);
                    if (admin != null)
                    {
                        hfAdminId.Value = admin.Id.ToString();
                        txtFirstName.Text = admin.FirstName;
                        txtLastName.Text = admin.LastName;
                        txtPhone.Text = admin.Phone;
                        txtAddress.Text = admin.Address;
                        txtEmail.Text = admin.User.Email;
                    }
                    else
                    {
                        lblError.Text = "Admin not found.";
                        lblError.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }

          
        }

        protected void goBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.GetRouteUrl("AdminList", null));
        }

        protected void btnUpdateAdmin_Click(object sender, EventArgs e)
        {
            Validate validator = new Validate();
            // Retrieve form data
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtAddress.Text.Trim();
            string password = txtPwd.Text.Trim();
            string confirmPassword = txtCpwd.Text.Trim();

            // Validate form data
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address)
                )
            {
                lblError.Text = "Please fill all required fields and ensure passwords match.";
                lblError.Visible = true;
                return;
            }

            if (!validator.IsValidEmail(email))
            {
                lblError.Text = "Invalid email address.";
                lblError.Visible = true;
                return;
            }

            if (!validator.IsValidPhone(phone))
            {
                lblError.Text = "Invalid phone number.";
                lblError.Visible = true;
                return;
            }

            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(confirmPassword))
            {
                // Check if passwords match
                if (password != confirmPassword)
                {
                    lblError.Text = "Passwords do not match.";
                    lblError.Visible = true;
                    return;
                }

                // Check if password is strong enough
                if (!validator.IsStrongPassword(password))
                {
                    lblError.Text = "Password must be at least 8 characters long and contain a mix of letters and numbers.";
                    lblError.Visible = true;
                    return;
                }
            }




            try
            {
                using (var context = new LMSContext())
                {
                    Guid adminId = Guid.Parse(hfAdminId.Value);

                    // Check if email exists in Users table, excluding current admin
                    bool emailExists = context.Users
                        .Where(a => a.Email == email)
                        .Any(a => !context.Admins.Any(adm => adm.UserId == a.Id && adm.Id == adminId));

                    // Check if phone exists in Admins table, excluding current admin
                    bool phoneExists = context.Admins
                        .Any(a => a.Phone == phone && a.Id != adminId);

                    if (emailExists || phoneExists)
                    {
                        lblError.Text = emailExists ? "Email already exists." : "Phone number already exists.";
                        lblError.Visible = true;
                        return;
                    }


                    // Retrieve the admin from the database
                    var adminEntity = context.Admins.Include("User").SingleOrDefault(a => a.Id == adminId);

                    if (adminEntity != null)
                    {
                        // Update the admin details
                        adminEntity.FirstName = firstName;
                        adminEntity.LastName = lastName;
                        adminEntity.Phone = phone;
                        adminEntity.Address = address;
                        adminEntity.User.Email = email;

                        if (password != null)
                        {
                            // Hash the password
                            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                            adminEntity.User.Password = hashedPassword;
                        }

                        // Save changes
                        context.SaveChanges();

                        // Redirect to the admin list page
                        Response.Redirect(Page.GetRouteUrl("AdminList", null));
                   
                    }
                    else
                    {
                        lblError.Text = "Admin not found.";
                        lblError.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }






        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all text boxes
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPwd.Text = string.Empty;
            txtCpwd.Text = string.Empty;

            lblError.Visible = false;
        }
    }
}