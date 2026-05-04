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
    public partial class FormList : System.Web.UI.Page
    {
        CommonBLL objBLL = new CommonBLL();
        decimal TotalAmount = 0;
        int CountRecords = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonBLL.BindFormCategoryDisctinct(drpCategory);
                drpCategory.Items.Insert(0, new ListItem("Select Category", ""));
                gvbind();
            }
        }
        protected void gvbind()
        {
            int CountRecords = 0;

            rpt_Menu.DataSource = objBLL.CategoryList(drpCategory.SelectedValue, "EWS", out CountRecords);
            rpt_Menu.DataBind();

        }

        protected void rpt_Menu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int CountRecord = 0;
            GridView grdView = e.Item.FindControl("grdView") as GridView;
            RepeaterItem item = e.Item;
            string ParentMenuId = (item.FindControl("ltrCategoryName") as Literal).Text;
            grdView.DataSource = objBLL.FormListCategoryWise(ParentMenuId, txtSearchBy.Text, 2, 2, 0, out CountRecord);
            grdView.DataBind();

        }

        protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvbind();
        }

        protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var status = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FormStatus"));
                var ltr = (Literal)e.Row.FindControl("ltrFormStatus");
                var lbl = (Label)e.Row.FindControl("lblStatusText");
                lbl.Text = status == 0 ? "Pending" : status == 1 ? "Approve" : status == 2 ? "Rejected" : "";


                if (lbl.Text == "Pending")
                {
                    lbl.CssClass = "btn btn-primary";
                }
                else if (lbl.Text == "Approve")
                {
                    lbl.CssClass = "btn btn-success";

                }
                else
                {
                    lbl.CssClass = "btn btn-danger";

                }

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvbind();
        }
    }
}