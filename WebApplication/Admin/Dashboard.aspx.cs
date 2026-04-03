using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using Newtonsoft.Json;

namespace WebApplication
{
    public partial class Dashboard : UserLoginSession
    {
        CommonBLL objBLL = new CommonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            ABPrc_AdminDashboardResult ObjUser = objBLL.ABAdminDashboard(1);
            if (ObjUser != null)
            {
                ltrPaidApplication.Text = ObjUser.PaidApplication.ToString();
                ltrTotalAmount.Text = ObjUser.TotalAmount.ToString();
                ltrTotalApplication.Text = ObjUser.TotalApplication.ToString();

                int CountRecords = 0;

                GridView1.DataSource = objBLL.CategoryWiseApplication(1, out CountRecords);
                GridView1.DataBind();

                GridView2.DataSource = objBLL.CategoryWisePlotAllotment(1, out CountRecords);
                GridView2.DataBind();

            }
        }

    }
}