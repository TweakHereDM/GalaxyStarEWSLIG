using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using BusinessLogicLayer;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication
{
    public partial class Apply : System.Web.UI.Page
    {
        CommonBLL objBLL = new CommonBLL();
        decimal TotalAmount = 0;
        int CountRecords = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonBLL.BindFormCategoryDisctinct(DrpCategory);
                DrpCategory.Items.Insert(0, new ListItem("--SELECT Cast--", ""));


            }
        }

        protected void Clear()
        {
            DrpApplyFor.SelectedValue = "";
            DrpCategory.SelectedValue = "";
            DrpAnnualIncome.SelectedValue = "";
            txtName.Text = "";
            txtDob.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtRelationName.Text = "";
            txtidValues.Text = "";
            txtAadharNumber.Text = "";
            txtAddress.Text = "";
            txtCountry.Text = "";
            txtState.Text = "";
            txtCity.Text = "";
            txtPinCode.Text = "";
            inpGender.ClearSelection();
            inpRelation.ClearSelection();
            idTypeRadioList.ClearSelection();
        }

        protected void btnSav_Click(object sender, EventArgs e)
        {
            string selectedGender = inpGender.SelectedValue;
            string selectedRelation = inpRelation.SelectedValue;
            string selectedidName = idTypeRadioList.SelectedValue;

            string selectedCategory = DrpCategory.SelectedItem.Text;
            string selectedApply = DrpApplyFor.SelectedValue;
            string selectedAnnualIncome = DrpAnnualIncome.SelectedItem.Text;

            var RegID = objBLL.AddEditRegister(0, selectedApply, txtName.Text, txtContact.Text, txtEmail.Text, selectedGender, txtDob.Text, selectedRelation, 
                txtRelationName.Text, selectedidName, txtidValues.Text, txtAadharNumber.Text, null, null, null, null, selectedCategory, null, selectedAnnualIncome, 
                txtAddress.Text, txtCountry.Text, txtState.Text, txtCity.Text, txtPinCode.Text, DateTime.Now.ToString("yyyy/MM/dd"), null, 0, 1);

            decimal Amount = 0;
            if (selectedApply == "EWS")
            {
                Amount = 500;
            }
            else
            {
                Amount = 1000;
            }


            ABPrc_CreateOrderNumberResult ObjUser = objBLL.GenerateOrderNumber(0);
            if (ObjUser != null)
            {
                string Id = ObjUser.OrderNumber;
                string a3 = "";
                Random ordeer_number = new Random();
                a3 = ordeer_number.Next(111111111, 999999999).ToString();
                string OrderNumber = txtName.Text.First() + Id + a3;

                

                string result = objBLL.Create_OrderSummary(0, Convert.ToInt32(RegID), null, OrderNumber, Amount, false, 0, 0, null, DateTime.Now.ToString("yyyy/MM/dd"),
                    DateTime.Now.ToString("yyyy/MM/dd"), null, Session.SessionID);

                WebsiteSession.OrderNumber = OrderNumber;
                WebsiteSession.UserName = txtName.Text;
                WebsiteSession.Father = txtRelationName.Text;
                WebsiteSession.RegId = Convert.ToInt32(RegID);
                WebsiteSession.EmailID = txtEmail.Text;
                WebsiteSession.UserMobile = txtContact.Text;
                WebsiteSession.Payable = Convert.ToDecimal(Amount);

                Response.Redirect("RazorPayCheckout.aspx");

                Clear();

            }
        }

    }
}