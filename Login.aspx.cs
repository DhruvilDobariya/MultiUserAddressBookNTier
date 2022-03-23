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

public partial class AdminPanel_Login : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Page Load

    #region Submit form
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        #region Local variable
        SqlString strUsername = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        #endregion Local variable
        #region Server side validation
        if (txtUserName.Text.Trim() == "" && txtPassword.Text.Trim() == "")
        {
            lblMsg.Text = "Please Enter Username Password";
            return;
        }
        else if (txtUserName.Text.Trim() == "")
        {
            lblMsg.Text = "Please Enter Username";
            return;
        }
        else if (txtPassword.Text.Trim() == "")
        {
            lblMsg.Text = "Please Enter Password";
            return;
        }
        #endregion Server side validation
        #region Set local variable
        if (txtUserName.Text.Trim() != "")
            strUsername = txtUserName.Text.Trim();
        if (txtPassword.Text.Trim() != "")
            strPassword = txtPassword.Text.Trim();
        #endregion Set local variable

        UserBAL userBAL = new UserBAL();
        UserENT entUser = userBAL.ValidateUser(strUsername, strPassword);

        if(entUser != null)
        {
            if (!entUser.UserID.IsNull)
            {
                Session["UserID"] = entUser.UserID.Value.ToString();
            }
            if (!entUser.DisplayName.IsNull)
            {
                Session["DisplayName"] = entUser.DisplayName.Value.ToString();
            }
            Response.Redirect("~/AdminPanel/Home", true);
        }
        else
        {
            lblMsg.Text = userBAL.Message;
        }
    }
    #endregion Submit form
}