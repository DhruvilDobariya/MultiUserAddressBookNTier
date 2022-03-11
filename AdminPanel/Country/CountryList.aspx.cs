using AddressBook.BAL;
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

public partial class AdminPanel_Country_Read : System.Web.UI.Page
{
    string Message = "Done!";
    #region PageLode
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCountry();
        }
    }
    #endregion PageLode
    #region FillCountry
    private void FillCountry()
    {
        CountryBAL countryBAL = new CountryBAL();
        DataTable dt = new DataTable();
        if(Session["UserID"] != null)
        {
            dt = countryBAL.SelectAll(Convert.ToInt32(Session["UserID"]));
        }
        gvCountry.DataSource = dt;
        gvCountry.DataBind();
    }
    #endregion FillCountry
    #region GridViewRowCommand
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != "")
            {
                DeleteCountry(Convert.ToInt32(e.CommandArgument.ToString()));
                FillCountry();
            }
        }
    }
    #endregion GridViewRowCommand
    #region DeleteCountry
    private void DeleteCountry(SqlInt32 Id)
    {
        
        CountryBAL countryBAL = new CountryBAL();
        if(Session["UserID"] != null)
        {
            if(countryBAL.Delete(Id , Convert.ToInt32(Session["UserID"])))
            {
                Session["Success"] = "Country Deleted Successfully";
                 FillCountry();
            }
            else
            {
                Session["Error"] = countryBAL.Message;
            }
        }
        
    }
    #endregion DeleteCountry
}