using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.admin
{
    public partial class userList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void adminList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                string AdminidStr = e.CommandArgument.ToString();
                
                if(!string.IsNullOrEmpty(AdminidStr))
                {
                    Session["AdminId"] = AdminidStr;
                    Response.Redirect(Page.GetRouteUrl("AdminEdit", null));
                }
               
            }
            else if (e.CommandName == "Delete")
            {
                Guid id = new Guid(e.CommandArgument.ToString());
                DeleteAdmin(id);

            }
        }

        private void DeleteAdmin(Guid id)
        {
            try
            {
                using (var context = new LMSContext())
                {
                    var admin = context.Admins.Include("User").SingleOrDefault(a => a.Id == id);
                    if (admin != null)
                    {
                        // If you also want to delete the related User entity, do this:
                        var user = admin.User;
                        if (user != null)
                        {
                            context.Users.Remove(user);
                        }

                        context.Admins.Remove(admin);
                        context.SaveChanges();

                        BindGridView(); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        private void BindGridView()
        {
            try
            {
                using (var context = new LMSContext())
                {
                    // Fetch the data from the database including related user data
                    var admins = context.Admins.Include("User").ToList();

                    // Bind the data to the GridView
                    adminList.DataSource = admins;
                    adminList.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during data retrieval
                lblError.Text = $"An error occurred: {ex.Message}";
                lblError.Visible = true;
            }
        }


        protected void addBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.GetRouteUrl("AdminAdd", null));

        }

        protected void adminList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}