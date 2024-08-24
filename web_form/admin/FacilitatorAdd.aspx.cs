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
    public partial class FacilitatorAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void goBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.GetRouteUrl("FacilitatorList", null));

        }


        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddFac_Click(object sender, EventArgs e)
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
            string departmentId = departmentList.SelectedValue;

            // Validate form data
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
                password != confirmPassword || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(departmentId))
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
                    bool emailExists = context.Users.Any(u => u.Email == email);
                    bool phoneExists = context.Facilitators.Any(f => f.Phone == phone);

                    if (emailExists || phoneExists)
                    {
                        lblError.Text = emailExists ? "Email already exists." : "Phone number already exists.";
                        lblError.Visible = true;
                        return;
                    }

                    // Hash the password
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                    // Retrieve the department object
                    var department = context.Departments.SingleOrDefault(dep => dep.Id == new Guid(departmentId));
                    if (department == null)
                    {
                        lblError.Text = "Selected department does not exist.";
                        lblError.Visible = true;
                        return;
                    }

                    // Create a new User object
                    var newUser = new UserDB
                    {
                        Email = email,
                        Password = hashedPassword,
                        Role = "Facilitator",
                        Status = "Active"
                    };

                    // Save newUser to the database to generate Id
                    context.Users.Add(newUser);
                    context.SaveChanges();

                    // Create a new Facilitator object with the generated UserId
                    var newFac = new FacilitatorDB
                    {
                        UserId = newUser.Id,
                        FirstName = firstName,
                        LastName = lastName,
                        Phone = phone,
                        Address = address,
                        Department = department
                    };

                    context.Facilitators.Add(newFac);
                    context.SaveChanges();

                    Response.Redirect(Page.GetRouteUrl("FacilitatorList", null));
                }
            }
            catch (Exception ex)
            {
                lblError.Text = $"An error occurred while saving the facilitator. Please try again. {ex.Message}";
                lblError.Visible = true;
                // Consider logging the exception details here
            }
        }

    }
}