using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Admin
{
    public partial class AddPayment : UserLoginSession
    {
        CommonBLL objBLL = new CommonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["OrderId"]))
            {
                string diam = ltrOrderID.Text = Request.QueryString["OrderId"].ToString();
                Prc_TransactionlistResult ObjUser = objBLL.TransactionDetails(0, 0, 2, diam, null, null, 0);
                if (ObjUser != null)
                {
                    lblApplyFor.Text = ObjUser.ApplyFor;
                    lblName.Text = ObjUser.CustomerName;
                    ltrRelationName.Text = ObjUser.RelationName;
                    lblCategory.Text = ObjUser.Category.ToString();
                    lblContact.Text = ObjUser.Contact.ToString();
                    txtAmount.Text = ObjUser.Total_Price.ToString();
                    ltrRegID.Text = ObjUser.RegID.ToString();
                    
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string selectedBamkName = DrpBankName.Value;
            txtAmount.Text = txtAmount.Text == "" ? "0" : txtAmount.Text;

            objBLL.UpdatePaymentStatus(ltrOrderID.Text, txttxnID.Text, selectedBamkName, "", "Admin", "Success", "", "", "", "", "", "Customer",
                           Convert.ToDecimal(txtAmount.Text), lblName.Text, ltrRelationName.Text, null, ltrRegID.Text);

            string orderID = ltrOrderID.Text;
            string script = $@"
                <script type='text/javascript'>
                    alert('Customer Paid Successfully');
                    window.location.href = 'TransactionList.aspx?ref={orderID}';
                </script>";

            ClientScript.RegisterStartupScript(this.GetType(), "AlertAndRedirect", script);
        }
    }
}