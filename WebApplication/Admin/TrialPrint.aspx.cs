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
    public partial class TrialPrint : UserLoginSession
    {
        CommonBLL objBLL = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonBLL.BindFormCategoryDisctinct(drpCategory);

                CommonBLL.DisctinctLotteryNo(drpLotteryNo);
                gvbind();

            }
        }
        protected void gvbind()
        {
            grdView.DataSource = objBLL.TrialLotteryList(drpCategory.SelectedValue, drpPlotCategory.SelectedValue, Convert.ToInt32(drpLotteryNo.SelectedValue), 1, out _);
            grdView.DataBind();

            ltrLotteryNo.Text = drpLotteryNo.SelectedValue;

            Prc_TrailNoListWithSeedResult objUser = objBLL.TrailNoListWithSeed(drpLotteryNo.SelectedValue);
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