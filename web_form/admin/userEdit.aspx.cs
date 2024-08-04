using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.admin
{
    public partial class adminUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the ID from query string
                if (!IsPostBack)
                {
                    Guid adminId;
                    if (Guid.TryParse(Request.QueryString["id"], out adminId))
                    {
                        LoadAdminData(adminId);
                    }
                    else
                    {
                        lblError.Text = $"Invalid Admin ID.{adminId} " ;
                        lblError.Visible = true;
                    }
                }
            }
        }

        private void LoadAdminData(Guid adminId)
        {
            using (var context = new LMSContext())
            {
                var admin = context.Admins.Include("User").SingleOrDefault(a => a.Id == adminId);
                if (admin != null)
                {
                    hfAdminId.Value = admin.Id.ToString();
                    txtFirstName.Text = admin.FirstName;
                    txtLastName.Text = admin.LastName;
                    txtPhone.Text = admin.Phone;
                    txtAddress.Text = admin.Address;
                    txtEmail.Text = admin.User.Email; // Assuming User.Email is the email field
                }
                else
                {
                    lblError.Text = "Admin not found.";
                    lblError.Visible = true;
                }
            }
        }

        protected void goBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.GetRouteUrl("AdminList", null));
        }

        protected void btnUpdateAdmin_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all text boxes
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPwd.Text = string.Empty;
            txtCpwd.Text = string.Empty;

            lblError.Visible = false;
        }
    }
}