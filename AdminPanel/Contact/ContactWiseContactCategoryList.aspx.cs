using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_ContactWiseContactCategoryList : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if(RouteData.Values["ContactID"] != null)
            {
                FillContactWiseContactCategory(Convert.ToInt32(RouteData.Values["ContactID"]));
            }
        }
    }
    #endregion Page Load

    #region Fill Contact
    private void FillContactWiseContactCategory(SqlInt32 Id)
    {
        ContactWiseContactCategoryBAL contactWiseContactCategoryBAL = new ContactWiseContactCategoryBAL();
        DataTable dt = contactWiseContactCategoryBAL.SelectAll(Id, Convert.ToInt32(Session["UserID"]));

        gvContactWiseContactCategory.DataSource = dt;
        gvContactWiseContactCategory.DataBind();
    }
    #endregion Fill Contact

    #region GridViewRowCommand
    protected void gvContactWiseContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecored")
        {
            if (e.CommandArgument != "")
            {
                DeleteContactWiseContactCategory(Convert.ToInt32(e.CommandArgument.ToString()));
                FillContactWiseContactCategory(Convert.ToInt32(RouteData.Values["ContactID"]));
            }
        }
    }
    #endregion GridViewRowCommand

    #region Delete Contact Wise Contact Category
    private void DeleteContactWiseContactCategory(SqlInt32 Id)
    {
        ContactWiseContactCategoryBAL contactWiseContactCategoryBAL = new ContactWiseContactCategoryBAL();
        if(contactWiseContactCategoryBAL.DeleteByPK(Id, Convert.ToInt32(Session["UserID"])))
        {
            Session["Success"] = "Contact wise contact category deleted successfully";
            FillContactWiseContactCategory(Convert.ToInt32(RouteData.Values["ContactID"]));
        }
        else
        {
            Session["Error"] = contactWiseContactCategoryBAL.Message;
        }
    }
    #endregion Delete Contact Wise Contact Category
}