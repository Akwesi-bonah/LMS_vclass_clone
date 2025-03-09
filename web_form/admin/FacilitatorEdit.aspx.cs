using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.include;
using vclass_clone.Models;
using vclass_clone.web_form.views;

namespace vclass_clone.web_form.admin
{
    public partial class FacilitatorEdit : System.Web.UI.Page
    {
        string facStr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                facStr = Session["FacId"] as string;
                Guid facid;
                if (Guid.TryParse(facStr, out facid))
                {
                    loadFacData(facid);
                }
                else
                {
                    lblError.Text = $"Invalid Fac ID.{facid} ";
                    lblError.Visible = true;
                }
            }

        }

        protected void goBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.GetRouteUrl("FacilitatorList", null));

        }


        private void loadFacData(Guid facid)
        {
            try
            {
                using(var context = new LMSContext())
                {
                    var fac = context.Facilitators.Include("User").SingleOrDefault(a => a.Id == facid);
                    if (fac != null)
                    {
                        hfacId.Value = fac.Id.ToString();
                        txtFirstName.Text = fac.FirstName;
                        txtLastName.Text = fac.LastName;
                        txtPhone.Text = fac.Phone.ToString();
                        txtAddress.Text = fac.Address.ToString();
                        txtEmail.Text = fac.User.Email.ToString();
                        departmentList.SelectedValue = fac.Department.Id.ToString();

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

        protected void btnEditFac_Click(object sender, EventArgs e)
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
            string facStr = hfacId.Value;  // Assuming this is how you get the facilitator ID

            // Validate form data
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(departmentId))
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

            if (string.IsNullOrEmpty(facStr) || !Guid.TryParse(facStr, out Guid facid))
            {
                lblError.Text = "Invalid or missing facilitator ID.";
                lblError.Visible = true;
                return;
            }

            try
            {
                using (var context = new LMSContext())
                {
                    // Check if email exists in Users table, excluding current facilitator
                    bool emailExists = context.Users
                        .Where(a => a.Email == email)
                        .Any(a => !context.Facilitators.Any(fac => fac.UserId == a.Id && fac.Id == facid));

                    // Check if phone exists in Facilitators table, excluding current facilitator
                    bool phoneExists = context.Facilitators
                        .Any(a => a.Phone == phone && a.Id != facid);

                    if (emailExists || phoneExists)
                    {
                        lblError.Text = emailExists ? "Email already exists." : "Phone number already exists.";
                        lblError.Visible = true;
                        return;
                    }

                    // Retrieve the facilitator from the database
                    var facEntity = context.Facilitators.Include("User").SingleOrDefault(a => a.Id == facid);

                    if (facEntity != null)
                    {
                        // Update the facilitator details
                        facEntity.FirstName = firstName;
                        facEntity.LastName = lastName;
                        facEntity.Phone = phone;
                        facEntity.Address = address;
                        facEntity.User.Email = email;

                        // Convert departmentId to Guid and retrieve the department entity
                        if (Guid.TryParse(departmentId, out Guid departmentIdGuid))
                        {
                            var department = context.Departments.SingleOrDefault(d => d.Id == departmentIdGuid);
                            if (department != null)
                            {
                                facEntity.Department = department;
                            }
                            else
                            {
                                lblError.Text = "Department not found.";
                                lblError.Visible = true;
                                return;
                            }
                        }

                        if (!string.IsNullOrEmpty(password))
                        {
                            // Hash the password
                            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                            facEntity.User.Password = hashedPassword;
                        }

                        context.SaveChanges();
                        // Redirect to the facilitator list page
                        Response.Redirect(Page.GetRouteUrl("FacilitatorList", null));
                    }
                    else
                    {
                        lblError.Text = "Facilitator not found.";
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
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            departmentList.SelectedIndex = -1;
        }
    }

    
}