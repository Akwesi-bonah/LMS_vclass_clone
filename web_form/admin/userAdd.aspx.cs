using System;
using System.Collections.Generic;
using vclass_clone.Models;
using vclass_clone.include;
using System.Linq;

namespace vclass_clone.web_form.admin
{
    public partial class userAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddAdmin_Click(object sender, EventArgs e)
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
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
                password != confirmPassword || string.IsNullOrEmpty(address))
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

            if (!validator.IsStrongPassword(password))
            {
                lblError.Text = "Password must be at least 8 characters long and contain a mix of letters and numbers.";
                lblError.Visible = true;
                return;
            }

            try
            {
                using (var context = new LMSContext())
                {
                    // Check if email or phone number already exists
                    bool emailExists = context.Users.Any(a => a.Email == email);
                    bool phoneExists = context.Admins.Any(a => a.Phone == phone);

                    if (emailExists || phoneExists)
                    {
                        lblError.Text = emailExists ? "Email already exists." : "Phone number already exists.";
                        lblError.Visible = true;
                        return;
                    }

                    // Hash the password
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                    // Create a new User object
                    var newUser = new UserDB
                    {
                        Email = email,
                        Password = hashedPassword,
                        Role = "Admin",
                        Status = "Active"
                    };

                    // Save newUser to the database to generate Id
                    context.Users.Add(newUser);
                    context.SaveChanges();

                    // Create a new Admin object with the generated UserId
                    var newAdmin = new AdminDB
                    {
                        UserId = newUser.Id,
                        FirstName = firstName,
                        LastName = lastName,
                        Phone = phone,
                        Address = address,
                    };

                    context.Admins.Add(newAdmin);
                    context.SaveChanges();
                }

                // Redirect to Admin List
                Response.Redirect(Page.GetRouteUrl("AdminList", null));
            }
            catch (Exception ex)
            {
                lblError.Text = "An error occurred while saving the administrator. Please try again.";
                lblError.Visible = true;
               
            }
        }

        protected void goBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.GetRouteUrl("AdminList", null));

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