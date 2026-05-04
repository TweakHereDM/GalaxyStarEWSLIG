using BusinessLogicLayer;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            int CountRecords = 0;
            string FormID = txtFormID.Text == "" ? "0" : txtFormID.Text;

            GridView dgGrid = new GridView();


            dgGrid.DataSource = objBLL.FormlistExport(0, txtSearch.Text, drpCategory.SelectedValue, DrpApplyFor.SelectedValue, Convert.ToInt32(FormID), 2, Convert.ToInt32(drpFormStatus.SelectedValue), out CountRecords);
            dgGrid.DataBind();

            dgGrid.HeaderRow.Cells[0].Text = "Sr No";
            dgGrid.HeaderRow.Cells[1].Text = "Form ID/ No";
            dgGrid.HeaderRow.Cells[2].Text = "Applicant Name";
            dgGrid.HeaderRow.Cells[3].Text = "Father/ Husband Name";
            dgGrid.HeaderRow.Cells[4].Text = "Mobile No";
            dgGrid.HeaderRow.Cells[5].Text = "Apply For (LIG/EWS)";
            dgGrid.HeaderRow.Cells[6].Text = "Category";
            dgGrid.HeaderRow.Cells[7].Text = "Form Status";
            dgGrid.HeaderRow.Cells[8].Text = "Reject Remark";
            
            DataTable dt = new DataTable();

            if (dgGrid.HeaderRow != null)
            {

                for (int i = 0; i < dgGrid.HeaderRow.Cells.Count; i++)
                {
                    dt.Columns.Add(dgGrid.HeaderRow.Cells[i].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in dgGrid.Rows)
            {
                DataRow dr;
                dr = dt.NewRow();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dr[i] = row.Cells[i].Text.Replace("&nbsp;", "");
                }
                dt.Rows.Add(dr);
            }


            objBLL.ExportToExcelByDT(dt, string.Format("StarCityFormList.xls", DateTime.UtcNow.AddMinutes(330)).ToString());
        }
    }
}