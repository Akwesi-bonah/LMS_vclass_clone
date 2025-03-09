using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.admin
{
    public partial class CourseAssigment : System.Web.UI.Page
    {
        

        
         
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                   
                    BindAssignmentGridView();
                }
            }

            

            private void BindAssignmentGridView()
            {
            try
            {
                using (var context = new LMSContext())
                {
                    var courses = context.CourseAssignments.Include("Course").Include("Groups").Include("Facilitator").ToList();
                    assignmentList.DataSource = courses;
                    assignmentList.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = $"An error occurred: {ex.Message}";
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }
            }

        protected void btnAddAssignment_Click(object sender, EventArgs e)
        {
            try
            {

                // Check if the Course selection is valid
                if (string.IsNullOrEmpty(DropDownListCourses.SelectedValue))
                {
                    lblError.Text = "Please select a course.";
                    lblError.Visible = true;
                    return;
                }

                // Check if the Course selection is valid
                if (string.IsNullOrEmpty(DropDownStudentGroup.SelectedValue))
                {
                    lblError.Text = "Please Select Student Group.";
                    lblError.Visible = true;
                    return;
                }

                // Check if the Facilitator selection is valid
                if (string.IsNullOrEmpty(DropDownListFacilitators.SelectedValue))
                {
                    lblError.Text = "Please select a facilitator.";
                    lblError.Visible = true;
                    return;
                }

                // Check if StartDate is provided and is a valid date
                if (!DateTime.TryParse(txtStartDate.Text, out DateTime startDate))
                {
                    lblError.Text = "Please enter a valid start date.";
                    lblError.Visible = true;
                    return;
                }

                // Check if EndDate is provided and is a valid date
                if (!DateTime.TryParse(txtEndDate.Text, out DateTime endDate))
                {
                    lblError.Text = "Please enter a valid end date.";
                    lblError.Visible = true;
                    return;
                }

                // Ensure the EndDate is after the StartDate
                if (endDate <= startDate)
                {
                    lblError.Text = "End date must be after the start date.";
                    lblError.Visible = true;
                    return;
                }

                // Check if the interval between StartDate and EndDate is at least two months
                var interval = endDate - startDate;
                if (interval.Days < 60) // 60 days approximately equal to two months
                {
                    lblError.Text = "The assignment duration must be at least two months.";
                    lblError.Visible = true;
                    return;
                }

                using (var context = new LMSContext())
                {
                    // Get the selected CourseId and FacilitatorId
                    var courseId = Guid.Parse(DropDownListCourses.SelectedValue);
                    var facilitatorId = Guid.Parse(DropDownListFacilitators.SelectedValue);
                    var groupId = Guid.Parse(DropDownStudentGroup.SelectedValue);
                    // Check if this assignment already exists
                    var existingAssignment = context.CourseAssignments
                        .FirstOrDefault(a => a.CourseId == courseId && a.FacilitatorId == facilitatorId && a.GroupId == groupId);

                    if (existingAssignment != null)
                    {
                        lblError.Text = "This course has already been assigned to the selected facilitator.";
                        lblError.Visible = true;
                        return;
                    }

                    // If all validations pass, create the assignment
                    var assignment = new CourseAssignmentDB
                    {
                        CourseId = courseId,
                        FacilitatorId = facilitatorId,
                        GroupId = groupId,
                        StartDate = startDate,
                        EndDate = endDate
                    };

                    context.CourseAssignments.Add(assignment);
                    context.SaveChanges();
                }

                lblError.Visible = false;
                BindAssignmentGridView();
                ClearForm();
            }
            catch (Exception ex)
            {
                lblError.Text = $"Error: {ex.Message}";
                lblError.Visible = true;
            }
        }

        private void getCourse(Guid id)
        {
            try
            {
                using (var context = new LMSContext())
                {
                    var assignment = context.CourseAssignments.Find(id);
                    if (assignment != null)
                    {
                        DropDownListCourses.SelectedValue = assignment.CourseId.ToString();
                        DropDownListFacilitators.SelectedValue = assignment.FacilitatorId.ToString();
                        DropDownStudentGroup.SelectedValue = assignment.GroupId.ToString();
                        txtStartDate.Text = assignment.StartDate.ToString("yyyy-MM-dd");
                        txtEndDate.Text = assignment.EndDate.ToString();

                        hCuId.Value = assignment.Id.ToString();


                        btnAddAssignment.Visible = false;
                        btnUpdateAssigmen.Visible = true;
                        lblheader.Text = "Update Assignment";
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = $"An error occurred: {ex.Message}";
                lblError.Visible = true;
            }
        }



        private void ClearForm()
        {
            DropDownListCourses.ClearSelection();
            DropDownListFacilitators.ClearSelection();
            DropDownStudentGroup.ClearSelection();
            txtStartDate.Text = string.Empty;
            txtEndDate.Text = string.Empty;

            hCuId.Value = string.Empty;
            btnAddAssignment.Visible = true;
            btnUpdateAssigmen.Visible = false;
            lblheader.Text = "Assign Course";
        }

        protected void assignmentList_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "AssignEdit")
                {
                string idStr = e.CommandArgument.ToString();
                Guid id;
                if (Guid.TryParse(idStr, out id))
                {
                    getCourse(id);
                }
            }
                else if (e.CommandName == "AssignDelete")
                {
                    var assignmentId = new Guid(e.CommandArgument.ToString());

                    using (var context = new LMSContext())
                    {
                        var assignment = context.CourseAssignments.Find(assignmentId);
                        if (assignment != null)
                        {
                            context.CourseAssignments.Remove(assignment);
                            context.SaveChanges();
                        }
                    }

                    // Rebind the GridView to reflect changes
                    BindAssignmentGridView();
                }
            }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        protected void btnUpdateAssignment_Click(object sender, EventArgs e)
        {
            try
            {

                // Check if the Course selection is valid
                if (string.IsNullOrEmpty(DropDownListCourses.SelectedValue))
                {
                    lblError.Text = "Please select a course.";
                    lblError.Visible = true;
                    return;
                }

                // Check if the Course selection is valid
                if (string.IsNullOrEmpty(DropDownStudentGroup.SelectedValue))
                {
                    lblError.Text = "Please Select Student Group.";
                    lblError.Visible = true;
                    return;
                }

                // Check if the Facilitator selection is valid
                if (string.IsNullOrEmpty(DropDownListFacilitators.SelectedValue))
                {
                    lblError.Text = "Please select a facilitator.";
                    lblError.Visible = true;
                    return;
                }

                // Check if StartDate is provided and is a valid date
                if (!DateTime.TryParse(txtStartDate.Text, out DateTime startDate))
                {
                    lblError.Text = "Please enter a valid start date.";
                    lblError.Visible = true;
                    return;
                }

                // Check if EndDate is provided and is a valid date
                if (!DateTime.TryParse(txtEndDate.Text, out DateTime endDate))
                {
                    lblError.Text = "Please enter a valid end date.";
                    lblError.Visible = true;
                    return;
                }

                // Ensure the EndDate is after the StartDate
                if (endDate <= startDate)
                {
                    lblError.Text = "End date must be after the start date.";
                    lblError.Visible = true;
                    return;
                }

                // Check if the interval between StartDate and EndDate is at least two months
                var interval = endDate - startDate;
                if (interval.Days < 60) // 60 days approximately equal to two months
                {
                    lblError.Text = "The assignment duration must be at least two months.";
                    lblError.Visible = true;
                    return;
                }

                using (var context = new LMSContext())
                {
                    var id = Guid.Parse(hCuId.Value);
                    var assignment = context.CourseAssignments.Find(id);

                    if (assignment != null)
                    {
                        assignment.CourseId = Guid.Parse(DropDownListCourses.SelectedValue);
                        assignment.FacilitatorId = Guid.Parse(DropDownListFacilitators.SelectedValue);
                        assignment.GroupId = Guid.Parse(DropDownStudentGroup.SelectedValue);
                        assignment.StartDate = DateTime.Parse(txtStartDate.Text);
                        assignment.EndDate = DateTime.Parse(txtEndDate.Text);
                        context.SaveChanges();
                    }
                }

                    lblError.Visible = false;
                BindAssignmentGridView();
                ClearForm();
            }
            catch (Exception ex)
            {
                lblError.Text = $"Error: {ex.Message}";
                lblError.Visible = true;
            }
        }
    }
    }
    
