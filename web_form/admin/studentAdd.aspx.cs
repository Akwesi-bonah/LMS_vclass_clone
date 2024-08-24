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
    public partial class studentAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void goBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.GetRouteUrl("StudentList", null));
        }

        protected void btnAddFac_Click(object sender, EventArgs e)
        {
            Validate validator = new Validate();

            // Retrieve form data
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string studentNumber = txtStNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            string gender = dbgender.SelectedValue;
            string level = dpLevel.SelectedValue;
            string group = dbgroup.SelectedValue;
            string password = txtPwd.Text.Trim();
            string confirmPassword = txtCpwd.Text.Trim();


            // Validate form data
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
                password != confirmPassword || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(group))
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

            if (!validator.IsValidPhone(studentNumber))
            {
                lblError.Text = "Invalid Student number.";
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
                    bool emailExists = context.Users.Any(u => u.Email == email);
                    bool phoneExists = context.Students.Any(f => f.StudentNumber == studentNumber);

                    if (emailExists || phoneExists)
                    {
                        lblError.Text = emailExists ? "Email already exists." : "student number already exists.";
                        lblError.Visible = true;
                        return;
                    }

                    // Hash the password
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                    // Retrieve the department object
                    var groundId = context.Groups.SingleOrDefault(dep => dep.Id == new Guid(group));
                    if (groundId == null)
                    {
                        lblError.Text = "Selected Student Group does not exist.";
                        lblError.Visible = true;
                        return;
                    }

                    // Create a new User object
                    var newUser = new UserDB
                    {
                        Email = email,
                        Password = hashedPassword,
                        Role = "Student",
                        Status = "Active"
                    };

                    // Save newUser to the database to generate Id
                    context.Users.Add(newUser);
                    context.SaveChanges();

                    var newStu = new StudentDB
                    {
                        UserId = newUser.Id,
                        FirstName = firstName,
                        LastName = lastName,
                        StudentNumber = studentNumber,

                        Gender = gender,
                        Level = level,
                        Group = groundId

                    };

                    context.Students.Add(newStu);
                    context.SaveChanges();

                    Response.Redirect(Page.GetRouteUrl("StudentList", null));
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "An error occurred while saving the student. Please try again." + ex.ToString();
                lblError.Visible = true;
                // Consider logging the exception details here
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}