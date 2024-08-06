using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.admin
{
    public partial class group : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               Bind();
            }
        }

        
        private void Bind()
        {
            SqlGroup.DataBind();
            sqlDepartment.DataBind();
        }
        private void BindGroupGridView()
        {
            SqlGroup.DataBind();
        }

        protected void btnAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new LMSContext())
                {
                    var group = new GroupDB
                    {
                        Name = txtGroupName.Text,
                        Description = txtGroupDescription.Text,
                        DepartmentId = Guid.Parse(DropDownList1.SelectedValue)
                    };

                    context.Groups.Add(group);
                    context.SaveChanges();
                }

                lblError.Visible = false;
                BindGroupGridView();
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
            txtGroupName.Text = string.Empty;
            txtGroupDescription.Text = string.Empty;
            DropDownList1.ClearSelection();
        }

        protected void groupList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
               
            }
            else if (e.CommandName == "Delete")
            {
                var groupId = new Guid(e.CommandArgument.ToString());

                using (var context = new LMSContext())
                {
                    var group = context.Groups.Find(groupId);
                    if (group != null)
                    {
                        context.Groups.Remove(group);
                        context.SaveChanges();
                    }
                }

                BindGroupGridView();
            }
        }
    }

}
