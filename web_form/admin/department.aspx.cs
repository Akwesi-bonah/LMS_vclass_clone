using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.admin
{
    public partial class department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddDepartment_Click(object sender, EventArgs e)
        {
            // Retrieve form data
            string name = txtName.Text.Trim();
            string description = txtDescription.Text.Trim();

            // Validate form data
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
            {
                lblError.Text = "Please fill all required fields.";
                lblError.Visible = true;
                return;
            }

            try
            {
                using (var context = new LMSContext())
                {
                    // Create a new Department object
                    var newDepartment = new DepartmentDB
                    {
                        Name = name,
                        Description = description
                    };

                    context.Departments.Add(newDepartment);
                    context.SaveChanges();

                    txtName.Text = "";
                    txtDescription.Text = "";
                    lblError.Text = "Department added successfully.";
                    lblError.CssClass = "text-success";
                    lblError.Visible = true;

                    // Refresh the GridView
                    departmentList.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "An error occurred while saving the department. Please try again.";
                lblError.Visible = true;
                // Consider logging the exception details here
            }
        }

        protected void departmentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                try
                {
                    Guid departmentId = new Guid(e.CommandArgument.ToString());

                    using (var context = new LMSContext())
                    {
                        var department = context.Departments.Find(departmentId);
                        if (department != null)
                        {
                            context.Departments.Remove(department);
                            context.SaveChanges();
                            departmentList.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = "An error occurred while deleting the department. Please try again.";
                    lblError.Visible = true;
                    // Consider logging the exception details here
                }
            }
            else if (e.CommandName == "Edit")
            {
                // Implement edit functionality if required
            }
        }

    }
}