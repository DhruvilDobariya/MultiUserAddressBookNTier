using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;
using System.Configuration;
using AddressBook.BAL;

public partial class AdminPanel_ContactCategory_ContactCategoryList : System.Web.UI.Page
{
    #region Page Lode
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillContactCategory();
        }
    }
    #endregion Page Lode
    #region Fill Contact Category
    private void FillContactCategory()
    {
        ContactCategoryBAL contactCategoryBAL = new ContactCategoryBAL();
        DataTable dt = contactCategoryBAL.SelectAll(Convert.ToInt32(Session["UserID"]));
        gvContactCategory.DataSource = dt;
        gvContactCategory.DataBind();
    }
    #endregion Fill Contact Category
    #region GridView RowCommand
    protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DeleteContactCategory(Convert.ToInt32(e.CommandArgument.ToString()));
                FillContactCategory();
            }
        }
    }
    #endregion GridView RowCommand
    #region Delete Contact Category
    private void DeleteContactCategory(SqlInt32 Id)
    {
        ContactCategoryBAL contactCategoryBAL = new ContactCategoryBAL();
        if (contactCategoryBAL.Delete(Id, Convert.ToInt32(Session["UserID"]))){
            Session["Success"] = "Contact Category Deleted Successfully";
        }
        else
        {
            if (contactCategoryBAL.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
            {
                Session["Error"] = "This Contact Category contain some records, So please delete these record, If you want to delete this Contact Category.";
            }
            else
            {
                Session["Error"] = contactCategoryBAL.Message;
            }
        }
    }
    #endregion Delete Contact Category
}