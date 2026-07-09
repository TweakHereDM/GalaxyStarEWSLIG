using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace WebApplication
{
    public partial class LotteryReward : UserLoginSession
    {
        CommonBLL objBLL = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetTimer();
                WebsiteSession.CountNo = 1;
                CommonBLL.BindFormCategoryDisctinct(drpCategory);
                DrpApplyFor_SelectedIndexChanged(null, null);

                var CurrentCount = objBLL.FormlistTake1by1(0, null, null, null, 0, 1, WebsiteSession.CountNo, out int CountRecords);
                if (CurrentCount.Count > 0)
                {
                    Prc_GeneralSettingDetailsResult objUser = objBLL.GeneralSettingDetails(1);
                    if (objUser != null)
                    {

                        var maxTrialNo = objBLL.DisctinctLotteryNoList(out int CountRecord).Select(x => x.TrialNo).DefaultIfEmpty(0).Max();

                        if (objUser.IsFinalLottery > maxTrialNo)
                        {
                            lnkReset.Visible = true;
                        }
                        else
                        {
                            lnkReset.Visible = false;

                        }
                    }
                }
                else
                {
                    lnkReset.Visible = false;
                }
                //gvbind();
            }
        }
        protected void SetTimer()
        {
            Prc_GeneralSettingDetailsResult objUser = objBLL.GeneralSettingDetails(1);
            if (objUser != null)
            {
                WebsiteSession.SetDate = Literal1.Text = objUser.NextLotteryTime.ToString("MMM dd, yyyy H:mm:ss");

                var maxTrialNo = objBLL.DisctinctLotteryNoList(out int CountRecord).Select(x => x.TrialNo).DefaultIfEmpty(0).Max();

                if (objUser.IsFinalLottery > maxTrialNo)
                {
                    int TrialNo = Convert.ToInt32(maxTrialNo) + 1;

                    ltrLotteryText.Text = "Trial " + TrialNo.ToString();
                    lnkReset.Visible = true;
                }
                else
                {
                    ltrLotteryText.Text = "Final";
                    lnkReset.Visible = false;

                }

                if (objUser.IsFinalLottery == 0)
                {
                    ltrTrialLotteryCount.Text = "";
                    LinkButton1.Visible = true;
                    txtTrialLottery.Visible = true;
                }
                else
                {
                    ltrTrialLotteryCount.Text = objUser.IsFinalLottery.ToString();
                    LinkButton1.Visible = false;
                    txtTrialLottery.Visible = false;

                }

            }
        }
        protected void gvbind()
        {
            int CountRecords = 0;
            if (Convert.ToDateTime(WebsiteSession.SetDate) < DateTime.Now)
            {
                rpt_item.DataSource = objBLL.FormlistTake1by1(0, null, drpCategory.SelectedValue, DrpApplyFor.SelectedValue, 0, 1, WebsiteSession.CountNo, out CountRecords);
                rpt_item.DataBind();
                ltrRecordCount.Text = CountRecords.ToString();

                WebsiteSession.CountNo = WebsiteSession.CountNo + 1;

                if (WebsiteSession.CountNo > Convert.ToInt32(ltrAllotmentCount.Text))
                {
                    Timer1.Enabled = false;
                }
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(ltrAllotmentCount.Text) > 0)
            //{

            if (Convert.ToDateTime(WebsiteSession.SetDate) < DateTime.Now)
            {
                if (ltrLotteryText.Text == "Final")
                {
                    lnkReset.Visible = false;

                }
                else
                {
                    lnkReset.Visible = true;
                }
                //WebsiteSession.SetDate = Literal1.Text = DateTime.Now.AddMinutes(5).ToString("MMM dd, yyyy H:mm:ss");

                ////Apply For Is Visible
                //var Category = objBLL.FormCategoryDisctinct(drpCategory.SelectedValue, out _);
                //foreach (var Cat in Category)
                //{

                //    var GetCount = objBLL.CategoryList(Cat.CategoryName, DrpApplyFor.SelectedValue, out _); //Apply
                //    if (GetCount.Count() > 0)
                //    {
                //        foreach (var item in GetCount)
                //        {

                //            var FormCount = objBLL.Formlist(0, null, Cat.CategoryName, DrpApplyFor.SelectedValue, 0, 1, 1, out _);
                //            if (FormCount.Count == 0)
                //            {
                //                for (int i = 0; i < item.AllotmentCount; i++)
                //                {
                //                    objBLL.UpdateRandomCustomerAlloty(Cat.CategoryName, DrpApplyFor.SelectedValue);
                //                }
                //            }
                //        }

                //    }

                //}

                //Apply For Is Hide
                int CountRecord = 0;
                var Final = objBLL.FormlistTake1by1(0, null, null, null, 0, 1, 100, out CountRecord);
                if (CountRecord < 79)
                {
                    var Category = objBLL.FormCategoryDisctinct(drpCategory.SelectedValue, out _);
                    foreach (var Cat in Category)
                    {
                        var ApplyFor = new List<string> { "EWS", "LIG" };
                        foreach (var Apply in ApplyFor)
                        {

                            var GetCount = objBLL.CategoryList(Cat.CategoryName, Apply, out _);
                            if (GetCount.Count() > 0)
                            {
                                foreach (var item in GetCount)
                                {

                                    for (int i = 0; i < item.AllotmentCount; i++)
                                    {
                                        objBLL.UpdateRandomCustomerAlloty(Cat.CategoryName, Apply);
                                    }

                                }

                            }
                        }
                    }
                }

                WebsiteSession.CountNo = 1;

                gvbind();
                Timer1.Enabled = true;
            }
            else
            {
                Response.Write("<script>alert('Wait for the timer to complete')</script>");
            }

            
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

            gvbind();
        }

        protected void DrpApplyFor_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (drpCategory.SelectedValue == "Un-Reserved-Women(Widow and Landless)" || drpCategory.SelectedValue == "Sate Govt Employee (Single & Landless Women)")
            {
                DrpApplyFor.Items.Remove(DrpApplyFor.Items.FindByValue("LIG"));
            }
            else
            {
                if (DrpApplyFor.Items.FindByValue("LIG") == null)
                {
                    DrpApplyFor.Items.Add("LIG");
                }
            }

            int CountRecord = 0;
            ltrAllotmentCount.Text = "0";
            ltrApplyFor.Text = DrpApplyFor.SelectedValue;
            ltrCategory.Text = drpCategory.SelectedValue;
            var ApplyFor = objBLL.CategoryList(drpCategory.SelectedValue, DrpApplyFor.SelectedValue, out CountRecord);
            if (ApplyFor.Count() > 0)
            {
                foreach (var item in ApplyFor)
                {
                    ltrAllotmentCount.Text = Convert.ToString(Convert.ToInt32(ltrAllotmentCount.Text) + item.AllotmentCount);
                }
            }
            rpt_item.DataSource = null;
            rpt_item.DataBind();
            ltrRecordCount.Text = "0";


        }

        protected void lnkReset_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtSeedNo.Text))
            {
                var objUser = objBLL.CheckSeedNo(Convert.ToInt32(txtSeedNo.Text));
                if (objUser.Contains("Added"))
                {
                    lnkReset.Visible = false;
                    ltrTrialLotteryCount.Text = ltrTrialLotteryCount.Text == "" ? "0" : ltrTrialLotteryCount.Text;

                    objBLL.UpdateSetLotteryTimer(1, -1);
                    objBLL.ResetTrialLottery(0);
                    TrailNoWithSeed();
                    SetTimer();
                    rpt_item.DataSource = null;
                    rpt_item.DataBind();
                    ltrRecordCount.Text = "0";
                }
                else
                {
                    Response.Write("<script>alert('" + objUser + "')</script>");
                    return;
                }
                
            }
            else
            {
                Response.Write("<script>alert('Please enter Seed No')</script>");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSeedNo.Text))
            {
                var objUser = objBLL.CheckSeedNo(Convert.ToInt32(txtSeedNo.Text));
                if (objUser.Contains("Added"))
                {
                    txtTrialLottery.Text = txtTrialLottery.Text == "" ? "0" : txtTrialLottery.Text;
                    objBLL.UpdateSetLotteryTimer(1, Convert.ToInt32(txtTrialLottery.Text));
                    TrailNoWithSeed();
                    ltrTrialLotteryCount.Text = txtTrialLottery.Text;
                    LinkButton1.Visible = false;
                    txtTrialLottery.Visible = false;
                    SetTimer();
                }
                else
                {
                    Response.Write("<script>alert('" + objUser + "')</script>");
                    return;
                }

                    
            }
            else
            {
                Response.Write("<script>alert('Please enter Seed No')</script>");
            }
        }
        protected void TrailNoWithSeed()
        {
            Prc_GeneralSettingDetailsResult objUser = objBLL.GeneralSettingDetails(1);
            if (objUser != null)
            {
                var maxTrialNo = objBLL.DisctinctLotteryNoList(out int CountRecord).Select(x => x.TrialNo).DefaultIfEmpty(0).Max();

                if (objUser.IsFinalLottery > maxTrialNo)
                {
                    int TrialNo = Convert.ToInt32(maxTrialNo) + 1;

                    objBLL.TrailNoWithSeedAdd(TrialNo.ToString(), txtSeedNo.Text);

                }
                else
                {
                    objBLL.TrailNoWithSeedAdd("Final", txtSeedNo.Text);

                }
                ltrSeedNo.Text = txtSeedNo.Text;
                txtSeedNo.Text = "";
            }
        }
    }
}
