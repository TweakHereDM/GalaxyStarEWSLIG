using BusinessLogicLayer;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Admin
{
    public partial class FormList : UserLoginSession
    {
        CommonBLL objBLL = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CommonBLL.BindFormCategoryDisctinct(drpCategory);
                drpCategory.Items.Insert(0, new ListItem("Select Category", ""));
                gvbind();
            }
        }
        protected void gvbind()
        {
            int CountRecords = 0;
            string FormID = txtFormID.Text == "" ? "0" : txtFormID.Text;
            GridView1.DataSource = objBLL.Formlist(0, txtSearch.Text, drpCategory.SelectedValue, DrpApplyFor.SelectedValue, Convert.ToInt32(FormID), 2, Convert.ToInt32(drpFormStatus.SelectedValue), out CountRecords);
            GridView1.DataBind();
            ltrRecordCount.Text = CountRecords.ToString();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvbind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            gvbind();

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var status = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FormStatus"));
                var ltr = (Literal)e.Row.FindControl("ltrFormStatus");
                var lbl = (Label)e.Row.FindControl("lblStatusText");
                Literal ltrRejectRemark = (Literal)e.Row.FindControl("ltrRejectRemark");
                lbl.Text = status == 0 ? "Pending" : status == 1 ? "Approve" : status == 2 ? "Rejected" : "";
                TextBox txtRejectRemark = (TextBox)e.Row.FindControl("txtRejectRemark");

                if (!string.IsNullOrEmpty(ltrRejectRemark.Text))
                {
                    txtRejectRemark.Visible = false;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow Row in GridView1.Rows)
            {
                CheckBox chkStatus = (CheckBox)Row.FindControl("chkStatus");
                Literal ltrRegID = (Literal)Row.FindControl("ltrRegID");
                TextBox txtRejectRemark = (TextBox)Row.FindControl("txtRejectRemark");

                var Message = objBLL.UpdateRejectRemark(ltrRegID.Text, txtRejectRemark.Text, Convert.ToInt32(chkStatus.Checked));

                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{Message}');", true);
            }
            gvbind();
        }
    }
}