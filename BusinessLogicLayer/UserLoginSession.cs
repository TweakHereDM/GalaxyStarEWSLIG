using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusinessLogicLayer
{
    public class UserLoginSession : System.Web.UI.Page
    {

        protected override void OnLoad(System.EventArgs e)
        {

            if (WebsiteSession.UserID== 0)// if (string.IsNullOrEmpty(PromoterSession.PsrNo.ToString()))
            {
                WebsiteSession.RedirectReferral = HttpContext.Current.Request.Url.AbsolutePath;
                Response.Redirect("Index.aspx?msg=session-expired");
            }
            else
            {
               
            }
            base.OnLoad(e);
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
