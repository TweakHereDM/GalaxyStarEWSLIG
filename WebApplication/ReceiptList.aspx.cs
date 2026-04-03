using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using BusinessLogicLayer;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication
{
    public partial class ReceiptList : System.Web.UI.Page
    {
        CommonBLL objBLL = new CommonBLL();
        decimal TotalAmount = 0;
        int CountRecords = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ref"]))
                {
                    txtSearchBy.Text = Request.QueryString["ref"].ToString();
                    btnSearch_Click(null, null);
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int CountRecords = 0;

            if (!string.IsNullOrEmpty(txtSearchBy.Text) || !string.IsNullOrEmpty(txtFormNo.Text))
            {
                string FormNo = txtFormNo.Text == "" ? "2" : txtFormNo.Text;

                grdView.DataSource = objBLL.Transactionlist(0, 1, Convert.ToInt32(FormNo), null, txtSearchBy.Text, null, null, 0, out CountRecords);
                grdView.DataBind();
            }

        }
        
    }
}