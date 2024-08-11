using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vclass_clone.Models;

namespace vclass_clone.web_form.facilitator
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Ensure the user is logged in and the session has a UserId
                if (Session["UserId"] != null)
                {
                    Guid userId = Guid.Parse(Session["UserId"].ToString());

                    using (var context = new LMSContext())
                    {
                        var facilitator = context.Facilitators
                                                 .FirstOrDefault(f => f.UserId == userId);

                        if (facilitator != null)
                        {
                            Guid facilitatorId = facilitator.Id;

                            Session["FacilitatorId"] = facilitatorId;

                          
                        }
                       
                    }
                }
                
            }
        }
    }

}