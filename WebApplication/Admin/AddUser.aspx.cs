using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using Microsoft.SqlServer.Server;
using Razorpay.Api;

namespace WebApplication
{
    public partial class AddUser : UserLoginSession
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

                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    string UserID = Request.QueryString["Id"].ToString();
                    ltrUserID.Text = UserID;
                    Prc_RegisterListResult ObjUser = objBLL.RegisterList(Convert.ToInt32(UserID), null, null, null, 2, 2, out CountRecords).FirstOrDefault();
                    if (ObjUser != null)
                    {
                        drpBankName.SelectedValue = ObjUser.BankName;
                        DrpApplyFor.SelectedValue = ObjUser.ApplyFor;
                        DrpCategory.SelectedValue = ObjUser.Category;
                        DrpAnnualIncome.SelectedValue = ObjUser.AnnulIncome;
                        txtName.Text = ObjUser.Name;
                        txtDob.Text = ObjUser.DOB;
                        txtContact.Text = ObjUser.Contact;
                        txtEmail.Text = ObjUser.Email_ID;
                        txtDDAmount.Text = Convert.ToString(ObjUser.DDAmount);
                        txtDDNumber.Text = ObjUser.DDNumber;
                        txtRelationName.Text = ObjUser.RelationName;
                        txtidValues.Text = ObjUser.IDValues;
                        txtAadharNumber.Text = ObjUser.AadhaarNumber;
                        txtAddress.Text = ObjUser.Address;
                        txtCountry.Text = ObjUser.Country;
                        txtState.Text = ObjUser.State;
                        txtCity.Text = ObjUser.City;
                        txtPinCode.Text = ObjUser.Pincode;
                        inpGender.SelectedValue = ObjUser.Gender;
                        inpRelation.SelectedValue = ObjUser.Relation;
                        idTypeRadioList.SelectedValue = ObjUser.IDName;
                    }
                }

            }
        }

        protected void Clear()
        {
            drpBankName.SelectedValue = "";
            DrpApplyFor.SelectedValue = "";
            DrpCategory.SelectedValue = "";
            DrpAnnualIncome.SelectedValue = "";
            txtName.Text = "";
            txtDob.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtDDAmount.Text = "";
            txtDDNumber.Text = "";
            txtRelationName.Text = "";
            txtidValues.Text = "";
            txtAadharNumber.Text = "";
            txtBankAccountNum.Text = "";
            txtAddress.Text = "";
            txtCountry.Text = "";
            txtState.Text = "";
            txtCity.Text = "";
            txtPinCode.Text = "";
            inpGender.ClearSelection();
            inpRelation.ClearSelection();
            idTypeRadioList.ClearSelection();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string selectedGender = inpGender.SelectedValue;
            string selectedRelation = inpRelation.SelectedValue;
            string selectedidName = idTypeRadioList.SelectedValue;

            string selectedCategory = DrpCategory.SelectedItem.Text;
            string selectedApply = DrpApplyFor.SelectedValue;
            string selectedAnnualIncome = DrpAnnualIncome.SelectedItem.Text;
            txtDDAmount.Text = txtDDAmount.Text == "" ? "0" : txtDDAmount.Text;
            int userID = string.IsNullOrWhiteSpace(ltrUserID.Text) ? 0 : Convert.ToInt32(ltrUserID.Text);


            var RegID = objBLL.AddEditRegister(userID, selectedApply, txtName.Text, txtContact.Text, txtEmail.Text, selectedGender, txtDob.Text, selectedRelation, txtRelationName.Text,
                selectedidName, txtidValues.Text, txtAadharNumber.Text, null, txtBankAccountNum.Text, drpBankName.SelectedValue, null,
                selectedCategory, null, selectedAnnualIncome, txtAddress.Text, txtCountry.Text, txtState.Text, txtCity.Text, txtPinCode.Text,
                DateTime.Now.ToString("yyyy/MM/dd"), txtDDNumber.Text, Convert.ToDecimal(txtDDAmount.Text), 1);
            if (userID == 0)
            {
                decimal Amount = 0;
                if (selectedApply == "EWS")
                {
                    Amount = 500;
                }
                else
                {
                    Amount = 1000;
                }

                int fromId = 0;
                string OrderNumber = "";
                ABPrc_CreateOrderNumberResult ObjUser = objBLL.GenerateOrderNumber(0);
                if (ObjUser != null)
                {
                    string Id = ObjUser.OrderNumber;
                    string a3 = "";
                    Random ordeer_number = new Random();
                    a3 = ordeer_number.Next(111111111, 999999999).ToString();
                    OrderNumber = txtName.Text.First() + Id + a3;

                    fromId = 1000 + Convert.ToInt32(RegID);

                    string result = objBLL.Create_OrderSummary(0, Convert.ToInt32(RegID), Convert.ToString(fromId), OrderNumber, Amount, false, 0, 0, null, DateTime.Now.ToString("yyyy/MM/dd"),
                        DateTime.Now.ToString("yyyy/MM/dd"), null, Session.SessionID);

                }

                if (chkRegFees.Checked == true)
                {
                    objBLL.UpdatePaymentStatus(OrderNumber, txtDDNumber.Text, "Admin", "", "Admin", "Success", "", "", "", "", "", "Customer",
                                Amount, txtName.Text, txtRelationName.Text, Convert.ToString(fromId), RegID);
                }

                Response.Write("<script>alert('User Added Successfully')</script>");
            }
            else
            {
                Response.Write("<script>alert('User Updated Successfully')</script>");

            }
            Clear();
        }
    }
}