using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EventBusiness;
using EventManagementDataLayer;

namespace EventManagementSystem
{
    public partial class Receipt : System.Web.UI.Page
    {
        BusinessLayerClass businessobj = new BusinessLayerClass();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            gvreceiptbooking.DataSource = businessobj.getBookingstatus();
            gvreceiptbooking.DataBind();

        }

        protected void gvreceiptbooking_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int bookin_id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Cancel")
            {
                Response.Write("Booking Cancelled successfully");
                
                
            }

        }

        protected void gvreceiptbooking_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvreceiptbooking_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvreceiptbooking_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvreceiptbooking_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}