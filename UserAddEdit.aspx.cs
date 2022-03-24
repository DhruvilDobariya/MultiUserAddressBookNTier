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
public partial class UserAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        if (!Page.IsPostBack)
        {
            if (RouteData.Values["UserID"] != null && EncryptionDecryption.Decode(RouteData.Values["UserID"].ToString()).ToString() == Session["UserID"].ToString())
            {
                FillControlls();
                btnSubmit.Text = "Edit";
                lblTitle.Text = "Edit User Details";
            }
        }
    }
    #endregion Page Load
    #region Submit form
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Local variable
        SqlString strDisplayName = SqlString.Null;
        SqlString strMobileNo = SqlString.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        SqlString strUserName = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        #endregion Local variable
        #region Server side validation
        if (txtUserName.Text.Trim() == "" && txtName.Text.Trim() == "" && txtPassword.Text.Trim() == "")
        {
            lblMsg.Text = "Please Enter Email, Name and Password";
            return;
        }
        else if (txtUserName.Text.Trim() == "" && txtName.Text.Trim() == "")
        {
            lblMsg.Text = "Please Enter Email and Name";
            return;
        }
        else if (txtName.Text.Trim() == "" && txtPassword.Text.Trim() == "")
        {
            lblMsg.Text = "Please Enter Name and Password";
            return;
        }
        else if (txtUserName.Text.Trim() == "" && txtPassword.Text.Trim() == "")
        {
            lblMsg.Text = "Please Enter Email and Password";
            return;
        }
        else if (txtUserName.Text.Trim() == "")
        {
            lblMsg.Text = "Please Enter Email";
            return;
        }
        else if (txtName.Text.Trim() == "")
        {
            lblMsg.Text = "Please Enter Name";
            return;
        }
        else if (txtPassword.Text.Trim() == "")
        {
            lblMsg.Text = "Please Password";
            return;
        }
        #endregion Server side validation

        #region Set local variable
        if (txtUserName.Text.Trim() != "")
            strUserName = txtUserName.Text.Trim();
        if (txtName.Text.Trim() != "")
            strDisplayName = txtName.Text.Trim();
        if (txtPassword.Text.Trim() != "")
            strPassword = txtPassword.Text.Trim();
        if (txtAddress.Text.Trim() != "")
            strAddress = txtAddress.Text.Trim();
        if (txtMobileNo.Text.Trim() != "")
            strMobileNo = txtMobileNo.Text.Trim();
        if (txtEmail.Text.Trim() != "")
            strEmail = txtEmail.Text.Trim();
        #endregion Set local variable

        UserENT entUser = new UserENT()
        {
            UserName = strUserName,
            Password = strPassword,
            Address = strAddress,
            DisplayName = strDisplayName,
            Email = strEmail,
            MobileNo = strMobileNo
        };
        

        if (EncryptionDecryption.Decode(RouteData.Values["UserID"].ToString()) != null)
        {
            #region Update record
            UserBAL userBAL = new UserBAL();
            entUser.UserID = Convert.ToInt32(EncryptionDecryption.Decode(RouteData.Values["UserID"].ToString()));
            if (userBAL.Update(entUser))
            {
                Session["Success"] = "User updated successfully";
                Response.Redirect("~/AdminPanel/Home", true);
            }
            else
            {
                Session["Error"] = userBAL.Message;
            }
            
            #endregion Update record
        }
        else
        {
            #region Add record
            UserBAL userBAL = new UserBAL();
            if (userBAL.Insert(entUser))
            {
                Response.Redirect("~/Login.aspx", true);
            }
            else
            {
                Session["Error"] = userBAL.Message;
            }
            
            #endregion Add record
        }
    }
    #endregion Submit form
    #region FillControlls
    private void FillControlls()
    {
        UserBAL userBAL = new UserBAL();
        UserENT entUser = userBAL.SelectByPK(Convert.ToInt32(Session["UserID"]));

        if(entUser != null)
        {
            if (!entUser.UserName.IsNull)
            {
                txtUserName.Text = entUser.UserName.Value.ToString();
            }
            if (!entUser.Password.IsNull)
            {
                txtPassword.Text = entUser.Password.Value.ToString();
                txtRetypePassword.Text = entUser.Password.ToString();
            }
            if (!entUser.DisplayName.IsNull)
            {
                txtName.Text = entUser.DisplayName.Value.ToString();
            }
            if (!entUser.Email.IsNull)
            {
                txtEmail.Text = entUser.Email.Value.ToString();
            }
            if (!entUser.MobileNo.IsNull)
            {
                txtMobileNo.Text = entUser.MobileNo.Value.ToString();
            }
            if (!entUser.Address.IsNull)
            {
                txtAddress.Text = entUser.Address.Value.ToString();
            }
        }
        else
        {
            Session["Error"] = userBAL.Message;
        }
    }
    #endregion FillControlls

    protected void btnBack_Click(object sender, EventArgs e)
    {
        if(RouteData.Values["UserID"] != null)
        {
            Response.Redirect("~/AdminPanel/Home", true);
        }
        else
        {
            Response.Redirect("~/Signin", true);
        }
    }

    #region Clear Control
    private void ClearControl()
    {
        txtUserName.Text = "";
        txtPassword.Text = "";
        txtRetypePassword.Text = "";
        txtEmail.Text = "";
        txtMobileNo.Text = "";
        txtAddress.Text = "";
        txtName.Text = "";
    }
    #endregion Clear Control
}