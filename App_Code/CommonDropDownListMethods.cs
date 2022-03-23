using AddressBook.BAL;
using System;
using System.Collections;
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

/// <summary>
/// Summary description for CommonDropDownListMethods
/// </summary>
public static class CommonDropDownListMethods
{
    public static string Message;
    
    #region Country DropDown
    public static void FillCountryDropDown(DropDownList ddl, SqlInt32 UserId)
    {
        CountryBAL countryBAL = new CountryBAL();
        DataTable dt = countryBAL.SelectForDropDown(UserId);

        if(dt.Rows.Count > 0)
        {
            ddl.DataSource = dt;
            ddl.DataValueField = "CountryID";
            ddl.DataTextField = "CountryName";
            ddl.DataBind();
        }
    }
    #endregion Country DropDown

    #region State DropDown CountryID
    public static void FillStateDropDownByCountryID(DropDownList ddl, SqlInt32 UserId, SqlInt32 CountryId)
    {
        StateBAL stateBAL = new StateBAL();
        DataTable dt = stateBAL.SelectForDropDownByCountryID(UserId, CountryId);

        if (dt.Rows.Count > 0)
        {
            ddl.DataSource = dt;
            ddl.DataValueField = "StateID";
            ddl.DataTextField = "StateName";
            ddl.DataBind();
        }

    }
    #endregion State DropDown CountryID

    #region State DropDown
    public static void FillStateDropDownByCountryID(DropDownList ddl, SqlInt32 UserId)
    {
        StateBAL stateBAL = new StateBAL();
        DataTable dt = stateBAL.SelectForDropDown(UserId);

        if (dt.Rows.Count > 0)
        {
            ddl.DataSource = dt;
            ddl.DataValueField = "StateID";
            ddl.DataTextField = "StateName";
            ddl.DataBind();
        }

    }
    #endregion State DropDown

    #region City DropDown
    public static void FillCityDropDown(DropDownList ddl, SqlInt32 UserId, SqlInt32 StateId)
    {
        CityBAL stateBAL = new CityBAL();
        DataTable dt = stateBAL.SelectForDropDownByStateID(UserId, StateId);

        if (dt.Rows.Count > 0)
        {
            ddl.DataSource = dt;
            ddl.DataValueField = "CityID";
            ddl.DataTextField = "CityName";
            ddl.DataBind();
        }

    }
    #endregion City DropDown 

    #region Contact Category CheckBox
    public static void FillContactCategoryCheckBox(CheckBoxList chk, SqlInt32 UserId)
    {
        ContactCategoryBAL stateBAL = new ContactCategoryBAL();
        DataTable dt = stateBAL.SelectForDropDown(UserId);

        if (dt.Rows.Count > 0)
        {
            chk.DataSource = dt;
            chk.DataValueField = "ContactCategoryID";
            chk.DataTextField = "ContactCategoryName";
            chk.DataBind();
        }
    }
    #endregion Contact Category CheckBox
}