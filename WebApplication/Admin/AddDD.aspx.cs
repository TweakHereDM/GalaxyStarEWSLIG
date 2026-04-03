using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class AddDD : UserLoginSession
    {
        CommonBLL objBLL = new CommonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvBind();
            }
        }

        protected void gvBind()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["RegID"]))
            {
                string RegID = Request.QueryString["RegID"].ToString();

                Prc_TransactionlistResult ObjUser = objBLL.TransactionDetails(0, 1, 2, null, null, null, Convert.ToInt32(RegID));
                if (ObjUser != null)
                {
                    lblApplyFor.Text = ObjUser.ApplyFor;
                    lblName.Text = ObjUser.CustomerName;
                    lblCategory.Text = ObjUser.Category.ToString();
                    lblContact.Text = ObjUser.Contact.ToString();
                    txtDDAmount.Text = ObjUser.DDAmount.ToString("0.00") ?? "";
                    txtDDNumber.Text = ObjUser.DDNumber?.ToString() ?? "";
                    txtAccountHolderName.Text = ObjUser.AccountHolderName?.Trim() ?? "";
                    txtBankAccountNum.Text = (ObjUser.BankAccountNumber ?? "").Trim();
                    txtIFSCCode.Text = ObjUser.IFSCCode?.Trim() ?? "";
                    txtBankAddress.Text = ObjUser.BankAddress?.Trim() ?? "";
                    DrpBankName.SelectedValue = ObjUser.BankName;
                    lblFormID.Text = ObjUser.FormID.ToString();
                    txtReturnName.Text = ObjUser.DDReturnToName;
                    idTypeRadioList.SelectedValue = ObjUser.DDReturnIDName;
                    txtIDNo.Text = string.IsNullOrEmpty(ObjUser.DDReturnIDValue) ? "" : ObjUser.DDReturnIDValue.ToString();
                    txtDDDepositor.Text = string.IsNullOrEmpty(ObjUser.DDDepositer) ? ObjUser.CustomerName : ObjUser.DDDepositer; 
                    txtDDDepositorIDNo.Text = string.IsNullOrEmpty(ObjUser.DDDepositerIDNo) ? ObjUser.AadhaarNumber : ObjUser.DDDepositerIDNo;
                    rdoDepositorID.SelectedValue = string.IsNullOrEmpty(ObjUser.DDDepositerID) ? "Adhar Card" : ObjUser.DDDepositerID;
                    drpRelation.SelectedValue = ObjUser.DDDepositorRelation;
                }
            }
            else
            {
                Response.Redirect("RegisterList.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string RegID = Request.QueryString["RegID"].ToString();
            objBLL.UpdateDDAmount(RegID, txtAccountHolderName.Text, DrpBankName.SelectedValue, txtBankAccountNum.Text, txtIFSCCode.Text, txtBankAddress.Text,
                Convert.ToDecimal(txtDDAmount.Text), txtDDNumber.Text, txtDDDepositor.Text, rdoDepositorID.SelectedValue, txtDDDepositorIDNo.Text, drpRelation.SelectedValue);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string PaymentID = lblFormID.Text;
            if (!string.IsNullOrEmpty(PaymentID))
            {
                string url = $"DDReceipt.aspx?PaymentID={PaymentID}";
                ScriptManager.RegisterStartupScript(this, GetType(), "openNewTab", $"window.open('{url}', '_blank');", true);
            }
        }

        protected void lnkDDReturn_Click(object sender, EventArgs e)
        {
            string RegID = Request.QueryString["RegID"].ToString();
            string selectedidName = idTypeRadioList.SelectedValue;
            string interest = objBLL.UpdateDDReturn(Convert.ToInt32(RegID), txtReturnName.Text, selectedidName, txtIDNo.Text, 1);
            Response.Write("<script>alert('" + interest + "')</script>");
        }

        protected void lnkDDReturnPrint_Click(object sender, EventArgs e)
        {
            string PaymentID = lblFormID.Text;
            if (!string.IsNullOrEmpty(PaymentID))
            {
                string url = $"DDReturnPrint.aspx?PaymentID={PaymentID}";
                ScriptManager.RegisterStartupScript(this, GetType(), "openNewTab", $"window.open('{url}', '_blank');", true);
            }
        }
    }
}