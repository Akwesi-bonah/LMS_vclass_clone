using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.admin
{
    public partial class studentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
            
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.GetRouteUrl("StudentAdd", null));
        }



        private void BindGridView()
        {
            try
            {
                using (var context = new LMSContext())
                {
                    // Fetch the data from the database including related user data
                    var admins = context.Students.Include("User").Include("Group").ToList();

                    // Bind the data to the GridView
                    StuList.DataSource = admins;
                    StuList.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during data retrieval
                lblError.Text = $"An error occurred: {ex.Message}";
                lblError.Visible = true;
            }
        }

        protected void StuList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                // Retrieve the ID of the item to be edited
                string idStr = e.CommandArgument.ToString();

                if (!string.IsNullOrEmpty(idStr))
                {
                    // Store the ID in the session and redirect to the edit page
                    Session["StuId"] = idStr;
                    Response.Redirect(Page.GetRouteUrl("StudentEdit", null));
                }
            }
            else if (e.CommandName == "Delete")
            {
                string idStr = e.CommandArgument.ToString();
                Guid id = new Guid(idStr);

                if (id != Guid.Empty)
                {
                    DeleteStudent(id);
                }
            }
        }

        private void DeleteStudent(Guid id)
        {
            try
            {
                using (var context = new LMSContext())
                {
                    var student = context.Students.Include("User").SingleOrDefault(f => f.Id == id);
                    if (student != null)
                    {
                        var user = student.User;
                        if (user != null)
                        {
                            context.Users.Remove(user);
                        }

                        context.Students.Remove(student);
                        context.SaveChanges();
                        BindGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = $"An error occurred: {ex.Message}";
                lblError.Visible = true;
            }
        }

        protected void StuList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}