using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace WebApplication
{
    public partial class Website : System.Web.UI.MasterPage
    {
        CommonBLL objBLL = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            ltrUserName.Text = WebsiteSession.UserName;
          
            //rptTasks.DataSource = objBLL.TaskList(0, null, null, null, 0, WebsiteSession.UserName, 2, 2, out CountRecords);
            //rptTasks.DataBind();
            //ltrTaskCountCount.Text = CountRecords.ToString();


        }
      
        protected void lnkLastSaved_Click(object sender, EventArgs e)
        {
            WebsiteSession.lastSaved = true;
            Response.Redirect("AddNewProject.aspx");
        }

        protected void lnkAddNewProject_Click(object sender, EventArgs e)
        {
            WebsiteSession.OrderNumber = null;
            WebsiteSession.lastSaved = false;
            Response.Redirect("AddNewProject.aspx");


        }

        
        protected void rpt_AdminMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int CountRecord = 0;
                Repeater rptSubMenu = e.Item.FindControl("rptChildMenu") as Repeater;
                RepeaterItem item = e.Item;
                string ParentMenuId = (item.FindControl("ltrMenuID") as Label).Text;

                rptSubMenu.DataSource = objBLL.AdminPanelMenu(Convert.ToInt32(ParentMenuId), WebsiteSession.UserID, out CountRecord);
                rptSubMenu.DataBind();



            }
        }
    }
}