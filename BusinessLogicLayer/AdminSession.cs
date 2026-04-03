using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BusinessLogicLayer
{
    public class AdminSession
    {
        
        public static Int32 AdminID
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["AdminID"] != null)
                {
                    return (Int32)HttpContext.Current.Session["AdminID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["AdminID"] = value;
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
        public static string AdminName
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["AdminName"] != null)
                {
                    return (string)HttpContext.Current.Session["AdminName"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["AdminName"] = value;
            }
        }
        public static string AdminMobile
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["AdminMobile"] != null)
                {
                    return (string)HttpContext.Current.Session["AdminMobile"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["AdminMobile"] = value;
            }
        }
        public static string AdminGender
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["AdminGender"] != null)
                {
                    return (string)HttpContext.Current.Session["AdminGender"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["AdminGender"] = value;
            }
        }
        public static Int32 AdminWard
        {
            get
            {

                if (HttpContext.Current.Session != null && HttpContext.Current.Session["AdminWard"] != null)
                {
                    return (Int32)HttpContext.Current.Session["AdminWard"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["AdminWard"] = value;
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

    }
}
