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
            int CountRecord = 0;
            var Final = objBLL.FormlistTake1by1(0, null, null, null, 0, 1, 91, out CountRecord);
            if (CountRecord == 79)
            {
                Prc_TrailNoListWithSeedResult objUser = objBLL.TrailNoListWithSeed("Final");
                if (objUser != null)
                {
                    grdView.DataSource = objBLL.FormlistTake1by1(0, null, drpCategory.SelectedValue, drpPlotCategory.SelectedValue, 0, 1, 91, out _);
                    grdView.DataBind();


                    ltrSeedNo.Text = objUser.SeedNo.ToString();
                }

            }

        }
        protected void drpLotteryNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvbind();
        }



    }
}