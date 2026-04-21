using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Security.Cryptography;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace BusinessLogicLayer
{
    public class CommonBLL
    {
        private byte[] key = { };
        private byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };


        public string Encrypt(string stringToEncrypt)
        {
            try
            {
                string SEncryptionKey = "abhishek1234567890";
                key = System.Text.Encoding.UTF8.GetBytes(SEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray()).Replace("+", " ");
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string Decrypt(string stringToDecrypt)
        {
            stringToDecrypt = stringToDecrypt.Replace(" ", "+");
            byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];
            try
            {
                string SEncryptionKey = "abhishek1234567890";
                key = System.Text.Encoding.UTF8.GetBytes(SEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public void ExportToExcel(GridView gv, string fileName)
        {
            HttpContext ctx = HttpContext.Current;
            ctx.Response.Clear();
            ctx.Response.Buffer = true;
            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(sw);
            ctx.Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            ctx.Response.Charset = "";
            ctx.Response.ContentType = "application/vnd.ms-excel";
            gv.RenderControl(hw);
            ctx.Response.Write(sw.ToString());
            ctx.Response.End();
        }
        public string ImageUpload(FileUpload fileUpload, string ImagePrefix)
        {
            string ImageName = "!";
            try
            {
                if (fileUpload.HasFile)
                {
                    Int32 fileSize = fileUpload.PostedFile.ContentLength;
                    Stream stream = fileUpload.FileContent;
                    if (fileSize > 26246026)
                    {
                        return "!file size too large, can't upload";
                    }
                    if (!IsValidImage(stream))
                    {
                        return "!file is not an image or video";
                    }
                    Random rand = new Random((int)DateTime.Now.Ticks);
                    string tostr = DateTime.Now.ToString().Replace("/", "").Replace("|", "").Replace(":", "").Replace(" ", "");
                    int numIterations = 0;
                    numIterations = rand.Next(111111, 999999);
                    string filenewbasename = ImagePrefix + tostr + numIterations;
                    if (fileUpload.FileName.ToString() != "")
                    {
                        string fileName = filenewbasename + System.IO.Path.GetExtension(fileUpload.FileName).ToLower();
                        fileUpload.PostedFile.SaveAs(HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Storage"]) + fileName);
                        ImageName = fileName.ToString();
                    }
                }
            }
            catch (System.ArgumentException exp)
            {
                ImageName = "!Invalid File" + exp;
            }
            catch (Exception ex)
            {
                ImageName = "!" + ex.Message;
            }
            return ImageName;
        }
        public string ImageUpload12MB(FileUpload fileUpload, string ImagePrefix)
        {
            string ImageName = "!";
            try
            {
                if (fileUpload.HasFile)
                {
                    Int32 fileSize = fileUpload.PostedFile.ContentLength;
                    Stream stream = fileUpload.FileContent;
                    if (fileSize > 12400000)
                    {
                        return "!File size should less than 12 MB";
                    }
                    if (!IsValidImage(stream))
                    {
                        return "!file is not an image or video";
                    }
                    Random rand = new Random((int)DateTime.Now.Ticks);
                    string tostr = DateTime.Now.ToString().Replace("/", "").Replace("|", "").Replace(":", "").Replace(" ", "");
                    int numIterations = 0;
                    numIterations = rand.Next(111111, 999999);
                    string filenewbasename = ImagePrefix + tostr + numIterations;
                    if (fileUpload.FileName.ToString() != "")
                    {
                        string fileName = filenewbasename + System.IO.Path.GetExtension(fileUpload.FileName).ToLower();
                        fileUpload.PostedFile.SaveAs(HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["Storage"]) + fileName);
                        ImageName = fileName.ToString();
                    }
                }
            }
            catch (System.ArgumentException exp)
            {
                ImageName = "!Invalid File" + exp;
            }
            catch (Exception ex)
            {
                ImageName = "!" + ex.Message;
            }
            return ImageName;
        }
        private static bool IsValidImage(Stream imageStream)
        {
            if (imageStream.Length > 0)
            {
                byte[] header = new byte[20];
                imageStream.Read(header, 0, header.Length);

                bool hasImageHeader = _imageHeaders.Count(magic =>
                {
                    int i = 0;
                    if (magic.Length > header.Length)
                        return false;
                    return magic.Count(b => { return b == header[i++]; }) == magic.Length;
                }) > 0;
                return hasImageHeader;
            }
            return false;
        }
        private static byte[][] _imageHeaders = new byte[][]
        {
            new byte[]{ 0xFF, 0xD8 },
            new byte[]{ 0x42, 0x4D},
            new byte[]{ 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A },
            new byte[]{ 0x47, 0x49, 0x46 },   
            //new byte[]{ 0x41, 0x56, 0x49, 0x20 }, 
            //new byte[]{ 0x52, 0x49, 0x46, 0x46 }, 
            //new byte[]{ 0x30, 0x26, 0xB2, 0x75, 0x8E, 0x66, 0xCF, 0x11, 0xA6, 0xD9, 0x00, 0xAA, 0x00, 0x62 }, 
            //new byte[]{ 0x00, 0x00, 0x01, 0xB3 }, 
            //new byte[]{ 0x00, 0x00, 0x01, 0xba}, 
            //new byte[]{ 0x00, 0x00, 0x00, 0x18}, 
            new byte[]{ 0x46, 0x4C, 0x56 }
        };
        public ABproc_CheckuserLoginResult UserLogin(string UserID, string Password, string IPAddress)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                return (ABproc_CheckuserLoginResult)ObjContext.ABproc_CheckuserLogin(UserID, Password, IPAddress).ToList().SingleOrDefault();
            }
        }
        //public string RemoveSessionID(int ID)
        //{


        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.ABPrc_RemoveSessionID(ID);
        //    }

        //    return ErrMsg;
        //}

        public List<Prc_AdminPanelPageListResult> AdminPanelPageList(int Status, int AdminID, out int CountRecord)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                List<Prc_AdminPanelPageListResult> dList = ObjContext.Prc_AdminPanelPageList(Status, AdminID).ToList();
                CountRecord = dList.Count();

                return dList;
            }
        }
        public List<Prc_AdminPanelMenuResult> AdminPanelMenu(int ParentMenuID, int AdminID, out int CountRecord)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                List<Prc_AdminPanelMenuResult> dList = ObjContext.Prc_AdminPanelMenu(ParentMenuID, AdminID).ToList();
                CountRecord = dList.Count();
                return dList;
            }
        }
        public Prc_AdminPanelPagePermissionCheckResult AdminPanelPagePermissionCheck(string PageURL, int AdminID)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                return (Prc_AdminPanelPagePermissionCheckResult)ObjContext.Prc_AdminPanelPagePermissionCheck(PageURL, AdminID).Take(1).ToList().SingleOrDefault();
            }
        }
        public string UpdatePagePermission(int ID, int IsActive)
        {

            string ErrMsg = "!";

            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjContext.Prc_UpdatePagePermission(ID, IsActive);
            }
            return ErrMsg;
        }
        public List<Prc_ContactListResult> ContactList(string SearchBy, string Category, string ApplyFor, int Alloty, int Status, out int CountRecord)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                SearchBy = SearchBy == "" ? null : SearchBy;
                Category = Category == "" ? null : Category;
                ApplyFor = ApplyFor == "" ? null : ApplyFor;


                List<Prc_ContactListResult> dList = ObjContext.Prc_ContactList(SearchBy, Category, ApplyFor, Alloty, Status).ToList();
                CountRecord = dList.Count();

                return dList;
            }
        }
        public List<Prc_ContactListResult> ContactListTake1by1(string SearchBy, string Category, string ApplyFor, int Alloty, int Status, int takeout, out int CountRecord)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                SearchBy = SearchBy == "" ? null : SearchBy;
                Category = Category == "" ? null : Category;
                ApplyFor = ApplyFor == "" ? null : ApplyFor;


                List<Prc_ContactListResult> dList = ObjContext.Prc_ContactList(SearchBy, Category, ApplyFor, Alloty, Status).Take(takeout).ToList();
                CountRecord = dList.Count();

                return dList;
            }
        }

        public static void GetCategoryByName(ref DropDownList ObjDDL)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjDDL.DataSource = from ObjTbl in ObjContext.CategoryLists
                                    
                                    //orderby ObjTbl.G_ID
                                    select new { UserName = ObjTbl.CategoryName, ID = ObjTbl.CategoryName};
                ObjDDL.DataTextField = "UserName";
                ObjDDL.DataValueField = "ID";
                ObjDDL.DataBind();

            }
        }
        public static void GetCategoryByID(ref DropDownList ObjDDL)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjDDL.DataSource = from ObjTbl in ObjContext.CategoryLists
                                    
                                    //orderby ObjTbl.G_ID
                                    select new { UserName = ObjTbl.CategoryName, ID = ObjTbl.ID };
                ObjDDL.DataTextField = "UserName";
                ObjDDL.DataValueField = "ID";
                ObjDDL.DataBind();

            }
        }
        
        public static void GetStaffListCategoryWise(ref DropDownList ObjDDL, int CategoryID)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjDDL.DataSource = from ObjTbl in ObjContext.ABUser_logins
                                    join ac in ObjContext.AdminCategories on ObjTbl.ID equals ac.AdminID
                                    where ac.IsActive == true && ac.CategoryID == CategoryID
                                    //orderby ObjTbl.G_ID
                                    select new { UserName = ObjTbl.UserName, ID = ObjTbl.ID };
                ObjDDL.DataTextField = "UserName";
                ObjDDL.DataValueField = "ID";
                ObjDDL.DataBind();

            }
        }
        public static void GetCallType(ref DropDownList ObjDDL)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjDDL.DataSource = from ObjTbl in ObjContext.CallTypes
                                    where ObjTbl.Status == true
                                    //orderby ObjTbl.G_ID
                                    select new { UserName = ObjTbl.Title, ID = ObjTbl.Title };
                ObjDDL.DataTextField = "UserName";
                ObjDDL.DataValueField = "ID";
                ObjDDL.DataBind();

            }
        }
        public static void GetStaffList(ref DropDownList ObjDDL)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjDDL.DataSource = from ObjTbl in ObjContext.ABUser_logins
                                    where ObjTbl.Status == true
                                    //orderby ObjTbl.G_ID
                                    select new { UserName = ObjTbl.UserName, ID = ObjTbl.UserName };
                ObjDDL.DataTextField = "UserName";
                ObjDDL.DataValueField = "ID";
                ObjDDL.DataBind();

            }
        }


        public static void GetLabour(ref DropDownList ObjDDL)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjDDL.DataSource = from ObjTbl in ObjContext.Labours
                                    where ObjTbl.Status == true
                                    //orderby ObjTbl.G_ID
                                    select new { UserName = ObjTbl.Name, ID = ObjTbl.Name };
                ObjDDL.DataTextField = "UserName";
                ObjDDL.DataValueField = "ID";
                ObjDDL.DataBind();

            }
        }
        public static void GetTaskHeading(ref DropDownList ObjDDL, string StaffName)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                if (!string.IsNullOrEmpty(StaffName))
                {
                    ObjDDL.DataSource = from ObjTbl in ObjContext.TaskMasters
                                        where ObjTbl.Status == false && ObjTbl.StaffName == StaffName
                                        //orderby ObjTbl.G_ID
                                        select new { UserName = ObjTbl.Name, ID = ObjTbl.ID };
                    ObjDDL.DataTextField = "UserName";
                    ObjDDL.DataValueField = "ID";
                    ObjDDL.DataBind();
                }
                else
                {
                    ObjDDL.DataSource = from ObjTbl in ObjContext.TaskMasters
                                        where ObjTbl.Status == false
                                        //orderby ObjTbl.G_ID
                                        select new { UserName = ObjTbl.Name, ID = ObjTbl.ID };
                    ObjDDL.DataTextField = "UserName";
                    ObjDDL.DataValueField = "ID";
                    ObjDDL.DataBind();
                }

            }
        }
        public string DeleteContact(string SearchBy)
        {
            string ErrMsg = "!";
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjContext.Prc_DeleteContactList(SearchBy);
            }

            return ErrMsg;
        }

        public string AddEditRegister(int ID, string ApplyFor, string Name, string Contact, string Email_ID, string Gender, string DOB, string Relation, string RelationName, string IDName, string IDValues,
   string AadhaarNumber, string AccountHolderName, string BankAccountNumber, string BankName, string IFSCCode, string Category, string BankAddress, string AnnulIncome,
   string Address, string Country, string State, string City, string Pincode, string InsertDate, string DDNo, decimal DDAmount, int Status)
        {
            string ErrMsg = "!";
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjContext.Prc_AddEditRegister(ID, ApplyFor, Name, Contact, Email_ID, Gender, DOB, Relation, RelationName, IDName, IDValues, AadhaarNumber, AccountHolderName,
                    BankAccountNumber, BankName, IFSCCode, Category, BankAddress, AnnulIncome, Address, Country, State,
                    City, Pincode, InsertDate, DDNo, DDAmount, Status, ref ErrMsg);
            }
            return ErrMsg;
        }

        public ABPrc_CreateOrderNumberResult GenerateOrderNumber(int ID)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                return (ABPrc_CreateOrderNumberResult)ObjContext.ABPrc_CreateOrderNumber(ID).ToList().SingleOrDefault();
            }
        }

        public string Create_OrderSummary(int CustomerID, int RegID, string FormID, string Order_ID, decimal Total_Price, bool Payment_Status,
            decimal AmountReceived, decimal RefundAmount, string RefundDetail, string InsertDate, string PaymentDate, string RefundDate, string SessionID)
        {
            string ErrMsg = "!";
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjContext.Prc_Create_OrderSummary(CustomerID, RegID, FormID, Order_ID, Total_Price, Payment_Status, AmountReceived, RefundAmount,
                    RefundDetail, InsertDate, PaymentDate, RefundDate, SessionID);
            }
            return ErrMsg;
        }

        public string UpdatePaymentStatus(string OrderID, string Txn_id, string Payer_Email, string CardType, string txn_type, string PaymentType, string PaymentStatus, string Xbactch, string XRefNum,
           string XName, string XMaskedCardNumber, string Employee, decimal Amount, string CustomerName, string Father, string FormNo, string RegId)
        {
            string ErrMsg = "!";
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjContext.Prc_UpdatePaymentStatus(OrderID, Txn_id, Payer_Email, CardType, PaymentType, PaymentStatus, Xbactch, XRefNum, XName, XMaskedCardNumber, Employee, Amount, CustomerName, Father, FormNo, RegId);
            }

            return ErrMsg;
        }

        public string UpdateAmount(string OrderID, decimal Price, decimal RAmount)
        {
            string ErrMsg = "!";
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjContext.Prc_UpdateAmount(OrderID, Price, RAmount);
            }

            return ErrMsg;
        }


        public List<Prc_RegisterListResult> RegisterList(int ID, string SearchBy, string ApplyFor, string Category, int PaymentStatus, int DDStatus, out int CountRecord)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                SearchBy = SearchBy == "" ? null : SearchBy;
                ApplyFor = ApplyFor == "" ? null : ApplyFor;
                Category = Category == "" ? null : Category;

                List<Prc_RegisterListResult> dList = ObjContext.Prc_RegisterList(ID, SearchBy, ApplyFor, Category, PaymentStatus, DDStatus).ToList();
                CountRecord = dList.Count();
                return dList;
            }
        }

        public List<Prc_TransactionlistResult> Transactionlist(int ID, int PaymentStatus, int FormID, string OrderID, string SearchBy, string Category, string ApplyFor, int RegID, out int CountRecord)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                OrderID = OrderID == "" ? null : OrderID;
                SearchBy = SearchBy == "" ? null : SearchBy;
                Category = Category == "" ? null : Category;
                ApplyFor = ApplyFor == "" ? null : ApplyFor;

                List<Prc_TransactionlistResult> dList = ObjContext.Prc_Transactionlist(ID, PaymentStatus, FormID, OrderID, SearchBy, Category, ApplyFor, RegID).ToList();
                CountRecord = dList.Count();
                return dList;
            }
        }
        
        public List<Prc_FormCategoryDisctinctResult> FormCategoryDisctinct(string Category, out int CountRecord)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                Category = Category == "" ? null : Category;

                List<Prc_FormCategoryDisctinctResult> dList = ObjContext.Prc_FormCategoryDisctinct(Category).ToList();
                CountRecord = dList.Count();
                return dList;
            }
        }
        public List<Prc_FormListCategoryWiseResult> FormListCategoryWise(string Category, string SearchBy, int FormStatus, int Alloty, int FormNo, out int CountRecord)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                SearchBy = SearchBy == "" ? null : SearchBy;
                Category = Category == "" ? null : Category;

                List<Prc_FormListCategoryWiseResult> dList = ObjContext.Prc_FormListCategoryWise(Category, SearchBy, FormStatus, Alloty, FormNo).ToList();
                CountRecord = dList.Count();
                return dList;
            }
        }


        public Prc_TransactionlistResult TransactionDetails(int ID, int PaymentStatus, int FormID, string OrderID, string Category, string ApplyFor, int RegID)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                OrderID = OrderID == "" ? null : OrderID;
                return (Prc_TransactionlistResult)ObjContext.Prc_Transactionlist(ID, PaymentStatus, FormID, OrderID, null, Category, ApplyFor, RegID).ToList().SingleOrDefault();
            }
        }

        public List<Prc_FormlistResult> Formlist(int ID, string SearchBy, string Category, string ApplyFor, int RegNo, int Alloty, int FormStatus, out int CountRecord)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                SearchBy = SearchBy == "" ? null : SearchBy;
                Category = Category == "" ? null : Category;
                ApplyFor = ApplyFor == "" ? null : ApplyFor;

                List<Prc_FormlistResult> dList = ObjContext.Prc_Formlist(ID, SearchBy, Category, ApplyFor, RegNo, Alloty, FormStatus).ToList();
                CountRecord = dList.Count();
                return dList;
            }
        }
        public List<Prc_CategoryListResult> CategoryList(string Category, string ApplyFor, out int CountRecord)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                Category = Category == "" ? null : Category;
                ApplyFor = ApplyFor == "" ? null : ApplyFor;

                List<Prc_CategoryListResult> dList = ObjContext.Prc_CategoryList(Category, ApplyFor).ToList();
                CountRecord = dList.Count();
                return dList;
            }
        }
        public static void BindFormCategoryDisctinct(DropDownList ddl)
        {
            using (WebsiteDataContext EDC = new WebsiteDataContext())
            {
                ddl.DataSource = EDC.Prc_CategoryList(null, "LIG").ToList(); ;
                ddl.DataTextField = "CategoryName";
                ddl.DataValueField = "CategoryName";
                ddl.DataBind();
            }
        }

        public string UpdateDDAmount(string RegID, string AccountHolderName, string BankName, string BankAccountNumber, string IFSCCode, string BankAddress, decimal DDAmount, string DDNumber, string DDDepositer, 
            string DDDepositerID, string DDDepositerIDNo, string DDDepositorRelation)
        {
            string ErrMsg = "!";
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjContext.Prc_UpdateDDAmount(RegID, AccountHolderName, BankName, BankAccountNumber, IFSCCode, BankAddress, DDAmount, DDNumber, DDDepositer, DDDepositerID, DDDepositerIDNo, DDDepositorRelation, 
                    ref ErrMsg);
            }

            return ErrMsg;
        }

        public string UpdateDDReturn(int ID,  string DDReturnToName, string DDReturnIDName, string DDReturnIDValue, int DDReturn)
        {
            string ErrMsg = "!";
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjContext.Prc_UpdateDDReturn(ID, DDReturnToName, DDReturnIDName, DDReturnIDValue, DDReturn, ref ErrMsg);
            }

            return ErrMsg;
        }

        public string UpdateRejectRemark(string RegID, string RejectRemark, int FormStatus)
        {
            string ErrMsg = "!";
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjContext.Prc_UpdateRejectRemark(RegID, RejectRemark, FormStatus, ref ErrMsg);
            }

            return ErrMsg;
        }

        public string UpdateRandomCustomerAlloty(string Category, string ApplyFor)
        {
            string ErrMsg = "!";
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjContext.Prc_UpdateRandomCustomerAlloty(Category, ApplyFor);
            }

            return ErrMsg;
        }
        public Prc_GeneralSettingDetailsResult GeneralSettingDetails(int ID)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                return (Prc_GeneralSettingDetailsResult)ObjContext.Prc_GeneralSettingDetails(ID).ToList().SingleOrDefault();
            }
        }
        public string UpdateSetLotteryTimer(int ID, int IsFinalLottery)
        {

            string ErrMsg = "!";

            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjContext.Prc_UpdateSetLotteryTimer(ID, IsFinalLottery, ref ErrMsg);
            }
            return ErrMsg;
        }

        public string ResetTrialLottery(int ID)
        {

            string ErrMsg = "!";

            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjContext.Prc_ResetTrialLottery(ID);
            }
            return ErrMsg;
        }
        public List<Prc_TrialLotteryListResult> TrialLotteryList(string Category, int TrialNo, int Seq, out int CountRecord)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                List<Prc_TrialLotteryListResult> dList = new List<Prc_TrialLotteryListResult>();
                if (Seq == 1)
                {
                    dList = ObjContext.Prc_TrialLotteryList(Category, TrialNo).OrderBy(s => s.CustomerName.Trim()).ToList();
                }
                else
                {
                    dList = ObjContext.Prc_TrialLotteryList(Category, TrialNo).ToList();

                }
                CountRecord = dList.Count();
                return dList;
            }
        }

        public string TrailNoWithSeedAdd(string TrialNo, string SeedNo)
        {
            string ErrMsg = "!";
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjContext.Prc_TrailNoWithSeedAdd(TrialNo, SeedNo, ref ErrMsg);
            }
            return ErrMsg;
        }
        public Prc_TrailNoListWithSeedResult TrailNoListWithSeed(string TrialNo)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                return (Prc_TrailNoListWithSeedResult)ObjContext.Prc_TrailNoListWithSeed(TrialNo).ToList().SingleOrDefault();
            }
        }
        public List<Prc_FormlistResult> FormlistTake1by1(int ID, string SearchBy, string Category, string ApplyFor, int RegNo, int Alloty, int takeout, out int CountRecord)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                SearchBy = SearchBy == "" ? null : SearchBy;
                Category = Category == "" ? null : Category;
                ApplyFor = ApplyFor == "" ? null : ApplyFor;


                List<Prc_FormlistResult> dList = ObjContext.Prc_Formlist(ID, SearchBy, Category, ApplyFor, RegNo, Alloty, 1).Take(takeout).OrderBy(s => s.CustomerName.Trim()).ToList();
                CountRecord = dList.Count();

                return dList;
            }
        }
        public List<Prc_DisctinctLotteryNoResult> DisctinctLotteryNoList(out int CountRecord)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {

                List<Prc_DisctinctLotteryNoResult> dList = ObjContext.Prc_DisctinctLotteryNo(0).ToList();
                CountRecord = dList.Count();
                return dList;
            }

        }
        public static void DisctinctLotteryNo(DropDownList ddl)
        {
            using (WebsiteDataContext EDC = new WebsiteDataContext())
            {
                ddl.DataSource = EDC.Prc_DisctinctLotteryNo(0).ToList(); ;
                ddl.DataTextField = "TrialNo";
                ddl.DataValueField = "TrialNo";
                ddl.DataBind();
            }
        }
        public List<Prc_CategoryWisePlotAllotmentResult> CategoryWisePlotAllotment(int ID, out int CountRecord)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {

                List<Prc_CategoryWisePlotAllotmentResult> dList = ObjContext.Prc_CategoryWisePlotAllotment(ID).ToList();
                CountRecord = dList.Count();
                //TotalAmount = dList.Sum(item => item.Total_Price);

                return dList;
            }
        }

        //public proc_ABCheckLoginResult AdminLogin(string UserID, string Password)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (proc_ABCheckLoginResult)ObjContext.proc_ABCheckLogin(UserID, Password).ToList().SingleOrDefault();
        //    }
        //}

        //public List<ABPrc_VendorListResult> ABVendorList(string SearchBy, int Status, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        SearchBy = SearchBy == "" ? null : SearchBy;

        //        List<ABPrc_VendorListResult> dList = ObjContext.ABPrc_VendorList(SearchBy, Status).ToList();
        //        CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}
        //public string ABAddEditVendor(int ID, string Name, string Address, string Contact, string AlternateNo, string Email, string GSTIN, bool Status)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.ABPrc_AddEditVendor(ID, Name, Address, Contact, AlternateNo, Email, GSTIN, Status, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public ABPrc_VendorDetailsResult VendorDetails(int ID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (ABPrc_VendorDetailsResult)ObjContext.ABPrc_VendorDetails(ID).ToList().SingleOrDefault();
        //    }
        //}
        //public List<ABPrc_PurchaseListResult> ABPurchaseList(string SearchBy, int Status, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        SearchBy = SearchBy == "" ? null : SearchBy;
        //        List<ABPrc_PurchaseListResult> dList = ObjContext.ABPrc_PurchaseList(SearchBy, Status).ToList();
        //        CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}
        //public string PurchaseAddEdit(int ID, string Vendor, int ItemCode, string Item, decimal Price, decimal QTY, string Unit, string Color, string StyleNo, string PurchaseInvNo, string PONo,
        //    string OrderRefNo, string HSNCode, decimal GStPer, string Category, bool Status)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.ABPrc_PurchaseAddEdit(ID, Vendor, ItemCode, Item, Price, QTY, Unit, Color, StyleNo, PurchaseInvNo, PONo, OrderRefNo, HSNCode, GStPer, Category, Status, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public ABPrc_PurchaseDetailsResult PurchaseDetails(int ID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (ABPrc_PurchaseDetailsResult)ObjContext.ABPrc_PurchaseDetails(ID).ToList().SingleOrDefault();
        //    }
        //}
        //public List<ABPrc_StockListResult> ABStockList(string SearchBy, int Status, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        SearchBy = SearchBy == "" ? null : SearchBy;

        //        List<ABPrc_StockListResult> dList = ObjContext.ABPrc_StockList(SearchBy, Status).ToList();
        //        CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}
        //public string StockAddEdit(int ID, string Vendor, string Item, decimal QTY, string Unit, string HSNCode, decimal GSTPer, string Color, bool Status)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.ABPrc_StockAddEdit(ID, Vendor, Item, QTY, Unit, HSNCode, GSTPer, Color, Status, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public ABPrc_StockDetailsResult StockDetails(int ID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (ABPrc_StockDetailsResult)ObjContext.ABPrc_StockDetails(ID).ToList().SingleOrDefault();
        //    }
        //}
        //public List<ABPrc_WorkListResult> ABWorkList(string SearchBy, int Status, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<ABPrc_WorkListResult> dList = ObjContext.ABPrc_WorkList(SearchBy, Status).ToList();
        //        CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}
        //public string WorkAddEdit(int ID, string Name, bool Status)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.ABPrc_WorkAddEdit(ID, Name, Status, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public ABPrc_WorkDetailsResult WorkDetails(int ID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (ABPrc_WorkDetailsResult)ObjContext.ABPrc_WorkDetails(ID).ToList().SingleOrDefault();
        //    }
        //}
        //public List<ABPrc_LabourListResult> ABLabourList(string SearchBy, int Status, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<ABPrc_LabourListResult> dList = ObjContext.ABPrc_LabourList(SearchBy, Status).ToList();
        //        CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}
        //public string LabourAddEdit(int ID, string Name, string Mobile, decimal Balance, string AdharNo, string Father, string Qualification, string Category,
        //        string EmployeeID, string BankName, string IFSC, string AcNo, string UPIID, bool Status)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.ABPrc_LabourAddEdit(ID, Name, Mobile, Balance, AdharNo, Father, Qualification, Category,
        //        EmployeeID, BankName, IFSC, AcNo, UPIID, Status, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public ABPrc_LabourDetailsResult LabourDetails(int ID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (ABPrc_LabourDetailsResult)ObjContext.ABPrc_LabourDetails(ID).ToList().SingleOrDefault();
        //    }
        //}
        //public ABPrc_LabourDetailsByNameResult LabourDetailsByName(string Name)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (ABPrc_LabourDetailsByNameResult)ObjContext.ABPrc_LabourDetailsByName(Name).ToList().SingleOrDefault();
        //    }
        //}
        //public List<ABPrc_ItemTransferListResult> ABItemTransferList(string FromDate, string ToDate, string SearchBy, int ReceivedStatus, int Status, out int CountRecord, out decimal TotalQTY)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {

        //        FromDate = FromDate == "" ? null : FromDate;
        //        ToDate = ToDate == "" ? null : ToDate;
        //        SearchBy = SearchBy == "" ? null : SearchBy;

        //        List<ABPrc_ItemTransferListResult> dList = ObjContext.ABPrc_ItemTransferList(FromDate, ToDate, SearchBy, ReceivedStatus, Status).ToList();
        //        CountRecord = dList.Count();
        //        TotalQTY = dList.Sum(item => item.QTY);

        //        return dList;
        //    }
        //}
        //public string ItemTransferAddEdit(int ID, string Labour, string Item, string Working, decimal Cost, decimal QTY, string Unit, string QTYDesc, string Remark, string Color, decimal QTYCount)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.ABPrc_ItemTransferAddEdit(ID, Labour, Item, Working, Cost, QTY, Unit, QTYDesc, Remark, Color, QTYCount, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public ABPrc_ItemTransferDetailsResult ItemTransferDetails(int ID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (ABPrc_ItemTransferDetailsResult)ObjContext.ABPrc_ItemTransferDetails(ID).ToList().SingleOrDefault();
        //    }
        //}

        //public string ReceiveItem(int ID, decimal ReceivedQTY, string ReceivedItemName, decimal GSTPer, string HSNCode, string Color, string ReceivedNewUnit, decimal ReceivedNewQTY)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.ABPrc_ReceiveItem(ID, ReceivedQTY, ReceivedItemName, GSTPer, HSNCode, Color, ReceivedNewUnit, ReceivedNewQTY, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public ABPrc_MyCompanyDetailResult MyCompanyDetail(int ID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (ABPrc_MyCompanyDetailResult)ObjContext.ABPrc_MyCompanyDetail(ID).ToList().SingleOrDefault();
        //    }
        //}
        //public List<ABPrc_CustomerListResult> ABCustomerList(string SearchBy, int Status, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {

        //        SearchBy = SearchBy == "" ? null : SearchBy;

        //        List<ABPrc_CustomerListResult> dList = ObjContext.ABPrc_CustomerList(SearchBy, Status).ToList();
        //        CountRecord = dList.Count();

        //        return dList;
        //    }
        //}
        //public string ABCustomerAddEdit(int ID, string CustomerName, string Address, string Mobile, string GSTIN, string State, bool Status, string EmailID, string AlternateNo)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.ABPrc_CustomerAddEdit(ID, CustomerName, Address, Mobile, GSTIN, State, Status, EmailID, AlternateNo, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public ABPrc_CustomerDetailsResult ABCustomerDetails(int ID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (ABPrc_CustomerDetailsResult)ObjContext.ABPrc_CustomerDetails(ID).ToList().SingleOrDefault();
        //    }
        //}
        //public ABPrc_CustomerDetailsByMobileResult ABCustomerDetailsByMobile(string Mobile)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (ABPrc_CustomerDetailsByMobileResult)ObjContext.ABPrc_CustomerDetailsByMobile(Mobile).ToList().SingleOrDefault();
        //    }
        //}
        //public List<ABPrc_GSTStateListResult> ABGSTStateList(string SearchBy, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<ABPrc_GSTStateListResult> dList = ObjContext.ABPrc_GSTStateList(SearchBy).ToList();
        //        CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}
        //public ABPrc_CreateOrderNumberResult ABCreateOrderNumber(string SaleCategory)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (ABPrc_CreateOrderNumberResult)ObjContext.ABPrc_CreateOrderNumber(SaleCategory).ToList().SingleOrDefault();
        //    }
        //}
        //public string CreateCart(int ID, string OrderID, string CustomerName, string Mobile, string GSTIN, string State, string Address, int ProductID, string Color, decimal GSTPer,
        //  string HSNCode, decimal QTY, string Unit, int CustomerCode, decimal Rate, string QTYDescription, string Remark, string SaleCategory, string EventDate, string DeliveryRequired,
        //  string ReturnDate, string FinancialYear, decimal SecurityDeposit, decimal QTYCount, decimal Discount)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.ABPrc_CreateCart(ID, OrderID, CustomerName, Mobile, GSTIN, State, Address, ProductID, Color, GSTPer, HSNCode, QTY, Unit, CustomerCode, Rate,
        //           QTYDescription, Remark, SaleCategory, EventDate, DeliveryRequired, ReturnDate, FinancialYear, SecurityDeposit, QTYCount, Discount, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public List<ABPrc_CartListResult> ABCartList(string OrderID, string SaleCategory, string SearchBy, int Status, out int CountRecord, out decimal TotalAmount, out decimal TotalRate)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        OrderID = OrderID == "" ? null : OrderID;
        //        SearchBy = SearchBy == "" ? null : SearchBy;
        //        SaleCategory = SaleCategory == "" ? null : SaleCategory;

        //        List<ABPrc_CartListResult> dList = ObjContext.ABPrc_CartList(OrderID, SaleCategory, SearchBy, Status).ToList();
        //        CountRecord = dList.Count();
        //        TotalAmount = dList.Sum(item => item.TotalPrice);
        //        TotalRate = dList.Sum(item => item.Rate * item.QTY);

        //        return dList;
        //    }
        //}
        //public ABPrc_CartDetailsResult CartDetails(int ID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (ABPrc_CartDetailsResult)ObjContext.ABPrc_CartDetails(ID).ToList().SingleOrDefault();
        //    }
        //}
        //public ABPrc_OrderDetailsResult ABOrderDetails(int ID, string OrderID, string SaleCategory)
        //{
        //    OrderID = OrderID == "" ? null : OrderID;
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (ABPrc_OrderDetailsResult)ObjContext.ABPrc_OrderDetails(ID, OrderID, SaleCategory).ToList().SingleOrDefault();
        //    }
        //}
        //public List<ABPrc_OrderListResult> ABOrderList(string FromDate, string ToDate, string InvoiceNo, string SearchBy, string SaleCategory, int Status, out int CountRecord, 
        //    out decimal TotalAmount, out decimal SecurityWeHave)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        FromDate = FromDate == "" ? null : FromDate;
        //        ToDate = ToDate == "" ? null : ToDate;
        //        InvoiceNo = InvoiceNo == "" ? null : InvoiceNo;
        //        SearchBy = SearchBy == "" ? null : SearchBy;
        //        SaleCategory = SaleCategory == "" ? null : SaleCategory;

        //        List<ABPrc_OrderListResult> dList = ObjContext.ABPrc_OrderList(FromDate, ToDate, InvoiceNo, SearchBy, SaleCategory, Status).ToList();
        //        CountRecord = dList.Count();
        //        TotalAmount = dList.Sum(item => item.Rate);
        //        SecurityWeHave = dList.Sum(item => item.SecurityWeHave);

        //        return dList;
        //    }
        //}
        //public List<ABPrc_OrderListResult> ABOrderListTop5(string FromDate, string ToDate, string InvoiceNo, string SearchBy, string SaleCategory, int Status, out int CountRecord, out decimal TotalAmount)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        FromDate = FromDate == "" ? null : FromDate;
        //        ToDate = ToDate == "" ? null : ToDate;d
        //        InvoiceNo = InvoiceNo == "" ? null : InvoiceNo;
        //        SearchBy = SearchBy == "" ? null : SearchBy;
        //        SaleCategory = SaleCategory == "" ? null : SaleCategory;

        //        List<ABPrc_OrderListResult> dList = ObjContext.ABPrc_OrderList(FromDate, ToDate, InvoiceNo, SearchBy, SaleCategory, Status).Take(5).ToList();
        //        CountRecord = dList.Count();
        //        TotalAmount = dList.Sum(item => item.Rate);

        //        return dList;
        //    }
        //}
        //public string ABUpdateMyCompany(int ID, string Name, string Address, string GSTIN, string PAN_Card, string Telephone, string Tag_Line, string Bank_Name, string Ac_No, string ISFC_Code,
        //    string Branch, string WhatsappNo, string FactoryAddress)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.ABPrc_UpdateMyCompany(ID, Name, Address, GSTIN, PAN_Card, Telephone, Tag_Line, Bank_Name, Ac_No, ISFC_Code, Branch, WhatsappNo, FactoryAddress, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public List<ABPrc_DueListResult> ABDueList(string SaleCategory, string OrderID, string SearchBy, int PaymentStatus, int Status, out int CountRecord, out decimal TotalAmount)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        SearchBy = SearchBy == "" ? null : SearchBy;
        //        OrderID = OrderID == "" ? null : OrderID;
        //        SaleCategory = SaleCategory == "" ? null : SaleCategory ;

        //        List<ABPrc_DueListResult> dList = ObjContext.ABPrc_DueList(SaleCategory, OrderID, SearchBy, PaymentStatus, Status).ToList();
        //        CountRecord = dList.Count();
        //        TotalAmount = dList.Sum(item => item.Due);

        //        return dList;
        //    }
        //}
        //public List<ABPrc_SecurityWeHaveListResult> ABSecurityWeHaveList(string SaleCategory, string OrderID, string SearchBy, int Status, out int CountRecord, out decimal TotalAmount)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        SearchBy = SearchBy == "" ? null : SearchBy;
        //        OrderID = OrderID == "" ? null : OrderID;
        //        SaleCategory = SaleCategory == "" ? null : SaleCategory;

        //        List<ABPrc_SecurityWeHaveListResult> dList = ObjContext.ABPrc_SecurityWeHaveList(SaleCategory, OrderID, SearchBy, Status).ToList();
        //        CountRecord = dList.Count();
        //        TotalAmount = dList.Sum(item => item.SecurityWeHave);

        //        return dList;
        //    }
        //}
        //public List<ABPrc_DueListResult> ABDueListTop5(string SaleCategory, string OrderID, string SearchBy, int PaymentStatus, int Status, out int CountRecord, out decimal TotalAmount)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        SearchBy = SearchBy == "" ? null : SearchBy;
        //        OrderID = OrderID == "" ? null : OrderID;
        //        SaleCategory = SaleCategory == "" ? null : SaleCategory;

        //        List<ABPrc_DueListResult> dList = ObjContext.ABPrc_DueList(SaleCategory, OrderID, SearchBy, PaymentStatus, Status).Take(5).ToList();
        //        CountRecord = dList.Count();
        //        TotalAmount = dList.Sum(item => item.Due);

        //        return dList;
        //    }
        //}
        //public string ABAddPayment(string OrderID, string Remark, string Mode, string TxnID, string BankName, string SaleCategory, string FY, decimal AmountReceived)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.ABPrc_AddPayment(OrderID, Remark, Mode, TxnID, BankName, SaleCategory, FY, AmountReceived, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public string ABAddRefund(string OrderID, string Remark, string Mode, string TxnID, string BankName, string SaleCategory, string FY, decimal AmountRefunded)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.ABPrc_AddRefund(OrderID, Remark, Mode, TxnID, BankName, SaleCategory, FY, AmountRefunded, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public List<ABPrc_PaymentListResult> ABPaymentList(string SaleCategory, string InvNo, string ReceiptNo, string SearchBy, int Status, out int CountRecord, out decimal TotalAmount)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        SearchBy = SearchBy == "" ? null : SearchBy;
        //        InvNo = InvNo == "" ? null : InvNo;

        //        ReceiptNo = ReceiptNo == "" ? null : ReceiptNo;
        //        SaleCategory = SaleCategory == "" ? null : SaleCategory;

        //        List<ABPrc_PaymentListResult> dList = ObjContext.ABPrc_PaymentList(SaleCategory, InvNo, ReceiptNo, SearchBy, Status).ToList();
        //        CountRecord = dList.Count();
        //        TotalAmount = dList.Sum(item => item.AmountReceived);

        //        return dList;
        //    }
        //}
        //public List<ABPrc_RefundListResult> ABRefundList(string SaleCategory, string InvNo, string ReceiptNo, string SearchBy, int Status, out int CountRecord, out decimal TotalAmount)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        SearchBy = SearchBy == "" ? null : SearchBy;
        //        InvNo = InvNo == "" ? null : InvNo;

        //        ReceiptNo = ReceiptNo == "" ? null : ReceiptNo;
        //        SaleCategory = SaleCategory == "" ? null : SaleCategory;

        //        List<ABPrc_RefundListResult> dList = ObjContext.ABPrc_RefundList(SaleCategory, InvNo, ReceiptNo, SearchBy, Status).ToList();
        //        CountRecord = dList.Count();
        //        TotalAmount = dList.Sum(item => item.AmountRefunded);

        //        return dList;
        //    }
        //}
        //public List<ABPrc_PaymentListResult> ABPaymentListTop5(string SaleCategory, string InvNo, string ReceiptNo, string SearchBy, int Status, out int CountRecord, out decimal TotalAmount)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        SearchBy = SearchBy == "" ? null : SearchBy;
        //        InvNo = InvNo == "" ? null : InvNo;

        //        ReceiptNo = ReceiptNo == "" ? null : ReceiptNo;

        //        List<ABPrc_PaymentListResult> dList = ObjContext.ABPrc_PaymentList(SaleCategory, InvNo, ReceiptNo, SearchBy, Status).Take(5).ToList();
        //        CountRecord = dList.Count();
        //        TotalAmount = dList.Sum(item => item.AmountReceived);

        //        return dList;
        //    }
        //}
        public ABPrc_AdminDashboardResult ABAdminDashboard(int MemberID)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                return (ABPrc_AdminDashboardResult)ObjContext.ABPrc_AdminDashboard(MemberID).ToList().SingleOrDefault();
            }
        }
        public List<Prc_CategoryWiseApplicationResult> CategoryWiseApplication(int ID, out int CountRecord)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {

                List<Prc_CategoryWiseApplicationResult> dList = ObjContext.Prc_CategoryWiseApplication(ID).ToList();
                CountRecord = dList.Count();
                //TotalAmount = dList.Sum(item => item.Total_Price);

                return dList;
            }
        }
        //public string UpdateReturn(int ID)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.ABPrc_UpdateReturn(ID, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public List<Prc_CustomerListResult> CustomerList(string SearchBy, int Status, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        if (!string.IsNullOrEmpty(SearchBy))
        //        {
        //            SearchBy = null;
        //        }

        //        List<Prc_CustomerListResult> dList = ObjContext.Prc_CustomerList(SearchBy, Status).ToList();
        //        CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}
        //public Prc_CustomerDetailsResult CustomerDetail(int ID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (Prc_CustomerDetailsResult)ObjContext.Prc_CustomerDetails(ID).ToList().SingleOrDefault();
        //    }
        //}

        //public Prc_EmployeeDetailsResult EmployeeDetails(int ID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (Prc_EmployeeDetailsResult)ObjContext.Prc_EmployeeDetails(ID).ToList().SingleOrDefault();
        //    }
        //}
        //public Prc_OrderDetailsResult OrderDetails(string OrderNo)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (Prc_OrderDetailsResult)ObjContext.Prc_OrderDetails(OrderNo).ToList().SingleOrDefault();
        //    }
        //}
        //public Prc_CompanyListResult CompanyDetail()
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (Prc_CompanyListResult)ObjContext.Prc_CompanyList().ToList().SingleOrDefault();
        //    }
        //}
        //public List<Prc_CompanyListResult> CompanyList()
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_CompanyListResult> dList = ObjContext.Prc_CompanyList().ToList();
        //        //CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}
        //public List<Prc_StockListResult> StockList(string Vendor, string Item, int QTYLt, int QTYGt, out int CountRecord, out decimal? TotalAmount)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        Vendor = Vendor == "" ? null : Vendor;
        //        Item = Item == "" ? null : Item;

        //        List<Prc_StockListResult> dList = ObjContext.Prc_StockList(Vendor, Item, QTYLt, QTYGt).ToList();
        //        CountRecord = dList.Count();
        //        TotalAmount = dList.Sum(item => item.TotalCost);
        //        //BalanceAmt = dList.Sum(item => item.Amount_Received);

        //        return dList;
        //    }
        //}
        //public List<Prc_OrderListResult> OrderList(string Settlement, decimal Balance, string SearchBy, out int CountRecord, out decimal TotalAmount, out decimal BalanceAmt)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        if (!string.IsNullOrEmpty(SearchBy))
        //        {
        //            SearchBy = null;
        //        }

        //        List<Prc_OrderListResult> dList = ObjContext.Prc_OrderList(Settlement, Balance, SearchBy).ToList();
        //        CountRecord = dList.Count();
        //        TotalAmount = dList.Sum(item => item.Disc_Price);
        //        BalanceAmt = dList.Sum(item => item.Amount_Received);

        //        return dList;
        //    }
        //}
        //public List<Prc_TableListResult> TableList(int Category, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_TableListResult> dList = ObjContext.Prc_TableList(Category).ToList();
        //        CountRecord = dList.Count();
        //        return dList;
        //    }
        //}
        //public List<Prc_WorkListResult> WorkList(int Category, int TableNo)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_WorkListResult> dList = ObjContext.Prc_WorkList(Category, TableNo).ToList();

        //        return dList;
        //    }
        //}
        //public List<Prc_KOTListResult> KOTList(int DeliveryStatus, int Status, string Order_No, int OrderAssigned, int AssignedStatus, string Assigned, string LabourName, int LabourStatus, int Developing, int Category, string TableNo, string WorkRq, int LabourPaymentStatus, out int CountRecord, out decimal TotalAmount, out decimal LabourTotalAmount, out List<string> DistinctTableNo, out List<string> DistinctWorkRQ, out decimal FactoryEstimate)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {

        //        List<Prc_KOTListResult> dList = ObjContext.Prc_KOTList(DeliveryStatus, Status, Order_No, OrderAssigned, AssignedStatus, Assigned, LabourName, LabourStatus, Developing, Category, TableNo, WorkRq, LabourPaymentStatus).ToList();
        //        CountRecord = dList.Count();
        //        TotalAmount = dList.Sum(item => item.Price);
        //        LabourTotalAmount = dList.Sum(item => item.LabourCost);
        //        DistinctTableNo = dList.Select(item => item.Table_No).Distinct().ToList();
        //        DistinctWorkRQ = dList.Select(item => item.Work_Rq).Distinct().ToList();
        //        FactoryEstimate = dList.Sum(item => item.LabourCost) + dList.Sum(item => item.FMaterialCost) + dList.Sum(item => item.FMargin) + dList.Sum(item => item.FMiscCost);

        //        return dList;
        //    }
        //}
        //public List<Prc_WalletListResult> CustomerWalletList(int CustomerID, out int CountRecord, out decimal? TotalAmount)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_WalletListResult> dList = ObjContext.Prc_WalletList(CustomerID).ToList();
        //        CountRecord = dList.Count();
        //        TotalAmount = dList.Sum(item => item.Amount);

        //        return dList;
        //    }
        //}
        //public List<Prc_ProductUsageListResult> ProductUsageList(string ItemName, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_ProductUsageListResult> dList = ObjContext.Prc_ProductUsageList(ItemName).ToList();
        //        CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Amount);

        //        return dList;
        //    }
        //}
        //public List<Prc_EmployeeWalletListResult> EmployeeWalletList(int CustomerID, string FromDate, string ToDate, out int CountRecord, out decimal? TotalCR, out decimal? TotalDR)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_EmployeeWalletListResult> dList = ObjContext.Prc_EmployeeWalletList(CustomerID, FromDate, ToDate).ToList();
        //        CountRecord = dList.Count();
        //        TotalCR = dList.Sum(item => item.CR);
        //        TotalDR = dList.Sum(item => item.DR);


        //        return dList;
        //    }
        //}
        //public List<Prc_MiscExpensesListResult> MiscExpensesList(int KOTID, out int CountRecord, out decimal? TotalAmount)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_MiscExpensesListResult> dList = ObjContext.Prc_MiscExpensesList(KOTID).ToList();
        //        CountRecord = dList.Count();
        //        TotalAmount = dList.Sum(item => item.Amount);

        //        return dList;
        //    }
        //}
        //public List<Prc_PayModeListResult> PayModeList(int ParentMenuID, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_PayModeListResult> dList = ObjContext.Prc_PayModeList(ParentMenuID).ToList();
        //        CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}
        //public List<Prc_SupplierOrderListResult> SupplierOrderList(string SupplierName, int DeliveryStatus, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        SupplierName = SupplierName == "" ? null : SupplierName;
        //        List<Prc_SupplierOrderListResult> dList = ObjContext.Prc_SupplierOrderList(SupplierName, DeliveryStatus).ToList();
        //        CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}
        //public List<Prc_EmployeeListResult> EmployeeList(string SearchBy, int Status, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_EmployeeListResult> dList = ObjContext.Prc_EmployeeList(SearchBy, Status).ToList();
        //        CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}
        //public List<Prc_LabourListResult> LabourList(string SearchBy, int Status, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_LabourListResult> dList = ObjContext.Prc_LabourList(SearchBy, Status).ToList();
        //        CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}
        //public List<Prc_CategoryListResult> CategoryList(out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_CategoryListResult> dList = ObjContext.Prc_CategoryList().ToList();
        //        CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}


        //public List<Prc_MaterialRequireListResult> MaterialRequireList(string Employee, string Item, string Labour, int MaterialReceived, int CustomerID, int KOTID, out int CountRecord, out decimal TotalAmount)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {

        //        Employee = Employee == "Slip Generated By" ? null : Employee;
        //        List<Prc_MaterialRequireListResult> dList = ObjContext.Prc_MaterialRequireList(Employee, Item, Labour, MaterialReceived, CustomerID, KOTID).ToList();
        //        CountRecord = dList.Count();
        //        TotalAmount = dList.Sum(item => item.ItemRate);

        //        return dList;
        //    }
        //}
        //public List<Prc_AttendanceListResult> AttendanceList(string FromDate, string ToDate, int EmployeeID, int Status, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_AttendanceListResult> dList = ObjContext.Prc_AttendanceList(FromDate, ToDate, EmployeeID, Status).ToList();
        //        CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}

        //public string UpdateKOTImage(string DesignPhoto, int ID)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateKOTImage(DesignPhoto, ID);
        //    }

        //    return ErrMsg;
        //}
        //public string UpdateLabourTodayWork(string Description, int ID)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateLabourTodayWork(Description, ID);
        //    }

        //    return ErrMsg;
        //}
        //public string UpdateDeliveryStatus(bool DeliveryStatus, int ID)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateDeliveryStatus(DeliveryStatus, ID);
        //    }

        //    return ErrMsg;
        //}
        //public string UpdateMaterialRequireReceieved(bool MaterialReceived, int ID)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateMaterialRequireReceieved(MaterialReceived, ID);
        //    }

        //    return ErrMsg;
        //}
        //public string UpdateDeparture(int AttendanceID, int DepartureUpdateTime, string DepartureRemark, string DepartureUpdateBy)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateDeparture(AttendanceID, DepartureUpdateTime, DepartureRemark, DepartureUpdateBy, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public string UpdateKOTLabourRate(int KOTID, Decimal LabourRate, Decimal FMargin, bool PaymentStatus)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateKOTLabourRate(KOTID, LabourRate, FMargin, PaymentStatus);
        //    }

        //    return ErrMsg;
        //}
        //public string UpdateVendorOrderReceiving(int OrderID, bool ReceivingStatus)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateVendorOrderReceiving(OrderID, ReceivingStatus);
        //    }

        //    return ErrMsg;
        //}
        //public string DeleteStock(int StockID)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_DeleteStock(StockID);
        //    }

        //    return ErrMsg;
        //}
        //public string DeleteRoom(int RoomID)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_DeleteRoom(RoomID);
        //    }

        //    return ErrMsg;
        //}
        //public string UpdateKOTAssigned(string Assigned, int ID)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateKOTAssigned(Assigned, ID);
        //    }

        //    return ErrMsg;
        //}
        //public string UpdateLabourAssigned(string LabourAssigned, int AddDays, int ID)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateLabourAssigned(LabourAssigned, AddDays, ID);
        //    }

        //    return ErrMsg;
        //}
        //public string UpdateCompletionTime(int AddDays, int ID)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateCompletionTime(AddDays, ID);
        //    }

        //    return ErrMsg;
        //}

        //public string UpdateWorkDate(int CompletionDays, int DeliveryDays, int ID)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateWorkDate(CompletionDays, DeliveryDays, ID);
        //    }

        //    return ErrMsg;
        //}
        //public string UpdateSupplierDeliveryStatus(bool Status, int ID)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateSupplierDeliveryStatus(Status, ID);
        //    }

        //    return ErrMsg;
        //}
        //public string UpdateCustomerStatus(bool Status, int ID)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateCustomerStatus(Status, ID);
        //    }

        //    return ErrMsg;
        //}
        //public string UpdateLabourStatus(bool Status, int ID)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateLabourStatus(Status, ID);
        //    }

        //    return ErrMsg;
        //}
        //public string UpdateOrderAccept(string Assigned, string AssignedBy, int ID)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateOrderAccept(Assigned, AssignedBy, ID);
        //    }

        //    return ErrMsg;
        //}
        //public string UpdateOrderComplete(int ID)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateOrderComplete(ID);
        //    }

        //    return ErrMsg;
        //}
        //public string UpdateOrderSettle(string OrderID, string Settlemen, decimal Allowance, string ModeDetails, decimal AmountRec, decimal Balance)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateOrderSettle(OrderID, Settlemen, Allowance, ModeDetails, AmountRec, Balance);
        //    }

        //    return ErrMsg;
        //}
        //public static void GetLabourList(ref DropDownList ObjDDL)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjDDL.DataSource = from ObjTbl in ObjContext.Labours
        //                            where ObjTbl.Status == true
        //                            //orderby ObjTbl.G_ID
        //                            select new { UserName = ObjTbl.Name, ID = ObjTbl.ID };
        //        ObjDDL.DataTextField = "UserName";
        //        ObjDDL.DataValueField = "ID";
        //        ObjDDL.DataBind();

        //    }
        //}
        //public static void GetUserList(ref DropDownList ObjDDL)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjDDL.DataSource = from ObjTbl in ObjContext.User_logins
        //                            where ObjTbl.Status == true
        //                            //orderby ObjTbl.G_ID
        //                            select new { UserName = ObjTbl.UserName, ID = ObjTbl.ID };
        //        ObjDDL.DataTextField = "UserName";
        //        ObjDDL.DataValueField = "ID";
        //        ObjDDL.DataBind();

        //    }
        //}
        //public static void GetCategoryList(ref DropDownList ObjDDL)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjDDL.DataSource = from ObjTbl in ObjContext.Categories
        //                            where ObjTbl.Status == true
        //                            //orderby ObjTbl.G_ID
        //                            select new { Name = ObjTbl.Name, ID = ObjTbl.ID };
        //        ObjDDL.DataTextField = "Name";
        //        ObjDDL.DataValueField = "ID";
        //        ObjDDL.DataBind();

        //    }
        //}
        //public static void GetCustomerList(ref DropDownList ObjDDL)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjDDL.DataSource = from ObjTbl in ObjContext.Customers
        //                            where ObjTbl.Status == true
        //                            //orderby ObjTbl.G_ID
        //                            select new { Name = ObjTbl.Name, ID = ObjTbl.ID };
        //        ObjDDL.DataTextField = "Name";
        //        ObjDDL.DataValueField = "ID";
        //        ObjDDL.DataBind();

        //    }
        //}
        //public static void GetRoomList(ref DropDownList ObjDDL, int CustomerID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjDDL.DataSource = from ObjTbl in ObjContext.Table_Nos
        //                            where ObjTbl.Status == true && ObjTbl.Category == CustomerID
        //                            //orderby ObjTbl.G_ID
        //                            select new { Name = ObjTbl.Name, ID = ObjTbl.ID };
        //        ObjDDL.DataTextField = "Name";
        //        ObjDDL.DataValueField = "ID";
        //        ObjDDL.DataBind();

        //    }
        //}
        //public static void GetWorkList(ref DropDownList ObjDDL, int CustomerID, int RoomID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjDDL.DataSource = from ObjTbl in ObjContext.Work_Nos
        //                            where ObjTbl.Status == true && ObjTbl.Category == CustomerID && ObjTbl.Table_No == RoomID
        //                            //orderby ObjTbl.G_ID
        //                            select new { Name = ObjTbl.Name, ID = ObjTbl.ID };
        //        ObjDDL.DataTextField = "Name";
        //        ObjDDL.DataValueField = "ID";
        //        ObjDDL.DataBind();

        //    }
        //}
        //public static void GetWorkListRoomID(ref DropDownList ObjDDL, int RoomID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjDDL.DataSource = from ObjTbl in ObjContext.Work_Nos
        //                            where ObjTbl.Status == true && ObjTbl.Table_No == RoomID
        //                            //orderby ObjTbl.G_ID
        //                            select new { Name = ObjTbl.Name, ID = ObjTbl.ID };
        //        ObjDDL.DataTextField = "Name";
        //        ObjDDL.DataValueField = "ID";
        //        ObjDDL.DataBind();

        //    }
        //}
        //public string WalletMaster(string Ttype, int EmployeeID, decimal Amount, string Remark)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_WalletMaster(Ttype, EmployeeID, Amount, Remark, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public string EmployeeWalletTransfer(int DRID, int CRID, decimal Amount, string Remark)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_EmployeeWalletTransfer(DRID, CRID, Amount, Remark, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}

        //public string AddEditKOT(int ID, string Name, int Category, string Table_No, string Work_Rq, decimal Rate, decimal Disc, decimal Price, string Quantity, bool Status, string Remark, string O_Taken, bool Developing, decimal Tax, string F_B, bool Delivery_Status, string DesignPhoto)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_AddEditKOT(ID, Name, Category, Table_No, Work_Rq, Rate, Disc, Price, Quantity, Status, Remark, O_Taken, Developing, Tax, F_B, Delivery_Status, DesignPhoto, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public string AddEditMaterialRequire(int ID, string Vendor, string Item, decimal QTY, string Unit, string Labour, bool MaterialReceived, decimal ItemRate, int KOTID)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_AddEditMaterialRequire(ID, Vendor, Item, QTY, Unit, Labour, MaterialReceived, ItemRate, KOTID);
        //    }

        //    return ErrMsg;
        //}

        //public string AddEditStock(int ID, string Vendor, string Item, decimal QTY, string Unit, decimal Rate)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_AddEditStock(ID, Vendor, Item, QTY, Unit, Rate, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public string AddAttendance(int EmployeeID, int ArrivalUpdateTime, string ArrivalRemark, string ArrivalUpdatedBy)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_AddAttendance(EmployeeID, ArrivalUpdateTime, ArrivalRemark, ArrivalUpdatedBy, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public string AddEditSupplierCompany(int ID, string Name, string Link, bool Status, string Cla)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_AddEditSupplierCompany(ID, Name, Link, Status, Cla, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public string AddEditSupplierOrder(int ID, string ItemName, string Company, decimal Price, decimal TotalAmount, string QTY, string Unit, bool Status, bool DeliveryStatus)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_AddEditSupplierOrder(ID, ItemName, Company, Price, TotalAmount, QTY, Unit, Status, DeliveryStatus);
        //    }

        //    return ErrMsg;
        //}
        //public string AddEditWork(int ID, string Name, int Category, int TableNo, bool Status)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_AddEditWork(ID, Name, Category, TableNo, Status, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public string AddEditCustomer(int ID, string Name, string Email_ID, string GSTIN, string PAN_CARD, string Contact_Person, string Contact_No, string Add1, string Add2, string Country, string State, string City, decimal FinalPrice, bool Status)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_AddEditCustomer(ID, Name, Email_ID, GSTIN, PAN_CARD, Contact_Person, Contact_No, Add1, Add2, Country, State, City, FinalPrice, Status, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public string AddEditWallet(int ID, int CustomerID, decimal Price, string Remark, bool Status)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_AddEditWallet(ID, CustomerID, Price, Remark, Status);
        //    }

        //    return ErrMsg;
        //}
        //public string AddEditEmployee(int ID, string Name, string Password, bool Status, bool Settle, bool Balance, bool IsAdmin)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_AddEditEmployee(ID, Name, Password, Status, Settle, Balance, IsAdmin, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}

        //public string AddEditOrder(int ID, int CustomerID)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_AddEditOrder(ID, CustomerID);
        //    }

        //    return ErrMsg;
        //}
        //public string AddEditTable(int ID, string Name, int CustomerID, bool TableStatus, bool Status)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_AddEditTable(ID, Name, CustomerID, TableStatus, Status);
        //    }

        //    return ErrMsg;
        //}
        //public string AddEditPayMode(int ID, int ParentMenuID, string Name, bool Status)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_AddEditPayMode(ID, ParentMenuID, Name, Status, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public static void GetPayMode(ref DropDownList ObjDDL, int ParentMenuID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjDDL.DataSource = from ObjTbl in ObjContext.Pay_Modes
        //                            where ObjTbl.Status == true && ObjTbl.ParentMenuId == ParentMenuID
        //                            orderby ObjTbl.Title
        //                            select new { Title = ObjTbl.Title, ID = ObjTbl.ID };
        //        ObjDDL.DataTextField = "Title";
        //        ObjDDL.DataValueField = "ID";
        //        ObjDDL.DataBind();

        //    }
        //}
        //public static void BindPlace(ref DropDownList ObjDDL, int ParentMenuID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjDDL.DataSource = ObjContext.Prc_GetPlace(ParentMenuID);
        //        ObjDDL.DataTextField = "Title";
        //        ObjDDL.DataValueField = "ID";
        //        ObjDDL.DataBind();
        //    }
        //}
        //public List<Prc_GetPlaceResult> GetPlace(int ParentMenuID, out int CountRecord)
        //{


        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_GetPlaceResult> dList = ObjContext.Prc_GetPlace(ParentMenuID).ToList();
        //        CountRecord = dList.Count();
        //        return dList;
        //    }
        //}
        //public static void GetFooterMenu(ref DropDownList ObjDDL, int ParentMenuID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjDDL.DataSource = from ObjTbl in ObjContext.Footer_Menus
        //                            where ObjTbl.IsVisible == true && ObjTbl.ParentMenuId == ParentMenuID
        //                            orderby ObjTbl.Title
        //                            select new { Title = ObjTbl.Title, ID = ObjTbl.ID };
        //        ObjDDL.DataTextField = "Title";
        //        ObjDDL.DataValueField = "ID";
        //        ObjDDL.DataBind();

        //    }
        //}
        //public static void Getdrppro(ref DropDownList ObjDDL, string Type)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjDDL.DataSource = from ObjTbl in ObjContext.drppros
        //                            where ObjTbl.Type == Type
        //                            orderby ObjTbl.Title
        //                            select new { Title = ObjTbl.Title, ID = ObjTbl.ID };
        //        ObjDDL.DataTextField = "Title";
        //        ObjDDL.DataValueField = "Title";
        //        ObjDDL.DataBind();

        //    }
        //}




        //public Prc_ProductDetailsResult ProductDetails(int ProductID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (Prc_ProductDetailsResult)ObjContext.Prc_ProductDetails(ProductID).ToList().SingleOrDefault();
        //    }
        //}
        //public Prc_MenuDetailsResult MenuDetails(int MenuID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (Prc_MenuDetailsResult)ObjContext.Prc_MenuDetails(MenuID).ToList().SingleOrDefault();
        //    }
        //}

        //public Prc_CouponDetailsResult CouponDetails(string Coupon, int Status)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (Prc_CouponDetailsResult)ObjContext.Prc_CouponDetails(Coupon, Status).ToList().SingleOrDefault();
        //    }
        //}
        //public Prc_OrderDetailsResult OrderDetails(int CartID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (Prc_OrderDetailsResult)ObjContext.Prc_OrderDetails(CartID).ToList().SingleOrDefault();
        //    }
        //}
        //public Prc_FooterMenuDetailResult FooterMenuDetail(int FooterMenuID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (Prc_FooterMenuDetailResult)ObjContext.Prc_FooterMenuDetail(FooterMenuID).ToList().SingleOrDefault();
        //    }
        //}

        //public List<Prc_GetLogoResult> GetLogo(string Location)
        //{


        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_GetLogoResult> dList = ObjContext.Prc_GetLogo(Location).ToList();
        //        return dList;
        //    }
        //}
        //public List<Prc_GetMenuResult> GetMenu(int ParentMenuID, out int CountRecord)
        //{


        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_GetMenuResult> dList = ObjContext.Prc_GetMenu(ParentMenuID).ToList();
        //        CountRecord = dList.Count();

        //        return dList;
        //    }
        //}
        //public List<Prc_GetPlaceResult> GetPlace(int ParentMenuID, out int CountRecord)
        //{


        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_GetPlaceResult> dList = ObjContext.Prc_GetPlace(ParentMenuID).ToList();
        //        CountRecord = dList.Count();
        //        return dList;
        //    }
        //}
        //public List<Prc_DrpProListResult> DrpProList(string Type, out int CountRecord)
        //{


        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_DrpProListResult> dList = ObjContext.Prc_DrpProList(Type).ToList();
        //        CountRecord = dList.Count();
        //        return dList;
        //    }
        //}
        //public List<Prc_EnquiryListResult> EnquiryList(string SearchBy, int Status, out int CountRecord)
        //{


        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_EnquiryListResult> dList = ObjContext.Prc_EnquiryList(SearchBy, Status).ToList();
        //        CountRecord = dList.Count();
        //        return dList;
        //    }
        //}

        //public List<Prc_GetFooterMenuResult> GetFooterMenu(int ParentMenuID, out int CountRecord)
        //{


        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_GetFooterMenuResult> dList = ObjContext.Prc_GetFooterMenu(ParentMenuID).ToList();
        //        CountRecord = dList.Count();

        //        return dList;
        //    }
        //}
        //public List<Prc_GetPincodeListResult> GetPincodeList(out int CountRecord)
        //{


        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_GetPincodeListResult> dList = ObjContext.Prc_GetPincodeList().ToList();
        //        CountRecord = dList.Count();
        //        return dList;
        //    }
        //}

        //public List<Prc_GetBannerResult> GetBanner(bool IsVisible, out int CountRecord)
        //{


        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_GetBannerResult> dList = ObjContext.Prc_GetBanner(IsVisible).ToList();
        //        CountRecord = dList.Count();
        //        return dList;
        //    }
        //}
        //public List<Prc_ProductListResult> ProductList(bool IsVisible, int ProductCount, int isFeatured, string Searchtxt, out int CountRecord)
        //{
        //    if (string.IsNullOrEmpty(Searchtxt))
        //    {
        //        Searchtxt = null;
        //    }

        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        List<Prc_ProductListResult> dList = ObjContext.Prc_ProductList(IsVisible, ProductCount, isFeatured, Searchtxt).ToList();
        //        CountRecord = dList.Count();
        //        return dList;
        //    }
        //}

        //public Prc_AdminDashboardResult AdminDashboard(int MemberID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return (Prc_AdminDashboardResult)ObjContext.Prc_AdminDashboard(MemberID).ToList().SingleOrDefault();
        //    }
        //}


        //public string Registration(int ID, string Name, string Mobile, string Email, string Password, string Address, string Country, string State, string City, string Pincode, bool Status, string Vercode)
        //{


        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_Registration(ID, Name, Mobile, Email, Password, Address, Country, State, City, Pincode, Status, Vercode, ref ErrMsg);
        //    }
        //    if (!ErrMsg.EndsWith("!"))
        //    {
        //        //Hashtable objHt = new Hashtable();
        //        //objHt.Add("PromoterId", ErrMsg.Split('~')[1]);
        //        //objHt.Add("Name", PromoterName.Trim());
        //        //objHt.Add("mail", PEmail.Trim());
        //        //objHt.Add("Password", PromoterPassword);
        //        //objHt.Add("Password2", PromoterPassword);
        //        //objHt.Add("Mobile", Mobile);
        //        //objHt.Add("PaymentMode", Bank_Name);
        //        //objHt.Add("companyname", System.Configuration.ConfigurationManager.AppSettings["companyname"]);
        //        //objHt.Add("url", System.Configuration.ConfigurationManager.AppSettings["url"]);
        //        //Email.SendEmail("Joining.htm", objHt, System.Configuration.ConfigurationManager.AppSettings["email"], PEmail.Trim(), "Registration Info");

        //        //string MsgSMS = string.Format("Congratulation, you have successfully registered with {0}, your Promoter ID is {1} & Password is {2} Login {3}", System.Configuration.ConfigurationManager.AppSettings["companyname"].ToString(), ErrMsg.Split('~')[1], PromoterPassword, System.Configuration.ConfigurationManager.AppSettings["url"].ToString());
        //        //sendSMS.SendSms(Mobile, MsgSMS);
        //    }
        //    return ErrMsg;
        //}
        //public string CancelOrder(int CartID, string Remark)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_CancelOrder(CartID, Remark, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}

        //public string UpdatePaymentStatus(string OrderID, string Txn_id, string Payer_Email, string txn_type, string PaymentType, string PaymentStatus)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdatePaymentStatus(OrderID, Txn_id, Payer_Email, txn_type, PaymentType, PaymentStatus);
        //    }

        //    return ErrMsg;
        //}
        //public string AddEditMenu(int MenuID, int ParentMenuID, string Title, int ColumnNo, string Image, bool Show, string DetailPage, string Description, bool Status)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_AddEditMenu(MenuID, ParentMenuID, Title, ColumnNo, Image, Show, DetailPage, Description, Status, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public string AddEditFooterMenu(int FooterMenuID, int ParentMenuID, string Title, int ColumnNo, string Description, string Link, bool IsVisible)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_AddEditFooterMenu(FooterMenuID, ParentMenuID, Title, ColumnNo, Description, Link, IsVisible, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public string CreateOrder(string OrderNo, string UserID, string Name, string EmailID, string Contact, string Address, string Pincode, string Country, string State,
        //    string City, string Remark, decimal Price, decimal DeliveryCharge, decimal TotalPrice, string DiscountName, decimal DiscountPrice)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_Create_Order(OrderNo, UserID, Name, EmailID, Contact, Address, Pincode, Country, State,
        //   City, Remark, Price, DeliveryCharge, TotalPrice, DiscountName, DiscountPrice);
        //    }

        //    return ErrMsg;
        //}
        //public string CartCreate(decimal DiscountedPrice, int ProductID, string UserID, int ProductCount, decimal TotalPrice, string Size)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_CartCreate(DiscountedPrice, ProductID, UserID, ProductCount, TotalPrice, Size, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public string ProductCreate(int ID, string relateditems, string Name, string Product_Code, decimal Price, decimal Discounted_Price, string Size, string Metal, string Weight, string Unit, string Description, string Image, string Origin,
        //    string Brilliance, string Color, string Eye_Clarity, string Shape, bool Featured, bool Stock_Status, string stoneweight, string stonetype, string stonecount, string stonesetting,
        //    int priority, string gender, string length, string width, string height, string shiptime, int Min_Quantity, bool isVisible)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_ProductCreate(ID, relateditems, Name, Product_Code, Price, Discounted_Price, Size, Metal, Weight, Unit, Description, Image, Origin,
        //    Brilliance, Color, Eye_Clarity, Shape, Featured, Stock_Status, stoneweight, stonetype, stonecount, stonesetting,
        //    priority, gender, length, width, height, shiptime, Min_Quantity, isVisible, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public string UpdateVerCode(string UserName, string VerCode)
        //{

        //    string ErrMsg = "!";
        //    //string PromoterPassword2 = RandomOTPString(5);
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateVerCode(UserName, VerCode, ref ErrMsg);
        //    }
        //    return ErrMsg;
        //}
        //public string UpdateDelivered(int ID, bool Delivered,  string DeliveryRemark)
        //{

        //    string ErrMsg = "!";

        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateDelivered(ID, Delivered, DeliveryRemark, ref ErrMsg);
        //    }
        //    return ErrMsg;
        //}
        //public string UpdateOutForDelivery(int ID, string CourierCompanyName, string AWBNumber, string DeliveryRemark)
        //{

        //    string ErrMsg = "!";

        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_UpdateOutForDelivery(ID, CourierCompanyName, AWBNumber, DeliveryRemark, ref ErrMsg);
        //    }
        //    return ErrMsg;
        //}
        //public string DeleteCart(int ID)
        //{
        //    string ErrMsg = "!";

        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_CartDelete(ID, ref ErrMsg);
        //    }
        //    return ErrMsg;
        //}
        //public string WishlistDelete(int ProductID, int WishID)
        //{
        //    string ErrMsg = "!";

        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_WishlistDelete(ProductID, WishID, ref ErrMsg);
        //    }
        //    return ErrMsg;
        //}


        //public Prc_UserDetailsResult getUserDetails(string UserID)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        return ObjContext.Prc_UserDetails(UserID).Single();
        //    }
        //}
        //public string ChangePassword(string UserID, string oldPassword, string newPassword, string IPAddress)
        //{
        //    string ErrMsg = "!";
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_ChangePassword(UserID, oldPassword, newPassword, IPAddress, ref ErrMsg);
        //    }
        //    return ErrMsg;
        //}

        //public List<Prc_CartListResult> CartList(string EmailID, int AddToCartStatus, int DeliveryStatus, string OrderID, int OrderCancel, out int CountRecord, out decimal? TotalAmount)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        if (string.IsNullOrEmpty(EmailID))
        //        {
        //            EmailID = null;
        //        }



        //        List<Prc_CartListResult> dList = ObjContext.Prc_CartList(EmailID, AddToCartStatus, DeliveryStatus, OrderID, OrderCancel).ToList();
        //        CountRecord = dList.Count();
        //        TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}
        //public List<Prc_OrderCustomerListResult> OrderCustomerList(int OrderID, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {

        //        List<Prc_OrderCustomerListResult> dList = ObjContext.Prc_OrderCustomerList(OrderID).ToList();
        //        CountRecord = dList.Count();
        //        return dList;
        //    }
        //}
        //public List<Prc_OrderListResult> OrderList(string OrderID, string EmailID, int PaymentStatus, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        if (string.IsNullOrEmpty(EmailID))
        //        {
        //            EmailID = null;
        //        }
        //        if (string.IsNullOrEmpty(OrderID))
        //        {
        //            OrderID = null;
        //        }
        //        List<Prc_OrderListResult> dList = ObjContext.Prc_OrderList(OrderID, EmailID, PaymentStatus).ToList();
        //        CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}
        //public List<Prc_UserListResult> UserList(string SearchBy, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        if (string.IsNullOrEmpty(SearchBy))
        //        {
        //            SearchBy = null;
        //        }

        //        List<Prc_UserListResult> dList = ObjContext.Prc_UserList(SearchBy).ToList();
        //        CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}
        //public List<Prc_AdminListResult> AdminList(out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {

        //        List<Prc_AdminListResult> dList = ObjContext.Prc_AdminList().ToList();
        //        CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}

        //public List<Prc_WishListResult> WishList(int ID, out int CountRecord)
        //{
        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {

        //        List<Prc_WishListResult> dList = ObjContext.Prc_WishList(ID).ToList();
        //        CountRecord = dList.Count();
        //        //TotalAmount = dList.Sum(item => item.Total_Price);

        //        return dList;
        //    }
        //}

        //public string EditLogo(string Logo, int ID)
        //{
        //    string ErrMsg = "!";

        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_EditLogo(Logo, ID);
        //    }

        //    return ErrMsg;
        //}

        //public string DeleteBanner(int ID)
        //{
        //    string ErrMsg = "!";

        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_DeleteBanner(ID);
        //    }

        //    return ErrMsg;
        //}
        //public string EnquiryUpdate(int ID)
        //{
        //    string ErrMsg = "!";

        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_EnquiryUpdate(ID);
        //    }

        //    return ErrMsg;
        //}
        //public string AddEditPincode(int ID, string Pincode, string Area, decimal DeliveryCharge)
        //{
        //    string ErrMsg = "!";

        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_AddEditPincode(ID, Pincode, Area, DeliveryCharge);
        //    }

        //    return ErrMsg;
        //}
        //public string AddEditCoupon(int ID, string CouponName, string CouponCode, decimal Discount, int FixedPrice, int ExpireDate, int OrderMin, bool Status)
        //{
        //    string ErrMsg = "!";

        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_AddEditCoupon(ID, CouponName, CouponCode, Discount, FixedPrice, ExpireDate, OrderMin, Status);
        //    }

        //    return ErrMsg;
        //}
        //public string AddBanner(string Name, string Banner, string Size, int Status)
        //{
        //    string ErrMsg = "!";

        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.Prc_AddBanner(Name, Banner, Size, Status, ref ErrMsg);
        //    }

        //    return ErrMsg;
        //}
        //public string EnquiryCreate(string Name, string Email, string Phone, string Message)
        //{
        //    string ErrMsg = "!";

        //    using (WebsiteDataContext ObjContext = new WebsiteDataContext())
        //    {
        //        ObjContext.proc_EnquiryCre(Name, Email, Phone, Message);
        //    }

        //    return ErrMsg;
        //}
    }
}

