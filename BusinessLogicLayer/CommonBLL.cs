using ClosedXML.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        public void ExportToExcelByDT(DataTable data, string fileName)
        {
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Sheet1");
            ws.Cell(1, 1).InsertTable(data);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AddHeader("content-disposition", String.Format(@"attachment;filename={0}.xlsx", fileName.Replace(" ", "_")));

            using (MemoryStream memoryStream = new MemoryStream())
            {
                wb.SaveAs(memoryStream);
                memoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
                memoryStream.Close();
            }

            HttpContext.Current.Response.End();

            //HttpContext ctx = HttpContext.Current;
            //ctx.Response.Clear();
            //ctx.Response.Buffer = true;
            //System.IO.StringWriter sw = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(sw);
            //ctx.Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            //ctx.Response.Charset = "";
            //ctx.Response.ContentType = "application/vnd.ms-excel";
            //gv.RenderControl(hw);
            //ctx.Response.Write(sw.ToString());
            //ctx.Response.End();
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
        public List<Prc_FormlistExportResult> FormlistExport(int ID, string SearchBy, string Category, string ApplyFor, int RegNo, int Alloty, int FormStatus, out int CountRecord)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                SearchBy = SearchBy == "" ? null : SearchBy;
                Category = Category == "" ? null : Category;
                ApplyFor = ApplyFor == "" ? null : ApplyFor;

                List<Prc_FormlistExportResult> dList = ObjContext.Prc_FormlistExport(ID, SearchBy, Category, ApplyFor, RegNo, Alloty, FormStatus).ToList();
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
                ddl.DataSource = EDC.Prc_CategoryList(null, "EWS").ToList(); ;
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

        
        public string CheckSeedNo(int SeedNo)
        {
            string ErrMsg = "!";
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                ObjContext.Prc_CheckSeedNo(SeedNo, ref ErrMsg);
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
        public List<Prc_TrialLotteryListResult> TrialLotteryList(string Category, string PlotCategory, int TrialNo, int Seq, out int CountRecord)
        {
            using (WebsiteDataContext ObjContext = new WebsiteDataContext())
            {
                List<Prc_TrialLotteryListResult> dList = new List<Prc_TrialLotteryListResult>();
                if (Seq == 1)
                {
                    dList = ObjContext.Prc_TrialLotteryList(Category, PlotCategory, TrialNo).OrderBy(s => s.CustomerName.Trim()).ToList();
                }
                else
                {
                    dList = ObjContext.Prc_TrialLotteryList(Category, PlotCategory, TrialNo).ToList();

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
        
    }
}

