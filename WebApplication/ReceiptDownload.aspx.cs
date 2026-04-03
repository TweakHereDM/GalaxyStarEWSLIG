using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using Razorpay.Api;

namespace WebApplication
{
    public partial class ReceiptDownload : System.Web.UI.Page
    {
        CommonBLL objBLL = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ref"]))
            {

                string PaymentID = Request.QueryString["ref"].ToString();
                Prc_TransactionlistResult ObjUser = objBLL.TransactionDetails(0, 1, Convert.ToInt32(PaymentID), null, null, null, 0);
                if (ObjUser != null)
                {

                    ltrAmount.Text = ObjUser.Total_Price.ToString();
                    //ltrBankName.Text = ObjUser.BankName;
                    ltrDate.Text = ObjUser.PaymentDate?.ToString("dd/MM/yyyy");
                    ltrMobileNo.Text = ObjUser.Contact.ToString();
                    ltrName.Text = ObjUser.CustomerName.ToString();
                    ltrReceiptNo.Text = ObjUser.Order_ID.ToString();
                    ltrRegNo.Text = ObjUser.FormID.ToString();
                    ltrScheme.Text = ObjUser.ApplyFor;
                    ltrCategory.Text = ObjUser.Category;
                    //if (string.IsNullOrEmpty(ObjUser.Description))
                    //{
                    //    ltrDonationFor.Text = "";
                    //}
                    //else
                    //{
                    //    ltrDonationFor.Text = " for " + ObjUser.Description;

                    //}
                }
            }
            else
            {
                //    Response.Redirect("");
            }
        }


    }
}