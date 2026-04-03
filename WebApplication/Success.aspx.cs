using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.IO;
using System.Net.Mail;
using System.Web.Configuration;
using Razorpay.Api;


namespace WebApplication
{
    public partial class Success : System.Web.UI.Page
    {
        CommonBLL objBLL = new CommonBLL();
        string diam = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["refRazor"]))
                {
                    bool IsValidRequest = true;
                    try
                    {
                        ltrOrderID.Text = diam = Request.QueryString["refRazor"].ToString();
                        string paymentId = Request.Form["razorpay_payment_id"];
                        string orderId = Request.Form["razorpay_order_id"];
                        string signature = Request.Form["razorpay_signature"];


                        string key = RazorPayApi.key;
                        string secret = RazorPayApi.secret;

                        RazorpayClient client = new RazorpayClient(key, secret);

                        Dictionary<string, string> attributes = new Dictionary<string, string>();

                        attributes.Add("razorpay_payment_id", paymentId);
                        attributes.Add("razorpay_order_id", orderId);
                        attributes.Add("razorpay_signature", signature);

                        Utils.verifyPaymentSignature(attributes);
                        ltrtxn_id.Text = paymentId;
                        ltrpayment_stat.Text = "Success";


                        objBLL.UpdatePaymentStatus(diam, ltrtxn_id.Text, "RazorPay", "", "Online", "Success", "", "", "", "", "", "Customer",
                            Convert.ToDecimal(WebsiteSession.Payable), WebsiteSession.UserName, WebsiteSession.Father, WebsiteSession.fromId,
                            WebsiteSession.RegId.ToString());

                    }
                    catch (Exception ex)
                    {
                        IsValidRequest = false;
                        Response.Write("<script>alert('" + ex.Message + "')</script>");
                    }
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void lnkbtn_Click(object sender, EventArgs e)
        {


            Response.Redirect("ReceiptList.aspx?ref=" + WebsiteSession.UserMobile);


        }
    }
}