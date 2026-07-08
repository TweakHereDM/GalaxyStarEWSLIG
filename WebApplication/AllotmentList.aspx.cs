using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using BusinessLogicLayer;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication
{
    public partial class AllotmentList : System.Web.UI.Page
    {
        CommonBLL objBLL = new CommonBLL();
        decimal TotalAmount = 0;
        int CountRecords = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvbind();
            }
        }

        protected void gvbind()
        {
            grdView.DataSource = objBLL.Formlist(0, null, null, null, 0, 1, -1, out CountRecords);
            grdView.DataBind();
        }
        
    }
}