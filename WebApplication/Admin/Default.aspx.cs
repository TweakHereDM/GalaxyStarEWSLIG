using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace WebApplication
{
    public partial class Default : System.Web.UI.Page
    {
        CommonBLL objBLL = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Index.aspx");

        }
    }
}