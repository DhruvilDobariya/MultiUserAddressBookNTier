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

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region PageLode
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (RouteData.Values["CountryID"] != null)
            {
                btnSubmit.Text = "Edit";
                lblTitle.Text = "Edit Country";
                FillControlls(Convert.ToInt32(RouteData.Values["CountryID"]));
            }
        }
    }
    #endregion PageLode
    #region SubmimForm
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Local variable
        SqlString CountryName = SqlString.Null;
        SqlString CountryCode = SqlString.Null;
        #endregion Local variable
        #region Server side validation
        if (txtCountry.Text.Trim() == "" && txtCode.Text.Trim() == "")
        {
            lblMsg.Text = "Please enter Country Name and Country Code";
            return;
        }
        else if (txtCountry.Text.Trim() == "")
        {
            lblMsg.Text = "Please enter Country Name";
            return;
        }
        else if (txtCode.Text.Trim() == "")
        {
            lblMsg.Text = "Please enter Country Code";
            return;
        }

        if (txtCountry.Text.Trim() != "")
            CountryName = txtCountry.Text.Trim();
        if (txtCode.Text.Trim() != "")
            CountryCode = txtCode.Text.Trim();
        #endregion Server side validation
        CountryENT entCountry = new CountryENT();
        entCountry.CountryName = CountryName;
        entCountry.CountryCode = CountryCode;
        entCountry.UserID = Convert.ToInt32(Session["UserID"]);
        CountryBAL countryBAL = new CountryBAL();
        if(RouteData.Values["CountryID"] != null)
        {
            entCountry.CountryID = Convert.ToInt32(RouteData.Values["CountryID"]);
            if (countryBAL.Update(entCountry))
            {
                Session["Success"] = "Country Updated Successfully";
                Response.Redirect("~/AdminPanel/Country/List", true);
            }
            else
            {
                if (countryBAL.Message.Contains("Violation of UNIQUE KEY constraint 'UK_Country_CountryName_UserID'."))
                {
                    Session["Error"] = "Country aready exist";
                }
                else
                {
                    Session["Error"] = countryBAL.Message;
                }
            }
            
        }
        else
        {
            if (countryBAL.Insert(entCountry))
            {
                Session["Success"] = "Country Added Successfully";
                ClearControl();
            }
            else
            {
                if (countryBAL.Message.Contains("Violation of UNIQUE KEY constraint 'UK_Country_CountryName_UserID'."))
                {
                    Session["Error"] = "Country aready exist";
                }
                else
                {
                    Session["Error"] = countryBAL.Message;
                }
            }

        }
        

    }
    #endregion SubmitForm
    #region FillControlls
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
            SqlCommand objCmd = new SqlCommand("PR_Country_SelectByPKUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CountryID", Id);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Create Command and Set Parameters
            #region Get data and set data
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CountryName"].Equals(DBNull.Value))
                    {
                        txtCountry.Text = objSDR["CountryName"].ToString();
                    }
                    if (!objSDR["CountryCode"].Equals(DBNull.Value))
                    {
                        txtCode.Text = objSDR["CountryCode"].ToString();
                    }
                    break;
                }
            }
            else
            {
                lblMsg.Text = "Country Not Found!";
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
    #endregion FillControlls

    #region Clear Control
    private void ClearControl()
    {
        txtCountry.Text = "";
        txtCode.Text = "";
    }
    #endregion Clear Control
}