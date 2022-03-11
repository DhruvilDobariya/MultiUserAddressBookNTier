﻿using AddressBook.BAL;
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

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region PageLode
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCountryDropDown();
            if (RouteData.Values["StateID"] != null)
            {
                lblTitle.Text = "Edit State";
                btnSubmit.Text = "Edit";
                FillControlls(Convert.ToInt32(RouteData.Values["StateID"]));
            }
        }
    }
    #endregion PageLode
    #region FillCountryDropDown
    private void FillCountryDropDown()
    {
        CommonDropDownListMethods.FillCountryDropDown(ddlCountry, Convert.ToInt32(Session["UserID"]));
    }
    #endregion FillCountryDropDown
    #region SubmitForm
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Local variable
        SqlString strStateName = SqlString.Null;
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlString strStateCode = SqlString.Null;
        #endregion Local variable
        #region Server side validation
        if (txtState.Text.Trim() == "" || txtCode.Text.Trim() == "" || ddlCountry.SelectedValue == "-1")
        {
            lblMsg.Text = "Please Enter State Name, State Code and Country Name";
            return;
        }
        else if (txtState.Text.Trim() == "" || txtCode.Text.Trim() == "")
        {
            lblMsg.Text = "Please Enter State Name, State Code";
            return;
        }
        else if (txtCode.Text.Trim() == "" || ddlCountry.SelectedValue == "-1")
        {
            lblMsg.Text = "Please Enter State Code and Country Name";
            return;
        }
        else if (txtState.Text.Trim() == "" || ddlCountry.SelectedValue == "-1")
        {
            lblMsg.Text = "Please Enter State Name and Country Name";
            return;
        }
        if (txtState.Text.Trim() == "")
        {
            lblMsg.Text = "Please Enter State Name";
            return;
        }
        if (txtCode.Text.Trim() == "")
        {
            lblMsg.Text = "Please Enter State Code";
            return;
        }
        if (ddlCountry.SelectedValue == "-1")
        {
            lblMsg.Text = "Please Enter Country Name";
            return;
        }
        #endregion Server side validation
        #region Set local 
        if (txtState.Text != "")
            strStateName = txtState.Text;
        if (ddlCountry.SelectedValue != "")
            strCountryID = Convert.ToInt32(ddlCountry.SelectedValue);
        if (txtCode.Text != "")
            strStateCode = txtCode.Text;
        #endregion Set local variable
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection

        StateBAL stateBAL = new StateBAL();
        StateENT entState = new StateENT();
        entState.StateName = strStateName;
        entState.StateCode = strStateCode;
        entState.CountryID = strCountryID;
        entState.UserID = Convert.ToInt32(Session["UserID"]);

        if(RouteData.Values["StateID"] != null)
        {
            #region Update
            entState.StateID = Convert.ToInt32(RouteData.Values["StateID"]);
            if (stateBAL.Update(entState))
            {
                Session["Success"] = "State Updated Successfully";
                Response.Redirect("~/AdminPanel/State/List", true);
            }
            else
            {
                if (stateBAL.Message.Contains("Violation of UNIQUE KEY constraint 'UK_State_StateName_UserID'."))
                {
                    Session["Error"] = "State alrady exist!";
                }
                else
                {
                    Session["Error"] = stateBAL.Message;
                }
            }
            #endregion Update
        }
        else
        {
            #region Insert
            if (stateBAL.Insert(entState))
            {
                Session["Success"] = "State Added Successfully";
                ClearControl();
            }
            else
            {
                if (stateBAL.Message.Contains("Violation of UNIQUE KEY constraint 'UK_State_StateName_UserID'."))
                {
                    Session["Error"] = "State alrady exist!";
                }
                else
                {
                    Session["Error"] = stateBAL.Message;
                }
            }
            #endregion Insert
        }
    }
    #endregion SubmitForm

    #region Fill Controlls
    private void FillControlls(SqlInt32 Id)
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Set Parameters
            SqlCommand objCmd = new SqlCommand("PR_State_SelectByPKUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@StateID", Id);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Create Command and Set Parameters

            #region Get data and set data
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["StateName"].Equals(DBNull.Value))
                    {
                        txtState.Text = objSDR["StateName"].ToString();
                    }
                    if (!objSDR["StateCode"].Equals(DBNull.Value))
                    {
                        txtCode.Text = objSDR["StateCode"].ToString();
                    }
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountry.SelectedValue = objSDR["CountryID"].ToString();
                    }
                    break;
                }
            }
            else
            {
                lblMsg.Text = "State Not Found!";
            }
            #endregion Get data and set data

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
    #endregion Fill Controlls

    #region Clear Control
    private void ClearControl()
    {
        txtState.Text = "";
        txtCode.Text = "";
        ddlCountry.SelectedValue = "-1";
    }
    #endregion Clear Control
}