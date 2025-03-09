using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.admin
{
    public partial class Course : System.Web.UI.Page
    {
        string curId; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
                btnUpdateCourse.Visible = false;
            }
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
                lblError.Text = "Please fill all required fields.";
                lblError.Visible = true;
                lblSuccess.Visible = false; // Hide success label if there's an error
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
                        lblSuccess.Visible = false;
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

                    lblError.Visible = false;
                    lblSuccess.Text = "Course added successfully!";
                    lblSuccess.Visible = true;
                    BindGridView();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = $"Error: {ex.Message}";
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }
        }

       

        private void getCourse(Guid id)
        {
            try
            {
                using (var context = new LMSContext())
                {
                    var course = context.Courses.Find(id);
                    if (course != null)
                    {
                        txtCourseName.Text = course.Name;
                        txtCourseDescription.Text = course.Description;
                        txtCourseCode.Text = course.Code;
                        dbLevel.SelectedValue = course.Level;
                        hCuId.Value = course.Id.ToString();
                       

                        btnAddCourse.Visible = false;
                        btnUpdateCourse.Visible = true;
                        lblheader.Text = "Update Course";
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = $"An error occurred: {ex.Message}";
                lblError.Visible = true;
            }
        }

        protected void btnUpdateCourse_Click(object sender, EventArgs e)
        {
            string courseName = txtCourseName.Text.Trim();
            string courseCode = txtCourseCode.Text.Trim();
            string courseDescription = txtCourseDescription.Text.Trim();
            string courseLevel = dbLevel.SelectedItem.Text;
            curId= hCuId.Value;

            if (string.IsNullOrEmpty(courseName) || string.IsNullOrEmpty(courseCode) ||
                string.IsNullOrEmpty(courseDescription) || string.IsNullOrEmpty(courseLevel))
            {
                lblError.Text = "Please fill all required fields";
                lblError.Visible = true;
                lblSuccess.Visible = false;
                return;
            }

            if (string.IsNullOrEmpty(curId) || !Guid.TryParse(curId, out Guid id))
            {
                lblError.Text = "Invalid or missing course ID.";
                lblError.Visible = true;
                return;
            }

            try
            {
                using (var context = new LMSContext())
                {
                    var course = context.Courses.Find(id);
                    if (course != null)
                    {
                        course.Name = courseName;
                        course.Code = courseCode;
                        course.Description = courseDescription;
                        course.Level = courseLevel;

                        context.SaveChanges();

                        lblSuccess.Text = "Course updated successfully!";
                        lblSuccess.Visible = true;
                        lblError.Visible = false;
                        ClearForm();
                        BindGridView();

                        btnAddCourse.Visible = true;
                        btnUpdateCourse.Visible = false;
                        lblheader.Text = "Add Course";
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = $"Error: {ex.Message}";
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }
        }

        private void BindGridView()
        {
            try
            {
                using (var context = new LMSContext())
                {
                    var courses = context.Courses.ToList();
                    CourseList.DataSource = courses;
                    CourseList.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = $"An error occurred: {ex.Message}";
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }
        }

        private void ClearForm()
        {
            txtCourseName.Text = string.Empty;
            txtCourseCode.Text = string.Empty;
            txtCourseDescription.Text = string.Empty;
            dbLevel.SelectedIndex = 0;
            btnAddCourse.Visible = true;
            btnUpdateCourse.Visible = false;
            lblheader.Text = "Add Course";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

       

        protected void CourseList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditCourse")
            {
                string idStr = e.CommandArgument.ToString();
                Guid id;
                if (Guid.TryParse(idStr, out id))
                {
                    getCourse(id);
                }
            }
            else if (e.CommandName == "DeleteCourse")
            {
                var courseId = new Guid(e.CommandArgument.ToString());
                try
                {
                    using (var context = new LMSContext())
                    {
                        var course = context.Courses.Find(courseId);
                        if (course != null)
                        {
                            context.Courses.Remove(course);
                            context.SaveChanges();
                            lblgsus.Text = "Course deleted successfully!";
                            lblgsus.Visible = true;
                            lblError.Visible = false;
                            BindGridView();
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = $"An error occurred: {ex.Message}";
                    lblError.Visible = true;
                    lblSuccess.Visible = false;
                }
            }

        }

        protected void CourseList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }

}