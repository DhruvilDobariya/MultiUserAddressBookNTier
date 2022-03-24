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

public partial class AdminPanel_Contact_ContactList : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillContact();
        }
    }
    #endregion Page Load
    #region Fill Contact
    private void FillContact()
    {
        ContactBAL contactBAL = new ContactBAL();
        DataTable dt = contactBAL.SelectAll(Convert.ToInt32(Session["UserID"]));
        gvContact.DataSource = dt;
        gvContact.DataBind();
    }
    #endregion Fill Contact
    #region GridView RowCommand
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DeleteContact(Convert.ToInt32(e.CommandArgument.ToString()));
                FillContact();
            }
        }
    }
    #endregion GridView RowCommand
    #region Delete Contact
    private void DeleteContact(SqlInt32 Id)
    {

        ContactBAL contactBAL = new ContactBAL();
        if (contactBAL.Delete(Id, Convert.ToInt32(Session["UserID"])))
        {
            DeleteContactCategory(Id);

            #region Delete Image
            FileInfo file = new FileInfo(Server.MapPath("~/UserContent/" + Id.ToString() + ".jpg"));

            if (file.Exists)
            {
                file.Delete();
            }
            #endregion Delete Image

            DeleteContactImage(Id);

            Session["Success"] = "Contact deleted successfully";
        }
        else
        {
            Session["Error"] = contactBAL.Message;
        }
    }
    #endregion Delete Contact
    
    #region Delete Image
    private void DeleteContactImage(SqlInt32 Id)
    {
        ContactBAL contactBAL = new ContactBAL();
        if (!contactBAL.DeleteImage(Id, Convert.ToInt32(Session["UserID"])))
        {
            Session["Error"] = contactBAL.Message;
        }
    }
    #endregion Delete Image

    #region Delete Contact Category
    private void DeleteContactCategory(SqlInt32 Id)
    {
        ContactWiseContactCategoryBAL contactWiseContactCategoryBAL = new ContactWiseContactCategoryBAL();
        if (!contactWiseContactCategoryBAL.DeleteByCountryID(Id, Convert.ToInt32(Session["UserID"])))
        {
            Session["Error"] = contactWiseContactCategoryBAL.Message;
        }
    }
    #endregion Delete Contact Category
}