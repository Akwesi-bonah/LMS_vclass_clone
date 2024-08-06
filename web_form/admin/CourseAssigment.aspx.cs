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
                    //BindCourseDropdown();
                    //BindFacilitatorDropdown();
                    BindAssignmentGridView();
                }
            }

            //private void BindCourseDropdown()
            //{
            //    using (var context = new LMSContext())
            //    {
            //        DropDownListCourses.DataSource = context.Courses.ToList();
            //        DropDownListCourses.DataTextField = "Name";
            //        DropDownListCourses.DataValueField = "Id";
            //        DropDownListCourses.DataBind();
            //    }
            //}

            //private void BindFacilitatorDropdown()
            //{
            //    using (var context = new LMSContext())
            //    {
            //        DropDownListFacilitators.DataSource = context.Facilitators.ToList();
            //        DropDownListFacilitators.DataTextField = "Name";
            //        DropDownListFacilitators.DataValueField = "Id";
            //        DropDownListFacilitators.DataBind();
            //    }
            //}

            private void BindAssignmentGridView()
            {
                SqlAssignment.DataBind();
            }

            protected void btnAddAssignment_Click(object sender, EventArgs e)
            {
                try
                {
                    using (var context = new LMSContext())
                    {
                        var assignment = new CourseAssignmentDB
                        {
                            CourseId = Guid.Parse(DropDownListCourses.SelectedValue),
                            FacilitatorId = Guid.Parse(DropDownListFacilitators.SelectedValue),
                            StartDate = DateTime.Parse(txtStartDate.Text),
                            EndDate = DateTime.Parse(txtEndDate.Text)
                        };

                        context.CourseAssignments.Add(assignment);
                        context.SaveChanges();
                    }

                    lblError.Visible = false;
                    // Rebind the GridView to show the new assignment
                    BindAssignmentGridView();
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
                DropDownListCourses.ClearSelection();
                DropDownListFacilitators.ClearSelection();
                txtStartDate.Text = string.Empty;
                txtEndDate.Text = string.Empty;
            }

            protected void assignmentList_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "Edit")
                {
                    // Handle edit logic here
                    // You might redirect to an edit page or open a modal for editing
                }
                else if (e.CommandName == "Delete")
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

       
    }
    }
    
