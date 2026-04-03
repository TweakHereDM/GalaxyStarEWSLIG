using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Diagnostics;

namespace WebApplicationAdmin
{
    public partial class FinalPrint : UserLoginSession
    {
        CommonBLL objBLL = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonBLL.BindFormCategoryDisctinct(drpCategory);

                gvbind();

            }
        }
        protected void gvbind()
        {
            //if (Convert.ToDateTime(WebsiteSession.SetDate) < DateTime.Now)
            //{
                grdView.DataSource = objBLL.FormlistTake1by1(0, null, drpCategory.SelectedValue, null, 0, 1, 91, out _);
                grdView.DataBind();
            //}

            Prc_TrailNoListWithSeedResult objUser = objBLL.TrailNoListWithSeed("Final");
            if (objUser != null)
            {
                ltrSeedNo.Text = objUser.SeedNo.ToString();
            }

        }
        protected void drpLotteryNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvbind();
        }



    }
}