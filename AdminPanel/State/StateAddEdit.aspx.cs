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
                FillControlls(Convert.ToInt32(EncryptionDecryption.Decode(RouteData.Values["StateID"].ToString())));
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

        if(EncryptionDecryption.Decode(RouteData.Values["StateID"].ToString()) != null)
        {
            #region Update
            entState.StateID = Convert.ToInt32(EncryptionDecryption.Decode(RouteData.Values["StateID"].ToString()));
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
        StateBAL stateBAL = new StateBAL();
        StateENT entState = stateBAL.SelectByPK(Id, Convert.ToInt32(Session["UserID"]));

        if(entState != null)
        {
            if (!entState.StateName.IsNull)
            {
                txtState.Text = entState.StateName.Value.ToString();
            }
            if (!entState.StateCode.IsNull)
            {
                txtCode.Text = entState.StateCode.Value.ToString();
            }
            if(!entState.StateID.IsNull)
            {
                ddlCountry.SelectedValue = entState.CountryID.Value.ToString();
            }
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