using BusinessLogicLayer;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Admin
{
    public partial class TransactionList : UserLoginSession
    {
        CommonBLL objBLL = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CommonBLL.BindFormCategoryDisctinct(DrpCategory);
                DrpCategory.Items.Insert(0, new ListItem("--SELECT Cast--", ""));
                gvbind();
            }
        }
        protected void gvbind()
        {
            int CountRecords = 0;
            var FormID = "";
            string RegID = "0";
            string OrderID = "0";

            if (!string.IsNullOrEmpty(Request.QueryString["ref"]))
            {
                OrderID = Request.QueryString["ref"].ToString();
                txtOrderID.Text = OrderID;

            }
            else
            {
               OrderID = txtOrderID.Text;
            }

            if (txtFormID.Text == "")
            {
                FormID = "2";
            }
            else
            {
                FormID = txtFormID.Text;
            }

            if (!string.IsNullOrEmpty(Request.QueryString["RegID"]))
            {
                RegID = Request.QueryString["RegID"].ToString();
            }

            grdView.DataSource = objBLL.Transactionlist(0, Convert.ToInt32(drpPaymentStatus.SelectedValue), Convert.ToInt32(FormID), OrderID, 
                txtSearchBy.Text, DrpCategory.SelectedValue, drpApplyFor.SelectedValue, Convert.ToInt32(RegID),
                out CountRecords);
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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string args;
            if (e.CommandName == "AddPayment")
            {
                args = e.CommandArgument.ToString();

                Response.Redirect("AddPayment.aspx?OrderId=" + args);
            }

            if (e.CommandName == "Print")
            {
                args = e.CommandArgument.ToString();
                string url = "/ReceiptDownload.aspx?ref=" + args;
                ScriptManager.RegisterStartupScript(this, GetType(), "Open", $"window.open('{url}', '_blank');", true);

            }
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltrAmountRec = (Literal)e.Row.FindControl("ltrAmountRec");
                LinkButton btnPayment = (LinkButton)e.Row.FindControl("btnPayment");

                decimal amountReceived = 0;
                if (decimal.TryParse(ltrAmountRec.Text, out amountReceived))
                {
                    if (amountReceived > 0)
                    {
                        btnPayment.Visible = false;
                    }
                    else
                    {
                        btnPayment.Visible = true;
                    }
                }
                else
                {
                    btnPayment.Visible = true;
                }

            }
        }
    }
}