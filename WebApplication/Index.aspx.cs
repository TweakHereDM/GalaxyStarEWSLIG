using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Index : System.Web.UI.Page
    {
        CommonBLL objBLL = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            GridView2.DataSource = objBLL.CategoryWisePlotAllotment(1, out _);
            GridView2.DataBind();

            DateTime inputDate = DateTime.Now; // Replace with your actual date to check

            DateTime startDate = new DateTime(2026, 4, 3);
            DateTime endDate = new DateTime(2026, 4, 18);

            if (inputDate >= startDate && inputDate <= endDate)
            {
                Apply.Visible = true;
                Apply1.Visible = true;
                Apply2.Visible = true;
                Apply3.Visible = true;

            }
            else
            {
                Apply.Visible = false;
                Apply1.Visible = false;
                Apply2.Visible = false;
                Apply3.Visible = false;
            }

        }
    }
}