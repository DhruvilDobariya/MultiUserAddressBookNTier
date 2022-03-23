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
            if (RouteData.Values["UserID"] != null && RouteData.Values["UserID"].ToString() == Session["UserID"].ToString())
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
        

        if (RouteData.Values["UserID"] != null)
        {
            #region Update record
            UserBAL userBAL = new UserBAL();
            entUser.UserID = Convert.ToInt32(RouteData.Values["UserID"]);
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
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Set Parameters
            SqlCommand objCmd = new SqlCommand("PR_User_SelectByPK", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Create Command and Set Parameters
            #region Get data and set data
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                    {
                        txtName.Text = objSDR["DisplayName"].ToString();
                    }
                    if (!objSDR["MobileNo"].Equals(DBNull.Value))
                    {
                        txtMobileNo.Text = objSDR["MobileNo"].ToString();
                    }
                    if (!objSDR["Email"].Equals(DBNull.Value))
                    {
                        txtEmail.Text = objSDR["Email"].ToString();
                    }
                    if (!objSDR["Address"].Equals(DBNull.Value))
                    {
                        txtAddress.Text = objSDR["Address"].ToString();
                    }
                    if (!objSDR["UserName"].Equals(DBNull.Value))
                    {
                        txtUserName.Text = objSDR["UserName"].ToString();
                    }
                    if (!objSDR["Password"].Equals(DBNull.Value))
                    {
                        txtPassword.Text = objSDR["Password"].ToString();
                    }
                    if (!objSDR["Password"].Equals(DBNull.Value))
                    {
                        txtRetypePassword.Text = objSDR["Password"].ToString();
                    }
                    break;
                }
            }
            else
            {
                lblMsg.Text = "User Not Found!";
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