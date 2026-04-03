using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Diagnostics;

namespace WebApplicationAdmin
{
    public partial class Index : System.Web.UI.Page
    {
        CommonBLL objBLL = new CommonBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }


        protected void buttLogin_Click(object sender, EventArgs e)
        {
            Page.Validate("Index");
            if (Page.IsValid)
            {
                ABproc_CheckuserLoginResult objLogin = objBLL.UserLogin(txtUser.Text.ToString(), txtPass.Text.ToString(),
                            Request.ServerVariables["remote_addr"]);
                if (objLogin != null)
                {
                    string result = objLogin.LoginResult.ToString();
                    if (result == "1")
                    {
                        WebsiteSession.UserID = Convert.ToInt32(objLogin.ID);
                        WebsiteSession.UserName = objLogin.UserName;
                        WebsiteSession.IsAdmin = objLogin.IsAdmin;
                        if (!string.IsNullOrEmpty(WebsiteSession.RedirectReferral))
                        {
                            Response.Redirect(WebsiteSession.RedirectReferral);
                        }
                        else
                        {

                            Response.Redirect("dashboard.aspx");
                        }


                    }
                    else
                    {
                        Session.Abandon();
                        errormessage("Invalid User ID/Password", "Index");
                    }
                }
                else
                {
                    Session.Abandon();
                    errormessage("Invalid User ID/Password", "Index");
                }
            }
        }
        public void errormessage(string error, string ValidationGroup)
        {
            CustomValidator cv = new CustomValidator();
            cv.IsValid = false;
            cv.ErrorMessage = error;
            cv.ValidationGroup = ValidationGroup;
            this.Page.Validators.Add(cv);
        }

    }
}