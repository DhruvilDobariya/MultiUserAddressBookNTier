using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactWiseContactWiseContactCategoryDALBase
/// </summary>

namespace AddressBook.DAL
{
    public class ContactWiseContactCategoryDALBase
    {
        #region Local Variable
        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion Local Variable

        #region Get ContactWiseContactCategory By ContactId
        public DataTable GetContactWiseContactCategoryById(SqlInt32 ContactID, SqlInt32 UserId)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                DataTable dt = new DataTable();
                #region Create Command and Bind Data
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_ContactWiseContactCategory_SelectByPKUserID";
                objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                objCmd.Parameters.AddWithValue("@UserID", UserId);

                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

                dt.Load(objSDR);
                return dt;

                #endregion Create Command and Bind Data

            }
            catch (Exception ex)
            {
                _Message = ex.ToString();
                return null;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Get ContactWiseContactCategory By ContactId

        #region Insert ContactWiseContactCategory
        public bool InsertContactWiseContactCategory(ContactWiseContactCategoryENT entContactWiseContactCategory)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Set Parameters
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_ContactWiseContactCategory_InsertUserID";

                objCmd.Parameters.AddWithValue("@ContactID", entContactWiseContactCategory.ContactID);
                objCmd.Parameters.AddWithValue("@ContactCategoryID", entContactWiseContactCategory.ContactCategoryID);
                objCmd.Parameters.AddWithValue("@UserID", entContactWiseContactCategory.UserID);
                objCmd.ExecuteNonQuery();
                #endregion Create Command and Set Parameters

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    _Message = "This ContactWiseContactCategory contain some records, So please delete these record, If you want to delete this ContactWiseContactCategory.";
                    return false;
                }
                else
                {
                    _Message = ex.Message;
                    return false;
                }
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Insert ContactWiseContactCategory

        #region Delete ContactWiseContactCategory By Id
        public bool DeleteContactWiseContactCategory(SqlInt32 ContactID, SqlInt32 UserID)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Set Parameters
                SqlCommand objCmd = new SqlCommand("PR_ContactWiseContactCategory_DeleteByPKUserID", objConn);
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@ContactWiseContactCategoryID", ContactWiseContactCategoryID);
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(UserID));
                objCmd.ExecuteNonQuery();
                #endregion Create Command and Set Parameters

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    _Message = "This ContactWiseContactCategory contain some records, So please delete these record, If you want to delete this ContactWiseContactCategory.";
                    return false;
                }
                else
                {
                    _Message = ex.Message;
                    return false;
                }
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Delete ContactWiseContactCategory By Id

    }
}
