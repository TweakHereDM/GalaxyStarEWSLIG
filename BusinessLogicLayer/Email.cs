using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using TemplateParser;
using System.Net;
using System.Net.Mail;
using System.Collections;

public class Email
{
    public static string SendEmail(string FilePath, Hashtable templateVars, string Mailfrom, string MailTo, string Subject, params string[] BCC)
    {
        Parser parser = new Parser(HttpContext.Current.Server.MapPath("~/Templates/" + FilePath), templateVars);
        return SendEMail(Mailfrom, MailTo, Subject, parser.Parse(), BCC);
    }
    public static string SendEMail(string Mailfrom, string MailTo, string Subject, string body, params string[] BCC)
    {
        try
        {
            System.Net.Mail.MailAddress mailadd = new System.Net.Mail.MailAddress(Mailfrom, System.Configuration.ConfigurationManager.AppSettings["smtp_DisplayName"]);
            System.Net.Mail.MailMessage mailmsg = new System.Net.Mail.MailMessage();
            mailmsg.To.Add(MailTo);
            for (int I = 0; I <= BCC.GetUpperBound(0); I++)
            {
                mailmsg.Bcc.Add(BCC[I]);
            }
            mailmsg.From = mailadd;
            mailmsg.Subject = Subject;
            mailmsg.Body = body;
            mailmsg.IsBodyHtml = true;
            System.Net.NetworkCredential cred = new System.Net.NetworkCredential();
            cred.UserName = System.Configuration.ConfigurationManager.AppSettings["smtp_username"];
            cred.Password = System.Configuration.ConfigurationManager.AppSettings["smtp_pwd"];
            System.Net.Mail.SmtpClient mailsmtp = new System.Net.Mail.SmtpClient();
            mailsmtp.Credentials = cred;
            mailsmtp.Host = System.Configuration.ConfigurationManager.AppSettings["smtp_host"];
            mailsmtp.Send(mailmsg);
            return "Email successfully sent.";
        }
        catch (Exception ex)
        {
            return "Send Email Failed." + ex.Message;
        }

    } 
    //public static string SendEMail(string Mailfrom, string MailTo, string Subject, string body, params string[] BCC)
    //{
    //    try
    //    {
    //        System.Net.Mail.MailAddress mailadd = new System.Net.Mail.MailAddress(Mailfrom, System.Configuration.ConfigurationManager.AppSettings["smtp_DisplayName"]);
    //        System.Net.Mail.MailMessage mailmsg = new System.Net.Mail.MailMessage();
    //        mailmsg.To.Add(MailTo);
    //        for (int I = 0; I <= BCC.GetUpperBound(0); I++)
    //        {
    //            mailmsg.Bcc.Add(BCC[I]);
    //        }
    //        mailmsg.From = mailadd;
    //        mailmsg.Subject = Subject;
    //        mailmsg.Body = body;
    //        mailmsg.IsBodyHtml = true;
    //        System.Net.NetworkCredential cred = new System.Net.NetworkCredential();
    //        cred.UserName = System.Configuration.ConfigurationManager.AppSettings["smtp_username"];
    //        cred.Password = System.Configuration.ConfigurationManager.AppSettings["smtp_pwd"];
    //        System.Net.Mail.SmtpClient mailsmtp = new System.Net.Mail.SmtpClient();
    //        mailsmtp.Credentials = cred;
    //        mailsmtp.Host = System.Configuration.ConfigurationManager.AppSettings["smtp_host"];
    //        mailsmtp.Send(mailmsg);
    //        return "Email successfully sent.";
    //    }
    //    catch (Exception ex)
    //    {
    //        return "Send Email Failed." + ex.Message;
    //    }

    //}   

}