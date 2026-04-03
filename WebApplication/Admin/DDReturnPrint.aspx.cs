using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class DDReturnPrint : System.Web.UI.Page
    {

        CommonBLL objBLL = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["PaymentID"]))
            {

                string PaymentID = Request.QueryString["PaymentID"].ToString();
                Prc_TransactionlistResult ObjUser = objBLL.TransactionDetails(0, 1, Convert.ToInt32(PaymentID), null, null, null, 0);
                if (ObjUser != null)
                {
                    ltrAmount1.Text = ltrAmount.Text = ObjUser.DDAmount.ToString();
                    ltrDate1.Text = ltrDate.Text = ObjUser.DDReturnDate?.ToString("dd/MM/yyyy");
                    ltrName1.Text = ltrName.Text = ObjUser.CustomerName?.ToString();
                    ltrReceiptNo1.Text = ltrReceiptNo.Text = ObjUser.Order_ID.ToString();
                    ltrRegNo1.Text = ltrRegNo.Text = ObjUser.FormID.ToString();
                    ltrScheme1.Text = ltrScheme.Text = ObjUser.ApplyFor;
                    ltrCategory1.Text = ltrCategory.Text = ObjUser.Category;
                    ltrBankName1.Text = ltrBankName.Text = ObjUser.BankName;
                    ltrDDAmount1.Text = ltrDDAmount.Text = ObjUser.DDAmount.ToString();
                    ltrDDnumber1.Text = ltrDDnumber.Text = ObjUser.DDNumber;
                    ltrIDName1.Text = ltrIDName.Text = ObjUser.DDReturnIDName;
                    ltrIDValue1.Text = ltrIDValue.Text = ObjUser.DDReturnIDValue;
                    ltrDDReceiver1.Text = ltrDDReceiver.Text = ObjUser.DDReturnToName;
                }
            }
            else
            {
                //    Response.Redirect("");
            }
        }


    }
}