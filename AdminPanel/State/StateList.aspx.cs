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

public partial class AdminPanel_State_StateList : System.Web.UI.Page
{
    #region PageLode
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillState();
        }
    }
    #endregion PageLode
    #region FillState
    private void FillState()
    {
        StateBAL stateBAL = new StateBAL();
        DataTable dt = new DataTable();
        dt = stateBAL.SelectAll(Convert.ToInt32(Session["UserID"]));
        gvState.DataSource = dt;
        gvState.DataBind();
    }
    #endregion FillState 
    #region GridViewRowCommand
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DeleteState(Convert.ToInt32(e.CommandArgument.ToString()));
                FillState();
            }
        }
    }
    #endregion GridViewRowCommand
    #region DeleteState
    private void DeleteState(SqlInt32 Id)
    {
        StateBAL stateBAL = new StateBAL();
        if (stateBAL.Delete(Id,Convert.ToInt32(Session["UserID"])))
        {
            Session["Success"] = "State Deleted Successfully";
        }
        else
        {
            if (stateBAL.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
            {
                Session["Error"] = "This State contain some records, So please delete these record, If you want to delete this state.";
            }
            else
            {
                Session["Error"] = stateBAL.Message;
            }
        }
    }
    #endregion DeleteState
}