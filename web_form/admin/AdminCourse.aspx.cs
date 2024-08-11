using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.admin
{
    public partial class Course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindDepartmentDropdown();
                BindCourseGridView();
            }
        }

        

        private void BindCourseGridView()
        {
            SqlCourse.DataBind();
            courseList.DataBind(); 

        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            string courseName = txtCourseName.Text.Trim();
            string courseCode = txtCourseCode.Text.Trim();
            string courseDescription = txtCourseDescription.Text.Trim();
            string courseLevel = dbLevel.SelectedItem.Text; 

            // Validate form data
            if (string.IsNullOrEmpty(courseName) || string.IsNullOrEmpty(courseCode) ||
                string.IsNullOrEmpty(courseDescription) || string.IsNullOrEmpty(courseLevel))
            {
                lblError.Text = "Please fill all required fields";
                lblError.Visible = true;
                return;
            }

            try
            {
                using (var context = new LMSContext())
                {
                    // Check if course code already exists
                    bool courseExists = context.Courses.Any(c => c.Code == courseCode);
                    if (courseExists)
                    {
                        lblError.Text = "Course code already exists. Please use a different course code.";
                        lblError.Visible = true;
                        return;
                    }

                    var course = new CourseDB
                    {
                        Name = courseName, 
                        Code = courseCode,
                        Description = courseDescription,
                        Level = courseLevel
                    };

                    context.Courses.Add(course);
                    context.SaveChanges();
                }

                lblError.Visible = false;
                BindCourseGridView();
                ClearForm();
            }
            catch (Exception ex)
            {
                lblError.Text = $"Error: {ex.Message}";
                lblError.Visible = true;
            }
        }

        private void ClearForm()
        {
            txtCourseName.Text = string.Empty;
            txtCourseCode.Text = string.Empty;
            txtCourseDescription.Text = string.Empty;
            dbLevel.SelectedIndex= -1;
            //DropDownListDepartments.ClearSelection();
        }

        protected void courseList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                // Handle edit logic here
                // You might redirect to an edit page or open a modal for editing
            }
            else if (e.CommandName == "Delete")
            {
                var courseId = new Guid(e.CommandArgument.ToString());

                using (var context = new LMSContext())
                {
                    var course = context.Courses.Find(courseId);
                    if (course != null)
                    {
                        context.Courses.Remove(course);
                        context.SaveChanges();
                    }
                }

                // Rebind the GridView to reflect changes
                BindCourseGridView();
            }
        }
    }
}