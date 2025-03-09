using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.include;
using vclass_clone.Models;

namespace vclass_clone.web_form.admin
{
    public partial class studentEdit : System.Web.UI.Page
    {
        string stuIdStr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                stuIdStr = Session["StuId"] as string;
                Guid stuid;
                if (Guid.TryParse(stuIdStr,out stuid))
                {
                    loadStudentData(stuid);

                }
            }
        }

        protected void goBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.GetRouteUrl("StudentList", null));

        }

        private void loadStudentData(Guid stuid)
        {
            try
            {
                using (var context = new LMSContext())
                {
                    var stu = context.Students.Include("User").Include("Group").SingleOrDefault(a => a.Id == stuid);
                    if (stu != null)
                    {
                        // Store the student ID in the correct hidden field
                        hstuId.Value = stu.Id.ToString();
                        txtFirstName.Text = stu.FirstName;
                        txtLastName.Text = stu.LastName;
                        txtStNumber.Text = stu.StudentNumber.ToString();
                        dbgender.SelectedValue = stu.Gender.ToString();
                        dpLevel.SelectedValue = stu.Level;
                        dbgroup.SelectedValue = stu.Group.Id.ToString();
                        txtEmail.Text = stu.User.Email.ToString();
                    }
                    else
                    {
                        lblError.Text = "Student not found.";
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

        protected void btnUptStu_Click(object sender, EventArgs e)
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
            string stuIdStr = hstuId.Value; 

            // Validate form data
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(group))
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

            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(confirmPassword))
            {
                if (password != confirmPassword)
                {
                    lblError.Text = "Passwords do not match.";
                    lblError.Visible = true;
                    return;
                }

                if (!validator.IsStrongPassword(password))
                {
                    lblError.Text = "Password must be at least 8 characters long and contain a mix of letters and numbers.";
                    lblError.Visible = true;
                    return;
                }
            }

            if (string.IsNullOrEmpty(stuIdStr) || !Guid.TryParse(stuIdStr, out Guid stuid))
            {
                lblError.Text = "Invalid or missing student ID.";
                lblError.Visible = true;
                return;
            }

            try
            {
                using (var context = new LMSContext())
                {
                    bool emailExists = context.Users
                        .Where(a => a.Email == email)
                        .Any(a => !context.Students.Any(stu => stu.UserId == a.Id && stu.Id == stuid));

                    bool StudentNumberExists = context.Students
                        .Any(a => a.StudentNumber == studentNumber && a.Id != stuid);

                    if (emailExists || StudentNumberExists)
                    {
                        lblError.Text = emailExists ? "Email already exists." : "Student number already exists.";
                        lblError.Visible = true;
                        return;
                    }

                    var StuEntity = context.Students.Include("User").SingleOrDefault(a => a.Id == stuid);

                    if (StuEntity != null)
                    {
                        // Update the student details
                        StuEntity.FirstName = firstName;
                        StuEntity.LastName = lastName;
                        StuEntity.User.Email = email;
                        StuEntity.StudentNumber = studentNumber;
                        StuEntity.Gender = gender;
                        StuEntity.Level = level;

                        // Convert groupid to Guid and retrieve the Group entity
                        if (Guid.TryParse(group, out Guid groupIdGuid))
                        {
                            var groupEntity = context.Groups.SingleOrDefault(g => g.Id == groupIdGuid);
                            if (groupEntity != null)
                            {
                                StuEntity.Group = groupEntity;
                            }
                            else
                            {
                                lblError.Text = "Group not found.";
                                lblError.Visible = true;
                                return;
                            }
                        }

                        if (!string.IsNullOrEmpty(password))
                        {
                            // Hash the password
                            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                            StuEntity.User.Password = hashedPassword;
                        }

                        context.SaveChanges();
                        Response.Redirect(Page.GetRouteUrl("StudentList", null));
                    }
                    else
                    {
                        lblError.Text = "Student not found.";
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
            txtEmail.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtStNumber.Text = string.Empty;
            dbgender.SelectedIndex = -1;
            dpLevel.SelectedIndex = -1;
            dbgender.SelectedIndex = -1;
            txtEmail.Text = string.Empty;
        }
    }
}