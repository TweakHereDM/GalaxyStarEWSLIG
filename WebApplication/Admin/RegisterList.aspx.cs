using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Admin
{
    public partial class RegisterList : UserLoginSession
    {
        CommonBLL objBLL = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CommonBLL.BindFormCategoryDisctinct(inpCategory);
                inpCategory.Items.Insert(0, new ListItem("--SELECT Cast--", ""));

                gvbind();
            }
        }
        protected void gvbind()
        {
            int CountRecords = 0;
           
            grdView.DataSource = objBLL.RegisterList(0, txtSearchBy.Text, drpApplyFor.SelectedValue, inpCategory.SelectedValue, Convert.ToInt32(drpStatus.SelectedValue), 
                Convert.ToInt32(drpDDStatus.SelectedValue), out CountRecords);
            grdView.DataBind();
            ltrRecordCount.Text = CountRecords.ToString();

            if (CountRecords < 1)
            {
                //btnDelete.Visible = false;
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvbind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdView.PageIndex = e.NewPageIndex;

            gvbind();

        }
        protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "AddDD")
            {
                string RegID = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(RegID))
                {
                    Response.Redirect($"AddDD.aspx?RegID={RegID}");
                }
            }
            if (e.CommandName == "AddTransaction")
            {
                string RegID = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(RegID))
                {
                    Response.Redirect("TransactionList.aspx?RegID=" + RegID);
                }
            }
        }

        protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btnPayment = (LinkButton)e.Row.FindControl("btnPayment");
                LinkButton lnkTransaction = (LinkButton)e.Row.FindControl("lnkTransaction");

                if ((bool)DataBinder.Eval(e.Row.DataItem, "Payment_Status") == false)
                {
                    btnPayment.Visible = false;
                    lnkTransaction.Visible = true;
                }
                else
                {
                    btnPayment.Visible = true;

                    lnkTransaction.Visible = false;
                }

                if ((decimal)DataBinder.Eval(e.Row.DataItem, "DDAmount") > 0)
                {
                    btnPayment.Style.Add("background-color", "LightGreen");

                }
                if ((int)DataBinder.Eval(e.Row.DataItem, "DDReturn") > 0)
                {
                    btnPayment.Style.Add("background-color", "Red");

                }

            }
        }
    }
}