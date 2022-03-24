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
        public ContactWiseContactCategoryENT GetContactWiseContactCategoryById(SqlInt32 ContactID, SqlInt32 UserId)
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
                objCmd.CommandText = "PR_ContactWiseContactCategory_SelectByContactIDUserID";
                objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                objCmd.Parameters.AddWithValue("@UserID", UserId);

                SqlDataReader objSDR = objCmd.ExecuteReader();

                ContactWiseContactCategoryENT entContactWiseContactCategory = new ContactWiseContactCategoryENT();

                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["ContactWiseContactCategoryID"].Equals(DBNull.Value))
                        {
                            entContactWiseContactCategory.ContactWiseContactCategoryID = Convert.ToInt32(objSDR["ContactWiseContactCategoryID"].ToString());
                        }
                        if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                        {
                            entContactWiseContactCategory.ContactCategory.ContactCategoryName = objSDR["ContactCategory"].ToString();
                        }
                        break;
                    }
                }

                return entContactWiseContactCategory;

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

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
        public bool InsertContactWiseContactCategory(List<ContactWiseContactCategoryENT> contactWiseContactCategories)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                foreach(var contactWiseContactCategory in contactWiseContactCategories)
                {
                    #region Create Command and Set Parameters
                    SqlCommand objCmd = new SqlCommand();
                    objCmd.Connection = objConn;
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_ContactWiseContactCategory_InsertUserID";

                    objCmd.Parameters.AddWithValue("@ContactID", contactWiseContactCategory.ContactID);
                    objCmd.Parameters.AddWithValue("@ContactCategoryID", contactWiseContactCategory.ContactCategoryID);
                    objCmd.Parameters.AddWithValue("@UserID", contactWiseContactCategory.UserID);
                    objCmd.ExecuteNonQuery();
                    #endregion Create Command and Set Parameters
                }

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

        #region Delete ContactWiseContactCategory By ContactId
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
                SqlCommand objCmd = new SqlCommand("PR_ContactWiseContactCategory_DeleteByContactIDUserID", objConn);
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                objCmd.Parameters.AddWithValue("@UserID", UserID);
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
        #endregion Delete ContactWiseContactCategory By ContactId

        #region Delete ContactWiseContactCategory By Id
        public bool DeleteContactWiseContactCategoryByPK(SqlInt32 ContactWiseContactCategoryID, SqlInt32 UserID)
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
                objCmd.Parameters.AddWithValue("@ContactID", ContactWiseContactCategoryID);
                objCmd.Parameters.AddWithValue("@UserID", UserID);
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

        #region SelectOrNot
        public List<ContactWiseContactCategoryENT> SelectOrNot(SqlInt32 ContactID, SqlInt32 UserID)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Set Parameters
                SqlCommand objCmd = new SqlCommand("PR_ContactCategory_SelectOrNot", objConn);
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@UserID", UserID);
                objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                SqlDataReader objSDR = objCmd.ExecuteReader();
                #endregion Create Command and Set Parameters

                List<ContactWiseContactCategoryENT> contactWiseContactCategories = new List<ContactWiseContactCategoryENT>();

                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        ContactWiseContactCategoryENT entContactWiseContactCategory = new ContactWiseContactCategoryENT();

                        if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                        {
                            entContactWiseContactCategory.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"].ToString());
                        }
                        /*if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                        {
                            entContactWiseContactCategory.ContactCategory.ContactCategoryName = objSDR["ContactCategoryName"].ToString();
                        }*/
                        if (!objSDR["SelectOrNot"].Equals(DBNull.Value))
                        {
                            entContactWiseContactCategory.SelecteOrNot = objSDR["SelectOrNot"].ToString();
                        }
                        if (!objSDR["ContactWiseContactCategoryID"].Equals(DBNull.Value))
                        {
                            entContactWiseContactCategory.ContactWiseContactCategoryID = Convert.ToInt32(objSDR["ContactWiseContactCategoryID"].ToString());
                        }

                        contactWiseContactCategories.Add(entContactWiseContactCategory);
                    }
                }

                return contactWiseContactCategories;

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

            }
            catch (Exception ex)
            {
                _Message = ex.Message;
                return null;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion SelectOrNot

    }
}
