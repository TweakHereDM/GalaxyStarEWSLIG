using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Admin
{
    public partial class UpdatePayment : UserLoginSession
    {
        CommonBLL objBLL = new CommonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["OrderId"]))
                {
                    string diam = ltrOrderID.Text = Request.QueryString["OrderId"].ToString();
                    Prc_TransactionlistResult ObjUser = objBLL.TransactionDetails(0, 2, 2, diam, null, null, 0);
                    if (ObjUser != null)
                    {
                        lblApplyFor.Text = ObjUser.ApplyFor;
                        lblName.Text = ObjUser.CustomerName;
                        ltrRelationName.Text = ObjUser.RelationName;
                        lblCategory.Text = ObjUser.Category.ToString();
                        lblContact.Text = ObjUser.Contact.ToString();
                        txtPrice.Text = ObjUser.Total_Price.ToString();
                        txtAmount.Text = ObjUser.AmountReceived.ToString();
                        ltrRegID.Text = ObjUser.RegID.ToString();

                    }
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            txtAmount.Text = txtAmount.Text == "" ? "0" : txtAmount.Text;
            txtPrice.Text = txtPrice.Text == "" ? "0" : txtPrice.Text;

            objBLL.UpdateAmount(ltrOrderID.Text, Convert.ToDecimal(txtPrice.Text), Convert.ToDecimal(txtAmount.Text));

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