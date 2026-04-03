using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BusinessLogicLayer
{
    public class WebsiteSession
    {

        public static Int32 UserID
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["UserID"] != null)
                {
                    return (Int32)HttpContext.Current.Session["UserID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["UserID"] = value;
            }
        }
        public static string SetDate
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["SetDate"] != null)
                {
                    return (string)HttpContext.Current.Session["SetDate"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["SetDate"] = value;
            }
        }
        public static Int32 CountNo
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["CountNo"] != null)
                {
                    return (Int32)HttpContext.Current.Session["CountNo"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["CountNo"] = value;
            }
        }
        public static decimal Payable
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["Payable"] != null)
                {
                    return Convert.ToDecimal(HttpContext.Current.Session["Payable"]);
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["Payable"] = value;
            }
        }
        public static decimal Price
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["Price"] != null)
                {
                    return (decimal)HttpContext.Current.Session["Price"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["Price"] = value;
            }
        }

        public static bool Settle
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["Settle"] != null)
                {
                    return (bool)HttpContext.Current.Session["Settle"];
                }
                else
                {
                    return false;
                }
            }
            set
            {
                HttpContext.Current.Session["Settle"] = value;
            }
        }
        public static bool Balance
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["Balance"] != null)
                {
                    return (bool)HttpContext.Current.Session["Balance"];
                }
                else
                {
                    return false;
                }
            }
            set
            {
                HttpContext.Current.Session["Balance"] = value;
            }
        }
        public static bool IsAdmin
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["IsAdmin"] != null)
                {
                    return (bool)HttpContext.Current.Session["IsAdmin"];
                }
                else
                {
                    return false;
                }
            }
            set
            {
                HttpContext.Current.Session["IsAdmin"] = value;
            }
        }

        public static string EmailID
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["EmailID"] != null)
                {
                    return (string)HttpContext.Current.Session["EmailID"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["EmailID"] = value;
            }
        }
        public static string OrderID
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["OrderID"] != null)
                {
                    return (string)HttpContext.Current.Session["OrderID"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["OrderID"] = value;
            }
        }
        public static string CallNo
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["CallNo"] != null)
                {
                    return (string)HttpContext.Current.Session["CallNo"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["CallNo"] = value;
            }
        }
        public static string UserName
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["UserName"] != null)
                {
                    return (string)HttpContext.Current.Session["UserName"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }
        public static string Father
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["Father"] != null)
                {
                    return (string)HttpContext.Current.Session["Father"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["Father"] = value;
            }
        }
        public static string fromId
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["fromId"] != null)
                {
                    return (string)HttpContext.Current.Session["fromId"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["fromId"] = value;
            }
        }
        public static Int32 RegId
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["RegId"] != null)
                {
                    return (Int32)HttpContext.Current.Session["RegId"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["RegId"] = value;
            }
        }
        public static string UserMobile
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["UserMobile"] != null)
                {
                    return (string)HttpContext.Current.Session["UserMobile"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["UserMobile"] = value;
            }
        }
        public static string UserGender
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["UserGender"] != null)
                {
                    return (string)HttpContext.Current.Session["UserGender"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["UserGender"] = value;
            }
        }
        public static Int32 UserWard
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["UserWard"] != null)
                {
                    return (Int32)HttpContext.Current.Session["UserWard"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["UserWard"] = value;
            }
        }
        public static string OTP
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["OTP"] != null)
                {
                    return (string)HttpContext.Current.Session["OTP"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["OTP"] = value;
            }
        }

        public static string randomStr
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["randomStr"] != null)
                {
                    return (string)HttpContext.Current.Session["randomStr"];
                }
                else
                {
                    return String.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["randomStr"] = value;
            }
        }



        public static string RedirectReferral
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["RedirectReferral"] != null)
                {
                    return (string)HttpContext.Current.Session["RedirectReferral"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["RedirectReferral"] = value;
            }
        }
        public static Int32 ResumeUpload
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["ResumeUpload"] != null)
                {
                    return (Int32)HttpContext.Current.Session["ResumeUpload"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["ResumeUpload"] = value;
            }
        }
        public static Int32 BusinessUpload
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["BusinessUpload"] != null)
                {
                    return (Int32)HttpContext.Current.Session["BusinessUpload"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["BusinessUpload"] = value;
            }
        }
        public static string OrderNumber
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["OrderNumber"] != null)
                {
                    return (string)HttpContext.Current.Session["OrderNumber"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["OrderNumber"] = value;
            }
        }
        public static decimal PayableAmount
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["PayableAmount"] != null)
                {
                    return (decimal)HttpContext.Current.Session["PayableAmount"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["PayableAmount"] = value;
            }
        }
        public static bool lastSaved
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["lastSaved"] != null)
                {
                    return (bool)HttpContext.Current.Session["lastSaved"];
                }
                else
                {
                    return false;
                }
            }
            set
            {
                HttpContext.Current.Session["lastSaved"] = value;
            }
        }

    }
}
