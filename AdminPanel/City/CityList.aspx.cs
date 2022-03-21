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

public partial class AdminPanel_City_CityList : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCity();
        }
    }
    #endregion Page Load
    #region Fill City
    private void FillCity()
    {
        CityBAL cityBAL = new CityBAL();
        DataTable dt = cityBAL.SelectAll(Convert.ToInt32(Session["UserID"]));
        gvCity.DataSource = dt;
        gvCity.DataBind();
    }
    #endregion FillCity
    #region GridView RowCommand
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DeleteCity(Convert.ToInt32(e.CommandArgument.ToString()));
                FillCity();
            }
        }
    }
    #endregion GridView RowCommand
    #region Delete City
    private void DeleteCity(SqlInt32 Id)
    {
        CityBAL cityBAL = new CityBAL();
        if (cityBAL.Delete(Id, Convert.ToInt32(Session["UserID"])))
        {
            Session["Success"] = "City deleted successfully";
        }
        else
        {
            Session["Error"] = cityBAL.Message;
        }
    }
    #endregion Delete City
}