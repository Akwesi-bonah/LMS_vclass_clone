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

        //private void BindDepartmentDropdown()
        //{
        //    using (var context = new LMSContext())
        //    {
        //        DropDownListDepartments.DataSource = context.Departments.ToList();
        //        DropDownListDepartments.DataTextField = "Name";
        //        DropDownListDepartments.DataValueField = "Id";
        //        DropDownListDepartments.DataBind();
        //    }
        //}

        private void BindCourseGridView()
        {
            SqlCourse.DataBind();
        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new LMSContext())
                {
                    var course = new CourseDB
                    {
                        Name = txtCourseName.Text,
                        Code = txtCourseCode.Text,
                        Description = txtCourseDescription.Text,
                        Level = txtCourseLevel.Text,
                    };

                    context.Courses.Add(course);
                    context.SaveChanges();
                }

                lblError.Visible = false;
                // Rebind the GridView to show the new course
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
            txtCourseLevel.Text = string.Empty;
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