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

        }

        protected void adminList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Guid id = new Guid(e.CommandArgument.ToString());
                Console.Write(id);
                Response.Redirect(Page.GetRouteUrl("AdminEdit", new { id = id }));
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
                    var admin = context.Admins.SingleOrDefault(a => a.Id == id);
                    if (admin != null)
                    {
                        context.Admins.Remove(admin);
                        context.SaveChanges();
                        BindGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }

        private void BindGridView()
        {
            adminList.DataBind();
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.GetRouteUrl("AdminAdd", null));

        }
    }
}