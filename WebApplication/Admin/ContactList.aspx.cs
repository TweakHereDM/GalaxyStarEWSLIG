using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace WebApplication
{
    public partial class ContactList : UserLoginSession
    {
        CommonBLL objBLL = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                gvbind();
            }
        }
        protected void gvbind()
        {
            int CountRecords = 0;

            rpt_item.DataSource = objBLL.ContactList(txtSearchBy.Text, null, null, Convert.ToInt32(drpAssigned.SelectedValue), 2, out CountRecords);
            rpt_item.DataBind();
            ltrRecordCount.Text = CountRecords.ToString();
            if (CountRecords < 1)
            {
                btnDelete.Visible = false;
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvbind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            objBLL.DeleteContact(null);

            gvbind();
        }

        //protected void lnkExport_Click(object sender, EventArgs e)
        //{
        //    GridView dgGrid = new GridView();

        //    int CountRecords = 0;

        //    dgGrid.DataSource = objBLL.ContactList(0, txtFromDate.Text, txtToDate.Text, txtSearchBy.Text, drpCategory.SelectedValue, drpStaff.SelectedValue, 2, Convert.ToInt32(drpAssigned.SelectedValue), Convert.ToInt32(drpComplete.SelectedValue),
        //        out CountRecords);
        //    dgGrid.DataBind();


        //    objBLL.ExportToExcel(dgGrid, string.Format("ContactList{0}.xls", DateTime.UtcNow.AddMinutes(330)).ToString());
        //}



        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkDelete = new CheckBox();
            foreach (RepeaterItem mRow in rpt_item.Items)
            {
                chkDelete = (CheckBox)mRow.FindControl("chkDelete");

                if (chkSelectAll.Checked)
                {
                    chkDelete.Checked = true;

                }
                else
                {
                    chkDelete.Checked = false;

                }

            }
        }
    }
}