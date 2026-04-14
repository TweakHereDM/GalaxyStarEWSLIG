using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using Razorpay.Api;

namespace WebApplication
{
    public partial class RazorPayCheckout : System.Web.UI.Page
    {
        public CommonBLL objBLL = new CommonBLL();
        
        public string orderId;
        public decimal amt;
        public string name;
        public string email;
        public string mobileno;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Master Page
            if (!IsPostBack)
            {

                if (WebsiteSession.Payable > 0)
                {
                    ltrOrderNo.Text = WebsiteSession.OrderNumber;

                    //if (decimal.TryParse(WebsiteSession.Payable.ToString(), out decimal amount))
                    //{
                    //    WebsiteSession.Payable = Math.Round(amount); 
                    //}

                    ltrPayableAmount.Text = WebsiteSession.Payable.ToString("N2");

                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    //decimal Payment = Math.Round(WebsiteSession.Payable, 2);

                    //amt = Payment * 100; // its 500 bec it multiple by 100 by default so to make rs 500 u have to write 5000
                    //name = WebsiteSession.UserName;
                    //email = WebsiteSession.EmailID;
                    //mobileno = WebsiteSession.UserMobile;
                    //string receiptnumber = WebsiteSession.OrderNumber;

                    //Dictionary<string, object> input = new Dictionary<string, object>();
                    //input.Add("amount", amt); // this amount should be same as transaction amount
                    //input.Add("currency", "INR");
                    //input.Add("payment_capture", 1);
                    //input.Add("receipt", WebsiteSession.OrderNumber);

                    //string key = RazorPayApi.key;
                    //string secret = RazorPayApi.secret;

                    //RazorpayClient client = new RazorpayClient(key, secret);

                    //Razorpay.Api.Order order = client.Order.Create(input);
                    //orderId = order["id"].ToString();
                    //WebsiteSession.OrderID = orderId;
                    //WebsiteSession.PayableAmount = amt;
                    
                }
                else
                {
                    //Response.Redirect("Unpaid_Invoice_Order_Details?ref=" + WebsiteSession.OrderNumber);
                }

            }
        }
    }
}