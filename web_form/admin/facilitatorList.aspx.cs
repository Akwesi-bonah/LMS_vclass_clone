﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vclass_clone.web_form.admin
{
    public partial class facilitatorList : System.Web.UI.Page
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
            Response.Redirect(Page.GetRouteUrl("FacilitatorAdd", null));

        }

        private void BindGridView()
        {
            SqlFacilitator.DataBind();
        }
    }
}