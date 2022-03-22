using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (RouteData.Values["ContactCategoryID"] != null)
            {
                lblTitle.Text = "Edit Contact Category";
                btnSubmit.Text = "Edit";
                FillControlls(Convert.ToInt32(RouteData.Values["ContactCategoryID"]));
            }
        }
    }
    #endregion Page Lode
    #region Submit Form
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Local variable
        SqlString strContactCategory = SqlString.Null;
        #endregion Local variable
        #region Server side validation
        if (txtContactCategory.Text.Trim() == "")
        {
            lblMsg.Text = "Please enter a Contact Category";
            return;
        }
        #endregion Server side validation
        #region Set local 
        if (txtContactCategory.Text.Trim() != "")
            strContactCategory = txtContactCategory.Text.Trim();
        #endregion Set local variable
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection

        ContactCategoryBAL contactCategoryBAL = new ContactCategoryBAL();
        ContactCategoryENT entContactCategory = new ContactCategoryENT();
        entContactCategory.ContactCategoryName = strContactCategory;
        entContactCategory.UserID = Convert.ToInt32(Session["UserID"]);

        if(RouteData.Values["ContactCategoryID"] != null)
        {
            #region Update
            entContactCategory.ContactCategoryID = Convert.ToInt32(RouteData.Values["ContactCategoryID"]);
            if (contactCategoryBAL.Update(entContactCategory))
            {
                Session["Success"] = "Contact Category Updated Successfully";
                Response.Redirect("~/AdminPanel/ContactCategory/List", true);
            }
            else
            {
                if (contactCategoryBAL.Message.Contains("Violation of UNIQUE KEY constraint 'UK_ContactCategory_ContactCategoryName_UserID'."))
                {
                    Session["Error"] = "Contact Category alrady exist!";
                }
                else
                {
                    Session["Error"] = contactCategoryBAL.Message;
                }
            }
            #endregion Update
        }
        else
        {
            #region Insert
            if (contactCategoryBAL.Insert(entContactCategory))
            {
                Session["Success"] = "Contact Category Added Successfully";
                ClearControl();
            }
            else
            {
                if (contactCategoryBAL.Message.Contains("Violation of UNIQUE KEY constraint 'UK_ContactCategory_ContactCategoryName_UserID'."))
                {
                    Session["Error"] = "Contact Category alrady exist!";
                }
                else
                {
                    Session["Error"] = contactCategoryBAL.Message;
                }
            }
            #endregion Insert
        }
    }
    #endregion Submit Form

    #region Fill Controlls
    private void FillControlls(SqlInt32 Id)
    {
        ContactCategoryBAL contactCategoryBAL = new ContactCategoryBAL();
        ContactCategoryENT entContactCategory = contactCategoryBAL.SelectByPK(Id, Convert.ToInt32(Session["UserID"]));

        if(entContactCategory != null)
        {
            if (!entContactCategory.ContactCategoryName.IsNull)
            {
                txtContactCategory.Text = entContactCategory.ContactCategoryName.Value.ToString();
            }
        }

    }
    #endregion Fill Controlls

    #region Clear Control
    private void ClearControl()
    {
        txtContactCategory.Text = "";
    }
    #endregion Clear Control
}