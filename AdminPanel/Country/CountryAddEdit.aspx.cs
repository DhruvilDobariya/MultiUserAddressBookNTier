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
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (RouteData.Values["CountryID"] != null)
            {
                btnSubmit.Text = "Edit";
                lblTitle.Text = "Edit Country";
                FillControlls(Convert.ToInt32(EncryptionDecryption.Decode(RouteData.Values["CountryID"].ToString())));
            }
        }
    }
    #endregion Page Load
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

        if(EncryptionDecryption.Decode(RouteData.Values["CountryID"].ToString()) != null)
        {
            #region Update
            entCountry.CountryID = Convert.ToInt32(EncryptionDecryption.Decode(RouteData.Values["CountryID"].ToString()));
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
            #endregion Update

        }
        else
        {
            #region Add
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
            #endregion Add
        }


    }
    #endregion SubmitForm
    #region FillControlls
    private void FillControlls(SqlInt32 Id)
    {
        CountryBAL countryBAL = new CountryBAL();
        CountryENT entCountry = countryBAL.SelectByPK(Id, Convert.ToInt32(Session["UserID"]));

        if(!entCountry.CountryName.IsNull)
        {
            txtCountry.Text = entCountry.CountryName.Value.ToString();
        }
        if (!entCountry.CountryCode.IsNull)
        {
            txtCode.Text = entCountry.CountryCode.Value.ToString();
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