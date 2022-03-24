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
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Bind Data
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactWiseContactCategory_SelectByContactIDUserID";
            objCmd.Parameters.AddWithValue("@ContactID", Id);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            SqlDataReader objSDR = objCmd.ExecuteReader();
            gvContactWiseContactCategory.DataSource = objSDR;
            gvContactWiseContactCategory.DataBind();
            #endregion Create Command and Bind Data

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Fill Contact

    #region GridViewRowCommand
    protected void gvContactWiseContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            if (e.CommandArgument != null)
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